using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Abstract;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Concrete.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private IConfiguration _configuration;
        private TokenOptions _tokenOptions;
        private DateTime _tokenExpiration;
        public JwtHelper()
        {
            _configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _tokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpration);
        }
        public AccessToken CreateToken(User user, List<Demand> demands, List<Menu> menus)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var singleCreadential = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwtSecurityToken = CreateJwtSecurityToken(_tokenOptions, user, singleCreadential, demands, menus);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new AccessToken
            {
                Token = token,
                TokenExpiration = _tokenExpiration
            };

        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<Demand> demands, List<Menu> menus)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                 issuer: tokenOptions.Issuer,
                 audience: tokenOptions.Audience,
                 expires: _tokenExpiration,
                 notBefore: DateTime.Now,
                 claims: SetClaims(user, demands,menus),
                 signingCredentials: signingCredentials
                );

            return jwtSecurityToken;
        }
        public IEnumerable<Claim> SetClaims(User user, List<Demand> demands,List<Menu> menus)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddFirstName(user.FirstName);
            claims.AddLastName(user.LastName);
            claims.AddRegistrationNumber(user.RegistrationNumber);
            claims.AddRoles(demands.Select(x => x.DemandName).ToArray());
            claims.AddManus(menus.Select(x => x.Path).ToArray());

            return claims;
        }













    }
}
