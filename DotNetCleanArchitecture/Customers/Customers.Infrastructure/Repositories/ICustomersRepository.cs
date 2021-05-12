
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Customers.Core.Aggregates;

namespace Customers.Infrastructure.Repositories
{
    public interface ICustomersRepository
    {
        Task CreateAsync(Customer customer);

        Task<Customer> GetCustomerAsync(Guid customerID);

        Task<bool> UpdateAsync(Customer Customer);
    }
}
