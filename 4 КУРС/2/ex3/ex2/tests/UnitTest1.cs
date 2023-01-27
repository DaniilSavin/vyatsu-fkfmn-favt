using ExpressionNamespace;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [DataRow(2, 2, 1)]
        public void ConstructorTest1(double a, double b, double x)
        {
            Expression expression = new Expression(a, b, x);

            Assert.AreEqual(a, expression.A);
            Assert.AreEqual(b, expression.B);
            Assert.AreEqual(x, expression.X);
        }
        [DataTestMethod]
        [DataRow(2, 2, 0), ExpectedException(typeof(ArgumentException))]
        [DataRow(1, 2, 3)]
        [DataRow(1, 2, -1)]
        public void ConstructorTest2(double a, double b, double x)
        {
           new Expression(a, b, x);
        }
        [DataTestMethod]
        [DataRow(2, 2, 1, 1, 5, 0), ExpectedException(typeof(ArgumentException))]
        [DataRow(2, 2, 1, 5, 1, 3)]
        [DataRow(2, 2, 1, 5, 1, 300)]
        public void ConstructorTest3(double a, double b, double x, double xMin, double xMax, double step)
        {
            new Expression(a, b, x, xMin, xMax, step);
        }
        [TestMethod]
        public void ConstructorTest4()
        {
            double a = 3, b = 2, x = 1;
            double xMin = 1, xMax = 4, step = 1;
            Expression expression = new Expression(a, b, x, xMin, xMax, step);

            Assert.AreEqual(a, expression.A);
            Assert.AreEqual(b, expression.B);
            Assert.AreEqual(x, expression.X);
            Assert.AreEqual(xMin, expression.XMin);
            Assert.AreEqual(xMax, expression.XMax);
            Assert.AreEqual(step, expression.Step);
        }

        [TestMethod]
        public void CalcTest()
        {
            double a = 2, b = 0, x = 1;
            Expression expression = new Expression(a, b, x);
            var roundedExpected = Math.Round(0.38629436111989061883, 5);

            var result = Math.Round(expression.Calc(), 5);

            Assert.AreEqual(roundedExpected, result);
        }

        [DataTestMethod]
        [DataRow(0, 4, +0.01, 5, 1, new int[] { -312961842, 53, 12, 4, 1 })]
        public void BorderLine(double a, double b, double xMin, double xMax, double step, int[] values)
        {
            Expression expression = new Expression(a, b, xMin, xMin, xMax, step);

            var result = expression.CalcInterval().ToList().ConvertAll(x => (int)Math.Floor(x)).ToArray();

            CollectionAssert.AreEqual(values, result);
        }
        [DataTestMethod]
        [DataRow(1, 1, 1.001, 5, 1, new int[] { -999985, 14, 15, 16, 17 })]
        [DataRow(1, 1, 0.999, -5, -1, new int[] { -999985, 12, 12, 12, 11 })]
        public void BorderLine2(double x, double b, double aMin, double aMax, double step, int[] values)
        {
            List<int> result = new List<int>();
            double a = aMin;

            while (result.Count < values.Length)
            {
                Expression expression = new Expression(a, b, x);
                result.Add((int)(expression.Calc()));
                a += step;
            }
            var result2 = result.ToArray();

            CollectionAssert.AreEqual(values, result2);
        }
    }
}
