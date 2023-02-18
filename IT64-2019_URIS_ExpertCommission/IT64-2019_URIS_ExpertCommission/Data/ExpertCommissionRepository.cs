using IT64_2019_URIS_ExpertCommission.Entities;
using Microsoft.EntityFrameworkCore;

namespace IT64_2019_URIS_ExpertCommission.Data
{
    public class ExpertCommissionRepository : IExpertCommissionRepository
    {
        private readonly ExpertCommissionAPIDbContext dbContext;

        public ExpertCommissionRepository(ExpertCommissionAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

  

        public async Task<IEnumerable<ExpertCommission>> GetAllAsync()
        {
            return await dbContext.ExpertCommissions.ToListAsync();
        }

        public async Task<ExpertCommission> GetAsync(Guid expertCommissionId)
        {
            return await dbContext.ExpertCommissions.FirstOrDefaultAsync(x => x.ExpertCommissionId == expertCommissionId);

        }
        public async Task<ExpertCommission> AddAsync(ExpertCommission expertCommission)
        {
            expertCommission.ExpertCommissionId = Guid.NewGuid();
            await dbContext.AddAsync(expertCommission);
            await dbContext.SaveChangesAsync();
            return expertCommission;
        }

        public async Task<ExpertCommission> DeleteAsync(Guid expertCommissionId)
        {
            var expertCommission = await dbContext.ExpertCommissions.FirstOrDefaultAsync(x => x.ExpertCommissionId == expertCommissionId);

            if(expertCommission == null)
            {
                return null;
            }

            dbContext.ExpertCommissions.Remove(expertCommission);
            await dbContext.SaveChangesAsync();
            return expertCommission;
        }

        public async Task<ExpertCommission> UpdateAsync(Guid expertCommissionId, ExpertCommission expertCommission)
        {
            var existingExpertComm = await dbContext.ExpertCommissions.FindAsync(expertCommissionId);

            if(existingExpertComm == null)
            {
                return null;
            }

            existingExpertComm.ExpertCommissionName = expertCommission.ExpertCommissionName;
            existingExpertComm.PresidentName = expertCommission.PresidentName;
            existingExpertComm.NumberOfMembers = expertCommission.NumberOfMembers;

            await dbContext.SaveChangesAsync();
            return existingExpertComm;



            

        }
    }
}
