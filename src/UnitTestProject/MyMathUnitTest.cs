using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class MyMathUnitTest
    {
        [TestMethod]
        public void MyMath_Add_2_2_Returns_4()
        {
            int x = 2;
            int y = 2;
            MyMath myMath = new MyMath();
            int actual = myMath.Add(x, y);
            int expected = 4;

            Assert.AreEqual<int>(expected, actual);
        }

        [TestMethod]
        public void MyMath_Add_1_1_Returns_2()
        {
            int x = 1;
            int y = 1;
            MyMath myMath = new MyMath();
            int actual = myMath.Add(x, y);
            int expected = 2;

            Assert.AreEqual<int>(expected, actual);
        }
    }
}
