using URIS_ProtectedZone_IT67_2019.Entities;

namespace URIS_ProtectedZone_IT67_2019.Repositories
{
    public interface IProtectedZoneRepository
    {
        Task<IEnumerable<ProtectedZone>> GetAllProtectedZones();
        Task<ProtectedZone> GetProtectedZone(Guid ProtectedZoneId);
        Task<ProtectedZone> AddProtectedZone(ProtectedZone protectedZone);
        Task<ProtectedZone> UpdateProtectedZone(Guid ProtectedZoneId, ProtectedZone protectedZone);
        Task<ProtectedZone> DeleteProtectedZone(Guid ProtectedZoneId);
    }
}
