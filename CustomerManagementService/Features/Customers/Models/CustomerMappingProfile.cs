using AutoMapper;
using CustomerManagementService.Model;

namespace CustomerManagementService.Features.Customers.Models
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CustomerCreateCommand, Customer>();
            CreateMap<CreateAddressCommand, Address>();
        }
    }
}
