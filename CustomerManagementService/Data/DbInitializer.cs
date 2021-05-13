using System.Collections.Generic;
using System.Linq;
using CustomerManagementService.Model;

namespace CustomerManagementService.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Customers.Any())
            {

                context.AddRange(
                    new Customer {
                        Title = "Mr",
                        Forename = "Jon",
                        Surname = "Smith",
                        EmailAddress = "jon@gmail.com",
                        IsActive = true,
                        Addresses = new List<Address>()
                        {
                            new Address
                            {
                                AddressLine1="123 New Road",
                                Town="Leeds",
                                County="West Yorkshire",
                                Postcode="LS1",
                                IsMainAddress = true
                            },
                            new Address
                            {
                                AddressLine1="Flat 1",
                                AddressLine2="456 Park Road",
                                Town="Leeds",
                                County="West Yorkshire",
                                Postcode="LS1",
                                IsMainAddress = false
                            }
                        }
                        
                    },
                    new Customer
                    {
                        Title = "Mrs",
                        Forename = "Jill",
                        Surname = "Smith",
                        EmailAddress = "jill@gmail.com",
                        IsActive = false,
                        Addresses = new List<Address>()
                        {
                            new Address
                            {
                                AddressLine1="123 Old Road",
                                Town="Manchester",
                                County="Lancashire",
                                Postcode="M1",
                                IsMainAddress = true
                            }
                        }
                    });
            }

            context.SaveChanges();
        }
    }
}
