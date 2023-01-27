using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        
        [DataTestMethod]
        [DataRow(90, 0, -90, 0, "any")] //��� �����, ������� �� ������, ���������� ����� ����� ����� ������ = any
        [DataRow(-90, 0, 90, 0, "any")]
        [DataRow(90, 0, -90, 0, "any")] //��� ����� �� ��������������� ������ (�� 2) ������ = any
        [DataRow(-90, 0, 90, 0, "any")]
        public void TestGetAzimuthAny(int latitude, int longitude, int latitude_2, int longitude_2, string expected) 
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }

        //��� ����������� ����� ������ = none
        [DataTestMethod]
        [DataRow(80, 40, 80, 40, "none")] //��� ����������� ����� ������ = none
        [DataRow(10, 10, 10, 10, "none")] 
        [DataRow(90, 0, 90, 0, "none")] //��� ���� ����� �� ����� ������ ������ = none
        [DataRow(-90, 0, -90, 0, "none")]
        public void TestGetAzimuthNone(int latitude, int longitude, int latitude_2, int longitude_2, string expected) 
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }

        
        [DataTestMethod]
        [DataRow(90, 0, 80, 40, "180")] //��� ����� ����� �� �������� ������ ������ = 180
        [DataRow(40, 10, 90, 0, "180")]
        [DataRow(-90, 0, 15, 0, "180")] //��� ����� ����� �� ����� ������ ������ = 180
        public void TestGetAzimuth180(int latitude, int longitude, int latitude_2, int longitude_2, string expected) 
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, 120, 0, 50, "270")] //��� ����� �� �������� 90 ��� 270, ������ ���� �����
        public void TestGetAzimuth270(int latitude, int longitude, int latitude_2, int longitude_2, string expected) 
        {
            Point point_1 = new Point(latitude, longitude);
            Point point_2 = new Point(latitude_2, longitude_2);
            string actual = point_1.Azimuth(point_2);
            Assert.AreEqual(expected, actual);
        }

    }
}
