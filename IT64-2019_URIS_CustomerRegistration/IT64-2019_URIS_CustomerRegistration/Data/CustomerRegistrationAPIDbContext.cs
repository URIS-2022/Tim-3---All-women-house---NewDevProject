using IT64_2019_URIS_CustomerRegistration.Entities;
using Microsoft.EntityFrameworkCore;

namespace IT64_2019_URIS_CustomerRegistration.Data
{
    public class CustomerRegistrationAPIDbContext : DbContext
    {
        public CustomerRegistrationAPIDbContext(DbContextOptions<CustomerRegistrationAPIDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<NaturalPerson> NaturalPersons { get; set;}
        public DbSet<LegalPerson> LegalPersons { get; set; }
    }
}
