using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace SinavProje.Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }
        public static void AddUserName(this ICollection<Claim> claims, string userName)
        {
            claims.Add(new Claim("UserName", userName));
        }

        public static void AddUserId(this ICollection<Claim> claims, string userId)
        {
            claims.Add(new Claim("UserId", userId));
        }
        public static string GetUserName(this ClaimsIdentity identity)
        {
            var claims = identity.FindFirst("UserName");
            if (claims == null)
            {
                return "";
            }
            return claims.Value.ToString();

        }
        public static string GetUserId(this ClaimsIdentity identity)
        {
            var claims = identity.FindFirst("UserId");
            if (claims == null)
            {
                return "";
            }
            return claims.Value.ToString();

        }
    }
}
