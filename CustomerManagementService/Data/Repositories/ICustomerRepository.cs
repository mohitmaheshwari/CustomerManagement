using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CustomerManagementService.Model;

namespace CustomerManagementService.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomersAsync();

        Task<List<Customer>> GetCustomersAsync(Expression<Func<Customer, bool>> expression);

        Task<Customer> AddCustomerAsync(Customer customer);
    }
}