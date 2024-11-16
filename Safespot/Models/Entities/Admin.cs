using Safespot.Models.Commons;

namespace Safespot.Models.Entities
{
    public class Admin : Auditable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public decimal Salary { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// this is when admin started his/her job
        /// </summary>
        public DateTime StartedAt { get; set; }
    }
}
