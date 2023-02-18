using URIS_BiddingProcess_it24.Models.entity;

namespace URIS_BiddingProcess_it24.Repositories
{
    public interface IPublicBiddingRepository
    {
        public Task<IEnumerable<PublicBidding>> GetAllAsync();
        Task<PublicBidding> GetByIdAsync(Guid id);

        Task<PublicBidding> AddAsync(PublicBidding publicBidding);

        Task<PublicBidding> UpdateAsync(Guid id, PublicBidding publicBidding);
        Task<PublicBidding> DeleteAsync(Guid id);
    }
}
