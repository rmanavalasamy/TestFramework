using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestFramework.Utility;

namespace TestFramework.PageObjects.Specific_Page_Objects
{
    public class CRUSH_Navigation
    {
        private static string _waffleIcon = "//*[@role='navigation']/button";
        private static string _menuName = "//*[text()='{0}']";
        private static string _menuItemWithDataLabel = "//a[contains(@data-label,'{0}')]";
        
        public static void SearchAndNavigateToTheApp(string placeHolder,string appName)
        {
            SeleniumOperations.ClickOnObject(By.XPath(_waffleIcon));
            TextBox.EnterValueInTextboxWithPlaceholder(appName, placeHolder);
            Thread.Sleep(1500);
            SeleniumOperations.DoubleClickOnObject(By.XPath(string.Format(_menuItemWithDataLabel, appName)));
            Thread.Sleep(8500);
        }

        public static void ClickMenuOnTopNavigationBar(string menu)
        {

           SeleniumOperations.ClickOnObjectWithAction(By.XPath(String.Format(_menuName, menu)));
        }

    }
}
