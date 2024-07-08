using SkillSync.AzureBlobStorage.Interfaces;
using SkillSync.Domain.DTOs.File;
using SkillSync.Domain.DTOs.Order;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Exceptions.OrderContent;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.Models;

namespace SkillSync.Business.Services
{
    public class OrderContentService : IOrderContentService
    {
        private readonly IOrderContentRepository _orderContentRepository;

        private readonly IFileService _fileService;

        private string GetPictureName(Guid orderId, Guid pictureId) => $"{orderId}-picture-{pictureId}";
        private string GetVideoName(Guid orderId, Guid videoId) => $"{orderId}-video-{videoId}";
        private string GetDocumentName(Guid orderId, Guid documentId) => $"{orderId}-document-{documentId}";
        private string GetAudioName(Guid orderId, Guid documentId) => $"{orderId}-audio-{documentId}";

        public OrderContentService
        (
            IOrderContentRepository orderContentRepository,
            IFileService fileService
        )
        {
            _orderContentRepository = orderContentRepository ?? throw new ArgumentNullException(nameof(orderContentRepository));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public void DeleteSpecificOrderContents(List<Guid> orderContentsIdToBeDeleted, Order order)
        {
            foreach (var orderContentIdToBeDeleted in orderContentsIdToBeDeleted)
            {
                var orderContent = order.Contents.FirstOrDefault(o => o.Id == orderContentIdToBeDeleted);
                if (orderContent != null)
                {
                    DeleteOrderContentFromStorage(orderContent);
                    order.Contents.Remove(orderContent);
                }
            }
        }

        public async Task<(Stream, string)> DownloadOrderContent(Guid orderContentId)
        {
            var orderContent = await _orderContentRepository.SingleByCondition(o => o.Id == orderContentId);

            if (orderContent == null)
            {
                throw new OrderContentNotFoundException();
            }

            var file = await _fileService.DownloadOrderContentAsync(orderContent.Content, orderContent.Type);

            return file;
        }

        private void DeleteOrderContentFromStorage(OrderContent orderContent)
        {
            switch (orderContent.Type)
            {
                case OrderContentType.Image:
                    _fileService.DeleteOrderContentPicture(orderContent.Content);
                    break;
                case OrderContentType.Video:
                    _fileService.DeleteOrderContentVideo(orderContent.Content);
                    break;
                case OrderContentType.Document:
                    _fileService.DeleteOrderContentDocument(orderContent.Content);
                    break;
                case OrderContentType.Audio:
                    _fileService.DeleteOrderContentAudio(orderContent.Content);
                    break;
            }
        }

        public void UpdateDescriptions(List<ModifiedDescriptionDto> newDescriptions, Order order)
        {
            foreach (var newDescription in newDescriptions)
            {
                var orderContent = order.Contents.FirstOrDefault(o => o.Id == newDescription.OrderContentId);
                if (orderContent != null)
                {
                    orderContent.Description = newDescription.Description;
                }
            }
        }

        public async Task UploadOrderContentMedia(UpsertOrderContentDto request, Order order, OrderContentPurpose purpose)
        {
            await UploadOrderContentMediaAsync(request.UploadedPictures, order, OrderContentType.Image, purpose);
            await UploadOrderContentMediaAsync(request.UploadedVideos, order, OrderContentType.Video, purpose);
            await UploadOrderContentMediaAsync(request.UploadedDocuments, order, OrderContentType.Document, purpose);
            await UploadOrderContentMediaAsync(request.UploadedAudios, order, OrderContentType.Audio, purpose);
        }

        private async Task UploadOrderContentMediaAsync(OrderContentFileDto[] medias, Order order, OrderContentType orderContentType, OrderContentPurpose purpose)
        {
            if (medias == null)
            {
                return;
            }

            if (order.Contents == null)
            {
                order.Contents = new List<OrderContent>();
            }

            for (int i = 0; i < medias.Length; i++)
            {
                var fileName = GetFileName(orderContentType, order.Id);
                var file = new UploadFileDto
                {
                    ContentType = medias[i].File.ContentType,
                    Name = fileName,
                    File = medias[i].File,
                };

                switch (orderContentType)
                {
                    case OrderContentType.Image:
                        await _fileService.UploadOrderContentPictureAsync(file);
                        break;
                    case OrderContentType.Video:
                        await _fileService.UploadOrderContentVideoAsync(file);
                        break;
                    case OrderContentType.Document:
                        await _fileService.UploadOrderContentDocumentAsync(file);
                        break;
                    case OrderContentType.Audio:
                        await _fileService.UploadOrderContentAudioAsync(file);
                        break;
                }

                order.Contents.Add(new OrderContent
                {
                    Content = fileName,
                    Description = medias[i].Description,
                    Type = orderContentType,
                    Purpose = purpose,
                });
            }
        }

        public OrderContent EnsureTextContentExists(List<OrderContent> orderContents, OrderContentPurpose purpose)
        {
            var textContent = orderContents?.FirstOrDefault(oc => oc.Type == OrderContentType.Text && oc.Purpose == purpose);

            if (textContent != null)
            {
                return textContent;
            }

            return new OrderContent
            {
                Type = OrderContentType.Text,
                Purpose = purpose
            };
        }

        private string GetFileName(OrderContentType contentType, Guid orderId)
        {
            return contentType switch
            {
                OrderContentType.Image => GetPictureName(orderId, Guid.NewGuid()),
                OrderContentType.Video => GetVideoName(orderId, Guid.NewGuid()),
                OrderContentType.Document => GetDocumentName(orderId, Guid.NewGuid()),
                OrderContentType.Audio => GetAudioName(orderId, Guid.NewGuid()),
                _ => throw new NotImplementedException()
            };
        }
    }
}