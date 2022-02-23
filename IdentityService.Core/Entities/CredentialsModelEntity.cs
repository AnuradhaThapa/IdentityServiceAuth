using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityService.Core.Entities
{
    public class CredentialsModelEntity
    { 
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
