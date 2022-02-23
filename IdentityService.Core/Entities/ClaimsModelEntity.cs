using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityService.Core.Entities
{
    public class ClaimsModelEntity
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string RoleType { get; set; }
    }
}
