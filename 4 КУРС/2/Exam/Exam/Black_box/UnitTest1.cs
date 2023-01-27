using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Exam;
using System.Collections.Generic;
using System.Linq;

namespace Black_box
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [DataRow(2.0, 5.0, 1.0, 5.0, 1.0)]
        public void ShouldReturnResult(double a, double b, double x_min, double x_max, double dx)// Путь 10
        {
            Calc c = new Calc();

            List<double> res = Calc.Calculation(a, b, x_min, x_max, dx);
            List<double> Y = new List<double> { 4, 5, 5, 5 };

            CollectionAssert.AreEqual(Y, res);
        }

        [DataTestMethod]
        [DataRow(2.0, 0.0, 1.0, 5.0, 1.0), ExpectedException(typeof(ArgumentException))]// b == 0 Путь 2
        [DataRow(2.0, 1.0, 1.0, 5.0, 1.0)]// b = x Путь 7
        [DataRow(2.0, 1.0, 6.0, 5.0, 1.0)]// x_min < x_max Путь 4
        [DataRow(2.0, 5.0, 1.0, 5.0, 10.0)]// dx > (x_max-x_min) Путь  5
        [DataRow(2.0, 5.0, 1.0, 5.0, 0)]// dx == 0 Путь 3
        public void ReturnError(double a, double b, double x_min, double x_max, double dx)
        {
            Calc c = new Calc();
            List<double> res = Calc.Calculation(a, b, x_min, x_max, dx);
          
        }
        /*
        [TestMethod]
        [DataRow(2.0, 1.0, 1.0, 5.0, 1.0), ExpectedException(typeof(ArgumentException))]
        public void B_Equals_X(double a, double b, double x_min, double x_max, double dx)
        {
            Calc c = new Calc();
            List<double> res = Calc.Calculation(a, b, x_min, x_max, dx);

        }
        
        [TestMethod]
        [DataRow(2.0, 1.0, 6.0, 5.0, 1.0), ExpectedException(typeof(ArgumentException))]
        public void XminLessXmax(double a, double b, double x_min, double x_max, double dx)
        {
            Calc c = new Calc();
            List<double> res = Calc.Calculation(a, b, x_min, x_max, dx);

        }

        [TestMethod]
        [DataRow(2.0, 5.0, 1.0, 5.0, 10.0), ExpectedException(typeof(ArgumentException))]
        public void DxGreaterError(double a, double b, double x_min, double x_max, double dx)
        {
            Calc c = new Calc();

            List<double> res = Calc.Calculation(a, b, x_min, x_max, dx);
            List<double> Y = new List<double> { 4, 5, 5, 5 }; 
        }
*/
        [TestMethod]
        [DataRow(2.0, -0.000000001, 1.0, 5.0, 1.0)]
        public void BorderLine1(double a, double b, double x_min, double x_max, double dx)
        {
            Calc c = new Calc();

            List<double> res = Calc.Calculation(a, b, x_min, x_max, dx);
            List<double> Y = new List<double> { -1, -2, -3, -4 };

            CollectionAssert.AreEqual(Y, res);
        }

        [TestMethod]
        [DataRow(2.0, +0.000000001, 1.0, 5.0, 1.0, new[] { 5, 4, 3, 3 })]
        public void BorderLine2(double a, double b, double x_min, double x_max, double dx, int[] Y)
        {
            Calc c = new Calc();
            List<int> Y_res = Y.OfType<int>().ToList();
            List<double> doubleList = Y_res.ConvertAll(x => (double)x);
            List<double> res = Calc.Calculation(a, b, x_min, x_max, dx);
            //List<double> Y = new List<double> { 5, 4, 3, 3 };

            CollectionAssert.AreEqual(doubleList, res);
        }
    }
}
