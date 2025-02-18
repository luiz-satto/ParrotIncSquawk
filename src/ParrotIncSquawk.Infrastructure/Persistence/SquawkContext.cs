using Microsoft.EntityFrameworkCore;
using ParrotIncSquawk.Infrastructure.Models;

namespace ParrotIncSquawk.Infrastructure.Persistence
{
    public class SquawkContext : DbContext
    {
        public virtual DbSet<Squawk> Squawks { get; set; } = default!;

        public SquawkContext()
        {            
        }

        public SquawkContext(DbContextOptions<SquawkContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Squawk>().HasData(
                new Squawk() { SquawkId = Guid.NewGuid(), UserId = Guid.NewGuid(), SquawkDate = DateTime.UtcNow, Text = "Squawk Squawk Squawk" },
                new Squawk() { SquawkId = Guid.NewGuid(), UserId = Guid.NewGuid(), SquawkDate = DateTime.UtcNow, Text = "Hue hue huE" },
                new Squawk() { SquawkId = Guid.NewGuid(), UserId = Guid.NewGuid(), SquawkDate = DateTime.UtcNow, Text = "Test test again Lol" }
            );
        }
    }
}
