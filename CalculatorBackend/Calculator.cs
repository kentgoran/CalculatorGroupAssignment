using System;
using System.Collections.Generic;

namespace CalculatorBackend
{
    public class Calculator
    {
        public string CurrentCalc { get; set; }
        public List<Number> HistoryCalc { get; set; }
        public Memory Mem { get;  }

        public Calculator()
        {
            this.Mem = new Memory();
        }
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

        public bool Subtraction()
        {
            bool success = Decimal.TryParse(CurrentCalc, out decimal valueToInput);
            if (success)
            {
                CurrentCalc = "0";
                HistoryCalc.Add(new Number(valueToInput, Operator.Subtraction));
                return true;
            }
            return false;
        }

        public bool Multiplication()
        {
            bool success = Decimal.TryParse(CurrentCalc, out decimal valueToInput);
            if (success)
            {
                CurrentCalc = "0";
                HistoryCalc.Add(new Number(valueToInput, Operator.Multiplication));
                return true;
            }
            return false;
        }

        public bool Division()
        {
            bool success = Decimal.TryParse(CurrentCalc, out decimal valueToInput);
            if (success)
            {
                CurrentCalc = "0";
                HistoryCalc.Add(new Number(valueToInput, Operator.Division));
                return true;
            }
            return false;
        }

        public bool Equals()
        {
            bool success = Decimal.TryParse(CurrentCalc, out decimal valueToInput);
            if (success)
            {
                HistoryCalc.Add(new Number(valueToInput, Operator.Equals));
                CurrentCalc = this.CalculateHistory();
                return true;
            }
            return false;
        }

        private string CalculateHistory()
        {
            decimal totalValue = 0;
            //Initial set to Addition, as to add the first value to totalValue, before starting to calculate the rest
            Operator nextOperator = Operator.Addition;
            foreach (var num in HistoryCalc)
            {
                switch (nextOperator)
                {
                    case Operator.Addition:
                        totalValue += num.value;
                        break;
                    case Operator.Subtraction:
                        totalValue -= num.value;
                        break;
                    case Operator.Division:
                        if(num.value != 0)
                        {
                            totalValue /= num.value;
                        }
                        else
                        {
                            throw new DivideByZeroException("Can't divide by zero");
                        }
                        break;
                    case Operator.Multiplication:
                        totalValue *= num.value;
                        break;
                    case Operator.Equals:
                        //End of the list
                        break;
                    default:
                        break;
                }
                nextOperator = num.calcOperator;
            }
            return totalValue.ToString();

        }

        public bool MemoryAdd()
        {
            bool success = decimal.TryParse(this.CurrentCalc, out decimal deciValue);
            if (success)
            {
                Mem.MemoryAdd(deciValue);
            }
            return success;
        }
        public bool MemorySubtract()
        {
            bool success = decimal.TryParse(this.CurrentCalc, out decimal deciValue);
            if (success)
            {
                Mem.MemorySubtract(deciValue);
            }
            return success;
        }
        public void MemoryRead()
        {
            this.CurrentCalc = this.Mem.Value.ToString();
        }
        public bool MemorySave()
        {
            bool success = decimal.TryParse(this.CurrentCalc, out decimal deciValue);
            if (success)
            {
                Mem.MemorySave(deciValue);
            }
            return success;
        }
    }
}