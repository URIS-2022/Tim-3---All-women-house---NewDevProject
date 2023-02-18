using Microsoft.EntityFrameworkCore;
using URIS_DOKUMENTACIJA_IT72.Data;
using URIS_DOKUMENTACIJA_IT72.Models.Domain;

namespace URIS_DOKUMENTACIJA_IT72.Repositories
{
    public class BiddingProgramRepository : IBiddingProgramRepository
    {
        private readonly DocumentationApiDbContext documentationApiDbContext;

        public BiddingProgramRepository(DocumentationApiDbContext documentationApiDbContext)
        {
            this.documentationApiDbContext = documentationApiDbContext;


        }

        public async Task<IEnumerable<BiddingProgram>> GetAllAsync()
        {
            return await documentationApiDbContext.BiddingPrograms
                .Include(x=>x.Document)
                .ToListAsync();
        }


        public async Task<BiddingProgram> GetAsync(Guid id)
        {

            return await documentationApiDbContext.BiddingPrograms
                 .Include(x => x.Document)
                 .FirstOrDefaultAsync(x => x.DocumentId == id);


        }



        public async Task<BiddingProgram> AddAsync(BiddingProgram biddingProgram)
        {

            biddingProgram.BiddingProgramId = Guid.NewGuid();
            await documentationApiDbContext.BiddingPrograms.AddAsync(biddingProgram);
            await documentationApiDbContext.SaveChangesAsync();

            return biddingProgram;
        }

        public async Task<BiddingProgram> DeleteAsync(Guid id)
        {
            var biddingProgram = await documentationApiDbContext.BiddingPrograms.FirstOrDefaultAsync(x => x.BiddingProgramId == id);

            if (biddingProgram == null)
            {
                return null;

            }

            documentationApiDbContext.BiddingPrograms.Remove(biddingProgram);
            await documentationApiDbContext.SaveChangesAsync();

            return biddingProgram;
        }



        public async Task<BiddingProgram> UpdateAsync(Guid id, BiddingProgram biddingProgram)
        {
            var existingBidProg = await documentationApiDbContext.BiddingPrograms.FirstOrDefaultAsync(x => x.BiddingProgramId == id);

            if (existingBidProg == null)
            {
                return null;
            }
            existingBidProg.RoundNumber = biddingProgram.RoundNumber;
            existingBidProg.DocumentId = biddingProgram.DocumentId;
           

            await documentationApiDbContext.SaveChangesAsync();

            return existingBidProg;

        }

    }
}
