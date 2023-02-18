using Korisnik_projekat.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Korisnik_projekat.Data
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options): base(options)
        { 
            
        }

        public DbSet<User> Users { get; set; }
    }
}
