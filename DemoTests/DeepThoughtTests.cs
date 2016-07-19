using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Tests
{
    [TestClass]
    public class DeepThoughtTests
    {
        [TestMethod]
        public void TheAnswerTest()
        {
            int expected = 42;
            DeepThought f1 = new DeepThought();
            int actual = f1.TheAnswer();
            Assert.AreEqual(expected, actual);
        }
    }
}