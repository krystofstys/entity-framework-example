using ModelFirst.Model;
using Microsoft.EntityFrameworkCore;

namespace ModelFirst.Context
{
    public class ExampleDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Office> Offices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost:5432;Database=Office;Username=postgres;Password=postgres");
    }
}
