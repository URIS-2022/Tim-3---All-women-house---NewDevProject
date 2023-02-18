using URIS_BiddingProcess_it24.Models.entity;

namespace URIS_BiddingProcess_it24.Repositories
{
    public interface IOpeningOfBidsRepository
    {
        Task<IEnumerable<OpeningOfBids>> GetAllAsync();

        Task<OpeningOfBids> GetByIdAsync(Guid id);

        Task<OpeningOfBids> AddAsync(OpeningOfBids openingOfBids);

        Task<OpeningOfBids> DeleteAsync(Guid id);

        Task<OpeningOfBids> UpdateAsync(Guid id, OpeningOfBids openingOfBids);
    }
}
