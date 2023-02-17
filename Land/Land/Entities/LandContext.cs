using Land.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Land.Entities
{
    public class LandContext : DbContext
    {
        private readonly IConfiguration configuration;

        public LandContext(DbContextOptions<LandContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<LandDto> Land { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Land"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LandDto>()
                .HasData(new
                {
                    LabelLand = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    Surface = "500m2",
                    SoilCulture = "field",
                    _Class = "first",
                    Workability = "arable",
                    FormOfProperty = "personal",
                    Drainage = "possible"
                });

            modelBuilder.Entity<LandDto>()
                .HasData(new
                {
                    LabelLand = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e965b"),
                    Surface = "500m2",
                    SoilCulture = "field",
                    _Class = "first",
                    Workability = "arable",
                    FormOfProperty = "personal",
                    Drainage = "possible"
                });
        }
    }
}
