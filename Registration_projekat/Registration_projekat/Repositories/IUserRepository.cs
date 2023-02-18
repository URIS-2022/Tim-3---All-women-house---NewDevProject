using Registration_projekat.Models;

namespace Registration_projekat.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
