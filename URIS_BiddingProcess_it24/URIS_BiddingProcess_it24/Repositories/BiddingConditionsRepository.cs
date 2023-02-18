using Microsoft.EntityFrameworkCore;
using URIS_BiddingProcess_it24.Data;
using URIS_BiddingProcess_it24.Models.entity;

namespace URIS_BiddingProcess_it24.Repositories
{
    public class BiddingConditionsRepository : IBiddingConditionsRepository
    {
        private readonly BiddingProcessApiDbContext biddingProcessAPIDbContext;

        public BiddingConditionsRepository(BiddingProcessApiDbContext biddingProcessAPIDbContext)
        {
            this.biddingProcessAPIDbContext = biddingProcessAPIDbContext;
        }

        public async Task<BiddingConditions> AddAsync(BiddingConditions condition)
        {
            condition.BiddingConditionsId=Guid.NewGuid();
            await biddingProcessAPIDbContext.AddAsync(condition);
            await biddingProcessAPIDbContext.SaveChangesAsync();
            return condition;

        }

        public async Task<BiddingConditions> DeleteAsync(Guid id)
        {
            var biddingConditions = await biddingProcessAPIDbContext.BiddingsConditions.FindAsync(id);
            if (biddingConditions == null)
            {
                return null;
            }
            biddingProcessAPIDbContext.BiddingsConditions.Remove(biddingConditions);
            await biddingProcessAPIDbContext.SaveChangesAsync();
            return biddingConditions;
        }

        public async Task<IEnumerable<BiddingConditions>> GetAllAsync()
        {
            return await biddingProcessAPIDbContext.BiddingsConditions
                .Include(x => x.Bidding).ToListAsync();
        }

        public async Task<BiddingConditions> GetByIdAsync(Guid id)
        {
            return await biddingProcessAPIDbContext.BiddingsConditions
                .Include(x => x.Bidding).FirstOrDefaultAsync(x => x.BiddingConditionsId == id);

        }

        public async Task<BiddingConditions> UpdateAsync(Guid id, BiddingConditions condition)
        {
            //find bidding condition in Db
            var existingBiddingConditions = await biddingProcessAPIDbContext.BiddingsConditions.FindAsync(id);
            //if NOT NULL
            if (existingBiddingConditions != null)
            {
                existingBiddingConditions.Price = condition.Price;
                existingBiddingConditions.RentalDuration = condition.RentalDuration;
                existingBiddingConditions.BiddingId = condition.BiddingId;
                await biddingProcessAPIDbContext.SaveChangesAsync();
                return existingBiddingConditions;
            }
            //If null
            return null;
        }
    }
}
