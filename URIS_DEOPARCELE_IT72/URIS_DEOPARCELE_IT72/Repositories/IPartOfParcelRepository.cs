using URIS_DEOPARCELE_IT72.Models.Domain;

namespace URIS_DEOPARCELE_IT72.Repositories
{
    public interface IPartOfParcelRepository
    {


        Task<IEnumerable<PartOfParcel>> GetAllAsync();

        Task<PartOfParcel> GetAsync(Guid id);


        Task<PartOfParcel> AddAsync(PartOfParcel partOfParcel);

        Task<PartOfParcel> DeleteAsync(Guid id);

        Task<PartOfParcel> UpdateAsync(Guid id,PartOfParcel partOfParcel);

    }
}
