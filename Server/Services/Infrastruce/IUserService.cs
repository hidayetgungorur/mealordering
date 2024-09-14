using System;
using MealOrdering.Shared.Dto;

namespace MealOrdering.Server.Services.Infrastruce
{
	public interface IUserService
	{
        public Task<UserDto> GetUserById(Guid Id);

        public Task<List<UserDto>> GetUsers();
        public Task<UserDto> CreateUser(UserDto User);
        public Task<UserDto> UpdateUser(UserDto User);

        public Task<bool> DeleteUserById(Guid Id);

        public Task<UserLoginResponseDto> Login(string EMail, string Password);
    }
}

