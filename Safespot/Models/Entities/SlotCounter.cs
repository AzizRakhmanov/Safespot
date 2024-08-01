using Safespot.Models.Commons;

namespace Safespot.Models.Entities
{
    public class SlotCounter : Auditable
    {
        public Guid ParkingZoneId { get; set; }

        public ParkingZone ParkingZone { get; set; }

        public int FreeSlots { get; set; }

        public int EconomSlots { get; set; }

        public int BusinessSlots { get; set; }
    }
}
