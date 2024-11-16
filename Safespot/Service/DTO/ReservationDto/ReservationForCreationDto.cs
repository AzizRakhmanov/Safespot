using Safespot.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Safespot.Service.DTO.ReservationDto
{
    public class ReservationForCreationDto
    {
        [Required]
        public DateTimeOffset EndDate { get; set; }

        public PaymentType PaymentType { get; set; }

        public decimal PaidAmount { get; set; }

        public Guid CarPlateNumberId { get; set; }

        public CarPlateNumber CarPlateNumber { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid SlotId { get; set; }

        public Slot Slot { get; set; }

        public Guid ParkingZoneId { get; set; }

        public Safespot.Models.Entities.ParkingZone ParkingZone { get; set; }
    }
}
