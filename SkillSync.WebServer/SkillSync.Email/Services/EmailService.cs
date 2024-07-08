using MimeKit;
using SkillSync.Domain.Models;
using SkillSync.Email.Interfaces;

namespace SkillSync.Email.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;
        private readonly IEmailTemplateBuilder _emailTemplateBuilder;

        public EmailService(IEmailSender emailSender, IEmailTemplateBuilder emailTemplateBuilder)
        {
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            _emailTemplateBuilder = emailTemplateBuilder ?? throw new ArgumentNullException(nameof(emailTemplateBuilder));
        }

        public async Task SendConfirmationEmail(User user, string confirmationToken, string baseUrl)
        {
            BodyBuilder bodyBuilder = _emailTemplateBuilder.ConfirmationMailTemplate(user, confirmationToken, baseUrl);

            var email = CreateEmail(user.Email, "Confirmation Email", bodyBuilder);

            await SendEmail(email);
        }

        public MimeMessage CreateEmail(string to, string subject, BodyBuilder body)
        {
            var email = new MimeMessage();
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = body.ToMessageBody();

            return email;
        }

        private async Task SendEmail(MimeMessage email)
        {
            await _emailSender.Send(email);
        }
    }
}