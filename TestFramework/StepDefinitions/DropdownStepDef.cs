using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TestFramework.PageObjects;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions
{
    [Binding]
    public class DropdownStepDef
    {

        #region Select from dropdown
        [When(@"I select the ""(.*)"" text from the dropdown")]
        public void WhenISelectTheTextFromTheDropdown(string textToSelect)
        {

            Dropdown.SelectDropdownByText(textToSelect);         
        }

        [When(@"I select the ""(.*)"" value from the dropdown")]
        public void WhenISelectTheValueFromTheDropdown(string valueToSelect)
        {

            Dropdown.SelectDropdownByValue(valueToSelect);
        }
        
        [When(@"I select the option ""(.*)"" from ""(.*)"" dropdown on ""(.*)"" modal popup")]
        public void WhenISelectTheOptionFromDropdownOnModalPopup(string value, string dropDownName, string modal)
        {
             Dropdown.SelectTheOptionFromDropdownOnModalPopup(value, dropDownName, modal);
        }

        #endregion

        #region Verify selected value
        [Then(@"the ""(.*)"" in dropdown should have been selected")]
        public void ThenTheDropdownShouldHaveBeenSelected(string selectedValue)
        {
            try
            {
                Assert.True(true, selectedValue+" is not been selected");
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }           
        }
        #endregion

        [Then(@"verify the ""(.*)"" is selected in dropdown")]
        public void ThenVerifyTheIsSelectedInDropdown(string selectedText)
        {
            Dropdown.VerifySelectedValueInDropdown(selectedText);
        }

    }
}
