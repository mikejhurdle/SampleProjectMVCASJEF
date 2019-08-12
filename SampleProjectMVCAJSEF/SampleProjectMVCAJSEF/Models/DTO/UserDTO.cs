using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleProjectMVCAJSEF.Models.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public string Role { get; set; }
        public int? ClientId { get; set; }
    }
}