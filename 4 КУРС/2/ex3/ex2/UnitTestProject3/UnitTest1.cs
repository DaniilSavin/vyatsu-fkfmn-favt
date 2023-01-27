using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject3
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
        [DataRow(1, -1, 1, -2.928330672)]
        [DataRow(1, 0, 3, double.NaN)]//Nan
        public void CalcTest(double a, double b, double x, double expected)
        {
            //Arange
            Expression expression = new Expression(a, b, x);

            //Act
            var result = Math.Floor(expression.Calc());
            expected = Math.Floor(expected);

            //Assert
            Assert.AreEqual(expected, result);
        }
        [DataTestMethod]
        //[DataRow(1, 0, 1), ExpectedException(typeof(ArgumentException))]//1
        [DataRow(1, 1, 1), ExpectedException(typeof(ArgumentException))]//2
        public void ConstructorTest2(double a, double b, double x)
        {
            new Expression(a, b, x);
        }
        [DataTestMethod]
        [DataRow(1, 3, 5,50,25,1), ExpectedException(typeof(ArgumentException))]//3
        [DataRow(1, 3, 5, 10, 30, 100)]//4                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    &
        [DataRow(1, 3, 5, 10, 30, 0)]//5 dx=0 ex Exception
        public void ConstructorTest3(double a, double b, double x, 
            double xMin, double xMax, double step)
        {
            new Expression(a, b, x, xMin, xMax, step);
        }
        [DataTestMethod]
        [DataRow(1, -1, 1, 1, 5, 1, new int[] { -2, 0, 0, -1, -2 })]
        public void CalcRangeTest(double a, double b, double x,
            double xMin, double xMax, double step, int[] expected)
        {
            //Arange
            Expression expression = new Expression(a, b, x, xMin, xMax, step);

            //Act
            var result = expression.CalcRange().ConvertAll(item =>
            (int)(item));
            var actual = result.ToArray();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(1, 1, 0.01, 1, new double[] { 6, 3, 4, 4, 4 })]
        [DataRow(1, 1, -0.01, -1, new double[] { 0, -2, 0, 0, -1 })]
        [DataRow(1, 3, -2, 1, new double[] { -2,0, double.NaN, 4, 5 })]
        public void BorderBTest(double a,double x,
            double bMin, double step, double[] expected)
        {
            //Arange
            List<double> result = new List<double>();

            //Act
            while (result.Count < expected.Length)
            {
                double tmpResult = (new Expression(a, bMin, x)).Calc();
                result.Add(
                    (double.IsNaN(tmpResult)?double.NaN:(int)tmpResult)
                    );
                bMin += step;
            }
            var actual = result.ToArray();

            for (int i = 0; i < actual.Length; i++)
            {
                Console.WriteLine(actual[i]+" "+expected[i]);
            }
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
