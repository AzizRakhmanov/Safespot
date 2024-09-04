using System.ComponentModel;

namespace Safespot.Service.DTO.ParkingZone
{
    public class ParkingZoneForDetailsDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Free Slot")]
        public int FreeSlot { get; set; }

        [DisplayName("Econom slot")]
        public int EconomSlot { get; set; }

        [DisplayName("Business Slot")]
        public int BusinessSlot { get; set; }

        public Guid AddressId { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string GoogleMapUrl { get; set; }
    }
}
