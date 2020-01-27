using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack;

namespace StackTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ObjectStack s1 = new ObjectStack();
            Assert.AreEqual(true, s1.IsEmpty());
        }
    }
}
