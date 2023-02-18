using Registration_projekat.Models;

namespace Registration_projekat.Repositories
{
    public class StaticUserRepository: IUserRepository
    {
        private List<User> Users = new List<User>()
        {
            //new User()
            //    Name = "Milan", Surname = "Nikolic", Email = "milannikolic@gmail.com",
            //    UserId = Guid.NewGuid(), Username = "MilanNikolic", Password = "milannikolic123",
            //    Roles = new List<string> {"operater"}
            //},
            // new User()
            //{
            //    Name = "Milos", Surname = "Milosevic", Email = "milosmilosevic@gmail.com",
            //    UserId = Guid.NewGuid(), Username = "milosmilosevic1", Password = "milos12345",
            //    Roles = new List<string> {"tehnicki_sekretar"}
            //},
            //  new User()
            //{
            //    Name = "Marija", Surname = "Mikic", Email = "marijamikic@gmail.com",
            //    UserId = Guid.NewGuid(), Username = "marijamikic", Password = "marijamikic123",
            //    Roles = new List<string> {"prva_komisija"}
            //},
            //   new User()
            //{
            //    Name = "Jovana", Surname = "Nikolic", Email = "jovananikolic@gmail.com",
            //    UserId = Guid.NewGuid(), Username = "jovananikolic15", Password = "jovana12345",
            //    Roles = new List<string> {"superuser"}
            //},
            //    new User()
            //{
            //    Name = "Stefan", Surname = "Ilic", Email = "stefanilic@gmail.com",
            //    UserId = Guid.NewGuid(), Username = "stefanilic15", Password = "stefanilic15",
            //    Roles = new List<string> {"operater_nadmetanja"}
            //},
            //     new User()
            //{
            //    Name = "Nikola", Surname = "Mitrovic", Email = "nikolamitrovic@gmail.com",
            //    UserId = Guid.NewGuid(), Username = "nikolamitrovic", Password = "nikolamitrovic123",
            //    Roles = new List<string> {"licitant"}
            //},
            // new User()
            //{
            //    Name = "Jelena", Surname = "Stefanovic", Email = "jelenastefanovic@gmail.com",
            //    UserId = Guid.NewGuid(), Username = "Jelena123", Password = "jelenastefanovic123",
            //    Roles = new List<string> {"menadzer"}
            //},
            //  new User()
            //{
            //    Name = "Masa", Surname = "Stekic", Email = "masastekic@gmail.com",
            //    UserId = Guid.NewGuid(), Username = "MasaStekic", Password = "Masastekic123",
            //    Roles = new List<string> {"administrator"}
            //},
            //
        };

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = Users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
            x.Password == password);

            return user;
        }
    }
}
