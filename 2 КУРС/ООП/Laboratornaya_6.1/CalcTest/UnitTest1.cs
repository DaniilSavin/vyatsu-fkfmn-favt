using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcLibrary;

namespace CalcTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateTestMethod()
        {
            String[] a = Calc.GetOperands("23+4,5");
            Assert.AreEqual("23", a[0]);
            Assert.AreEqual("4,5", a[1]);
        }
        [TestMethod]
        public void OperandsTestMethod()
        {
            string a = Calc.GetOperation1("23+4,5");
            Assert.AreEqual("+", a[0].ToString());
        }
        [TestMethod]
        public void ResultTestMethod1()
        {
            Assert.AreEqual("27", Calc.DoubleOperation2["+"](23, 4).ToString());
            string result1 = Calc.DoOperation("23+4", true, 2, 3, 4);
            Assert.AreEqual("27", result1);
            Assert.AreEqual("19", Calc.DoubleOperation2["-"](23, 4).ToString());
            string result2 = Calc.DoOperation("23-4", true, 2, 3, 4);
            Assert.AreEqual("19", result2);
            Assert.AreEqual("-19", Calc.DoubleOperation2["-"](4, 23).ToString());
            string result3 = Calc.DoOperation("4-23", true, 2, 3, 4);
            Assert.AreEqual("-19", result3);
            Assert.AreEqual("92", Calc.DoubleOperation2["*"](4, 23).ToString());
            string result4 = Calc.DoOperation("4*23", true, 2, 3, 4);
            Assert.AreEqual("92", result4);
        }
    }
}
