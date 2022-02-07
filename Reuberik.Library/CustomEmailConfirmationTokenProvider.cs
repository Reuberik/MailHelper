using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reuberik.Library {
    public class CustomEmailConfirmationTokenProvider<TUser> :
        DataProtectorTokenProvider<TUser> where TUser : class {
        private readonly ILogger<DataProtectorTokenProvider<TUser>> logger;

        public CustomEmailConfirmationTokenProvider(IDataProtectionProvider dataProtectionProvider,
                                        IOptions<EmailConfirmationTokenProviderOptions> options,
                                        ILogger<DataProtectorTokenProvider<TUser>> logger)
            : base(dataProtectionProvider, options, logger) {
            this.logger = logger;
        }
    }

    public class EmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions {
        public EmailConfirmationTokenProviderOptions() {
            Name = "EmailDataProtectorTokenProvider";
            TokenLifespan = TimeSpan.FromHours(4);
        }
    }
}
