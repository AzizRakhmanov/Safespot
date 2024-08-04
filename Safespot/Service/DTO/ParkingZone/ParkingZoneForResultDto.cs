using System.ComponentModel;

namespace Safespot.Service.DTO.ParkingZoneDto
{
    public class ParkingZoneForResultDto
    {
        [DisplayName("Name")]
        public string FirstName { get; set; }

        [DisplayName("Surname")]
        public string LastName { get; set; }

        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }


        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
