using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [Parallelizable(ParallelScope.Fixtures)]
    public class TypeOfTestCases<TWebDriver> where TWebDriver : IWebDriver,  new()
    {
        IWebDriver driver;
        [Test, Category("remote")]
        public void TestMethod()
        {
            driver = new TWebDriver();
            //driver.Navigate().GoToUrl("www.google.com");
            Console.WriteLine("typeof.ToString()");
            //Assert.Pass("Your first passing test");
            driver.Navigate().GoToUrl("https://google.co.in");
        }

        [Test, Category("remote")]
        public void TestMethod2()
        {
            driver = new TWebDriver();
            //driver.Navigate().GoToUrl("www.google.com");
            Console.WriteLine("typeof.ToString()");
            //Assert.Pass("Your first passing test");
            driver.Navigate().GoToUrl("https://www.facebook.com");
        }
    }
}
