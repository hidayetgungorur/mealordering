using System;
namespace MealOrdering.Shared.Dto
{
    public class UserLoginResponseDto
    {
        public String ApiToken { get; set; }

        public UserDto User { get; set; }

    }

}

