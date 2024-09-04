using Safespot.Models.Entities;

namespace Safespot.Service.DTO.ParkingZoneDto
{
    public class ParkingZoneForCreationDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int FreeSlot { get; set; }

        public int EconomSlot { get; set; }

        public int BusinessSlot { get; set; }

        public Guid AddressId { get; set; }

        public Address Addresses { get; set; }
    }
}
