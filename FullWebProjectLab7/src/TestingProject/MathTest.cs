using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FullWebProject.Services;

namespace TestingProject
{

    [TestClass]
    public class MathTest
    {
        [TestMethod]
        public void WhenIMathServiceHasVatZero_Then_ShoudThrowException()
        {
            Action action = () => createSUT().ComputeVat(500, 0);
            action.ShouldThrow<Exception>();
        }

        [TestMethod]
        public void WhenIMathServiceHasVat20AndValue500_Then_ShoudReturn100()
        {
            createSUT().ComputeVat(500, 20).Should().Equals(100);
        }

        private IMathService createSUT()
        {
            return new MathService();
        }
    }
}
