using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Infrastructure.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
