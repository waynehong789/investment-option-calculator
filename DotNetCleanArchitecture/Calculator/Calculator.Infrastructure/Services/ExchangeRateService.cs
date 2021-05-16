using System;
using System.Net.Http;
using System.Threading.Tasks;
using Calculator.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Calculator.Infrastructure.Services
{

    public class ExchangeRateService : IExchangeRateService
    {
        private class ConvertResponse
        {
            public bool Success { get; set; }
            public QueryDeatils Query { get; set; }
            public InfoDetails Info { get; set; }
            public string Historical { get; set; }
            public string Date { get; set; }
            public double Result { get; set; }
            public class QueryDeatils
            {
                public string From { get; set; }
                public string To { get; set; }
                public double Amount { get; set; }
            }
            public class InfoDetails
            {
                public int timestamp { get; set; }
                public string rate { get; set; }
            }
        }
        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly ILogger<ExchangeRateService> _logger;

        public ExchangeRateService(
            IConfiguration config,
            ILogger<ExchangeRateService> logger
            )
        {
            _client = new HttpClient();
            _config = config;
            _logger = logger;
        }
        public async Task<double> ConvertAudToUsd(double amountToBeConvert)
        {
            try
            {
                _logger.LogInformation($" [ExchangeRateService] ConvertAudToUsd: Starting convert AUD to USD for amount {amountToBeConvert}");

                var url = ($"{_config.GetSection("Http:ExchangeRateApiBaseAddress").Value}/v1/convert?access_key={_config.GetSection("Http:ExchangeRateApiKey").Value}&from=AUD&to=USD&amount={amountToBeConvert}");
                var response = await _client.GetAsync(url);
                string jsonStr = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ConvertResponse>(jsonStr);
                if (result.Success)
                {
                    return result.Result;
                }
                else
                {
                    return amountToBeConvert * 0.78;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($" [ExchangeRateService] ConvertAudToUsd: Converting AUD to USD for amount {amountToBeConvert} failed: {ex.ToString()}");
                throw;
            }

        }
    }
}