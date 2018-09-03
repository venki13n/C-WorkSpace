using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture, TestFixtureSource(typeof(MyFactoryClass), "TestCaseListString")]
    [Parallelizable]
    //[Parallelizable(ParallelScope.Fixtures)]
    class ChildFixture : SuperFixtureCLass
    {
     
        public ChildFixture(String String) : base(String)
        {
        }

        [Test]
        public void testCase1()
        {
            driver.Navigate().GoToUrl("https://google.co.in");
        }
        [Test]
        public void testCase2()
        {
            driver.Navigate().GoToUrl("https://www.facebook.com");
        }
    }
}
