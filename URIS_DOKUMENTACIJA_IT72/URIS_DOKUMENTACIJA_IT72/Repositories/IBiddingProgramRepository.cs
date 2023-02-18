using URIS_DOKUMENTACIJA_IT72.Models.Domain;

namespace URIS_DOKUMENTACIJA_IT72.Repositories
{
    public interface IBiddingProgramRepository
    {
        Task<IEnumerable<BiddingProgram>> GetAllAsync();

        Task<BiddingProgram> GetAsync(Guid id);


        Task<BiddingProgram> AddAsync(BiddingProgram biddingProgram);

        Task<BiddingProgram> DeleteAsync(Guid id);

        Task<BiddingProgram> UpdateAsync(Guid id, BiddingProgram biddingProgram);
    }
}
