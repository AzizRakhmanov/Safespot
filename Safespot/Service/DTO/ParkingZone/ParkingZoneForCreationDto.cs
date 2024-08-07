using System.ComponentModel.DataAnnotations;
using static Duende.IdentityServer.Models.IdentityResources;

namespace Safespot.Service.DTO.ParkingZoneDto
{
    public class ParkingZoneForCreationDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int FreeSlot { get; set; }

        public int EconomSlot { get; set; }

        public int BusinessSlot { get; set; }
    }
}
