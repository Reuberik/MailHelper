namespace Reuberik.Library.Models {
    public class AuthMessageSenderOptions {
        public AuthMessageSenderOptions() { }

        public AuthMessageSenderOptions(string domain, int port, string userName, string key, bool useSsl, bool requiresAuthentication, string defaultSenderEmail, string defaultSenderDisplayName, bool useHtml) {
            Domain = domain;
            Port = port;
            UserName = userName;
            Key = key;
            UseSsl = useSsl;
            RequiresAuthentication = requiresAuthentication;
            DefaultSenderEmail = defaultSenderEmail;
            DefaultSenderDisplayName = defaultSenderDisplayName;
            UseHtml = useHtml;
        }

        public string Domain { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Key { get; set; }
        public bool UseSsl { get; set; }
        public bool RequiresAuthentication { get; set; } = true;
        public string DefaultSenderEmail { get; set; }
        public string DefaultSenderDisplayName { get; set; }
        public bool UseHtml { get; set; }
    }
}