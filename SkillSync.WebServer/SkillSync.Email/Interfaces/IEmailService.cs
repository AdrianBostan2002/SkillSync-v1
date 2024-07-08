using SkillSync.Domain.Models;

namespace SkillSync.Email.Interfaces
{
    public interface IEmailService
    {
        Task SendConfirmationEmail(User user, string confirmationToken, string baseUrl);
    }
}