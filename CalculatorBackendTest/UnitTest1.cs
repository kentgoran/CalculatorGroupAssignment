using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorBackend;
using System.Collections.Generic;

namespace CalculatorBackendTest
{
    [TestClass]
    public class UnitTest1
    {
        private const string ZERO = "0";
        private const string NUMBS = "25472";
        private readonly Number expectedNumberAddition = new Number(25472m, Operator.Addition);
        Calculator calc;
        [TestInitialize]
        public void CalcInit()
        {
            calc = new Calculator
            {
                CurrentCalc = NUMBS,
                HistoryCalc = new List<Number> 
                { 
                    new Number(23, Operator.Division),
                    new Number(18.7m, Operator.Subtraction),
                    new Number(1.1m, Operator.Addition)
                }
            };
        }

        [TestMethod]
        public void ClearCurrent_ClearsInput()
        {
            calc.ClearCurrent();
            
            Assert.AreEqual(ZERO, calc.CurrentCalc);
        }

        [TestMethod]
        public void ClearEverything_ClearsInput()
        {
            calc.ClearEverything();

            Assert.AreEqual(ZERO, calc.CurrentCalc);
        }

        [TestMethod]
        public void ClearEverything_ClearsHistory()
        {
            calc.ClearEverything();

            Assert.AreEqual(0, calc.HistoryCalc.Count);
        }

        [TestMethod]
        public void CalculatorAddMethodTest()
        {
            bool success = calc.Addition();
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void CalculatorAddMethodTest_AddsToHistory()
        {

            calc.Addition();

            Assert.AreEqual(expectedNumberAddition, calc.HistoryCalc[calc.HistoryCalc.Count - 1]);
        }
        //
        //   [TestMethod]
        //   public void CalculatorSubstractMethodTest()
        //   {
        //       Calculator calculator = new Calculator();
        //       bool success = calculator.Subtraction();
        //       Assert.Istrue(success);
        //
        //       Asser.AreEqual(new List<Number> {});
        //
        //   }
        //
        //   [TestMethod]
        //   public void CalculatorMultiplicationMethodTest()
        //   {
        //       Calculator calculator = new Calculator();
        //       bool success = calculator.Multiplication();
        //
        //       Assert.IsTrue(success);
        //   }
        //
        //   [TestMethod]
        //   public void CalculatorDivisionMethodTest()
        //   {
        //       Calculator calculator = new Calculator();
        //       bool success = calculator.Division();
        //
        //       Assert.IsTrue(success);
        //   }


    }
}
