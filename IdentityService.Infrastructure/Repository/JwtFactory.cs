using IdentityService.Core.Interfaces;
using IdentityService.Infrastructure.JWT;
using IdentityService.Core.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using IdentityService.Infrastructure.Model;

namespace IdentityService.Infrastructure.Repository
{
    public class JwtFactory : IJwtFactory
    {
        public JwtFactory()
        {
        }

        public async Task<string> GenerateEncodedToken(ClaimsModelEntity user)
        {

            var key = Encoding.ASCII.GetBytes(Keys.Token);
            var JWToken = new JwtSecurityToken(
            issuer: Keys.WebSiteDomain,
            audience: Keys.WebSiteDomain,
            claims: GetUserClaims(user),
            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
            expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            return token;
        }

        private IEnumerable<Claim> GetUserClaims(ClaimsModelEntity user)
        {
            List<Claim> claims = new List<Claim>();
            Claim _claim;
            _claim = new Claim(ClaimTypes.Name, user.UserName);
            claims.Add(_claim);

            _claim = new Claim("Role", user.RoleType);
            claims.Add(_claim);

            _claim = new Claim("UserId", user.UserId);
            claims.Add(_claim);

            return claims.AsEnumerable<Claim>();
        }

        //public ClaimsIdentity GenerateClaimsIdentity(string userName, string id)
        //{
        //    return new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
        //    {
        //    new Claim("JwtId", id),
        //    new Claim("JwtRole", "JwtClaim")
        //});
        //}

        /// Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).
        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() -
                                new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                                .TotalSeconds);
    }
}
