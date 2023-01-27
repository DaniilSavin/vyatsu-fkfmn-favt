<<<<<<< HEAD
﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
namespace zadanie_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double latitude = 1, longitude = 2;
            Point point = new Point(latitude, longitude);
            Assert.AreEqual (1, point.Latitude);

        }
        /*[TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestMethod2()
        {

        }*/
        
    }
}
=======
﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
namespace zadanie_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            double latitude = 1, longitude = 2;
            Point point = new Point(latitude, longitude);
            Assert.AreEqual (1, point.Latitude);

        }
        /*[TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestMethod2()
        {

        }*/
        
    }
}
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
