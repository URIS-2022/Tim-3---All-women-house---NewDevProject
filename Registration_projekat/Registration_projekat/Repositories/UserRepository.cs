using Microsoft.EntityFrameworkCore;
using Registration_projekat.Data;
using Registration_projekat.Models;

namespace Registration_projekat.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RegistrationDBContext registrationDBContext;
        public UserRepository(RegistrationDBContext registrationDBContext)
        {
            this.registrationDBContext = registrationDBContext;
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
           var user = await registrationDBContext.Users
                .FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower() && x.Password == password); 

            if(user == null)
            {
                return null;
            }

            var userRoles = await registrationDBContext.Users_Roles.Where(x => x.UserId == user.UserId).ToListAsync();

            if(userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                  var role = await registrationDBContext.Roles.FirstOrDefaultAsync(x => x.RoleId == userRole.RoleId);
                  if (role != null)
                  {
                        user.Roles.Add(role.Name);

                  }
                }
            }

            user.Password = null;
            return user;
        }
    }
}
