using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using System;
using ClassLibrary;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public static void CalculateTestMethod()
        {
            String[] a = CalcLibrary.Calc.GetOperands("23+4,5");
            Assert.AreEqual("23", a[0]);
            Assert.AreEqual("4,5", a[1]);
        }
        [TestMethod]
        public static void ResultTestMethod()
        {
            Assert.AreEqual("27,5", CalcLibrary.Calc.DoubleOperation["+"](23, 4.5).ToString());
            string result = CalcLibrary.Calc.DoOperation("23+4,5");
            Assert.AreEqual("27,5", result);
        }
    }
}
