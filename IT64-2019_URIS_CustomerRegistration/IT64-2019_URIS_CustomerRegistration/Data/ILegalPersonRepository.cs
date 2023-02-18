using IT64_2019_URIS_CustomerRegistration.Entities;

namespace IT64_2019_URIS_CustomerRegistration.Data
{
    public interface ILegalPersonRepository
    {
        Task<IEnumerable<LegalPerson>> GetAllAsync();
        Task<LegalPerson> GetAsync(Guid legalPersonId);
        Task<LegalPerson> AddAsync(LegalPerson legalPerson);
        Task<LegalPerson> UpdateAsync(Guid legalPersonId,LegalPerson legalPerson);
        Task<LegalPerson> DeleteAsync(Guid legalPersonId);

    }
}
