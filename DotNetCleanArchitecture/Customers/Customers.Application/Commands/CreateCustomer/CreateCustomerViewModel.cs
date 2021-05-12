using System;

namespace Customers.Application.Commands.CreateCustomer
{
    public class CreateCustomerViewModel
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}

        public CreateCustomerViewModel(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

}