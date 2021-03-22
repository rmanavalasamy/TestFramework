using System;
using TechTalk.SpecFlow;
using TestFramework.PageObjects;
using TestFramework.Utility;

namespace TestFramework.StepDefinitions
{
    [Binding]
    public class FileHandlingStepDef
    {
        string filepath = @"C:\Users\" + Environment.UserName + @"\Downloads";

        #region Click_File_Upload_Control

        [When(@"I click ""(.*)"" file upload button control")]
        public void WhenIClickFileUploadButtonControlOnModalPopup(string fieldName)
        {
            try
            {
                FileUpload.ClickFileUploadButton(fieldName);
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }

        [When(@"I click ""(.*)"" file upload button control on ""(.*)"" modal popup")]
        public void WhenIClickFileUploadButtonControlOnModalPopup(string fieldName, string modalName)
        {
            try
            {
                FileUpload.ClickFileUploadButton(fieldName, modalName);
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }

        #endregion

        #region Upload_File

        [When(@"I will select ""(.*)"" file and select ""(.*)"" option")]
        public void WhenIWillSelectFileAndSelectOption(string fileName, string option)
        {
            try
            {
                //FileHandling.UploadFile(fileName, option);
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }


        [When(@"I will upload ""(.*)"" image file")]
        public void WhenIWillUploadImageFile(string fileName)
        {
            try
            {
                FileUpload.UploadImageFile(fileName);
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }

        #endregion

        #region Delete_All_Available_Files_From_Downloads_Folder

        [When(@"I delete all available files")]
        public void WhenIDeleteAllAvailableFiles()
        {
            try
            {
                FileHandling.DeleteAllAvailableFiles(filepath);
            }
            catch (Exception ex)
            {
                ExceptionHandling.HandleException(ex);
            }
        }

        #endregion

    }
}
