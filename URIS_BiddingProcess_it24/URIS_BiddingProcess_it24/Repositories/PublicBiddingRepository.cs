using Microsoft.EntityFrameworkCore;
using URIS_BiddingProcess_it24.Data;
using URIS_BiddingProcess_it24.Models.entity;

namespace URIS_BiddingProcess_it24.Repositories
{
    public class PublicBiddingRepository : IPublicBiddingRepository
    {
        private readonly BiddingProcessApiDbContext biddingProcessAPIDbContext;

        public PublicBiddingRepository(BiddingProcessApiDbContext biddingProcessAPIDbContext)
        {
            this.biddingProcessAPIDbContext = biddingProcessAPIDbContext;
        }
        public async Task<PublicBidding> AddAsync(PublicBidding publicBidding)
        {
            publicBidding.PublicBiddingId = Guid.NewGuid();
            await biddingProcessAPIDbContext.AddAsync(publicBidding);
            await biddingProcessAPIDbContext.SaveChangesAsync();
            return publicBidding;
        }

        public async Task<PublicBidding> DeleteAsync(Guid id)
        {
            var publicBidding = await biddingProcessAPIDbContext.PublicBiddings.FindAsync(id);
            if (publicBidding == null)
            {
                return null;
            }
            biddingProcessAPIDbContext.PublicBiddings.Remove(publicBidding);
            await biddingProcessAPIDbContext.SaveChangesAsync();
            return publicBidding;
        }

        public async Task<IEnumerable<PublicBidding>> GetAllAsync()
        {
            return await biddingProcessAPIDbContext.PublicBiddings.
                Include(x => x.Bidding).ToListAsync();
        }

        public async Task<PublicBidding> GetByIdAsync(Guid id)
        {
            return await biddingProcessAPIDbContext.PublicBiddings
                .Include(x => x.Bidding).FirstOrDefaultAsync(x => x.PublicBiddingId == id);
        }

        public async Task<PublicBidding> UpdateAsync(Guid id, PublicBidding publicBidding)
        {
            //find bidding condition in Db
            var existingPublicBidding = await biddingProcessAPIDbContext.PublicBiddings.FindAsync(id);
            //If IS NOT null
            if (existingPublicBidding != null)
            {
                existingPublicBidding.PriceStep = publicBidding.PriceStep;
                existingPublicBidding.BiddingId = publicBidding.BiddingId;
                await biddingProcessAPIDbContext.SaveChangesAsync();
                return existingPublicBidding;
            }
            //If null
            return null;
        }
    }
}
