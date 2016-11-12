using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebFormsProject;
using WebFormsProject.Class;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Palindrome.check("ana"), true);
            Assert.AreEqual(Palindrome.check("andrei"), false);
         }
    }
}
