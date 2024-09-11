using Microsoft.AspNetCore.Identity;

namespace Safespot.Mvc.Areas.Identity.Data
{
    public class LoginModel : IdentityUser
    {
        public string FirstName { get; set; }   

        public string LastName { get; set; }

        public string MiddleName {  get; set; }

        public DateTime BirthDate { get; set; }
    }
}
