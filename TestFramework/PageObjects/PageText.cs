using OpenQA.Selenium;
using TestFramework.Utility;

namespace TestFramework.PageObjects
{
    public class PageText
    {
        private static string _textField = "(//*[contains(.,'{0}')])";

        public static void VerifyPageTextDisplayed(string text)
        {
            try
            {
                 SeleniumOperations.VerifyFieldState(By.XPath(string.Format(_textField, text)), "displayed");
            }
            catch { throw; }
        }

    }
}
