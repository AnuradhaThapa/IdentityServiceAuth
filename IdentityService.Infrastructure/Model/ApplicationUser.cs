using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Infrastructure.Model
{  
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string UserId { get; set; }
    }
}
