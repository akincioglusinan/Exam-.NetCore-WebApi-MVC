using System;
using System.Collections.Generic;
using System.Text;

namespace SinavProje.Core.Utilities.Security.Authorization
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
