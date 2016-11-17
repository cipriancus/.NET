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
    public class TextTest
    {
        [TestMethod]
        public void WhenBinBanana_Then_ShoudlReturn1()
        {
            int val = createSUT().ExtractSpecialCharacterFrom('b', "banana");
            val.Equals(2);
        }

        [TestMethod]
        public void WhenCinBanana_Then_ShoudlReturn0()
        {
            int valoare = createSUT().ExtractSpecialCharacterFrom('c', "banana");
            valoare.Equals(0);
        }

        private ITextService createSUT()
        {
            return new TextService();
        }

    }
}
