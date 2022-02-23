using IdentityService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Core.Interfaces
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(ClaimsModelEntity user);
    }
}
