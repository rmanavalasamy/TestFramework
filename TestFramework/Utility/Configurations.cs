using Microsoft.Extensions.Configuration;
using System;

namespace TestFramework.Utility
{
    public class Configurations
    {
        public static string siteURL;
        public static string githubURL;
        public static string browserName;
        public static int driverWaitTime;
        public static int explicitWaitTime;
        public static string reportPath;
        public static string reportColour;
        public static string salesForceUserName;
        public static string salesForcePassword;
        public static bool deleteCookies;
        public static bool useIngognitoMode;
        public static string driversBaseDirectory = System.IO.Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "/../../../" + "WebDrivers");
      
        public static void ReadConfig()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appConfig.json").Build();
            siteURL = config.GetSection("BrowserConfig:Url").Value;
            browserName = config.GetSection("BrowserConfig:Browser").Value;
            driverWaitTime = Convert.ToInt32(config.GetSection("DriverConfig:ImplicitWaitTime").Value);
            explicitWaitTime = Convert.ToInt32(config.GetSection("DriverConfig:ExplicitWaitTime").Value);
            reportPath = config.GetSection("ReportConfig:ReportPath").Value;
            reportColour = config.GetSection("ReportConfig:ReportColour").Value;
            salesForceUserName = config.GetSection("Credentials:Salesforce:UserName").Value;
            salesForcePassword = config.GetSection("Credentials:Salesforce:Password").Value;
            deleteCookies = Convert.ToBoolean(config.GetSection("BrowserConfig:DeleteCookies").Value);
            useIngognitoMode = Convert.ToBoolean(config.GetSection("BrowserConfig:UseIngognitoMode").Value);
            
        }



    }
}
