using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace CBT_NUnit
{
    [TestFixture("chrome")]
    [TestFixture("ie")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class ParallelTest : CBTAPI
    {
        public ParallelTest(string browser) : base(browser) { }
        [Test]
        public void TestTodos()
        {
            driver.Navigate().GoToUrl("http://crossbrowsertesting.github.io/todo-app.html");
            // Check the title
            driver.FindElement(By.Name("todo-4")).Click();
            driver.FindElement(By.Name("todo-5")).Click();
        }
    }
}