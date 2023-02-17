using Microsoft.EntityFrameworkCore;
using Township.Models;

namespace Township.Entities
{
    public class TownshipContext : DbContext
    {
        private readonly IConfiguration configuration;

        public TownshipContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<TownshipDto> Township { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Township"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TownshipDto>()
                .HasData(new
                {
                    IdTownship = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    NameOfTownship = "Old town"
                });

            modelBuilder.Entity<TownshipDto>()
                .HasData(new
                {
                    IdTownship = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e965b"),
                    NameOfTownship = "New town"
                });
        }
    }
}
