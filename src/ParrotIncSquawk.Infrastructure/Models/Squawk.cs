using System.ComponentModel.DataAnnotations;

namespace ParrotIncSquawk.Infrastructure.Models
{
    public class Squawk
    {
        [Key]
        public Guid SquawkId { get; set; }

        public Guid UserId { get; set; }

        public required string Text { get; set; }

        public DateTime SquawkDate { get; set; }
    }
}
