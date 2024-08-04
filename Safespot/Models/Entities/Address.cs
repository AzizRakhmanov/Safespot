using Safespot.Models.Commons;

namespace Safespot.Models.Entities
{
    public class Address : Auditable
    {
        public string Country { get; set; }

        public string Region { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string GoogleMapUrl { get; set; }
    }
}
