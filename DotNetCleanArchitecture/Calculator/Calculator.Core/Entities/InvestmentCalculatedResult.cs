using System;
using System.Text.Json.Serialization;

namespace Calculator.Core.Entities
{
    public class InvestmentCalculatedResult
    {
        public double ROI { get; set; } = 0;
        public double Fee { get; set; } = 0;

    }
}