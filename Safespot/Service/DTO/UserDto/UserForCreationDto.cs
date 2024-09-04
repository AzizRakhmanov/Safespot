using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Safespot.Service.DTO.UserDto
{
    public class UserForCreationDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Middle Name required")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Birth Date required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [EmailAddress(ErrorMessage = "Email is not in the correct format")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
    }
}
