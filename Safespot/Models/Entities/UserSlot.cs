using Safespot.Models.Commons;

namespace Safespot.Models.Entities
{
    public class UserSlot : Auditable
    {
        public Guid ParkingZoneId { get; set; }

        public ParkingZone ParkingZone { get; set; }

        public Guid SlotId { get; set; }

        public Slot Slot { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
