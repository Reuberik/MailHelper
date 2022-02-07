using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reuberik.Library.Models {
    public class SmtpSettings {
        public SmtpSettings() {

        }

        public SmtpSettings(string mail, string displayName, string password, string host, int port) {
            Mail = mail;
            DisplayName = displayName;
            Password = password;
            Host = host;
            Port = port;
        }

        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
