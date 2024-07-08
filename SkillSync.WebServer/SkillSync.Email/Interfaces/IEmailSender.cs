using MimeKit;

namespace SkillSync.Email.Interfaces
{
    public interface IEmailSender
    {
        Task Send(MimeMessage email);
    }
}