using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SinavProje.Core.Extensions;
using SinavProje.Core.Utilities.Security.Authorization.Encyription;
using SinavProje.Entities.Concrete.Entities;

namespace SinavProje.Core.Utilities.Security.Authorization.Jwt
{
    public class JwtTokenHelper : ITokenHelper
    {
        private readonly TokenOptions _tokenOptions;
        private readonly DateTime _accessTokenExpiration;
        public JwtTokenHelper(IOptions<TokenOptions> configuration)
        {

            _tokenOptions = configuration.Value;
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }

        public AccessToken CreateToken(User user)
        {

            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration,
                UserName = user.UserName,
                UserId = user.Id,
                Email = user.Email,
                Name = user.Name
            };
        }
        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user),
                signingCredentials: signingCredentials
            );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(User user)
        {
            var claims = new List<Claim>();
            claims.AddUserId(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.Name}");
            claims.AddUserName(user.UserName);
            return claims;
        }
    }
}
