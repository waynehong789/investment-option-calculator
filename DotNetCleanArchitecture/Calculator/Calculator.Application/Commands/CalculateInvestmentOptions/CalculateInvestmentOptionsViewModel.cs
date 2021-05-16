using System;

namespace Calculator.Application.Commands.CalculateInvestmentOptions
{
    public class CalculateInvestmentOptionsViewModel
    {
        public double InvestmentReturn { get; set; }
        public double Fees { get; set; }

        public CalculateInvestmentOptionsViewModel(double investmentReturn, double fees)
        {
            InvestmentReturn = investmentReturn;
            Fees = fees;
        }
    }

}