using Microsoft.EntityFrameworkCore;
using Registration_projekat.Models;

namespace Registration_projekat.Repositories
{
    public interface IRegistrationRepository
    {
        Task<IEnumerable<Registration>> GetAllAsync();
        Task<Registration> GetAsync(Guid id);

        Task<Registration> AddAsync(Registration registration);
        Task<Registration> UpdateAsync(Guid id, Registration registration);

        Task<Registration> DeleteAsync(Guid id);
    }
}
