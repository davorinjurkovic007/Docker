using Microsoft.EntityFrameworkCore;

namespace DockerAPI.Models
{
    public class ColourContext : DbContext
    {
        public ColourContext(DbContextOptions<ColourContext> options) : base(options)
        {
        }

        public DbSet<Colour> ColourItems { get; set; } = default!;
    }
}
