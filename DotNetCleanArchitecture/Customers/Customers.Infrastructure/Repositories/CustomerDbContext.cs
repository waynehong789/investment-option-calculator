using Customers.Core.Aggregates;
using MongoDB.Driver;

namespace Customers.Infrastructure.Repositories
{
    public class CustomerDbContext : ICustomerDbContext
    {
        private readonly IMongoDatabase _database = null;
        private readonly string _CustomersCollection = "Customers";

        public CustomerDbContext(IMongoDatabase database)
        {
            _database = database;
        }

        public IMongoCollection<Customer> CustomersCollection
        {
            get
            {
                return _database.GetCollection<Customer>(_CustomersCollection);
            }
        }
    }
}
