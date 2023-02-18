using URIS_BiddingProcess_it24.Models.entity;

namespace URIS_BiddingProcess_it24.Repositories
{
    public interface IBiddingRepository
    {
        Task<IEnumerable<Bidding>> GetAllAsync();

        Task<Bidding> GetByIdAsync(Guid id);

        Task<Bidding> AddAsync(Bidding bidding);

        Task<Bidding> DeleteAsync(Guid id);

        Task<Bidding> UpdateAsync(Guid id, Bidding bidding);
    }
}
