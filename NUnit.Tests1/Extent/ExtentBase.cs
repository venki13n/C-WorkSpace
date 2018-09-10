using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NUnit.Tests1.Extent
{
    class ExtentBase
    {
        private static ExtentReports extentReports;
        private static ExtentHtmlReporter htmlReporter;
        private static Dictionary<int, ExtentTest> TestsInProgress = null;
        private static readonly Object obj = new Object();
        public static ExtentReports extentInstance
        {
            get
            {
                lock (obj)
                {
                    if (extentReports == null)
                    { return getInstance(); }
                    return extentReports;
                }
            }
        }

        private ExtentBase() { }
        private static ExtentReports getInstance()
        {
            htmlReporter = new ExtentHtmlReporter(@"G:\htmlFile.html");
            htmlReporter.LoadConfig(@"C:\Users\ABC\source\repos\SeleniumNUnitTest\NUnit.Tests1\Extent\extent-config.xml");
            htmlReporter.Configuration().Theme = Theme.Dark;
            htmlReporter.Configuration().DocumentTitle = "ArrowReport";
            htmlReporter.Configuration().ReportName = "ArrowReport";
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
            extentReports.AddSystemInfo("OS_NAME", "Windows 10");
            extentReports.AddSystemInfo("HostMachine", "Local Machine");
            return extentReports;
        }

        public static ExtentTest CreateTest(string TestName, string Category="")
        {            
            lock (obj)
            {
                TestsInProgress = new Dictionary<int, ExtentTest>();
                ExtentTest test = extentInstance.CreateTest(TestName);
                TestsInProgress.Add(Thread.CurrentThread.ManagedThreadId, test);
                //Console.WriteLine("Thread :{0}, Test: {1}", TestsInProgress.Keys.ToString(), TestName);
                if (!Category.Equals(""))
                {
                    test.AssignCategory(Category);
                }
                return test;              
            }
        }

        public static ExtentTest GetTargetTest()
        {
           // Console.WriteLine("Thread is :" + TestsInProgress[Thread.CurrentThread.ManagedThreadId]);
            lock (obj)
                {
                    //Console.WriteLine("Thread is :" + TestsInProgress[Thread.CurrentThread.ManagedThreadId].ToString());
                    return TestsInProgress[Thread.CurrentThread.ManagedThreadId];
                }
            
        }

        public static void FlushExtent()
        {        
            extentInstance.Flush();
            //extentInstance.AddSystemInfo("LastMinuteUpdate", "LateUpadte");
        }
    
    }
}
