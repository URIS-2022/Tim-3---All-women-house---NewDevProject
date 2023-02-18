using Korisnik_projekat.Models.User;

namespace Korisnik_projekat.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> GetAsync(Guid id);

        Task<User> AddAsync(User user);

        Task<User> DeleteAsync(Guid id);

        Task<User> UpdateAsync(Guid id, User user);
    }
}
