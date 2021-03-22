using System;
using TechTalk.SpecFlow;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions
{
    [Binding]
    public class ComboboxSteps
    {

        [When(@"I search on ""(.*)"" combobox and select ""(.*)"" on ""(.*)"" modal popup")]
        public void WhenISearchOnComboboxAndSelect(string comboboxName, string value,string modal)
        {
            Combobox.SelectFromComboBoxOnModalPopup(comboboxName, value, modal);
        }
    }
}
