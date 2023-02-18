using Microsoft.EntityFrameworkCore;
using URIS_BiddingProcess_it24.Data;
using URIS_BiddingProcess_it24.Models.entity;

namespace URIS_BiddingProcess_it24.Repositories
{
    public class OpeningOfBidsRepository : IOpeningOfBidsRepository
    {
        private readonly BiddingProcessApiDbContext biddingProcessAPIDbContext;

        public OpeningOfBidsRepository(BiddingProcessApiDbContext biddingProcessAPIDbContext)
        {
            this.biddingProcessAPIDbContext = biddingProcessAPIDbContext;
        }
        public async Task<OpeningOfBids> AddAsync(OpeningOfBids openingOfBids)
        {
            openingOfBids.OpeningOfBidsId = Guid.NewGuid();
            await biddingProcessAPIDbContext.AddAsync(openingOfBids);
            await biddingProcessAPIDbContext.SaveChangesAsync();
            return openingOfBids;
        }

        public async Task<OpeningOfBids> DeleteAsync(Guid id)
        {
            var openingOfBids = await biddingProcessAPIDbContext.OpeningsOfBids.FindAsync(id);
            if (openingOfBids == null)
            {
                return null;
            }
            biddingProcessAPIDbContext.OpeningsOfBids.Remove(openingOfBids);
            await biddingProcessAPIDbContext.SaveChangesAsync();
            return openingOfBids;
        }

        public async Task<IEnumerable<OpeningOfBids>> GetAllAsync()
        {
            return await biddingProcessAPIDbContext.OpeningsOfBids
                .Include(x => x.Bidding).ToListAsync();
        }

        public async Task<OpeningOfBids> GetByIdAsync(Guid id)
        {
            return await biddingProcessAPIDbContext.OpeningsOfBids
                .Include(x => x.Bidding).FirstOrDefaultAsync(x => x.OpeningOfBidsId == id);
        }

        public async Task<OpeningOfBids> UpdateAsync(Guid id, OpeningOfBids openingOfBids)
        {
            //find bidding condition in Db
            var existingOpeningOfBids = await biddingProcessAPIDbContext.OpeningsOfBids.FindAsync(id);
            //if NOT NULL
            if (existingOpeningOfBids != null)
            {
                existingOpeningOfBids.ArrivingDate = openingOfBids.ArrivingDate;
                existingOpeningOfBids.ArrivingHour = openingOfBids.ArrivingHour;
                existingOpeningOfBids.BiddingId = openingOfBids.BiddingId;
                await biddingProcessAPIDbContext.SaveChangesAsync();
                return existingOpeningOfBids;
            }
            //If null
            return null;
        }
    }
}
