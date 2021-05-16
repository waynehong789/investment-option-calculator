using System;
using System.Text.Json.Serialization;

namespace Calculator.Core.Entities
{
    public class InvestmentOption
    {
        public OptionDetails Option { get; set; }
        public double Percentage { get; set; }

        public class OptionDetails
        {
            public string Value { get; set; }
            public string Lable { get; set; }
        }
    }
}