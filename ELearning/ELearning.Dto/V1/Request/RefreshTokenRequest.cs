using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Dto.V1.Request
{
    public class RefreshTokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
