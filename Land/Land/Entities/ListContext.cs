using Land.Models;
using Microsoft.EntityFrameworkCore;

namespace Land.Entities
{
    public class ListContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ListContext(DbContextOptions<ListContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<ListDto> List { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Land"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListDto>()
                .HasData(new
                {
                    IdList = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    SumSurface = "500m2",
                    LabelLand = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e965b"),
                });

            modelBuilder.Entity<ListDto>()
                .HasData(new
                {
                    IdList = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e965b"),
                    SumSurface = "1500m2",
                    LabelLand = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                });
        }
    }
}
