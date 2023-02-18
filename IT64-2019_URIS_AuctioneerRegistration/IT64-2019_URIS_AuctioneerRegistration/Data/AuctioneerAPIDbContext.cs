using IT64_2019_URIS_AuctioneerRegistration.Entities;
using Microsoft.EntityFrameworkCore;

namespace IT64_2019_URIS_AuctioneerRegistration.Data
{
    public class AuctioneerAPIDbContext : DbContext
    {
        public AuctioneerAPIDbContext(DbContextOptions<AuctioneerAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Auctioneer> Auctioneers { get; set; }
    }
}
