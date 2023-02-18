using IT64_2019_URIS_CustomerRegistration.Entities;

namespace IT64_2019_URIS_CustomerRegistration.Data
{
    public interface INaturalPersonRepository
    {
        Task<IEnumerable<NaturalPerson>> GetAllAsync();
        Task<NaturalPerson> GetAsync(Guid naturalPersonId);
        Task<NaturalPerson> AddAsync(NaturalPerson naturalPerson);
        Task<NaturalPerson> UpdateAsync(Guid naturalPersonId, NaturalPerson naturalPerson);
        Task<NaturalPerson> DeleteAsync(Guid naturalPersonId);

    }
}
