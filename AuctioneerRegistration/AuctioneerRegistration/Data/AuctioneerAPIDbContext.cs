using AuctioneerRegistration.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctioneerRegistration.Data
{
    public class AuctioneerAPIDbContext : DbContext
    {
        public AuctioneerAPIDbContext(DbContextOptions<AuctioneerAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Auctioneer> Auctioneers { get; set; }
    }
}
