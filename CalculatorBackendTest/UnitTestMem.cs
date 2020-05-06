using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorBackend;
using System.Collections.Generic;

namespace CalculatorBackendTest
{
    [TestClass]
    public class UnitTestMem
    {
        private Memory mem;
        private const decimal EXPECTEDNUM = 354m;
        private const decimal NUM = 354m;
        private const decimal SUBVALUE = 708m;
        private const decimal SAVENUM = 652m;
        private const decimal ZERO = 0;

        [TestInitialize]
        public void TestInit()
        {
            mem = new Memory();
        }


        [TestMethod]
        public void MemoryAddTest()
        {
            mem.MemoryAdd(NUM);

            Assert.AreEqual(EXPECTEDNUM, mem.Value);
        }

        [TestMethod]
        public void MemorySubtractTest()
        {
            mem.MemoryAdd(SUBVALUE);
            mem.MemorySubtract(NUM);

            Assert.AreEqual(EXPECTEDNUM, mem.Value);
        }

        [TestMethod]
        public void MemorySaveTest()
        {
            mem.MemorySave(SAVENUM);

            Assert.AreEqual(SAVENUM, mem.Value);
        }

        [TestMethod]
        public void MemoryClearTest()
        {
            mem.MemoryClear();

            Assert.AreEqual(ZERO, mem.Value);
        }
    }
}
