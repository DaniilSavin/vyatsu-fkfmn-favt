using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        
        [DataTestMethod]
        [DataRow(90, 0, -90, 0, "any")] //Для точек, лежащих на прямой, проходящей через центр Земли азимут = any
        [DataRow(-90, 0, 90, 0, "any")]
        [DataRow(90, 0, -90, 0, "any")] //Для точек на противоположных полюса (см 2) азимут = any
        [DataRow(-90, 0, 90, 0, "any")]
        public void TestGetAzimuthAny(int latitude, int longitude, int latitude_2, int longitude_2, string expected) 
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }

        //Для совпадающих точек азимут = none
        [DataTestMethod]
        [DataRow(80, 40, 80, 40, "none")] //Для совпадающих точек азимут = none
        [DataRow(10, 10, 10, 10, "none")] 
        [DataRow(90, 0, 90, 0, "none")] //Для двух точек на одном полюсе азимут = none
        [DataRow(-90, 0, -90, 0, "none")]
        public void TestGetAzimuthNone(int latitude, int longitude, int latitude_2, int longitude_2, string expected) 
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }

        
        [DataTestMethod]
        [DataRow(90, 0, 80, 40, "180")] //Для одной точки на северном полюсе азимут = 180
        [DataRow(40, 10, 90, 0, "180")]
        [DataRow(-90, 0, 15, 0, "180")] //Для одной точки на южном полюсе азимут = 180
        public void TestGetAzimuth180(int latitude, int longitude, int latitude_2, int longitude_2, string expected) 
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, 120, 0, 50, "270")] //Для точек на экваторе 90 или 270, смотря куда ближе
        public void TestGetAzimuth270(int latitude, int longitude, int latitude_2, int longitude_2, string expected) 
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }

    }
}
