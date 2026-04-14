using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.DTOs;

namespace UserService.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllUsers(PaginationDto pagination);
        Task<UserResponseDto> Login(LoginRequestDto loginDto);
    }
}
