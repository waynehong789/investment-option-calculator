using System;
using System.Collections.Generic;
using Calculator.Core.Entities;
using Shared.Application.Models;

namespace Calculator.Application.Commands.CalculateInvestmentOptions
{
    public class CalculateInvestmentOptionsCommand : AuthRequest<CalculateInvestmentOptionsViewModel>
    {
        public double InvestmentAmount { get; set; }
        public List<InvestmentOption> SelectedOptions { get; set; }

    }
}