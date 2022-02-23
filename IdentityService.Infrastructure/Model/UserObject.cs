using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityService.Infrastructure.Model
{
    public class UserObject
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
