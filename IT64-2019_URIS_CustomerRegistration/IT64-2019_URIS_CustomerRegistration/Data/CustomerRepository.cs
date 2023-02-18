using IT64_2019_URIS_CustomerRegistration.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace IT64_2019_URIS_CustomerRegistration.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerRegistrationApiDbContext dbContext;
        public CustomerRepository(CustomerRegistrationApiDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

      
        public async Task<Customer> DeleteAsync(Guid customerId)
        {
            var customer = await dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);

            if(customer == null)
            {
                return null;
            }


            dbContext.Customers.Remove(customer);
            await dbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetAsync(Guid customerId)
        {
            return await dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            
        }
        public async Task<Customer> AddAsync(Customer customer)
        {
            customer.CustomerId = Guid.NewGuid();
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();

            return customer;
        }


        public async Task<Customer> UpdateAsync(Guid customerId, Customer customer)
        {
            var existingCustomer = await dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);

            if(customer == null)
            {
                return null;
            }

            existingCustomer.Person = customer.Person;
            existingCustomer.RealizedArea = customer.RealizedArea;
            existingCustomer.AuthorizedPerson = customer.AuthorizedPerson;
            existingCustomer.Payments = customer.Payments;
            existingCustomer.Priority = customer.Priority;
            existingCustomer.Guarantor = customer.Guarantor;

            await dbContext.SaveChangesAsync();

            return existingCustomer;

        }
    }
}
