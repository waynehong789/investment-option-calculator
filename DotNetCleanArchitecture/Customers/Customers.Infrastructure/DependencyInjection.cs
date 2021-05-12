using Customers.Core.Aggregates;
using Customers.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using Shared.Infrastructure.Serializers;

namespace Customers.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomersInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Repositories
            services.AddTransient<ICustomerDbContext, CustomerDbContext>();
            services.AddTransient<ICustomersRepository, CustomersRepository>();

            BsonClassMap.RegisterClassMap<Customer>(cm =>
            {
                cm.AutoMap();
                cm.MapIdMember(c => c.ID).SetIdGenerator(GuidGenerator.Instance); //[BsonId]
                cm.MapMember(c => c.CreatedDateUtc).SetSerializer(new DateTimeNullableSerializer(BsonType.DateTime)); // [BsonRepresentation(BsonType.DateTime)]
            });

            return services;
        }
    }
}