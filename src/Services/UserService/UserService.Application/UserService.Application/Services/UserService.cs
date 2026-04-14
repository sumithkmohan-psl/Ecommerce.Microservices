using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllUsers(PaginationDto pagination)
        {
            var query = await _userRepository.GetAllUsers();

            var users = query.Skip((pagination.Index - 1) * pagination.Size)
                             .Take(pagination.Size)
                             .ToList();

            return users.Select(u => new UserResponseDto
            {
                UserId = u.UserId,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Role = u.Role.Name
            });
        }

        public async Task<UserResponseDto> Login(LoginRequestDto loginDto)
        {
            var query = await _userRepository.GetAllUsers();

            var user = query.FirstOrDefault(u => u.Email == loginDto.UserName && u.Password == loginDto.Password);

            if (user == null)
            {
                return null;
            }

            return new UserResponseDto
            {
                UserId = user.UserId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role.Name
            };
        }
    }
}
