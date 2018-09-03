//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Diagnostics;
//using System.Threading;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Remote;
//using NUnit.Framework;
//using System.IO;


//namespace PerfectoLabSeleniumTestProject3
//{
//    /// <summary>
//    /// Summary description for RemoteWebDriverTest
//    /// 
//    /// For programming samples and updated templates refer to the Perfecto GitHub at: https://github.com/PerfectoCode
//    /// </summary>
//    [TestFixture("Android", "6.0.1", "ShirPhilipp")]
//    [TestFixture("iOS", "9.2.1", "Shir Philipp")]
//    [Parallelizable(ParallelScope.Fixtures)]
//    public class RemoteWebDriverTest
//    {
//        private RemoteWebDriver driver;
//        String deviceOS, deviceVersion, deviceDescription;
//        String executionID;

//        public RemoteWebDriverTest(String deviceOS, String deviceVersion, String deviceDescription)
//        {
//            this.deviceOS = deviceOS;
//            this.deviceVersion = deviceVersion;
//            this.deviceDescription = deviceDescription;
//        }

//        [SetUp]
//        public void PerfectoOpenConnection()
//        {
//            var browserName = "mobileOS";
//            var host = "demo.perfectomobile.com";

//            DesiredCapabilities capabilities = new DesiredCapabilities(browserName, string.Empty, new Platform(PlatformType.Any));
//            capabilities.SetCapability("user", "");

//            //TODO: Provide your password
//            capabilities.SetCapability("password", "");

//            //TODO: Provide your device ID
//            capabilities.SetCapability("platformName", deviceOS);
//            Console.WriteLine(this.deviceOS + this.deviceVersion + this.deviceDescription);
//            capabilities.SetCapability("platformVersion", deviceVersion);
//            capabilities.SetCapability("description", deviceDescription);

//            //capabilities.SetPerfectoLabExecutionId(host);

//            // Add a persona to your script (see https://community.perfectomobile.com/posts/1048047-available-personas)
//            //capabilities.SetCapability(WindTunnelUtils.WIND_TUNNEL_PERSONA_CAPABILITY, WindTunnelUtils.GEORGIA);

//            // Name your script
//            capabilities.SetCapability("scriptName", "VSSimpleFixture_" + deviceOS);

//            var url = new Uri(string.Format("https://{0}/nexperience/perfectomobile/wd/hub", host));
//            System.Threading.Thread.Sleep(2000);
//            driver = new RemoteWebDriver(url, capabilities);

//            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(40));
//            //ICapabilities cap = driver.Capabilities;
//            //executionID = (String)cap.GetCapability("executionId");
//           // Console.WriteLine(executionID);
//        }

  
//    }
//}