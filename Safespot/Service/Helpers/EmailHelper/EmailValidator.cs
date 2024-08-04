using Safespot.Service.Exceptions;
using System.Text.RegularExpressions;

namespace Safespot.Service.Helpers.EmailHelper
{
    public static class EmailValidator
    {

        public static string ValidateEmail(this Attribute attribute, string email)
        {
            Regex regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$");

            if (!regex.IsMatch(email))
            {
                throw new SafespotException("Email is not invalid", 404);
            }

            return email;

        }
    }
}
