using Microsoft.AspNetCore.Identity;

namespace Safespot.Areas.Identity.Models
{
    public class UserForLoginDto : IdentityUser
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
