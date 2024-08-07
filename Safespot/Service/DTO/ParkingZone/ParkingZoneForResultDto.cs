using System.ComponentModel;
using static Duende.IdentityServer.Models.IdentityResources;

namespace Safespot.Service.DTO.ParkingZoneDto
{
    public class ParkingZoneForResultDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Free Slot")]
        public int FreeSlot { get; set; }

        [DisplayName("Econom slot")]
        public int EconomSlot { get; set; }

        [DisplayName("Business Slot")]
        public int BusinessSlot { get; set; }
    }
}
