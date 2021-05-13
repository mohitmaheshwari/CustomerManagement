using System.ComponentModel.DataAnnotations;

namespace CustomerManagementService.Features.Customers.Models
{
    public class CreateAddressCommand
    {
        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required]
        public string Town { get; set; }

        public string County { get; set; }

        [Required]
        public string Postcode { get; set; }

        public string Country { get; set; }

        public bool IsMainAddress { get; set; }
    }
}
