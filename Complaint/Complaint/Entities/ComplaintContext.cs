using Complaint.Models;
using Microsoft.EntityFrameworkCore;

namespace Complaint.Entities
{
    public class ComplaintContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ComplaintContext(DbContextOptions<ComplaintContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<ComplaintDto> Complaint { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Complaint"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComplaintDto>()
                .HasData(new
                {
                    IdComplaint = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    SubmissionDate = new DateTime(2015, 12, 31),
                    TypeOfComplaint = "Complaint against the Decision on Leasing",
                    StatusOfComplaint = "Not approved"
                });

            modelBuilder.Entity<ComplaintDto>()
                .HasData(new
                {
                    IdComplaint = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3975c0"),
                    SubmissionDate = new DateTime(2017, 10, 09),
                    TypeOfComplaint = "Complaint against the Decision on Leasing",
                    StatusOfComplaint = "Not approved"
                });
        }
    }
}
