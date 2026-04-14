using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.DTOs
{
    public class LoginRequestDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
