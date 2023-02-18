using Microsoft.EntityFrameworkCore;
using URIS_DEOPARCELE_IT72.Models.Domain;

namespace URIS_DEOPARCELE_IT72.Data
{
    public class PartParcelAPIDbContext:DbContext
    {

        public PartParcelAPIDbContext(DbContextOptions<PartParcelAPIDbContext> options) : base(options)
        { 
        
        }

        public DbSet<PartOfParcel> PartOfParcels { get; set; }

    }
}
