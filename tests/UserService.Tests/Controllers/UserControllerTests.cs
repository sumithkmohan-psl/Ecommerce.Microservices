using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.API.Controllers;
using UserService.Application.DTOs;
using UserService.Application.Interfaces;

namespace UserService.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly UserController _userController;

        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _tokenServiceMock = new Mock<ITokenService>();
            _userController = new UserController(_userServiceMock.Object, _tokenServiceMock.Object);
        }

        [Theory]
        [InlineData("sumithkmohan@gmail.com","123")]
        [InlineData("anugraha.r1996@gmail.com", "1234")]
        public async Task Login_ReturnsOkResult_WhenCredentialsAreValid(string email, string password)
        {
            // Arrange
            var loginRequest = new LoginRequestDto { UserName = email, Password = password };

            var userResponse = new UserResponseDto
            {
                UserId = 1,
                Email = email,
                FirstName = "Sumith",
                LastName = "K Mohan",
                Role = "Admin"
            };

            var token = "fake-jwt-token";

            _userServiceMock.Setup(s=>s.Login(loginRequest)).ReturnsAsync(userResponse);

            _tokenServiceMock.Setup(s => s.GetToken(userResponse.UserId, userResponse.Role)).Returns(token);

            // Act
            var result = await _userController.Login(loginRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedToken = Assert.IsType<LoginResponseDto>(okResult.Value);
            Assert.Equal(token, returnedToken.Token);
        }
    }
}
