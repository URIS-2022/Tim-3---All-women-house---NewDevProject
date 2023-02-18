using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using URIS_OGLAS_IT72.Data;
using URIS_OGLAS_IT72.Models.Domain;

namespace URIS_OGLAS_IT72.Repositories
{
    public class AdvertismentRepository : IAdvertismentRepository
    {
        private readonly AdverAPIDbContext adverAPIDbContext;

        public AdvertismentRepository(AdverAPIDbContext adverAPIDbContext) 
        {
            this.adverAPIDbContext = adverAPIDbContext;
        }


        public async Task<IEnumerable<Advertisment>> GetAllAsync()
        {
            return await adverAPIDbContext.Advertisments
                 .Include(x => x.DecisionOfAdvertisments)
                 .ToListAsync();
        }


        public async Task<Advertisment> GetAsync(Guid id)
        {

            return await adverAPIDbContext.Advertisments
                 .Include(x => x.DecisionOfAdvertisments)
                 .FirstOrDefaultAsync(x => x.DecisionOfAdvertismentId == id);


        }


        public async Task<Advertisment> AddAsync(Advertisment advertisment)
        {

            advertisment.AdvertismentId = Guid.NewGuid();
            await adverAPIDbContext.Advertisments.AddAsync(advertisment);
            await adverAPIDbContext.SaveChangesAsync();

            return advertisment;
        }


        public async Task<Advertisment> DeleteAsync(Guid id)
        {
            var advertisment = await adverAPIDbContext.Advertisments.FirstOrDefaultAsync(x => x.AdvertismentId == id);

            if (advertisment == null)
            {
                return null;

            }

            adverAPIDbContext.Advertisments.Remove(advertisment);
            await adverAPIDbContext.SaveChangesAsync();

            return advertisment;
        }




        public async Task<Advertisment> UpdateAsync(Guid id, Advertisment advertisment)
        {
            var existingAdvertisment = await adverAPIDbContext.Advertisments.FirstOrDefaultAsync(x => x.AdvertismentId == id);

            if (existingAdvertisment == null)
            {
                return null;
            }
            existingAdvertisment.TipGaranta = advertisment.TipGaranta;
            existingAdvertisment.DecisionOfAdvertismentId = advertisment.DecisionOfAdvertismentId;
            
            await adverAPIDbContext.SaveChangesAsync();

            return existingAdvertisment;

        }
    }
}
