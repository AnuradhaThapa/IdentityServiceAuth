using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IdentityService.Core.Entities
{
    public class UserDetailsEntity
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string UserId { get; set; }
        [Required]
        public int ClientType { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Role")]
        public string RoleType { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }

        [Display(Name = "IsActive")]
        public bool HasActiveRole { get; set; }
        public string AgentId { get; set; }
    }
}
