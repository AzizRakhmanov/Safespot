using Safespot.Models.Entities;
using System.ComponentModel.DataAnnotations;


namespace Safespot.Service.DTO.SlotDto
{
    public class SlotForCreationDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Nama { get; set; }

        /// <summary>
        /// Amound of money user paid
        /// </summary>

        [Required(ErrorMessage = "Slot not paid")]
        public decimal UserMoney { get; set; }

        public SlotCategory Category { get; set; }

        public Guid ParkingZoneId { get; set; }
    }
}
