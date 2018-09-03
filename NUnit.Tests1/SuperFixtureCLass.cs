using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture("Chrome")]
    [TestFixture("ie")]
    [TestFixture("firefox")]    
    [Parallelizable]
    class SuperFixtureCLass
    {
        public static String _remoteDriverUri = "http://192.168.0.4:4444/wd/hub";
        public IWebDriver driver;
        public String browserName;
        public SuperFixtureCLass(String driver)
        {
            this.browserName = driver;
        }

        
        public void setUpBrowser()
        {
            //Console.WriteLine(browserName);
            
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
          
        }

        [SetUp]
        public void setUpBrowserGrid()
        {
            //Console.WriteLine(browserName);
            //var driverCapabilities = new DesiredCapabilities();
            //driverCapabilities.SetCapability(CapabilityType.BrowserName, browserName);
            
            //driverCapabilities.SetCapability(CapabilityType.Version, _browserVersion);

            //if (AppConfig.UseSauceLabs)
            //{
            //    driverCapabilities.SetCapability("build", string.Format("{0}: {1}", AppConfig.BuildName, AppConfig.BuildId));
            //    driverCapabilities.SetCapability(CapabilityType.Platform, _operatingSystem);
            //    driverCapabilities.SetCapability("username", AppConfig.SL_UserName);
            //    driverCapabilities.SetCapability("accessKey", AppConfig.SL_AccessKey);
            //    driverCapabilities.SetCapability("parentTunnel", AppConfig.ParentTunnelId);
            //    driverCapabilities.SetCapability("tunnelIdentifier", AppConfig.TunnelId);
            //    driverCapabilities.SetCapability("name", TestContext.CurrentContext.Test.Name + "-" + _browserName);

            //    foreach (var capability in AppConfig.Capabilities)
            //    {
            //        var splittedCap = capability.Split(':');
            //        if (splittedCap.Length == 2)
            //            driverCapabilities.SetCapability(splittedCap[0], splittedCap[1]);
            //    }
            //}
           

            switch (browserName)
            {
                case "Chrome":
                    Console.WriteLine(browserName);
                    ChromeOptions options = new ChromeOptions();
                    driver= new RemoteWebDriver(new Uri(_remoteDriverUri), options);
                    break;
                case "ie":
                    Console.WriteLine(browserName);
                    InternetExplorerOptions ieoptions = new InternetExplorerOptions();
                    ieoptions.IgnoreZoomLevel = true;
                    //ieoptions.UsePerProcessProxy = true;
                    driver = new RemoteWebDriver(new Uri(_remoteDriverUri), ieoptions);
                    break;

                case "firefox":
                    Console.WriteLine(browserName);
                    FirefoxOptions fxoptions = new FirefoxOptions();
                    driver = new RemoteWebDriver(new Uri(_remoteDriverUri), fxoptions);
                    break;
                default:
                    Console.WriteLine(browserName);
                    ChromeOptions choptions = new ChromeOptions();                    
                    driver = new RemoteWebDriver(new Uri(_remoteDriverUri), choptions);
                    break;
            }

        }
    }
}
