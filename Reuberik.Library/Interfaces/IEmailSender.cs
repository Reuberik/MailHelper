using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reuberik.Library.Models;
using Microsoft.AspNetCore.Http;

namespace Reuberik.Library.Interfaces {
    public interface IEmailSender {
        Task<TResult> SendEmailAsync(string email, string subject, string htmlMessage);
        Task<TResult> SendEmailAsync(string email, string subject, string htmlMessage, List<IFormFile> attachments);
        Task<TResult> SendEmailAsync(MailRequest model);
    }
}
