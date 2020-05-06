using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorBackend;
using System.Collections.Generic;

namespace CalculatorBackendTest
{
    [TestClass]
    public class UnitTestCalc
    {
        private const string ZERO = "0";
        private const string NUMBS = "25";
        private readonly Number expectedNumberAddition = new Number(25m, Operator.Addition);
        private readonly Number expectedNumberSubtraction = new Number(25m, Operator.Subtraction);
        private readonly Number expectedNumberMultiplication = new Number(25m, Operator.Multiplication);
        private readonly Number expectedNumberDivision = new Number(25m, Operator.Division);
        private readonly Number expectedNumberEquals = new Number(25m, Operator.Equals);
        private readonly string expectedResult = "275";
        Calculator calc;

        [TestInitialize]
        public void CalcInit()
        {
            calc = new Calculator
            {
                CurrentCalc = NUMBS,
                HistoryCalc = new List<Number> 
                { 
                    new Number(10m, Operator.Division),
                    new Number(2m, Operator.Subtraction),
                    new Number(1m, Operator.Addition),
                    new Number(7m, Operator.Multiplication)
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
        public void AdditionMethodTest()
        {
            bool success = calc.Addition();
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void AdditionMethodTest_AddsToHistory()
        {
            calc.Addition();
            Assert.AreEqual(expectedNumberAddition, calc.HistoryCalc[calc.HistoryCalc.Count - 1]);
        }

        [TestMethod]
        public void SubstractionMethodTest()
        {
            bool success = calc.Subtraction();
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void SubstractionMethodTest_AddsToHistory()
        {
            calc.Subtraction();
            Assert.AreEqual(expectedNumberSubtraction, calc.HistoryCalc[calc.HistoryCalc.Count - 1]);
        }
        [TestMethod]
        public void MultiplicationMethodTest()
        {
            bool success = calc.Multiplication();
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void MultiplicationMethodTest_AddsToHistory()
        {
            calc.Multiplication();
            Assert.AreEqual(expectedNumberMultiplication, calc.HistoryCalc[calc.HistoryCalc.Count - 1]);
        }
        [TestMethod]
        public void DivisionMethodTest()
        {
            bool success = calc.Division();
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void DivisionMethodTest_AddsToHistory()
        {
            calc.Division();
            Assert.AreEqual(expectedNumberDivision, calc.HistoryCalc[calc.HistoryCalc.Count - 1]);
        }
        [TestMethod]
        public void EqualsMethodTest()
        {
            bool success = calc.Equals();
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void EqualsMethodTest_AddsToHistory()
        {
            calc.Equals();
            Assert.AreEqual(expectedNumberEquals, calc.HistoryCalc[calc.HistoryCalc.Count - 1]);
        }
        [TestMethod]
        public void EqualsMethodTest_PrintsResult()
        {
            calc.Equals();
            Assert.AreEqual(expectedResult, calc.CurrentCalc);
        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void EqualsMethodTest_AttemptToDivideByZero_ThrowsDivideByZeroException()
        {
            calc.Division();
            calc.Equals();

            Assert.Fail();
        }
    }
}
