using Registration_projekat.Models;

namespace Registration_projekat.Repositories
{
    public interface IRegistrationFormRepository
    {
        Task<IEnumerable<RegistrationForm>> GetAllAsync();
        Task<RegistrationForm> GetAsync(Guid id);
        Task<RegistrationForm> AddAsync(RegistrationForm registrationForm);

        Task<RegistrationForm> UpdateAsync(Guid id, RegistrationForm registrationForm);

        Task<RegistrationForm> DeleteAsync(Guid id);
    }
}
