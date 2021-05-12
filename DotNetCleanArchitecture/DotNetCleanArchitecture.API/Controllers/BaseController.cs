
using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetCleanArchitecture.API.Controllers
{

    public abstract class BaseController : Controller
    {
        public readonly IMediator _mediator;
        public readonly ILogger<BaseController> _logger;

        public BaseController(IMediator mediator, ILogger<BaseController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}