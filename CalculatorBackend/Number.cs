using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorBackend
{
    public class Number
    {
        public decimal value;
        public Operator calcOperator;

        public Number(decimal input, Operator calcOperator)
        {
            this.value = input;
            this.calcOperator = calcOperator;
        }

        public override bool Equals(object obj)
        {
            Number otherNumber = obj as Number;
            if(otherNumber.value == this.value && otherNumber.calcOperator == this.calcOperator)
            {
                return true;
            }
            return false;
        }
    }
}
