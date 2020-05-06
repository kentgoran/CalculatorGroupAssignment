using System;
using System.Collections.Generic;

namespace CalculatorBackend
{
    public class Calculator
    {
        public string CurrentCalc { get; set; }
        public List<Number> HistoryCalc { get; set; }

        public void ClearCurrent()
        {
            CurrentCalc = "0";
        }
        public void ClearEverything()
        {
            this.ClearCurrent();
            HistoryCalc.Clear();
        }

        public bool Addition()
        {
            bool success = Decimal.TryParse(CurrentCalc, out decimal valueToInput);
            if (success)
            {
                CurrentCalc = "0";
                HistoryCalc.Add(new Number(valueToInput, Operator.Addition));
                return true;
            }
            return false;
        }
    }
}