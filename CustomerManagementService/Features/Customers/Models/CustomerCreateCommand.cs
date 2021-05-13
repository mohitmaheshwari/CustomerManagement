using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CustomerManagementService.Model;
using MediatR;

namespace CustomerManagementService.Features.Customers.Models
{
    public class CustomerCreateCommand : IRequest<Customer>
    {
        [Required]
        [MaxLength(9)]
        public string Title { get; set; }

        [Required]
        public string Forename { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public string MobileNo { get; set; }

        public bool IsActive { get; set; }

        public List<CreateAddressCommand> Addresses { get; set; }
    }
}
