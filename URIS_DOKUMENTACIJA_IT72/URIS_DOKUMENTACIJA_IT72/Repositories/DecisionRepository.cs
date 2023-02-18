using Microsoft.EntityFrameworkCore;
using URIS_DOKUMENTACIJA_IT72.Data;
using URIS_DOKUMENTACIJA_IT72.Models.Domain;

namespace URIS_DOKUMENTACIJA_IT72.Repositories
{
    public class DecisionRepository : IDecisionRepository
    {
        private readonly DocumentationApiDbContext documentationApiDbContext;

        public DecisionRepository(DocumentationApiDbContext documentationApiDbContext)
        {
            this.documentationApiDbContext = documentationApiDbContext;


        }

        public async Task<IEnumerable<Decision>> GetAllAsync()
        {
            return await documentationApiDbContext.Decisions
                .Include(x=>x.Document)
                .ToListAsync();
        }

        public async Task<Decision> GetAsync(Guid id)
        {

            return await documentationApiDbContext.Decisions
                 .Include(x => x.Document)
                 .FirstOrDefaultAsync(x => x.DocumentId == id);


        }



        public async Task<Decision> AddAsync(Decision decision)
        {

            decision.DecisionId = Guid.NewGuid();
            await documentationApiDbContext.Decisions.AddAsync(decision);
            await documentationApiDbContext.SaveChangesAsync();

            return decision;
        }


        public async Task<Decision> DeleteAsync(Guid id)
        {
            var decision = await documentationApiDbContext.Decisions.FirstOrDefaultAsync(x => x.DecisionId == id);

            if (decision == null)
            {
                return null;

            }

            documentationApiDbContext.Decisions.Remove(decision);
            await documentationApiDbContext.SaveChangesAsync();

            return decision;
        }




        public async Task<Decision> UpdateAsync(Guid id, Decision decision)
        {
            var existingDecision = await documentationApiDbContext.Decisions.FirstOrDefaultAsync(x => x.DecisionId == id);

            if (existingDecision == null)
            {
                return null;
            }
            existingDecision.NumberOfDecision=decision.NumberOfDecision;
            existingDecision.ParliamentaryDecision=decision.ParliamentaryDecision;
            existingDecision.DocumentId=decision.DocumentId;

            await documentationApiDbContext.SaveChangesAsync();

            return existingDecision;

        }
    }
}
