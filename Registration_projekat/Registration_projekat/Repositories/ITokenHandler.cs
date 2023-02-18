using Registration_projekat.Models;

namespace Registration_projekat.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
