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
        [TestCase(90, 0, -90, 0, "any")] //��� �����, ������� �� ������, ���������� ����� ����� ����� ������ = any
        [TestCase(-90, 0, 90, 0, "any")]
        [TestCase(90, 0, -90, 0, "any")] //��� ����� �� ��������������� ������ (�� 2) ������ = any
        [TestCase(-90, 0, 90, 0, "any")]
        public void TestGetAzimuthAny(int latitude, int longitude, int latitude_2, int longitude_2, string expected)
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }

        //��� ����������� ����� ������ = none
        [Test]
        [TestCase(80, 40, 80, 40, "none")] //��� ����������� ����� ������ = none
        [TestCase(10, 10, 10, 10, "none")]
        [TestCase(90, 0, 90, 0, "none")] //��� ���� ����� �� ����� ������ ������ = none
        [TestCase(-90, 0, -90, 0, "none")]
        public void TestGetAzimuthNone(int latitude, int longitude, int latitude_2, int longitude_2, string expected)
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        [TestCase(90, 0, 80, 40, "180")] //��� ����� ����� �� �������� ������ ������ = 180
        [TestCase(40, 10, 90, 0, "180")]
        [TestCase(-90, 0, 15, 0, "180")] //��� ����� ����� �� ����� ������ ������ = 180
        public void TestGetAzimuth180(int latitude, int longitude, int latitude_2, int longitude_2, string expected)
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(0, 120, 0, 50, "270")] //��� ����� �� �������� 90 ��� 270, ������ ���� �����
        public void TestGetAzimuth270(int latitude, int longitude, int latitude_2, int longitude_2, string expected)
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }

    }
}