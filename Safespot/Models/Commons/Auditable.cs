namespace Safespot.Models.Commons
{
    public class Auditable
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
