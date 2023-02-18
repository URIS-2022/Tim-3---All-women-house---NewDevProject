﻿using Microsoft.EntityFrameworkCore;
using URIS_DOKUMENTACIJA_IT72.Data;
using URIS_DOKUMENTACIJA_IT72.Models.Domain;

namespace URIS_DOKUMENTACIJA_IT72.Repositories
{
    public class BiddingProgramRepository : IBiddingProgramRepository
    {
        private readonly DocumentationAPIDbContext documentationAPIDbContext;

        public BiddingProgramRepository(DocumentationAPIDbContext documentationAPIDbContext)
        {
            this.documentationAPIDbContext = documentationAPIDbContext;


        }

        public async Task<IEnumerable<BiddingProgram>> GetAllAsync()
        {
            return await documentationAPIDbContext.BiddingPrograms
                .Include(x=>x.Document)
                .ToListAsync();
        }


        public async Task<BiddingProgram> GetAsync(Guid id)
        {

            return await documentationAPIDbContext.BiddingPrograms
                 .Include(x => x.Document)
                 .FirstOrDefaultAsync(x => x.DocumentId == id);


        }



        public async Task<BiddingProgram> AddAsync(BiddingProgram biddingProgram)
        {

            biddingProgram.BiddingProgramId = Guid.NewGuid();
            await documentationAPIDbContext.BiddingPrograms.AddAsync(biddingProgram);
            await documentationAPIDbContext.SaveChangesAsync();

            return biddingProgram;
        }

        public async Task<BiddingProgram> DeleteAsync(Guid id)
        {
            var biddingProgram = await documentationAPIDbContext.BiddingPrograms.FirstOrDefaultAsync(x => x.BiddingProgramId == id);

            if (biddingProgram == null)
            {
                return null;

            }

            documentationAPIDbContext.BiddingPrograms.Remove(biddingProgram);
            await documentationAPIDbContext.SaveChangesAsync();

            return biddingProgram;
        }



        public async Task<BiddingProgram> UpdateAsync(Guid id, BiddingProgram biddingProgram)
        {
            var existingBidProg = await documentationAPIDbContext.BiddingPrograms.FirstOrDefaultAsync(x => x.BiddingProgramId == id);

            if (existingBidProg == null)
            {
                return null;
            }
            existingBidProg.RoundNumber = biddingProgram.RoundNumber;
            existingBidProg.DocumentId = biddingProgram.DocumentId;
           

            await documentationAPIDbContext.SaveChangesAsync();

            return existingBidProg;

        }

    }
}
