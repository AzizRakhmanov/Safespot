using Safespot.Models.Commons;

namespace Safespot.Models.Entities
{
    public class Slot : Auditable
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsAvailableForBooking { get; set; } = true;

        public SlotCategory Category { get; set; }

        public Guid ParkingZoneId { get; set; }

        public ParkingZone ParkingZone { get; set; }
    }
}