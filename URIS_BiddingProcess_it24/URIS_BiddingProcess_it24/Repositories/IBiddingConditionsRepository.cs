using URIS_BiddingProcess_it24.Models.entity;

namespace URIS_BiddingProcess_it24.Repositories
{
    public interface IBiddingConditionsRepository
    {
        Task<IEnumerable<BiddingConditions>> GetAllAsync();
        Task<BiddingConditions> GetByIdAsync(Guid id);

        Task<BiddingConditions> AddAsync(BiddingConditions condition);

        Task<BiddingConditions> UpdateAsync(Guid id, BiddingConditions condition);
        Task<BiddingConditions> DeleteAsync(Guid id);
    }
}
