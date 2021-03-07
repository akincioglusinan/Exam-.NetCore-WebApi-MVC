using System;
using System.Collections.Generic;
using System.Text;

namespace SinavProje.Core.Utilities.Security.Authorization
{
    public class TokenOptions:ITokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
