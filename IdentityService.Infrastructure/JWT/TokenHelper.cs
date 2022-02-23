using IdentityService.Core.Entities;
using IdentityService.Core.Interfaces;
using IdentityService.Infrastructure.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Infrastructure.JWT
{
    public class Tokens
    {
        public static async Task<string> GenerateJwtResponse( 
    IJwtFactory jwtFactory, ClaimsModelEntity user,
     JsonSerializerSettings serializerSettings)
        {
            var response = new
            {
                id = user.Id,
                auth_token = await jwtFactory.GenerateEncodedToken(user),
                expires_in = new DateTimeOffset(DateTime.Now.AddDays(3)).DateTime
            };

            return JsonConvert.SerializeObject(response, serializerSettings);
        }
    }
}
