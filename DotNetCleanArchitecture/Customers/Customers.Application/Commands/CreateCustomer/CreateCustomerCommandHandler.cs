using System;
using System.Threading;
using System.Threading.Tasks;
using Customers.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Application.Models;
using Microsoft.Extensions.Configuration;
using System.Net;
using Customers.Core.Aggregates;

namespace Customers.Application.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Result<CreateCustomerViewModel>>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IConfiguration _config;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;

        public CreateCustomerCommandHandler(

            ICustomersRepository customersRepository,
            IConfiguration config,
            ILogger<CreateCustomerCommandHandler> logger
        )
        {
            _customersRepository = customersRepository;
            _config = config;
            _logger = logger;
        }

        public async Task<Result<CreateCustomerViewModel>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newCustomer = new Customer(request.FirstName, request.LastName);
                
                await _customersRepository.CreateAsync(newCustomer);
                
                return new Result<CreateCustomerViewModel>(new CreateCustomerViewModel(newCustomer.FirstName, newCustomer.LastName))
                {
                    Success = true,
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    Message = Convert.ToString(HttpStatusCode.OK)
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"[x] CreateCustomerCommandHandler: {e.ToString()}");
                throw;
            }
        }
    }
}