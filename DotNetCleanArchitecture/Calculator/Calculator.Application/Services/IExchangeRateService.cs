using System.Threading.Tasks;

namespace Calculator.Application.Services
{
    public interface IExchangeRateService
    {
        Task<double> ConvertAudToUsd (double amountToBeConvert);
    }
}