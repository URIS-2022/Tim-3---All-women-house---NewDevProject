using URIS_DOKUMENTACIJA_IT72.Models.Domain;

namespace URIS_DOKUMENTACIJA_IT72.Repositories
{
    public interface IDecisionRepository
    {
        Task<IEnumerable<Decision>> GetAllAsync();

        Task<Decision> GetAsync(Guid id);


        Task<Decision> AddAsync(Decision decision);

        Task<Decision> DeleteAsync(Guid id);

        Task<Decision> UpdateAsync(Guid id,  Decision decision);
    }
}
