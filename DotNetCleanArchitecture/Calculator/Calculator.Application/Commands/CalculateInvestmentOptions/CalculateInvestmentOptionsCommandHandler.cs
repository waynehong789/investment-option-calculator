using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Application.Models;
using Microsoft.Extensions.Configuration;
using System.Net;
using Calculator.Core.Functions;
using Calculator.Application.Services;

namespace Calculator.Application.Commands.CalculateInvestmentOptions
{
    public class CalculateInvestmentOptionsCommandHandler : IRequestHandler<CalculateInvestmentOptionsCommand, Result<CalculateInvestmentOptionsViewModel>>
    {
        private readonly IExchangeRateService _exchangeRateService;
        private readonly IConfiguration _config;
        private readonly ILogger<CalculateInvestmentOptionsCommandHandler> _logger;

        public CalculateInvestmentOptionsCommandHandler(

            IExchangeRateService exchangeRateService,
            IConfiguration config,
            ILogger<CalculateInvestmentOptionsCommandHandler> logger
        )
        {
            _exchangeRateService = exchangeRateService;
            _config = config;
            _logger = logger;
        }

        public async Task<Result<CalculateInvestmentOptionsViewModel>> Handle(CalculateInvestmentOptionsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                double investmentReturn = 0;
                double fees = 0;

                // Calculate ROI and Fee for each investment option
                foreach (var selectedOption in request.SelectedOptions)
                {
                    var result = CalculateInvestment.Execute((request.InvestmentAmount * selectedOption.Percentage / 100), selectedOption.Option.Value, selectedOption.Percentage);
                    investmentReturn += result.ROI;
                    fees += result.Fee;
                }

                // Convert total Fees from AUD to USD
                var usdFees = await _exchangeRateService.ConvertAudToUsd(fees);

                return new Result<CalculateInvestmentOptionsViewModel>(new CalculateInvestmentOptionsViewModel(Math.Round(investmentReturn, 2), Math.Round(usdFees, 2)))
                {
                    Success = true,
                    StatusCode = Convert.ToInt32(HttpStatusCode.OK),
                    Message = Convert.ToString(HttpStatusCode.OK)
                };
            }
            catch (Exception e)
            {
                _logger.LogError($"[x] CalculateInvestmentOptionsCommandHandler: {e.ToString()}");
                throw;
            }
        }
    }
}