using Microsoft.EntityFrameworkCore;
using URIS_BiddingProcess_it24.Data;
using URIS_BiddingProcess_it24.Models.entity;

namespace URIS_BiddingProcess_it24.Repositories
{
    public class BiddingRepository : IBiddingRepository
    {
        private readonly BiddingProcessApiDbContext biddingProcessAPIDbContext;

        public BiddingRepository(BiddingProcessApiDbContext biddingProcessAPIDbContext)
        {
            this.biddingProcessAPIDbContext = biddingProcessAPIDbContext;
        }

        public async Task<Bidding> AddAsync(Bidding bidding)
        {
            bidding.BiddingId = Guid.NewGuid();
            await biddingProcessAPIDbContext.AddAsync(bidding);
            await biddingProcessAPIDbContext.SaveChangesAsync();
            return bidding;
        }

        public async Task<Bidding> DeleteAsync(Guid id)
        {
            var bidding = await biddingProcessAPIDbContext.Biddings.FindAsync(id);
            if(bidding == null)
            {
                return null;
            }
            biddingProcessAPIDbContext.Biddings.Remove(bidding);
            await biddingProcessAPIDbContext.SaveChangesAsync();
            return bidding;
        }

        public async Task<IEnumerable<Bidding>> GetAllAsync()
        {
            return await biddingProcessAPIDbContext.Biddings.ToListAsync();
        }
        public async Task<Bidding> GetByIdAsync(Guid id)
        {
           return await biddingProcessAPIDbContext.Biddings.FirstOrDefaultAsync(x => x.BiddingId== id);
        }

        public async Task<Bidding> UpdateAsync(Guid id, Bidding bidding)
        {
            var existingBidding = await biddingProcessAPIDbContext.Biddings.FirstOrDefaultAsync(x =>x.BiddingId== id);
            if(existingBidding== null) 
            {
                return null;
            }
            existingBidding.BiddingCode=bidding.BiddingCode;
            existingBidding.Status=bidding.Status;
            existingBidding.Type=bidding.Type;
            existingBidding.Excepted=bidding.Excepted;
            existingBidding.StartingPrice=bidding.StartingPrice;
            existingBidding.DateOfMaintenance=bidding.DateOfMaintenance;
            existingBidding.StartTime=bidding.StartTime;
            existingBidding.EndTime=bidding.EndTime;

            await biddingProcessAPIDbContext.SaveChangesAsync();

            return existingBidding;
        }
    }
}
