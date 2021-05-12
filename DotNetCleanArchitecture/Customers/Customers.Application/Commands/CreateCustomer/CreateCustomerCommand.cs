using System;
using Shared.Application.Models;

namespace Customers.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommand: AuthRequest<CreateCustomerViewModel>
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Phone {get; set;}

    }
}