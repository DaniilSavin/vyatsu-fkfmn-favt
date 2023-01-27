using ClassLibrary;
using NUnit.Framework;

namespace TestProject2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(90, 0, -90, 0, "any")] //Для точек, лежащих на прямой, проходящей через центр Земли азимут = any
        [TestCase(-90, 0, 90, 0, "any")]
        [TestCase(90, 0, -90, 0, "any")] //Для точек на противоположных полюса (см 2) азимут = any
        [TestCase(-90, 0, 90, 0, "any")]
        public void TestGetAzimuthAny(int latitude, int longitude, int latitude_2, int longitude_2, string expected)
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }

        //Для совпадающих точек азимут = none
        [Test]
        [TestCase(80, 40, 80, 40, "none")] //Для совпадающих точек азимут = none
        [TestCase(10, 10, 10, 10, "none")]
        [TestCase(90, 0, 90, 0, "none")] //Для двух точек на одном полюсе азимут = none
        [TestCase(-90, 0, -90, 0, "none")]
        public void TestGetAzimuthNone(int latitude, int longitude, int latitude_2, int longitude_2, string expected)
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        [TestCase(90, 0, 80, 40, "180")] //Для одной точки на северном полюсе азимут = 180
        [TestCase(40, 10, 90, 0, "180")]
        [TestCase(-90, 0, 15, 0, "180")] //Для одной точки на южном полюсе азимут = 180
        public void TestGetAzimuth180(int latitude, int longitude, int latitude_2, int longitude_2, string expected)
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(0, 120, 0, 50, "270")] //Для точек на экваторе 90 или 270, смотря куда ближе
        public void TestGetAzimuth270(int latitude, int longitude, int latitude_2, int longitude_2, string expected)
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }

    }
}