using System.Collections.Generic;
using CustomerManagementService.Data.Repositories;
using CustomerManagementService.Features.Customers.Models;
using FluentValidation;
using System.Linq;

namespace CustomerManagementService.Features.Customers.Validators
{
    public class CustomerCreateCommandValidator
    : AbstractValidator<CustomerCreateCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCreateCommandValidator(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

            RuleFor(x => x.Forename)
                .Must(NotExist)
                .WithErrorCode("CustomerAlreadyExists")
                .WithMessage("A customer with this name already exists");

            RuleFor(x => x.Addresses)
                .Must(HaveOneMainAddress)
                .WithMessage("A customer must have one main address");
        }

        private bool NotExist(CustomerCreateCommand command, string forename)
        {
            var customers = _customerRepository.GetCustomersAsync().Result;

            return !customers.Any(
                y => y.Forename == forename 
                     && y.Surname == command.Surname 
                     && y.Title == command.Title);
        }

        private static bool HaveOneMainAddress(List<CreateAddressCommand> addresses)
        {
            return addresses.Count(a => a.IsMainAddress) == 1;
        }
    }
}
