using Safespot.Models.Commons;

namespace Safespot.Models.Entities
{
    public class CarPlateNumber : Auditable
    {
        public string Name { get; set; }

        public DateTime BookedFrom { get; set; }

        public DateTime BookedTo { get; set; }
    }
}