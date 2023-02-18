using Microsoft.EntityFrameworkCore;
using URIS_BiddingProcess_it24.Models.entity;

namespace URIS_BiddingProcess_it24.Data
{
    public class BiddingProcessApiDbContext:DbContext
    {
        public BiddingProcessApiDbContext(DbContextOptions<BiddingProcessApiDbContext> options) : base(options) 
        { 

        }
        public DbSet<Bidding> Biddings { get; set; }
        public DbSet<BiddingConditions> BiddingsConditions { get; set;}
        public DbSet<PublicBidding> PublicBiddings { get; set; }
        public DbSet<OpeningOfBids> OpeningsOfBids { get;set; }
    }
}
