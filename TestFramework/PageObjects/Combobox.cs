using OpenQA.Selenium;
using System.Threading;
using TechTalk.SpecFlow;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions
{
    [Binding]
    public class Combobox
    {
        #region locators
        private static string _cboFieldOnModal = "//h2[text()='{0}']//following::label[text()='{1}']/following::input[@role='combobox'][1]";
        private static string _cboItemFieldOnModal = "//li[contains(@class,'listbox__item') and contains(.,'{0}')][1]";
        private static string _cboItemNewOnModal = "//span[@title='{0}' and contains(text(),'{1}')][1]";
        #endregion

        #region Methods
        public static void SelectFromComboBoxOnModalPopup(string fieldName, string value, string modal)
        {
            if(value == "New Account")
            {
                SeleniumOperations.SelectFromSuggestionWithAction(By.XPath(string.Format(_cboFieldOnModal, modal, fieldName)), By.XPath(string.Format(_cboItemNewOnModal, value, value)), value);
            }
            else
            {
                SeleniumOperations.SelectFromSuggestionWithAction(By.XPath(string.Format(_cboFieldOnModal, modal, fieldName)), By.XPath(string.Format(_cboItemFieldOnModal, value)), value);
            }
            Thread.Sleep(1000);
        }
        #endregion

    }
}
