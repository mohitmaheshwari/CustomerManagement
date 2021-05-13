namespace CustomerManagementService.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersAsync();

        Task<List<Customer>> GetCustomersAsync(Expression<Func<Customer, bool>> expression);

        Task<Customer> AddCustomerAsync(Customer customer);
    }
}