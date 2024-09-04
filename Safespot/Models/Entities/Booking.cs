using Safespot.Models.Commons;

namespace Safespot.Models.Entities
{
    public class Booking : Auditable
    {
        public Guid SlotId { get; set; }

        public Slot Slot { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public decimal UserPaidMoney {  get; set; }

        public DateTimeOffset TilThisTime { get; set; }
    }
}
