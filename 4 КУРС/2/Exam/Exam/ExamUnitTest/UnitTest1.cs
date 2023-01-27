using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam;
using System.Collections.Generic;


namespace ExamUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Calc c = new Calc();

            List<double> res = Calc.Calculation(2.0, 5.0, 1.0, 5.0, 1.0);
            List<double> Y = new List<double> {4,5,5,5};

            CollectionAssert.AreEqual(Y, res);
        }
    }
}
