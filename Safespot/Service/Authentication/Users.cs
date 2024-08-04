using Microsoft.AspNetCore.Identity;

namespace Safespot.Service.Authentication
{
    public class Users : IdentityUser
    {
        public string Name { get; set; }

        public string Password { get; set; }
    }
}
