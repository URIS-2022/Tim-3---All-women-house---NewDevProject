using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Registration_projekat.Models;
using System.Xml;

namespace Registration_projekat.Data
{
    public class RegistrationDBContext : DbContext
    {
        public RegistrationDBContext(DbContextOptions<RegistrationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                 .HasOne(x => x.Role)
                 .WithMany(y => y.UserRoles)
                 .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.UserId);
        }


        public DbSet<Registration> Registrations { get; set; }

        public DbSet<RegistrationForm> RegistrationForms { get; set; }


        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> Users_Roles { get; set; }

    }
}
