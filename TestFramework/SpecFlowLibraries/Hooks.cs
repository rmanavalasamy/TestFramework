using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using log4net;
using OpenQA.Selenium;
using System;
using System.Reflection;
using TechTalk.SpecFlow;
using TestFramework.Utility;

namespace TestFramework.SpecFlowLibraries
{
    [Binding]
    public class Hooks
    {
        #region Variables
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        public static IWebDriver driver;
        #endregion
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
       

        #region SpecFlow Hook Methods
        #region Before Test Run
        [BeforeTestRun]
        public static void InitializeReport()
        {
            //var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            //XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            //Read configrations
            Configurations.ReadConfig();
            string reportColour = Configurations.reportColour;
            string reportPath = Configurations.reportPath;

            //Set report path
            string pathString = null;
            if (reportPath == "Default")
            {
                string folderName = System.IO.Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "/../../../"
                       + "Reports");
                pathString = System.IO.Path.Combine(folderName, "Report_" + DateTime.Now.ToString("ddMMyy_HHmmss"));
                System.IO.Directory.CreateDirectory(pathString);       
            }
            else
            {
                pathString = System.IO.Path.Combine(reportPath, "Report_" + DateTime.Now.ToString("ddMMyy_HHmmss")); ;
            }

            var htmlReporter = new ExtentHtmlReporter(pathString+"\\ExtentReport.html");

            //Set report colour
            if (reportColour == "Dark")
            {
                htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            }
            else if (reportColour == "White" || reportColour == "Standard")
            {
                htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            }

            //Attach report to reporter
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        #endregion

        #region After Test Run
        [AfterTestRun]
        public static void TearDownReport()
        {
           
            //Flush report once test completes
            extent.Flush();
        }
        #endregion

        #region Before Feature
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }
        #endregion

        #region After Step
        [AfterStep]
        public static void InsertReportingSteps(ScenarioContext scenarioContext)
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (scenarioContext.TestError == null)
            {
                var mediaEntity = SeleniumOperations.CaptureScreenshotAndReturnString(scenarioContext.ScenarioInfo.Title.Trim());

                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass("Passed", mediaEntity);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass("Passed", mediaEntity);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass("Passed", mediaEntity);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Pass("Passed", mediaEntity);
            }
            else if (scenarioContext.TestError != null)
            {
                var mediaEntity = SeleniumOperations.CaptureScreenshotAndReturnString(scenarioContext.ScenarioInfo.Title.Trim());

                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.InnerException, mediaEntity);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.InnerException, mediaEntity);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.InnerException, mediaEntity);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.InnerException, mediaEntity);
            }

        }
        #endregion

        #region Before Scenario
        [BeforeScenario]
        public static void Initialize(ScenarioContext scenarioContext)
        {            
            driver = Initialization.InitDriver();
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }
        #endregion

        #region After Scenario
        [AfterScenario]
        public static void CleanUp()
        {          
            SeleniumOperations.Quitdriver();
        }
        #endregion
        #endregion
    }
}
