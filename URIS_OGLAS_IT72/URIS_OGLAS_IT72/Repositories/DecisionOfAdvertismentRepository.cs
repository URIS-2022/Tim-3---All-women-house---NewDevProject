using Microsoft.EntityFrameworkCore;
using URIS_OGLAS_IT72.Data;
using URIS_OGLAS_IT72.Models.Domain;

namespace URIS_OGLAS_IT72.Repositories
{
    public class DecisionOfAdvertismentRepository : IDecisionOfAdvertismentRepository
    {
        private readonly AdverAPIDbContext adverAPIDbContext;

        public DecisionOfAdvertismentRepository(AdverAPIDbContext adverAPIDbContext)
        {
            this.adverAPIDbContext = adverAPIDbContext;
        }


        public async Task<IEnumerable<DecisionOfAdvertisment>> GetAllAsync()
        {
            return await adverAPIDbContext.DecisionOfAdvertisments.ToListAsync();
        }

        public async Task<DecisionOfAdvertisment> GetAsync(Guid id)
        {
            return await adverAPIDbContext.DecisionOfAdvertisments.FirstOrDefaultAsync(x => x.DecisionOfAdvertismentId == id);


        }

        public async Task<DecisionOfAdvertisment> AddAsync(DecisionOfAdvertisment decisionOfAdvertisment)
        {

            decisionOfAdvertisment.DecisionOfAdvertismentId = Guid.NewGuid();
            await adverAPIDbContext.DecisionOfAdvertisments.AddAsync(decisionOfAdvertisment);
            await adverAPIDbContext.SaveChangesAsync();

            return decisionOfAdvertisment;
        }

        public async Task<DecisionOfAdvertisment> DeleteAsync(Guid id)
        {
            var decisionOfAdvertisment = await adverAPIDbContext.DecisionOfAdvertisments.FirstOrDefaultAsync(x => x.DecisionOfAdvertismentId == id);

            if (decisionOfAdvertisment == null)
            {
                return null;

            }

            adverAPIDbContext.DecisionOfAdvertisments.Remove(decisionOfAdvertisment);
            await adverAPIDbContext.SaveChangesAsync();

            return decisionOfAdvertisment;
        }



        public async Task<DecisionOfAdvertisment> UpdateAsync(Guid id, DecisionOfAdvertisment decisionOfAdvertisment)
        {
            var existingDecisionOfAdvertisment = await adverAPIDbContext.DecisionOfAdvertisments.FirstOrDefaultAsync(x => x.DecisionOfAdvertismentId == id);

            if (existingDecisionOfAdvertisment == null)
            {
                return null;
            }
            existingDecisionOfAdvertisment.VremeDonosenja = decisionOfAdvertisment.VremeDonosenja;
            existingDecisionOfAdvertisment.NazivOdluke = decisionOfAdvertisment.NazivOdluke;

            await adverAPIDbContext.SaveChangesAsync();

            return existingDecisionOfAdvertisment;

        }
    }
}
