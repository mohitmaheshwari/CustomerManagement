using MediatR;
using System.Collections.Generic;
using CustomerManagementService.Model;

namespace CustomerManagementService.Features.Customers.Models
{
    public class CustomersQuery : IRequest<List<Customer>>
    {
        public bool? IsActive { get; set; }
    }
}
