using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using URIS_OGLAS_IT72.Models.Domain;

namespace URIS_OGLAS_IT72.Data
{
    public class AdverAPIDbContext : DbContext
    {

        public AdverAPIDbContext(DbContextOptions<AdverAPIDbContext> options) : base(options)
        {


        }
        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<DecisionOfAdvertisment> DecisionOfAdvertisments { get; set; }
    }
}
