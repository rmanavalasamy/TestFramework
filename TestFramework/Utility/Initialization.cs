using Microsoft.Edge.SeleniumTools;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestFramework.Utility
{
    public class Initialization
    {
        #region Variables
        public static IWebDriver driver;
        private static WebDriverWait _wait;
        private static RemoteWebDriver _remoteDriver;
        #endregion

        #region WebDriver initilization methods
        public static IWebDriver InitDriver()
        {
            Configurations.ReadConfig();
            string driversDir = Configurations.driversBaseDirectory;
            bool useIngognitoMode = Configurations.useIngognitoMode;
            bool deleteCookies = Configurations.deleteCookies;

            switch (Configurations.browserName.ToLower())
            {
                case "chrome":                 
                    var chromeCaps = new ChromeOptions();
                    chromeCaps.AddArgument("--disable-notifications");
                    if (useIngognitoMode)
                    {
                        chromeCaps.AddArgument("--incognito");
                    }
                    driver = new ChromeDriver(chromeCaps);
                    break;
                case "firefox":
                    //FirefoxDriverService fService = FirefoxDriverService.CreateDefaultService(driversDir);
                    driver = new FirefoxDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
                case "edge":
                    var options = new EdgeOptions();                  
                    options.UseChromium = true;
                    if (useIngognitoMode)
                    {
                        options.AddArgument("-inprivate");
                    }
                    driver = new EdgeDriver(driversDir, options);
                    break;
            }
            SetWaitTime(driver);
            if (deleteCookies)
            {
                driver.Manage().Cookies.DeleteAllCookies();
            }            
            driver.Manage().Window.Maximize();
            return driver;
        }

        public IWebDriver InitDriver(string remoteURL)
        {
            Configurations.ReadConfig();
            string driversDir = Configurations.driversBaseDirectory;
            bool useIngognitoMode = Configurations.useIngognitoMode;
            bool deleteCookies = Configurations.deleteCookies;

            switch (Configurations.browserName.ToLower())
            {
                case "chrome":
                    var Chromecaps = new ChromeOptions();
                    Chromecaps.PlatformName = "LINUX";
                    Chromecaps.BrowserVersion = "87";
                    _remoteDriver = new RemoteWebDriver(new Uri(remoteURL), Chromecaps);
                    break;
                case "firefox":
                    var firefoxCaps = new FirefoxOptions();
                    firefoxCaps.PlatformName = "Windows 10";
                    firefoxCaps.BrowserVersion = "77";
                    _remoteDriver = new RemoteWebDriver(new Uri(remoteURL), firefoxCaps);
                    break;
                case "ie":
                    var IECaps = new InternetExplorerOptions();
                    IECaps.PlatformName = "Windows 10";
                    IECaps.BrowserVersion = "77";
                    _remoteDriver = new RemoteWebDriver(new Uri(remoteURL), IECaps);
                    break;
            }
            SetWaitTime(driver);
            driver.Manage().Window.Maximize();
            return driver;
        }
        #endregion

        #region WebDriver wait methods
        public static void SetWaitTime(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Configurations.driverWaitTime);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Configurations.explicitWaitTime));
        }
        #endregion
    }
}
