using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using Reuberik.Library.Models;
using System.IO;
using System.Threading.Tasks;

namespace Reuberik.Library.Services {
    public class EmailSender : IEmailSender {
        public EmailSender(IOptions<SmtpSettings> smtpSettings) {
            _smtpSettings = smtpSettings.Value;
        }

        private readonly SmtpSettings _smtpSettings;

        public async Task SendEmailAsync(string email, string subject, string htmlMessage) {
            await SendEmailAsync(new MailRequest(email, subject, htmlMessage));
        }

        public async Task SendEmailAsync(MailRequest mailRequest) {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_smtpSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null) {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments) {
                    if (file.Length > 0) {
                        using (var ms = new MemoryStream()) {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_smtpSettings.Host, _smtpSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_smtpSettings.Mail, _smtpSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
