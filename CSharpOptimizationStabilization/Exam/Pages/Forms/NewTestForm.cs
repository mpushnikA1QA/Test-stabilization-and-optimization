using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Exam.DataModels;
using OpenQA.Selenium;

//The correct namespace name must be specified where each file is located.
//Fix similar cases in other places.
namespace Exam.Pages.Forms
{
    public class NewTestForm : Form
    {
        //It is better to pass test data as a parameter to the class or to method. To make the logic more flexible.
        private ITextBox TestNameTextBox => ElementFactory.GetTextBox(By.Id("testName"), "New test name");
        private ITextBox TestMethodTextBox => ElementFactory.GetTextBox(By.Id("testMethod"), "New test method");
        private ITextBox EnvironmentTextBox => ElementFactory.GetTextBox(By.Id("environment"), "New test env");
        private ITextBox BrowserTextBox => ElementFactory.GetTextBox(By.Id("browser"), "New test browser");
        private ITextBox StartTimeTextBox => ElementFactory.GetTextBox(By.Id("startTime"), "New test start time");
        private ITextBox EndTimeTextBox => ElementFactory.GetTextBox(By.Id("endTime"), "New test end time");
        private IButton AttachmentButton => ElementFactory.GetButton(By.Id("attachment"), "Upload dialog");
        protected internal IButton SaveTestButton => ElementFactory.GetButton(By.XPath("//form[@id='addTestForm']/button[contains(@class,'primary')]"), "Save test");
        private ILabel TestSavedLabel => ElementFactory.GetLabel(By.Id("success"), "Test saved");

        public NewTestForm() : base(By.Id("title"), "Add test")
        {

        }

        public void FillAllTestData(TestModel testModel)
        {
            FillTestNameField(testModel.TestName);
            FillTestMethodField(testModel.TestMethod);
            FillEnvironmentField(testModel.Environment);
            FillBrowserField(testModel.Browser);
            FillStartTimeField(testModel.StartTime);
            FillEndTimeField(testModel.EndTime);
        }

        public void FillTestNameField(string testName)
        {
            TestNameTextBox.ClearAndType(testName);
        }

        public void FillTestMethodField(string testMethod)
        {
            TestMethodTextBox.ClearAndType(testMethod);
        }

        public void FillEnvironmentField(string environment)
        {
            EnvironmentTextBox.ClearAndType(environment);
        }

        public void FillBrowserField(string browser)
        {
            BrowserTextBox.ClearAndType(browser);
        }

        public void FillStartTimeField(string startTime)
        {
            StartTimeTextBox.ClearAndType(startTime);
        }

        public void FillEndTimeField(string endTime)
        {
            EndTimeTextBox.ClearAndType(endTime);
        }

        public void UploadScreenshot(string path)
        {
            AttachmentButton.SendKeys(path);
        }

        public void SaveTest()
        {
            SaveTestButton.ClickAndWait();
        }

        public bool IsTestSavedMessageAppeared()
        {
            return TestSavedLabel.State.WaitForDisplayed();
        }
    }
}
