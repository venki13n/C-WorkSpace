using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture]
    [Parallelizable]
    public class TestCases
    {
        IWebDriver driver;
        [TestCase("ie")]
        [TestCase("chrome")]
        [TestCase("fire")]
        [Parallelizable(ParallelScope.Self)]
        public void TestMethod(String browserName)
        {
            RemoteWebDriver driver;
            //DesiredCapabilities capability = DesiredCapabilities.
            //  capability.SetCapability("platform", "VISTA");
            //  capability.SetCapability("platformName", "windows");
            //  capability.SetCapability("version", "latest");
            //  capability.SetCapability("gridlasticUser", USERNAME);
            //  capability.SetCapability("gridlasticKey", ACCESS_KEY);
            //  capability.SetCapability("video", "True");
            //    driver = new RemoteWebDriver(
            //new Uri("http://YOUR_GRIDLASTIC_SUBDOMAIN.gridlastic.com:80/wd/hub/"), capability, TimeSpan.FromSeconds(600));// NOTE: connection timeout of 600 seconds or more required for time to launch grid nodes if non are available.
            //driver.Manage().Window.Maximize(); 
        }

        [SetUp]
        public void setUp()
        {
            
        }

        //public static Object[] ReturnBrowsers()
        //{



        //}
    }
}
