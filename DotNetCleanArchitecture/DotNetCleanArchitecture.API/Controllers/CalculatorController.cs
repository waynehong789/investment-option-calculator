using Calculator.Application.Commands.CalculateInvestmentOptions;
using DotNetCleanArchitecture.API.Functions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DotNetCleanArchitecture.API.Controllers
{
    [ApiController]
    [Route("api/Calculator")]
    public class CalculatorController : BaseController
    {
        public CalculatorController(IMediator mediator, ILogger<CalculatorController> logger) : base(mediator, logger)
        {
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> CalculateInvestmentOptions([FromBody] CalculateInvestmentOptionsCommand command) => await HandleControllerAction.Execute(this, command);
    }
}
