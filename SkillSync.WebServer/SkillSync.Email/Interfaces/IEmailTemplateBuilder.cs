using MimeKit;
using SkillSync.Domain.Models;

namespace SkillSync.Email.Interfaces
{
    public interface IEmailTemplateBuilder
    {
        BodyBuilder ConfirmationMailTemplate(User user, string confirmationToken, string baseUrl);
    }
}