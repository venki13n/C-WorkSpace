using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Atmakur.Testing.Core.Utilities
{
    public static class AppConfig
    {

        public static List<string> Capabilities { get; private set; }
        public static string InitUrl { get; private set; }

        public static TimeSpan ElementLoadWaitTime { get; private set; }
        public static TimeSpan SeleniumCommandWaitTime { get; private set; }
        public static string AssemblyDirectory { get; private set; }
        public static string SauceRemoteDriverUri { get; private set; }
        public static string SeleniumGridDriverUri { get; private set; }
        public static bool UseSeleniumGrid { get; private set; }
        public static bool OutputResultsToFile { get; private set; }
        public static bool OutputResultsToConsole { get; private set; }
        public static string DataSourceConnectionString { get; private set; }
        public static string CurrentEnvironment { get; private set; }
        internal static List<BrowserConfigEntity> BrowsersEnabled { get; set; }

        static AppConfig()
        {
            AssemblyDirectory = GetDirectoryName();

            //DataSourceConnectionString = ConfigurationManager.AppSettings["TestDataSource"];
            //Gets all required environment variables
        }

        private static string GetDirectoryName()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }




        public class ConfigEntity
        {

            public string Environment { get; set; }
            public AppConfigEntity AppConfig { get; set; }
            public List<BrowserConfigEntity> Browsers { get; set; }
        }

        public class AppConfigEntity
        {
            public bool UseSauceLabs { get; private set; }
            public List<string> Capabilities { get; private set; }
            public string InitUrl { get; private set; }
            public int ElementLoadWaitTime { get; private set; }
            public int SeleniumCommandWaitTime { get; private set; }
            public string BuildName { get; private set; }
            public string SauceRemoteDriverUri { get; private set; }
            public string SeleniumGridDriverUri { get; private set; }
            public bool UseSeleniumGrid { get; private set; }
            public bool OutputResultsToFile { get; private set; }
            public bool OutputResultsToConsole { get; private set; }
            public string SL_Tunnel { get; private set; }
        }

        public class BrowserConfigEntity
        {
            public string Browser { get; set; }
            public string Version { get; set; }
            public string Platform { get; set; }
            public bool IsEnabled { get; set; }
        }
    }
}
