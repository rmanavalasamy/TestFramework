using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestFramework.Utility;

namespace TestFramework.PageObjects
{   
    public class Dropdown
    {

        #region locators
        private static string _ddlField = "//select[@id='dropdown']";
        private static string _ddlStatusField = "(//h2[text()='{0}']//following::label[text()='{1}']/following::div/lightning-base-combobox[contains(@class,'combobox_container')])[1]";
        private static string _ddlStatusFieldOption = "(//lightning-base-combobox-item[@data-value='{0}' and @role='option'])[1]";
        #endregion

        #region Select from dropdown methods
        public static void SelectDropdownByValue(string value)
        {
            SeleniumOperations.SelectDropdownByValue(By.XPath(_ddlField), value);
        }

        public static void SelectDropdownByText(string fieldName)
        {
            SeleniumOperations.SelectDropdownByText(By.XPath(_ddlField), fieldName);
        }

        public static void VerifySelectedValueInDropdown(string selectedValue)
        {
            Assert.True(SeleniumOperations.IsDropdownValueSelected(By.XPath(string.Format(_ddlField, selectedValue)), selectedValue));
        }

        public static void SelectTheOptionFromDropdownOnModalPopup(string value, string dropDownName, string modal)
        {
            SeleniumOperations.ClickOnObject(By.XPath(string.Format(_ddlStatusField, modal, dropDownName)));
            Thread.Sleep(1500);
            SeleniumOperations.ClickOnObject(By.XPath(string.Format(_ddlStatusFieldOption, value)));
        }
        #endregion
    }
}
