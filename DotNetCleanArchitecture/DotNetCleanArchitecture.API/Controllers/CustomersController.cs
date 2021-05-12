using Customers.Application.Commands.CreateCustomer;
using DotNetCleanArchitecture.API.Functions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController : BaseController
    {
        public CustomersController(IMediator mediator, ILogger<CustomersController> logger): base(mediator, logger)
        {
        }

        [HttpPost]
        public async Task<JsonResult> CreateCustomer([FromBody]CreateCustomerCommand command) => await HandleControllerAction.Execute(this, command);
    }
}
