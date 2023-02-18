using AuctioneerRegistration.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctioneerRegistration.Data
{
    public class AuctioneerRepository : IAuctioneerRepository
    {
        private readonly AuctioneerApiDbContext dbContext;
        public AuctioneerRepository(AuctioneerApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

       
        public async Task<IEnumerable<Auctioneer>> GetAllAsync()
        {
            return await dbContext.Auctioneers.ToListAsync();
        }

        public async Task<Auctioneer> GetAsync(Guid auctioneerId)
        {
            return await dbContext.Auctioneers.FirstOrDefaultAsync(x => x.AuctioneerId == auctioneerId);
        }

        public async Task<Auctioneer> AddAsync(Auctioneer auctioneer)
        {
            auctioneer.AuctioneerId = Guid.NewGuid();
            await dbContext.Auctioneers.AddAsync(auctioneer);
            await dbContext.SaveChangesAsync();
            return auctioneer;

        }

        public async Task<Auctioneer> UpdateAsync(Guid auctioneerId, Auctioneer auctioneer)
        {
            var existingAuctioneer =await dbContext.Auctioneers.FindAsync(auctioneerId);

            if(existingAuctioneer == null)
            {
                return null;
            }

            existingAuctioneer.FirstName = auctioneer.FirstName;
            existingAuctioneer.LastName = auctioneer.LastName;
            existingAuctioneer.JMBG = auctioneer.JMBG;
            existingAuctioneer.Street =auctioneer.Street;
            existingAuctioneer.City = auctioneer.City;
            existingAuctioneer.State = auctioneer.State;
            existingAuctioneer.PassportNum = auctioneer.PassportNum;

            await dbContext.SaveChangesAsync();
            return auctioneer;
        }

        public async Task<Auctioneer> DeleteAsync(Guid auctioneerId)
        {
            var existingAuctioneer = await dbContext.Auctioneers.FindAsync(auctioneerId);

            if(existingAuctioneer != null)
            {
                dbContext.Auctioneers.Remove(existingAuctioneer);
                await dbContext.SaveChangesAsync();
                return existingAuctioneer;
            }
            return null;
        }
    }
}
