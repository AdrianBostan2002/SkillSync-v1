using AutoMapper;
using Azure.Core;
using SkillSync.AzureBlobStorage.Interfaces;
using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.DTOs.Order;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Exceptions.Order;
using SkillSync.Domain.Exceptions.OrderContent;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.Models;

namespace SkillSync.Business.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;

        private readonly IOrderRepository _orderRepository;

        private readonly IUserService _userService;
        private readonly IFreelancerService _freelancerService;
        private readonly IOrderContentService _orderContentService;
        private readonly IFileService _fileService;
        private readonly IProjectService _projectService;
        private readonly IPushNotificationService _pushNotificationService;

        public OrderService
        (
            IMapper mapper,
            IOrderRepository orderRepository,
            IUserService userService,
            IFreelancerService freelancerService,
            IOrderContentService orderContentService,
            IFileService fileService,
            IProjectService projectService,
            IPushNotificationService pushNotificationService
        )
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _freelancerService = freelancerService ?? throw new ArgumentNullException(nameof(freelancerService));
            _orderContentService = orderContentService ?? throw new ArgumentNullException(nameof(orderContentService));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
            _pushNotificationService = pushNotificationService ?? throw new ArgumentNullException(nameof(pushNotificationService));
        }

        public async Task<Guid> AddOrderAsync(PlaceOrderDto request)
        {
            var order = _mapper.Map<Order>(request);

            order.Status = OrderStatus.Pending;
            order.Customer = await _userService.GetUserByEmailAsync(request.CustomerEmail);

            var placedOrder = await _orderRepository.AddAsync(order);

            await SendOrderParticipantsThatNewOrderPlacedNotification(request, order);

            return placedOrder.Id;
        }

        private async Task SendOrderParticipantsThatNewOrderPlacedNotification(PlaceOrderDto request, Order order)
        {
            User notificationReceiver = await GetOrderFreelancer(request.ProjectId);

            await _pushNotificationService.SendFreelancerNewOrderReceivedNotification(order, notificationReceiver);
            await _pushNotificationService.SendSkillScoutOrderPlacedSuccessfullyNotification(order);
        }

        public async Task<User> GetOrderFreelancer(Guid projectId)
        {
            var project = await _projectService.GetProjectById(projectId);
            var projectOwner = await _freelancerService.GetFreelancerById(project.FreelancerId);
            var notificationReceiver = await _userService.GetUserByIdAsync(projectOwner.UserId);
            return notificationReceiver;
        }

        public async Task UpdateOrderStatus(Guid orderId, OrderStatus newOrderStatus)
        {
            var order = await _orderRepository.GetByIdIncludeContents(orderId);

            if (order == null)
            {
                throw new OrderNotFoundException();
            }

            if (newOrderStatus == order.Status)
            {
                return;
            }

            if (order.Status != OrderStatus.Pending && newOrderStatus == OrderStatus.Pending)
            {
                throw new InvalidOrderStatusChangeException();
            }

            var finalProductsContent = order.Contents.Where(c => c.Purpose == OrderContentPurpose.FinalProduct).ToList();
            if ((newOrderStatus == OrderStatus.Delivered || newOrderStatus == OrderStatus.Completed) && finalProductsContent.Count() == 0)
            {
                throw new FinalProductsNotUploadedException();
            }

            if (newOrderStatus != OrderStatus.Pending && newOrderStatus != OrderStatus.Active)
            {
                order.CompletedAt = DateTime.Now;
            }

            order.Status = newOrderStatus;
            await _orderRepository.UpdateAsync(order);

            await SendOrderStatusChangedNotification(order);
        }

        private async Task SendOrderStatusChangedNotification(Order order)
        {
            User freelancer = await GetOrderFreelancer(order.ProjectId);

            if (order.Status == OrderStatus.Completed)
            {
                await _pushNotificationService.SendOrderCompletedNotification(order, freelancer);
            }

            await _pushNotificationService.SendSkillScoutOrderStatusChangedNotification(order, freelancer);
        }

        public async Task<OrderDto> GetOrderById(Guid id)
        {
            var order = await _orderRepository.GetByIdIncludeAllDependencies(id);

            var previewContents = order.Contents.Where(oc => oc.Purpose == OrderContentPurpose.Preview).ToList();
            var finalProductContents = order.Contents.Where(oc => oc.Purpose == OrderContentPurpose.FinalProduct).ToList();

            var orderDto = _mapper.Map<OrderDto>(order);
            orderDto.PreviewContents = _mapper.Map<List<OrderContentDto>>(previewContents);
            GetMediaFromBlobStorage(orderDto.PreviewContents);

            orderDto.FinalProductContents = _mapper.Map<List<OrderContentDto>>(finalProductContents);
            GetMediaFromBlobStorage(orderDto.FinalProductContents);

            return orderDto;
        }

        public void GetMediaFromBlobStorage(List<OrderContentDto> contents)
        {
            foreach (var orderContent in contents)
            {
                switch (orderContent.Type)
                {
                    case OrderContentType.Image:
                        orderContent.Content = _fileService.GetOrderContentPicture(orderContent.Content);
                        break;
                    case OrderContentType.Video:
                        orderContent.Content = _fileService.GetOrderContentVideo(orderContent.Content);
                        break;
                    case OrderContentType.Document:
                        orderContent.Content = _fileService.GetOrderContentDocument(orderContent.Content);
                        break;
                    case OrderContentType.Audio:
                        orderContent.Content = _fileService.GetOrderContentAudio(orderContent.Content);
                        break;
                }
            }
        }

        public async Task<List<GetOrderPreviewDto>> GetOrdersPreviewByStatus(string email, OrderStatus status, RoleType role)
        {
            switch (role)
            {
                case RoleType.SkillScout:
                    return await GetSkillScoutOrdersPreviewByStatus(email, status);
                case RoleType.Freelancer:
                    return await GetFreelancerOrdersPreviewByStatus(email, status);
                default:
                    break;
            }

            return await GetFreelancerOrdersPreviewByStatus(email, status);
        }

        private async Task<List<GetOrderPreviewDto>> GetFreelancerOrdersPreviewByStatus(string email, OrderStatus status)
        {
            var freelancer = await _freelancerService.GetFreelancerAsync(email);

            var ordersByStatus = await _orderRepository.GetFreelancerOrdersByStatusAsync(freelancer.Id, status);

            var ordersPreview = _mapper.Map<List<GetOrderPreviewDto>>(ordersByStatus, opts => opts.Items["IsFreelancerPerspective"] = true);

            return ordersPreview;
        }

        private async Task<List<GetOrderPreviewDto>> GetSkillScoutOrdersPreviewByStatus(string email, OrderStatus status)
        {
            var customer = await _userService.GetUserByEmailAsync(email);

            var ordersByStatus = await _orderRepository.GetSkillScoutOrdersByStatusAsync(customer.Id, status);

            var ordersPreview = _mapper.Map<List<GetOrderPreviewDto>>(ordersByStatus, opts => opts.Items["IsFreelancerPerspective"] = false);

            return ordersPreview;
        }

        public async Task UpsertOrderContetMediaAsync(UpsertOrderContentDto request, Guid orderId, OrderContentPurpose purpose)
        {
            var order = await _orderRepository.GetByIdIncludeContents(orderId);

            if (order == null)
            {
                throw new OrderContentNotFoundException();
            }

            var initialPreviewOrderContentsCount = order.Contents.Count(oc => oc.Purpose == OrderContentPurpose.Preview);

            if (request.DeletedOrderContents != null)
            {
                _orderContentService.DeleteSpecificOrderContents(request.DeletedOrderContents, order);
            }

            if (request.ModifiedDescriptions != null)
            {
                _orderContentService.UpdateDescriptions(request.ModifiedDescriptions, order);
            }

            await _orderContentService.UploadOrderContentMedia(request, order, purpose);

            if (!string.IsNullOrEmpty(request.ModifiedNotes))
            {
                var notes = _orderContentService.EnsureTextContentExists(order.Contents, purpose);

                notes.Content = request.ModifiedNotes;
                order.Contents.Add(notes);
            }

            await _orderRepository.UpdateAsync(order);

            var currentPreviewOrderContentsCount = order.Contents.Count(oc => oc.Purpose == OrderContentPurpose.Preview);

            if (initialPreviewOrderContentsCount != currentPreviewOrderContentsCount)
            {
                var freelancer = await GetOrderFreelancer(order.ProjectId);
                await _pushNotificationService.SendPreviewContentModifiedNotification(order, freelancer);
            }
        }

        public async Task<List<Order>> GetOrdersByProjectId(Guid projectId)
        {
            var order = await _orderRepository.FindByCondition(o => o.ProjectId == projectId);

            return order.ToList();
        }
    }
}