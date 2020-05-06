using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorBackend
{
    public class Memory
    {
        public decimal Value { get; private set; }        

        public void MemoryAdd(decimal value)
        {
            this.Value += value;
        }
    
        public void MemorySubtract(decimal value)
        {
            this.Value -= value; 
        }

        public void MemorySave(decimal value)
        {
            this.Value = value;
        }

        public void MemoryClear()
        {

            this.Value = 0;
        }
    }
}