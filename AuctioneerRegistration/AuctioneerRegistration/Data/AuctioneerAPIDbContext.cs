using AuctioneerRegistration.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctioneerRegistration.Data
{
    public class AuctioneerApiDbContext : DbContext
    {
        public AuctioneerApiDbContext(DbContextOptions<AuctioneerApiDbContext> options) : base(options)
        {
        }

        public DbSet<Auctioneer> Auctioneers { get; set; }
    }
}
