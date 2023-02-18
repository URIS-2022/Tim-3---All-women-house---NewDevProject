using URIS_Ministry_IT67_2019.Entities;

namespace URIS_Ministry_IT67_2019.Repositories
{
    public interface IMinistryRepository
    {
        Task<IEnumerable<Ministry>> GetAllMinistries();
        Task<Ministry> GetMinistry(Guid MinistryId);
        Task<Ministry> AddMinistry(Ministry ministry);

        Task<Ministry>UpdateMinistry(Guid MinistryId, Ministry ministry);

        Task<Ministry> DeleteMinistry(Guid MinistryId);
    }
}
