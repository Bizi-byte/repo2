using Shapes;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shapes.Tests
{
    [TestClass()]
    public class UnitTest1
    {
        [TestMethod()]
        public void ShapeTest()
        {
            Shape s1 = new Circle(10);
            Shape s2 = null;
            Assert.AreEqual(s1.Area(), Math.PI * 10 * 10, 0.001, "circle area");
            Assert.AreNotEqual(s2, null, "circle creation null");
        }

        [TestMethod()]
        public void ShapeTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AreaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PerimeterTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }
    }
}

namespace UnitTestShapes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
