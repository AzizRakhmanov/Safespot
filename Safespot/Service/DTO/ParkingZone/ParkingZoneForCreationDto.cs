using System.ComponentModel.DataAnnotations;

namespace Safespot.Service.DTO.ParkingZoneDto
{
    public class ParkingZoneForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        [Phone]
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email is confirmed with password")]
        public string Password { get; set; }
    }
}
