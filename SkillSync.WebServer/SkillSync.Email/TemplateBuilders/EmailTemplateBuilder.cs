using Microsoft.Extensions.Configuration;
using MimeKit;
using SkillSync.Domain.Models;
using SkillSync.Email.Interfaces;
using System.Web;

namespace SkillSync.Email.TemplateBuilders
{
    public class EmailTemplateBuilder : IEmailTemplateBuilder
    {
        private readonly IConfiguration _configuration;

        public EmailTemplateBuilder(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public BodyBuilder ConfirmationMailTemplate(User user, string confirmationToken, string baseUrl)
        {
            var templateFilePath = _configuration["EmailTemplates:ConfirmationTemplatePath"];

            if(templateFilePath == null)
            {
                throw new Exception("Email template path is not configured");
            }

            UriBuilder verificationLink = BuildEmailVerificationLink(user, confirmationToken, baseUrl);

            var htmlContent = File.ReadAllText(templateFilePath);
            htmlContent = htmlContent.Replace("[User's Name]", user.FirstName)
                                     .Replace("[Verification Link]", $"{verificationLink}")
                                     .Replace("[Your Company Name]", "SkillSync");

            BodyBuilder bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = htmlContent;

            return bodyBuilder;
        }

        private UriBuilder BuildEmailVerificationLink(User user, string confirmationToken, string baseUrl)
        {
            var uriBuilder = new UriBuilder($"{baseUrl}Identity/ConfirmEmail/");
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            string encodedUserId = HttpUtility.UrlEncode(user.Id);
            string encodedToken = HttpUtility.UrlEncode(confirmationToken);
            query["id"] = encodedUserId;
            query["confirmationToken"] = encodedToken;

            uriBuilder.Query = query.ToString();
            return uriBuilder;
        }
    }
}