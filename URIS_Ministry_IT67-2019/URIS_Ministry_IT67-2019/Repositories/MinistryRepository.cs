using Microsoft.EntityFrameworkCore;
using URIS_Ministry_IT67_2019.Data;
using URIS_Ministry_IT67_2019.Entities;

namespace URIS_Ministry_IT67_2019.Repositories
{
    public class MinistryRepository : IMinistryRepository
    {
        private readonly MinistryDbContext ministryDbContext;

        public MinistryRepository(MinistryDbContext ministryDbContext)
        {
            this.ministryDbContext = ministryDbContext;
        }

        public async Task<Ministry> AddMinistry(Ministry ministry)
        {
            ministry.MinistryId = Guid.NewGuid();
            await ministryDbContext.Ministries.AddAsync(ministry);
            await ministryDbContext.SaveChangesAsync();
            return ministry;
        }

        public async Task<Ministry> DeleteMinistry(Guid MinistryId)
        {
            var existingMinistry = await ministryDbContext.Ministries.FindAsync(MinistryId);
            if(existingMinistry == null)
            {
                return null;
            }   
            ministryDbContext.Ministries.Remove(existingMinistry);
            await ministryDbContext.SaveChangesAsync();
            return existingMinistry;
        }

        public async Task<IEnumerable<Ministry>> GetAllMinistries()
        {
            return await ministryDbContext.Ministries.ToListAsync();
        }

        public async Task<Ministry> GetMinistry(Guid MinistryId)
        {
            return await ministryDbContext.Ministries.FirstOrDefaultAsync(x => x.MinistryId == MinistryId);
        }

        public async Task<Ministry> UpdateMinistry(Guid MinistryId, Ministry ministry)
        {
            var existingMinistry = await ministryDbContext.Ministries.FindAsync(MinistryId);
            if(existingMinistry == null)
            {
                return null;
            }
            existingMinistry.MinistryName = ministry.MinistryName;
            existingMinistry.Minister = ministry.Minister;
            existingMinistry.Consent = ministry.Consent;
            await ministryDbContext.SaveChangesAsync();
            return existingMinistry;
        }
    }
}
