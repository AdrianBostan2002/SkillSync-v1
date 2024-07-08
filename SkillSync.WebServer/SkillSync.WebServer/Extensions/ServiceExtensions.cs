using Azure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SkillSync.DataAccess;
using SkillSync.Domain.Models;
using SkillSync.IdentityManager.Services.LinkedIn;
using System.Text;

namespace SkillSync.WebServer.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            var frontendAppUrl = configuration["FrontendApp:Url"];

            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy",
                                          policy =>
                                          {
                                              policy.WithOrigins(frontendAppUrl)
                                              .AllowAnyHeader()
                                              .AllowAnyMethod()
                                              .AllowCredentials();
                                          });
            });
        }

        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddGoogle(options =>
            {
                IConfigurationSection googleAuthNSection =
                configuration.GetSection("Google");
                options.ClientId = googleAuthNSection["ClientId"];
                options.ClientSecret = googleAuthNSection["ClientSecret"];
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/signin";
                options.LogoutPath = "/signout";
            })
            .AddLinkedIn("linkedin", options =>
            {
                IConfigurationSection linkedInAuthNSection =
                configuration.GetSection("LinkedIn");

                options.ClientId = linkedInAuthNSection["clientid"];
                options.ClientSecret = linkedInAuthNSection["clientSecret"];

                options.Scope.Add("profile");
                options.Scope.Add("email");
                options.Scope.Add("w_member_social");
                options.SaveTokens = true;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.FromMinutes(5),
                    ValidIssuer = "LabAPI-Backend",
                    ValidAudience = "LabAPI-Anyone",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecurityKey"]))
                };
            });
        }

        public static void AddAzureKeyVault(this WebApplicationBuilder builder)
        {
            var keyVaultUri = new Uri(builder.Configuration["KeyVaultConfig:KVUrl"]);
            var tenantId = builder.Configuration["KeyVaultConfig:TenantId"];
            var clientId = builder.Configuration["KeyVaultConfig:ClientId"];
            var clientSecret = builder.Configuration["KeyVaultConfig:ClientSecretId"];

            var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

            builder.Configuration.AddAzureKeyVault(keyVaultUri, credential);
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("azureSqlConnection")));
                //opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureLinkedInClient(this IServiceCollection services, IConfiguration configuration) =>
            services.AddHttpClient<ILinkedInService, LinkedInService>("LinkedInClient", client =>
            {
                var uri = configuration.GetSection("LinkedIn").GetValue<string>("ApiUri");
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                client.Timeout = TimeSpan.FromSeconds(30);
            });

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            })
            .AddSignInManager<SignInManager<User>>()
            .AddRoles<IdentityRole>();

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole),
            builder.Services);
            builder.AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
        }
    }
}
