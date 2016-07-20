using Microsoft.VisualStudio.TestTools.UnitTesting;
using Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Tests
{
    [TestClass()]
    public class StringSampleTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStringSampleNull()
        {
            StringSample sample = new StringSample(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetStringDemoFirstNull()
        {
            StringSample sample = new StringSample(string.Empty);
            string actual = sample.GetStringDemo(null, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetStringDemoFirstEmpty()
        {
            StringSample sample = new StringSample(string.Empty);
            string actual = sample.GetStringDemo("", "a");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetStringDemoSecondNull()
        {
            StringSample sample = new StringSample(string.Empty);
            string actual = sample.GetStringDemo("a", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetStringDemoOutRange()
        {
            StringSample sample = new StringSample(string.Empty);
            string actual = sample.GetStringDemo("a", "aa");
        }

        [TestMethod]
        public void TestStringSampleIsNotNull()
        {
            StringSample sample = new StringSample("a");
        }

        [TestMethod]
        public void GetStringDemoAB()
        {
            string expected = "b not found in a";
            StringSample sample = new StringSample(string.Empty);
            string actual = sample.GetStringDemo("a", "b");
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetStringDemoABCDBC()
        {
            string expected = "removed bc from abcd:ad";
            StringSample sample = new StringSample(string.Empty);
            string actual = sample.GetStringDemo("abcd", "bc");
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GetStringDemoTestToUpper()
        {
            string expected = "TEST";
            StringSample sample = new StringSample("Test");
            string actual = sample.GetStringDemo("aaaaaac", "c");
            Assert.AreEqual(expected,actual);
        }
    }
}