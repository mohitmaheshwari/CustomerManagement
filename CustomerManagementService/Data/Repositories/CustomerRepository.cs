using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CustomerManagementService.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementService.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await FindAll()
                .Include(x => x.Addresses)
                .ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersAsync(Expression<Func<Customer, bool>> expression)
        {
            return await FindByCondition(expression)
                .Include(x => x.Addresses)
                .ToListAsync();
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            return await Create(customer);
        }
    }
}
