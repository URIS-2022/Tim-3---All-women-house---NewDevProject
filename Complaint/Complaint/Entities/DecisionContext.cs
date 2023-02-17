using Complaint.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Complaint.Entities
{
    public class DecisionContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DecisionContext(DbContextOptions<DecisionContext> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<DecisionDto> Decision { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Complaint"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DecisionDto>()
                .HasData(new
                {
                    IdDecision = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    DecisionDate = new DateTime(2017, 10, 09),
                    MinistryOpinion = true
                });

            modelBuilder.Entity<DecisionDto>()
                .HasData(new
                {
                    IdDecision = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e965b"),
                    DecisionDate = new DateTime(2017, 11, 12),
                    MinistryOpinion = true
                });
        }
    }
}
