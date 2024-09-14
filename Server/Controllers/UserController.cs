using MealOrdering.Client.Utils;
using MealOrdering.Server.Services.Infrastruce;
using MealOrdering.Shared.CustomExceptions;
using MealOrdering.Shared.Dto;
using MealOrdering.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MealOrdering.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService UserService)
        {
            userService = UserService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ServiceResponse<UserLoginResponseDto>> Login(UserLoginRequestDto request)
        {
            ServiceResponse<UserLoginResponseDto> response = new ServiceResponse<UserLoginResponseDto>();
            try
            {
                response.Value = await userService.Login(request.Email, request.Password);
               
            }
            catch (Exception ex)
            {
                response.SetException(ex);
            }
            return response;
            
        }

        [HttpGet("Users")]
        public async Task<ServiceResponse<List<UserDto>>> GetUsers()
        {
            //throw new ApiException("Hata var");
            return new ServiceResponse<List<UserDto>>()
            {
                Value = await userService.GetUsers()
            };
        }

        [HttpPost("Create")]
        public async Task<ServiceResponse<UserDto>> CreateUser([FromBody] UserDto User)
        {
            return new ServiceResponse<UserDto>()
            {
                Value = await userService.CreateUser(User)
            };
        }

        [HttpPost("Update")]
        public async Task<ServiceResponse<UserDto>> UpdateUser([FromBody] UserDto User)
        {
            return new ServiceResponse<UserDto>()
            {
                Value = await userService.UpdateUser(User)
            };
        }

        [HttpGet("UserById/{Id}")]
        public async Task<ServiceResponse<UserDto>> GetUserById(Guid Id)
        {
            return new ServiceResponse<UserDto>()
            {
                Value = await userService.GetUserById(Id)
            };
        }

        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteUser([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await userService.DeleteUserById(id)
            };
        }

    }
}

