using Korisnik_projekat.Data;
using Korisnik_projekat.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Korisnik_projekat.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDBContext userDBContext;

        public UserRepository(UserDBContext userDBContext)
        {
            this.userDBContext = userDBContext;
        }

        public async Task<User> AddAsync(User user)
        {
            user.UserId = Guid.NewGuid();
            await userDBContext.AddAsync(user);
            await userDBContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteAsync(Guid id)
        {
            var user = await userDBContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if(user == null)
            {
                return null;
            }

            // Delete the region
            userDBContext.Users.Remove(user);
            await userDBContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await userDBContext.Users.ToListAsync();
        }

        public async Task<User> GetAsync(Guid id)
        {
           return await userDBContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
          
        }

        public async Task<User> UpdateAsync(Guid id, User user)
        {
            var existingUser = await userDBContext.Users.FirstOrDefaultAsync(x => x.UserId == id);

            if(existingUser == null)
            {
                return null;
            }

            existingUser.UserName = user.UserName;
            existingUser.Password = user.Password;
            existingUser.Name = user.Name;
            existingUser.Surname = user.Surname;
            existingUser.Email = user.Email;

            await userDBContext.SaveChangesAsync();

            return existingUser;
        }
    }
}
