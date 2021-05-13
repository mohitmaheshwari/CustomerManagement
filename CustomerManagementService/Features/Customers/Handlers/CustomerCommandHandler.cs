using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagementService.Data.Repositories;
using CustomerManagementService.Features.Customers.Models;
using CustomerManagementService.Model;
using MediatR;

namespace CustomerManagementService.Features.Customers.Handlers
{
    public class CustomerCommandHandler : IRequestHandler<CustomerCreateCommand, Customer>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerCommandHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Customer> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<Customer>(request);

            return await _repository.AddCustomerAsync(customer);
        }
    }
}
