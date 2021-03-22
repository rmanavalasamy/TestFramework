using iTextSharp.text.pdf.parser;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Threading;

namespace TestFramework.Utility
{
    public class FileHandling
    {
        IWebDriver driver;

        #region constructor
        public FileHandling(IWebDriver _driver)
        {
            driver = _driver;
        }
        #endregion

        #region Variable_Declarations

        //public static AutoItX auto = new AutoIt();

        #endregion

        #region .pdf_File_Opeartions

        //public static void DownloadPDFfile()
        //{
        //    try
        //    {
        //        switch (Configurations.browserName.ToLower())
        //        {
        //            case "chrome":
        //                // auto.Send("^{TAB}");    
        //                //Actions action = new Actions(Global.driver);
        //                //action.SendKeys(Keys.Control + "t").Build().Perform();
        //                Thread.Sleep(3000);
        //                auto.Send("^s");
        //                Thread.Sleep(5000);
        //                auto.ControlClick("Save As", "", "[CLASS:Button; INSTANCE:1]");
        //                auto.Sleep(5000);
        //                break;
        //            case "firefox":
        //                driver.FindElement(By.XPath("//*[@id='download']")).Click();
        //                Thread.Sleep(5000);
        //                string title = auto.WinGetTitle("[ACTIVE]");
        //                auto.Send("{ENTER}");
        //                Thread.Sleep(5000);
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch { throw; }

        //}
        public static void DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch { throw; }
        }
        public static string ReadPdfFile(string filePath)
        {
            try
            {
                StringBuilder text = new StringBuilder();

                if (File.Exists(filePath))
                {
                    iTextSharp.text.pdf.PdfReader pdfReader = new iTextSharp.text.pdf.PdfReader(filePath);

                    for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                    {
                        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                        string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                        currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                        text.Append(currentText);
                    }
                    pdfReader.Close();
                }
                return text.ToString();
            }
            catch { throw; }
        }
        public static string ExtractTextFromPdf(string filePath)
        {
            try
            {
                ITextExtractionStrategy its = new LocationTextExtractionStrategy();

                using (iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(filePath))
                {
                    StringBuilder text = new StringBuilder();

                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        string thePage = PdfTextExtractor.GetTextFromPage(reader, i, its);
                        string[] theLines = thePage.Split('\n');
                        foreach (var theLine in theLines)
                        {
                            text.AppendLine(theLine);
                        }
                    }
                    return text.ToString();
                }
            }
            catch { throw; }
        }

        #endregion

        #region File_Upload

        //public static void UploadFile(string fileName, string option = "")
        //{
        //    try
        //    {
        //        //** path for accessing files from project folder **//
        //        string pathProjectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        //        string filepath = System.IO.Path.Combine(pathProjectFolder, @"TestFiles\", fileName);

        //        //** path for accessing file from bin\Debug folder **//
        //        // string filepath = System.IO.Path.Combine(Environment.CurrentDirectory, @"TestFiles\", fileName); 

        //        auto.ControlFocus("Open", "", "Edit1");
        //        Thread.Sleep(10000);
        //        auto.ControlSetText("Open", "", "Edit1", filepath);
        //        Thread.Sleep(5000);
        //        switch (option)
        //        {
        //            case "Open":
        //                auto.ControlClick("Open", "", "Button1");
        //                break;
        //            case "Cancel":
        //                auto.ControlClick("Open", "", "Button2");
        //                break;
        //            default:
        //                auto.ControlClick("Open", "", "Button1");
        //                break;
        //        }

        //        auto.Sleep(10000);
        //    }
        //    catch { throw; }
        //}

        #endregion

        #region Excel_File_Operations

        //public static void ExportToExcel()
        //{
        //    try
        //    {
        //        switch (ConfigurationManager.AppSettings["browser"].ToString())
        //        {
        //            case "CHROME":
        //                break;
        //            case "FIREFOX":
        //                string title = auto.WinGetTitle("[ACTIVE]");
        //                auto.WinActivate(title);
        //                auto.Send("{ENTER}");
        //                Thread.Sleep(5000);
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch { throw; }

        //}

        public static void DeleteAllAvailableFiles(string filePath)
        {
            try
            {
                string[] Files = Directory.GetFiles(filePath);

                foreach (string file in Files)
                {
                    File.Delete(file);
                }
            }
            catch { throw; }
        }

        public static void DeleteExcelFileNameContainsCertainWord(string filePath, string fileName, string fileType)
        {
            try
            {
                string[] Files = Directory.GetFiles(filePath);

                foreach (string file in Files)
                {
                    if (file.Contains(fileName) && file.Contains(fileType))
                    {
                        File.Delete(file);
                    }
                }
            }
            catch { throw; }
        }

        public static void VerifyFileExistsWithCertainWord(string filePath, string filename, string fileType)
        {
            try
            {
                Thread.Sleep(10000);
                string[] Files = Directory.GetFiles(filePath);

                List<string> objDAReport = new List<string>();

                foreach (string file in Files)
                {
                    if (file.Contains(filename) && file.Contains(fileType))
                    {
                        objDAReport.Add(file);
                    }
                }

                if (objDAReport.Count == 1)
                {
                    Assert.IsTrue(true, "File Exists");
                }
                else
                {
                    Assert.Fail("File Doesn't Exists");
                }
            }
            catch { throw; }
        }

        public static bool IsFileExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
