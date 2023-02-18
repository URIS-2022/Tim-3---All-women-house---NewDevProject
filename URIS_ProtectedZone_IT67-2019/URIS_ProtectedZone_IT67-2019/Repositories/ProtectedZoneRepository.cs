using Microsoft.EntityFrameworkCore;
using URIS_ProtectedZone_IT67_2019.Data;
using URIS_ProtectedZone_IT67_2019.Entities;

namespace URIS_ProtectedZone_IT67_2019.Repositories
{
    public class ProtectedZoneRepository : IProtectedZoneRepository
    {
        private readonly ProtectedZoneDbContext protectedZoneDbContext;

        public ProtectedZoneRepository(ProtectedZoneDbContext protectedZoneDbContext)
        {
            this.protectedZoneDbContext = protectedZoneDbContext;
        }

        public async Task<ProtectedZone> AddProtectedZone(ProtectedZone protectedZone)
        {
            protectedZone.ProtectedZoneId = Guid.NewGuid();
            await protectedZoneDbContext.ProtectedZones.AddAsync(protectedZone);
            await protectedZoneDbContext.SaveChangesAsync();
            return protectedZone;
        }

        public async Task<ProtectedZone> DeleteProtectedZone(Guid ProtectedZoneId)
        {
            var existingProtectedZone = await protectedZoneDbContext.ProtectedZones.FindAsync(ProtectedZoneId);
            if (existingProtectedZone == null)
            {
                return null;
            }
            protectedZoneDbContext.ProtectedZones.Remove(existingProtectedZone);
            await protectedZoneDbContext.SaveChangesAsync();
            return existingProtectedZone;
        }

        public async Task<IEnumerable<ProtectedZone>> GetAllProtectedZones()
        {
            return await protectedZoneDbContext.ProtectedZones.ToListAsync();
        }

        public async Task<ProtectedZone> GetProtectedZone(Guid ProtectedZoneId)
        {
            return await protectedZoneDbContext.ProtectedZones.FirstOrDefaultAsync(x => x.ProtectedZoneId == ProtectedZoneId);
        }

        public async Task<ProtectedZone> UpdateProtectedZone(Guid ProtectedZoneId, ProtectedZone protectedZone)
        {
            var existingProtectedZone = await protectedZoneDbContext.ProtectedZones.FindAsync(ProtectedZoneId);
            if(existingProtectedZone == null)
            {
                return null;
            }
            existingProtectedZone.NumberOfZone = protectedZone.NumberOfZone;
            existingProtectedZone.PermittedWorks = protectedZone.PermittedWorks;
            await protectedZoneDbContext.SaveChangesAsync();
            return existingProtectedZone;
        }
    }
}
