using CBT_NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestParallel
    {
        [Test , Parallelizable]
        [TestCase("chrome")]
        [TestCase("ie")]
        public void TestMethod(String Browser) {
            // TODO: Add your test code here
            //IWebDriver dirver = CBTAPI.InitializeDriver(Browser);
            //dirver.Navigate().GoToUrl("www.google.com");
            //dirver.FindElement(By.Id("lst-ib")).SendKeys(Browser);
            Console.WriteLine(Browser);
            Console.WriteLine("Hello");
            Console.WriteLine("\nWhat is your name? ");
            var name = Console.ReadLine();
            var date = DateTime.Now;
            Console.WriteLine($"\nHello, {name}, on {date:d} at {date:t}!");
            Console.Write("\nPress any key to exit...");
        }
    }
}
