using OpenQA.Selenium;
using TestFramework.Utility;

namespace TestFramework.PageObjects
{
    public class Link
    {
        #region locators
        private static string _lnkField = "(//a[contains(.,'{0}')])[1]";
        #endregion

        #region click link methods
        public static void ClickOnLinkByText(string fieldName)
        {
            SeleniumOperations.ClickOnObject(By.XPath(string.Format(_lnkField, fieldName)));      
        }
        #endregion

        #region verification methods
        public static bool IsLinkDisplayed(string fieldName)
        {
            return SeleniumOperations.IsObjectDisplayed(By.XPath(string.Format(_lnkField, fieldName)));
        }
        #endregion

    }
}
