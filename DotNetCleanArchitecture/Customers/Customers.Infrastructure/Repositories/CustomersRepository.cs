using Customers.Core.Aggregates;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.Infrastructure.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly ICustomerDbContext _context = null;

        public CustomersRepository(ICustomerDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Customer customer)
        {
            await _context.CustomersCollection.InsertOneAsync(customer);
        }

        public async Task<Customer> GetCustomerAsync(Guid customerID)
        {
            return await _context.CustomersCollection.Find(x => x.ID == customerID).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            ReplaceOneResult updateResult =
                await _context
                        .CustomersCollection
                        .ReplaceOneAsync(
                            filter: x => x.ID == customer.ID,
                            replacement: customer);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
