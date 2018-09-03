using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
   

    //    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    //    public class TestCaseCsvAttribute : TestCaseSourceAttribute
    //    {
    //        public TestCsvReader(ChromeDriver)
    //        { }
    //    }

    //public class TestCsvReader<IWebDriver>
    //{
    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="TestCsvReader{T, C}"/> class.
    //    /// </summary>
    //    public TestCsvReader()
    //    {

    //    }
    //}
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class MyTests
    {
        [Test, TestCaseSource(typeof(MyFactoryClass), "TestCases")]
        public void DivideTest(String browserName)
        {
            Console.WriteLine(browserName);
            DivideTest2(browserName);
        }
        //[Parallelizable(ParallelizableAttribute(ParallelEnumerable))]
        [Test, TestCaseSource(typeof(MyFactoryClass), "TestCaseList")]        
        public void DivideTest2(String browserName)
        {
            //Console.WriteLine(browserName);
            IWebDriver driver;
            switch (browserName)
            {
                case "Chrome":
                    Console.WriteLine(browserName);
                    driver = new ChromeDriver();
                    break;
                case "ie":
                    Console.WriteLine(browserName);
                    driver = new InternetExplorerDriver();
                    break;

                case "firefox":
                    Console.WriteLine(browserName);
                    driver = new FirefoxDriver();
                    break;
                default:
                    Console.WriteLine(browserName);
                    driver = new ChromeDriver();
                    break;
             
            }
            driver.Navigate().GoToUrl("https://google.co.in");
        }
        //public ParallelEnumerable GetParallelEnumerable()
        //{
        //    var tc = new List<TestCaseData>();
        //    tc.Add(new TestCaseData("Chrome"));
        //    //tc.Add(new TestCaseData("safari"));
        //    tc.Add(new TestCaseData("ie"));
        //    tc.Add(new TestCaseData("firefox"));
        //    //new TestCases();
        //    //tc.AsParallel();
        //    return tc.TrueForAll();
        //}

    }

    public class MyFactoryClass
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                List<TestCaseData> tc = new List<TestCaseData>();
                tc.Add(new TestCaseData("Chrome"));
                //tc.Add(new TestCaseData("safari"));
                tc.Add(new TestCaseData("ie"));
                tc.Add( new TestCaseData("firefox"));
                //new TestCases();
                //tc.AsParallel();
                return tc.AsParallel<TestCaseData>();                                 
            }
           
        }

        public static List<TestCaseData> TestCaseList
        {
            get
            {
                List<TestCaseData> tc = new List<TestCaseData>();
                tc.Add(new TestCaseData("Chrome"));
                //tc.Add(new TestCaseData("safari"));
                tc.Add(new TestCaseData("ie"));
                tc.Add(new TestCaseData("firefox"));
                //new TestCases();
                tc.AsParallel<TestCaseData>();
                return tc;
            }

        }
        public static List<String> TestCaseListString
        {
            get
            {
                List<String> tc = new List<String>();
                tc.Add("Chrome");
                //tc.Add(new TestCaseData("safari"));
                tc.Add("ie");
                tc.Add("firefox");
                //new TestCases();
                tc.AsParallel();
                return tc;
            }

        }
    }

}
