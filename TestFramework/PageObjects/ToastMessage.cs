using OpenQA.Selenium;
using System.Threading;
using TestFramework.Utility;

namespace TestFramework.PageObjects
{
    public class ToastMessage
    {
        private static string _toastWithRole = "//div[@role='alert']";

        public static bool IsToastAlertDisplayed()
        {
            try
            {
                bool status = SeleniumOperations.IsObjectDisplayed(By.XPath(_toastWithRole));
                Thread.Sleep(3000);
                return status;
            }
            catch { throw; }
        }        
    }
}
