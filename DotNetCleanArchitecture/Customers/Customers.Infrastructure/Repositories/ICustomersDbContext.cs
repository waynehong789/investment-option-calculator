using Customers.Core.Aggregates;
using MongoDB.Driver;

namespace Customers.Infrastructure.Repositories
{
    public interface ICustomerDbContext
    {
        IMongoCollection<Customer> CustomersCollection { get; }
    }
}
