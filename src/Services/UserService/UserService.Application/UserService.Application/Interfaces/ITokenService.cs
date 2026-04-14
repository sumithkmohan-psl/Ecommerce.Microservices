using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Application.Interfaces
{
    public interface ITokenService
    {
        string GetToken(long userId, string role);
    }
}
