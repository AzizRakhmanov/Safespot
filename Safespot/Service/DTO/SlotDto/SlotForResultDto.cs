using Safespot.Models.Entities;

namespace Safespot.Service.DTO.SlotDto
{
    public class SlotForResultDto
    {
        public string Nama { get; set; }

        /// <summary>
        /// Amound of money user paid
        /// </summary>
        public decimal UserMoney { get; set; }

        public SlotCategory Category { get; set; }

        public Guid ParkingZoneId { get; set; }
    }
}
