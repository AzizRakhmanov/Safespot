using Safespot.Models.Commons;

namespace Safespot.Models.Entities
{
    public class ParkingZone : Auditable
    {
        public string Name { get; set; }

        public Guid AddressId { get; set; }

        public Address Address { get; set; }
    }
}
