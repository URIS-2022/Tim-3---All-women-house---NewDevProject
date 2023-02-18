using URIS_OGLAS_IT72.Models.Domain;

namespace URIS_OGLAS_IT72.Repositories
{
    public interface IDecisionOfAdvertismentRepository
    {

        Task<IEnumerable<DecisionOfAdvertisment>> GetAllAsync();

        Task<DecisionOfAdvertisment> GetAsync(Guid id);


        Task<DecisionOfAdvertisment> AddAsync(DecisionOfAdvertisment decisionOfAdvertisment);

        Task<DecisionOfAdvertisment> DeleteAsync(Guid id);

        Task<DecisionOfAdvertisment> UpdateAsync(Guid id, DecisionOfAdvertisment decisionOfAdvertisment);
    }
}
