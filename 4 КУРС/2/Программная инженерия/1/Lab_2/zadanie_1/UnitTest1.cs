using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace zadanie_1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1() //Для точек, лежащих на прямой, проходящей через центр Земли азимут = any
        {
            Point point_1 = new Point(90, 0);
            Point point_2 = new Point(-90, 0);
            string az = point_1.Azimuth(point_2);
            Assert.AreEqual("any", az);
        }
        [TestMethod]
        public void TestMethod2() //Для совпадающих точек азимут = none
        {
            Point point_1 = new Point(80, 40);
            Point point_2 = new Point(80, 40);
            string az = point_1.Azimuth(point_2);
            Assert.AreEqual("none", az);
        }
        [TestMethod]
        public void TestMethod3() //Для одной точки на северном полюсе азимут = 180
        {
            Point point_1 = new Point(90, 0);
            Point point_2 = new Point(80, 40);
            string az = point_1.Azimuth(point_2);
            Assert.AreEqual("180", az);
        }
        [TestMethod]
        public void TestMethod4() //Для двух точек на одном полюсе азимут = none
        {
            Point point_1 = new Point(90, 0);
            Point point_2 = new Point(90, 0);
            string az = point_1.Azimuth(point_2);
            Assert.AreEqual("none", az);
        }
        [TestMethod]
        public void TestMethod5() //Для точек на противоположных полюса (см 2) азимут = any
        {
            Point point_1 = new Point(90, 0);
            Point point_2 = new Point(90, 0);
            string az = point_1.Azimuth(point_2);
            Assert.AreEqual("none", az);
        }
        [TestMethod]
        public void TestMethod6() //Для одной точки на южном полюсе азимут = 180
        {
            Point point_1 = new Point(-90, 0);
            Point point_2 = new Point(15, 0);
            string az = point_1.Azimuth(point_2);
            Assert.AreEqual("180", az);
        }
        [TestMethod]
        public void TestMethod7() //Для точек на экваторе 90 или 270, смотря куда ближе
        {
            Point point_1 = new Point(0, 120);
            Point point_2 = new Point(0, 50);
            string az = point_1.Azimuth(point_2);
            Assert.AreEqual("270", az);
        }
        [TestMethod]
        public void TestMethod8() //При расчете расстояния между 2 произвольными точками расстояние должно быть меньше Pi*r,
                                  //где r - радиус Земли. Здесь хорошо бы проверить точки слева и справа от 180-го меридиана
        {
            Point point_1 = new Point(0, 120);
            Point point_2 = new Point(0, -160);
            var dis = point_1.Distance(point_2);
            //Assert.AreEqual("270", az);
        }
        [TestMethod]
        public void TestMethod9() //Для точек на одном меридиане 0("идем на север") или 180("идем на юг")
        {
            Point point_1 = new Point(23, 50);
            Point point_2 = new Point(15, 50);
            string az = point_1.Azimuth(point_2);
            Assert.AreEqual("0 (идем на север)", az);
        }
    }*/
}
