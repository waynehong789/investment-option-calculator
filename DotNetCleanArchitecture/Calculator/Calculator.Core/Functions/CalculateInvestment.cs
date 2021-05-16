using Calculator.Core.Constants;
using Calculator.Core.Entities;

namespace Calculator.Core.Functions
{
    public static class CalculateInvestment
    {
        public static InvestmentCalculatedResult Execute(double investmentAmount, string investmentOption, double percentage)
        {
            var result = new InvestmentCalculatedResult();

            switch (investmentOption)
            {
                case InvestmentOptionType.Cash_Investments:
                    if (percentage <= 50)
                    {
                        var roi1 = investmentAmount * 0.085;
                        result.ROI = roi1;
                        result.Fee = roi1 * 0.005;
                    }
                    else if (percentage > 50)
                    {
                        var roi2 = investmentAmount * 0.01;
                        result.ROI = roi2;
                        result.Fee = 0;
                    }

                    return result;
                case InvestmentOptionType.Fixed_Interest:
                    var roi3 = investmentAmount * 0.01;
                    result.ROI = roi3;
                    result.Fee = roi3 * 0.01;
                    return result;
                case InvestmentOptionType.Shares:
                    if (percentage <= 70)
                    {
                        var roi4 = investmentAmount * 0.043;
                        result.ROI = roi4;
                        result.Fee = roi4 * 0.025;
                    }
                    else if (percentage > 70)
                    {
                        var roi5 = investmentAmount * 0.06;
                        result.ROI = roi5;
                        result.Fee = roi5 * 0.025;
                    }
                    return result;
                case InvestmentOptionType.Managed_Funds:
                    var roi6 = investmentAmount * 0.12;
                    result.ROI = roi6;
                    result.Fee = roi6 * 0.003;
                    return result;
                case InvestmentOptionType.Exchange_Traded_Funds:
                    var roi7 = investmentAmount * 0.128;
                    result.ROI = roi7;
                    result.Fee = roi7 * 0.02;
                    return result;
                case InvestmentOptionType.Investment_Bonds:
                    var roi8 = investmentAmount * 0.08;
                    result.ROI = roi8;
                    result.Fee = roi8 * 0.009;
                    return result;
                case InvestmentOptionType.Annuities:
                    var roi9 = investmentAmount * 0.04;
                    result.ROI = roi9;
                    result.Fee = roi9 * 0.014;
                    return result;
                case InvestmentOptionType.Listed_Investment_Companies:
                    var roi10 = investmentAmount * 0.06;
                    result.ROI = roi10;
                    result.Fee = 0.013;
                    return result;
                case InvestmentOptionType.Real_Estate_Investment_Trusts:
                    var roi11 = investmentAmount * 0.04;
                    result.ROI = roi11;
                    result.Fee = roi11 * 0.02;
                    return result;

                default:
                    return result;
            }
        }
    }
}
