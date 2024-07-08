using AutoMapper;
using SkillSync.Chat.DTOs.Chat;
using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.DTOs.Order;
using SkillSync.Domain.DTOs.Project;
using SkillSync.Domain.DTOs.Project.PostSteps;
using SkillSync.Domain.DTOs.Review;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Models;

namespace SkillSync.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Skill, SkillDto>();

            CreateMap<SkillDto, Skill>();

            CreateMap<SkillSubcategory, SkillSubcategoryDto>();

            CreateMap<SkillCategory, SkillCategoryDto>();

            CreateMap<ProjectFeatureDto, ProjectFeature>();

            CreateMap<PostProjectRequest, Project>();

            CreateMap<FrequentlyAskedQuestionDto, ProjectFrequentlyAskedQuestion>();

            CreateMap<SkillCategoryFrequentlyAskedQuestion, FrequentlyAskedQuestionDto>();

            CreateMap<Project, GetProjectPreviewDto>();

            CreateMap<Project, ProjectDto>();

            CreateMap<OverviewStepDto, Project>();

            CreateMap<Project, OverviewStepDto>();

            CreateMap<Project, DescriptionFaqStepDto>();

            CreateMap<ProjectFrequentlyAskedQuestion, FrequentlyAskedQuestionDto>();

            CreateMap<ProjectFeature, GetProjectFeatureDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Feature.Name));

            CreateMap<FreelancerSkills, FreelancerSkillsDto>()
                .ForMember(dest => dest.SkillName, opt => opt.MapFrom(src => src.Skill.Name));

            CreateMap<Freelancer, FreelancerDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => GetUserFullName(src.User)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ScopeDescription))
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.User.ProfilePicture))
                .ForMember(dest => dest.CountryCode, opt => opt.MapFrom(src => src.User.CountryCode))
                .ForMember(dest => dest.Skills, opt => opt.MapFrom(src => src.FreelancerSkills));

            CreateMap<ChatMessage, ChatMessageDto<string>>()
                .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.Sender.Email));

            CreateMap<ChatRoom, ChatRoomDto>()
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Chat.Messages));

            CreateMap<Notification, NotificationDto>();

            CreateMap<PlaceOrderDto, Order>();

            CreateMap<Order, GetOrderPreviewDto>()
                .ForMember(dest => dest.ProjectTitle, opt => opt.MapFrom(src => src.Project.Title))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => GetPrice(src)))
                .AfterMap((src, dest, resContext) =>
                {
                    bool isFreelancerPerspective = (bool)resContext.Items["IsFreelancerPerspective"];
                    dest.Name = isFreelancerPerspective ? GetUserFullName(src.Customer) : GetUserFullName(src.Project.Freelancer.User);
                    dest.Email = isFreelancerPerspective ? src.Customer.Email : src.Project.Freelancer.User.Email;
                });

            CreateMap<OrderContent, OrderContentDto>()
                .ForMember(dest => dest.BlobName, opt => opt.MapFrom(src => src.Content));

            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => GetUserFullName(src.Customer)))
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Customer.Email))
                .ForMember(dest => dest.FreelancerName, opt => opt.MapFrom(src => GetUserFullName(src.Project.Freelancer.User)))
                .ForMember(dest => dest.FreelancerId, opt => opt.MapFrom(src => src.Project.Freelancer.Id))
                .ForMember(dest => dest.ProjectTitle, opt => opt.MapFrom(src => src.Project.Title))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => GetPrice(src)));

            CreateMap<ProjectReview, GetProjectReviewDto>()
                .ForMember(dest => dest.ReviewerName, opt => opt.MapFrom(src => GetUserFullName(src.Reviewer)))
                .ForMember(dest => dest.ReviewerProfilePicture, opt => opt.MapFrom(src => src.Reviewer.ProfilePicture));
        }

        private static int GetPrice(Order order)
        {
            var priceFeature = order.Project.Features.FirstOrDefault();

            string selectedValue = "0";
            if (priceFeature != null)
            {
                if (order.PackageType == PackageType.Basic)
                {
                    selectedValue = priceFeature.BasicSelectedValue;
                }
                else if (order.PackageType == PackageType.Standard)
                {
                    selectedValue = priceFeature.StandardSelectedValue;
                }
                else if (order.PackageType == PackageType.Premium)
                {
                    selectedValue = priceFeature.PremiumSelectedValue;
                }
            }

            return int.Parse(selectedValue);
        }

        private static string GetUserFullName(User user)
        {
            return $"{user.FirstName} {user.LastName}";
        }
    }
}