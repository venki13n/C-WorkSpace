//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.IE;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NUnit.Tests1
//{
//    [TestFixture(typeof(ChromeDriver))]
//    [TestFixture(typeof(InternetExplorerDriver))]
//    //[TestFixtureSource(typeof(browser))]
//    [Parallelizable]
//    public class TestClass<TWebDriver> where TWebDriver : IWebDriver, new()
//    {
//        IWebDriver driver;
//        [Test]
//        public void TestMethod()
//        {
//            // TODO: Add your test code here
//            //Assert.Pass("Your first passing test");
//            Console.WriteLine("Your test1 passing test");
//        }

        
        
//        public void TestMethod1()
//        {
//            // TODO: Add your test code here
//            //Assert.Pass("Your second passing test");
//            driver.Navigate().GoToUrl("google.com");
//            Console.WriteLine("Your test2 passing test");
//        }

//        [SetUp]
//        public void TestMethod2()
//        {
//            // TODO: Add your test code here
//            Console.WriteLine("Your setup passing test");
//            //List<IWebDriver> ie = new List<IWebDriver>();
//            //ie.Add(ChromeDriver);
//            driver = new TWebDriver();
            
//                //driver = new ChromeDriver();

//            //driver = new InternetExplorerDriver();
//        }
//        [TearDown]
//        public void TestMethod3()
//        {
//            // TODO: Add your test code here
//            Console.WriteLine("Your Teardown passing test");
//        }
//    }
//}
