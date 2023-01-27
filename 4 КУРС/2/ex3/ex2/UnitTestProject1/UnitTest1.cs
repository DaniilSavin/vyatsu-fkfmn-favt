using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLibrary1
{
    [TestClass]
    public class UnitTest1
    {
        [DataTestMethod]
        [DataRow(1, -1, 1)]
        public void ConstructorTest(double a, double b, double x)
        {
            Expression expression = new Expression(a, b, x);

            Assert.AreEqual(a, expression.A);
            Assert.AreEqual(b, expression.B);
            Assert.AreEqual(x, expression.X);
        }
        [DataTestMethod]
        [DataRow(1, -1, 1)]
        public void CalcTest(double a, double b, double x)
        {
            //Arange
            Expression expression = new Expression(a, b, x);

            //Act
            var result = Math.Floor(expression.Calc());
            var expected = Math.Floor(2.151055138);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
