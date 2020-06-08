using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Utilities
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public TimeSpan TokenLifetime { get; set; }

    }
}
