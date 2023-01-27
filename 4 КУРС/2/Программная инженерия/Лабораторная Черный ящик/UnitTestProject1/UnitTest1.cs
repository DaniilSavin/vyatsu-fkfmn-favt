using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibrary2;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AllParametersAreCorrect()
        {
            double a = 1, b = 1, xmin = 1, xmax = 5, dx = 1;
            Equation eq = new Equation(a,b,xmin,xmax,dx);
            List<double> answersX = new List<double>();
            List<double> answersY = new List<double>();
            Equation.Calculation(eq, ref answersX, ref answersY);
            Assert.AreEqual(-0.94, answersY[0]);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void xLessThanZeroError()
        {
            double a = 1, b = 1, xmin = -1, xmax = 5, dx = 1;
            Equation eq = new Equation(a, b, xmin, xmax, dx);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void APower2PlusBEquals0()
        {
            double a = 1, b = -1, xmin = 1, xmax = 5, dx = 1;
            Equation eq = new Equation(a, b, xmin, xmax, dx);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void XPower2Equals4XPlus1()
        {
            double a = 1, b = 1, xmin = (4 + 4 * Math.Sqrt(2)) / 2, xmax = 5, dx = 1;
            Equation eq = new Equation(a, b, xmin, xmax, dx);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void DxLessThanZero()
        {
            double a = 1, b = 1, xmin = 1, xmax = 5, dx = -1;
            Equation eq = new Equation(a, b, xmin, xmax, dx);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void XminGreaterThanXmax()
        {
            double a = 1, b = 1, xmin = 5, xmax = 1, dx = 1;
            Equation eq = new Equation(a, b, xmin, xmax, dx);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void DxGreaterThanXmaxMinusXmin()
        {
            double a = 1, b = 1, xmin = 1, xmax = 5, dx = 10;
            Equation eq = new Equation(a, b, xmin, xmax, dx);
        }
    }
}
