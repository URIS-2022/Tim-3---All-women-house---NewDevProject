using IT64_2019_URIS_CustomerRegistration.Entities;

namespace IT64_2019_URIS_CustomerRegistration.Data
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetAsync(Guid customerId);
        Task<Customer> AddAsync(Customer customer);
        Task<Customer> DeleteAsync(Guid customerId);
        Task<Customer> UpdateAsync(Guid customerId, Customer customer);


    }
}
