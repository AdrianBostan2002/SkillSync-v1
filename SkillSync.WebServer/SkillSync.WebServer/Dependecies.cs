using Azure.Storage.Blobs;
using SkillSync.AzureBlobStorage.Interfaces;
using SkillSync.AzureBlobStorage.Services;
using SkillSync.AzureOpenAiChatBot.Interfaces;
using SkillSync.AzureOpenAiChatBot.Services;
using SkillSync.Business;
using SkillSync.Business.Services;
using SkillSync.Chat.Services;
using SkillSync.CVDataExtractor.Interfaces;
using SkillSync.CVDataExtractor.Services;
using SkillSync.DataAccess.Repositories;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Email.Interfaces;
using SkillSync.Email.Senders;
using SkillSync.Email.Services;
using SkillSync.Email.TemplateBuilders;
using SkillSync.IdentityManager.Configurations;
using SkillSync.IdentityManager.Interfaces.IdentityManager;
using SkillSync.IdentityManager.Services.Auth;
using SkillSync.IdentityManager.Services.Google;
using SkillSync.IdentityManager.Services.JWT;
using SkillSync.IdentityManager.Services.LinkedIn;
using SkillSync.IdentityManager.Services.Login;
using SkillSync.Notifications.Services;

namespace SkillSync.WebServer
{
    public static class Dependecies
    {
        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            AddConfigurations(applicationBuilder);
            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);

            applicationBuilder.Services.AddScoped<IEmailTemplateBuilder, EmailTemplateBuilder>();
            applicationBuilder.Services.AddScoped<IEmailSender, EmailSender>();
            applicationBuilder.Services.AddScoped(_ =>
            {
                return new BlobServiceClient(applicationBuilder.Configuration.GetConnectionString("azureBlobStorage"));
            });

            applicationBuilder.Services.AddSignalR().AddAzureSignalR(applicationBuilder.Configuration.GetConnectionString("azureSignalR"));
            applicationBuilder.Services.AddAutoMapper(typeof(MappingProfile));
            applicationBuilder.Services.AddMemoryCache();
        }

        private static void AddConfigurations(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.Configure<GoogleAuthConfig>(applicationBuilder.Configuration.GetSection("Google"));
            applicationBuilder.Services.Configure<LinkedInAuthConfig>(applicationBuilder.Configuration.GetSection("LinkedIn"));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IFreelancerRepository, FreelancerRepository>();
            services.AddScoped<ISkillScoutRepository, SkillScoutRepository>();
            services.AddScoped<ISkillCategoryRepository, SkillCategoryRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ISkillSubcategoryRepository, SkillSubcategoryRepository>();
            services.AddScoped<IUserFavoriteProjectRepository, UserFavoriteProjectRepository>();
            services.AddScoped<IUserChatRepository, UserChatRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IUserNotificationRepository, UserNotificationRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderContentRepository, OrderContentRepository>();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IOwnSystemAuthService, OwnSystemAuthService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IGoogleAuthService, GoogleAuthService>();
            services.AddScoped<ILinkedInService, LinkedInService>();
            services.AddScoped<ISkillCategoryService, SkillCategoryService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFreelancerService, FreelancerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ISkillSubcategoryService, SkillSubcategoryService>();
            services.AddScoped<IUserFavoriteProjectService, UserFavoriteProjectService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IUserNotificationService, UserNotificationService>();
            services.AddScoped<IPushNotificationService, PushNotificationService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderContentService, OrderContentService>();
            services.AddScoped<ICVDataExtractorService, AzureDocumentIntelligenceCvExtractorService>();
            services.AddScoped<IChatBotService, AzureOpenAiChatBotService>();

            services.AddSingleton<ICacheService, CacheService>();
        }
    }
}