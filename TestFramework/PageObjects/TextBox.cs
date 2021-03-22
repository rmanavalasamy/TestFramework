using OpenQA.Selenium;
using TestFramework.Utility;

namespace TestFramework.PageObjects
{
    public class TextBox
    {
        #region locator variables
        private static string _txtField = "//*[contains(.,'{0}')]/following::input)[position()=1]";
        private static string _txtFieldWithPlaceHolderProperty = "//*[contains(@placeholder,'{0}')]";
        private static string _txtFieldWithIdProperty = "//*[@id='{0}']";
        private static string _txtFieldOnModal = "(//h2[contains(text(),'{0}')]//following::label[text()='{1}']/following::input[@type='text'])[1] ";
        private static string _txtFieldOnModal1 = "//h2[contains(text(),'{0}')]//following::span[text()='{1}']/following::input[@type='text'][1]";
        private static string _txtFieldSummaryOnModal = "//h2[text()='{0}']//following::div[contains(@class,'rich-text-area__content')]";
        #endregion

        #region Methods
        public static void EnterTheValueInTextboxOnModalPopup(string value, string textBoxName, string modal)
        {       
            if(modal == "New Account")
            {
                SeleniumOperations.EnterValueWithClearEnabled(By.XPath(string.Format(_txtFieldOnModal1, modal, textBoxName)), value);
            }
            else if (modal.ToLower().Contains("edit"))
            {
                SeleniumOperations.ClickAndEnterValueWithActionAndClearEnabled(By.XPath(string.Format(_txtFieldOnModal, modal, textBoxName)), value);
            }
            else
            {
                SeleniumOperations.EnterValueWithClearEnabled(By.XPath(string.Format(_txtFieldOnModal, modal, textBoxName)), value);
            }
        }


        public static void EnterTheValueInSummaryTextboxOnModalPopup(string value, string modal)
        {
            SeleniumOperations.ClickAndEnterValueWithAction(By.XPath(string.Format(_txtFieldSummaryOnModal, modal)), value);
        }


        public static void EnterValueInTextbox(string value, string fieldName)
        {
            SeleniumOperations.EnterValue(By.XPath(string.Format(_txtField, fieldName)), value);
        }

        public static void EnterValueInTextboxWithPlaceholder(string value, string placeholderTxt)
        {
            SeleniumOperations.EnterValue(By.XPath(string.Format(_txtFieldWithPlaceHolderProperty, placeholderTxt)), value);
        }
        public static void EnterValueInTextboxWithIdProperty(string value ,string Id)
        {
            SeleniumOperations.EnterValue(By.XPath(string.Format(_txtFieldWithIdProperty, Id)), value);
        }
        #endregion


    }
}
