using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using SkillSync.Email.Interfaces;

namespace SkillSync.Email.Senders
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;

        public EmailSender(IConfiguration config)
        {
            configuration = config;
        }
        public async Task Send(MimeMessage email)
        {
            var emailConfig = configuration.GetSection("EmailConfig");
            var username = emailConfig["EmailUsername"];
            var password = emailConfig["EmailPassword"];
            var emailHost = emailConfig["EmailHost"];
            var port = int.Parse(emailConfig["EmailPort"]);

            email.From.Add(MailboxAddress.Parse(username));

            var smtp = new SmtpClient();
            await smtp.ConnectAsync(emailHost, port, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(username, password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}