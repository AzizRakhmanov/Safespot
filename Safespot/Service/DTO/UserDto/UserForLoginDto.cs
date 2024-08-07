using Microsoft.AspNetCore.Identity;

namespace Safespot.Service.DTO.UserDto
{
    public class UserForLoginDto : IdentityUser
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; } = false;
    }
}
