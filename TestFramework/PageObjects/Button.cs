using OpenQA.Selenium;
using TestFramework.Constants;
using TestFramework.Utility;

namespace TestFramework.PageObjects
{
    public class Button
    {
        #region Locators
        private static string _btnField = "//button[contains(.,'{0}')]";
        private static string _btnWithValueProperty = "(//*[@value='{0}'])[1]";
        private static string _btnWithIdProperty = "(//*[@id='{0}'])[1]";
        private static string _btnLnkWithDataLabel = "//a[contains(@data-label,'{0}')]";
        private static string _btnWithLnkTitle = "(//a[@title='{0}'])[1]";
        private static string _btnWithTextOnModal = "//h2[text()='{0}']//following::button[text()='{1}'][1]";
        private static string _btnWithTitleOnModal = "//h2[text()='{0}']//following::button[@title='{1}'][1]";
        private static string _btnWithText = "(//*[text()='{0}'])[1]";
        #endregion

        #region Operations

        #region Click
        public static void ClickButtonWithValueProperty(string fieldName)
        {
            SeleniumOperations.ClickOnObject(By.XPath(string.Format(_btnWithValueProperty, fieldName)));
        }
        public static void ClickButtonWithIdProperty(string idName)
        {
            SeleniumOperations.ClickOnObject(By.XPath(string.Format(_btnWithIdProperty, idName)));
        }
        public static void ClickButton(string fieldName)
        {
            SeleniumOperations.ClickOnObject(By.XPath(string.Format(_btnField, fieldName)));
        }

        public static void ClickButtonWithDataLabelProperty(string value)
        {
 
            SeleniumOperations.ClickOnObject(By.XPath(string.Format(_btnLnkWithDataLabel, value)));
        }

        public static void ClickButtonWithTextProperty(string value)
        {
            SeleniumOperations.ClickOnObject(By.XPath(string.Format(_btnWithText, value)));
        }

        public static void ClickOnButtonOnModalPopup(string fieldName,string modal)
        {
            if (modal == CRUSH_ApplicationConstans.newAccountModal)
            {
                SeleniumOperations.ClickOnObjectWithAction(By.XPath(string.Format(_btnWithTitleOnModal, modal, fieldName)));
            }
            else
            {
                SeleniumOperations.ClickOnObjectWithAction(By.XPath(string.Format(_btnWithTextOnModal, modal, fieldName)));
            }
        }

        public static void ClickOnLinkButtonWithTitle(string title)
        {
            try
            {
                SeleniumOperations.ClickOnObject(By.XPath(string.Format(_btnWithLnkTitle, title)));
            }
            catch { throw; }
        }

        #endregion

        #region Verification
        public static void VerifyButtonState(string fieldName, string mode)
        {
            By by = By.XPath(string.Format(_btnField, fieldName));
            SeleniumOperations.VerifyFieldState(by, mode);
        }
        #endregion

        #endregion
    }
}
