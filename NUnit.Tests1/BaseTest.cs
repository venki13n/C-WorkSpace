using System;
using System.IO;
using System.Net;
using System.Text;
using NUnit.Framework;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections.Specialized;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace CBT_NUnit
{
    [TestFixture]
    public class CBTAPI
    {
        protected RemoteWebDriver driver;
        protected string browser;
        protected string session_id;
        public static string nodeURL = "http://192.168.0.4:4444/wd/hub";
        public string BaseURL = "https://crossbrowsertesting.com/api/v3/selenium";
        public string username = "chase@crossbrowsertesting.com";
        public string authkey = "12345";

        public CBTAPI(string browser)
        {
            this.browser = browser;
        }

        [SetUp]
        public void Initialize()
        {

            DesiredCapabilities capabilities = new DesiredCapabilities();            
            capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
            

           // capability.SetCapability("name", "NUnit-CBT");
            //capability.SetCapability("record_video", "true");
            //capability.SetCapability("build", "1.0");
            //capability.SetCapability("os_api_name", "Win10");

            switch (browser)
            {
                // These all pull the latest version by default
                // To specify version add SetCapability("version", "desired version")
                case "chrome":
                    capabilities.SetCapability(CapabilityType.BrowserName, "chrome");

                    break;
                case "ie":
                    capabilities.SetCapability(CapabilityType.BrowserName, "internet explorer");
                    break;
                case "safari":
                    capabilities.SetCapability(CapabilityType.BrowserName, "safari");
                    break;
                default:
                    capabilities.SetCapability(CapabilityType.BrowserName, "firefox");
                    break;
            }

            //capability.SetCapability("username", username);
            //capability.SetCapability("password", authkey);

            driver = new RemoteWebDriver(new Uri(nodeURL), capabilities);
        }
        public static IWebDriver InitializeDriver(String browser)
        {
            
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));


            // capability.SetCapability("name", "NUnit-CBT");
            //capability.SetCapability("record_video", "true");
            //capability.SetCapability("build", "1.0");
            //capability.SetCapability("os_api_name", "Win10");

            switch (browser)
            {
                // These all pull the latest version by default
                // To specify version add SetCapability("version", "desired version")
                case "chrome":
                    capabilities.SetCapability(CapabilityType.BrowserName, "chrome");

                    break;
                case "ie":
                    capabilities.SetCapability(CapabilityType.BrowserName, "internet explorer");
                    capabilities.SetCapability("ignoreZoomSetting", true);
                    
                    break;
                case "safari":
                    capabilities.SetCapability(CapabilityType.BrowserName, "safari");
                    
                    break;
                default:
                    capabilities.SetCapability(CapabilityType.BrowserName, "firefox");
                    break;
            }

            //capability.SetCapability("username", username);
            //capability.SetCapability("password", authkey);

            return new RemoteWebDriver(new Uri(nodeURL), capabilities);
            
        }

        [TearDown]
        public void Cleanup()
        {
            var session_id = driver.SessionId.ToString();
            driver.Quit();
            //setScore(session_id, "pass");
        }

        public void setScore(string sessionId, string score)
        {
            string url = BaseURL + "/" + sessionId;
            // encode the data to be written
            ASCIIEncoding encoding = new ASCIIEncoding();
            string data = "action=set_score&score=" + score;
            byte[] putdata = encoding.GetBytes(data);
            // Create the request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "PUT";
            request.Credentials = new NetworkCredential(username, authkey);
            request.ContentLength = putdata.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "HttpWebRequest";
            // Write data to stream
            Stream newStream = request.GetRequestStream();
            newStream.Write(putdata, 0, putdata.Length);
            WebResponse response = request.GetResponse();
            newStream.Close();
        }
    }
}