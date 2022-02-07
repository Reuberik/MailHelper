using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reuberik.Library.Models {
    public class MailRequest {
        public MailRequest() { }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public MailRequest(string toEmail, string subject, string body) {
            ToEmail = toEmail;
            Subject = subject;
            Body = body;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="attachments"></param>
        public MailRequest(string toEmail, string subject, string body, List<IFormFile> attachments) {
            ToEmail = toEmail;
            Subject = subject;
            Body = body;
            Attachments = attachments;
        }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
