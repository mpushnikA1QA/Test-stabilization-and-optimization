using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Exam
{
    public class NewTestForm : Form
    {
        public NewTestForm() : base(By.Id("title"), "Add test")
        {

        }
        public static TestModel TestModel = new();
        private ITextBox TestNameTextBox => ElementFactory.GetTextBox(By.Id("testName"), "New test name");
        private ITextBox TestMethodTextBox => ElementFactory.GetTextBox(By.Id("testMethod"), "New test method");
        private ITextBox EnvironmentTextBox => ElementFactory.GetTextBox(By.Id("environment"), "New test env");
        private ITextBox BrowserTextBox => ElementFactory.GetTextBox(By.Id("browser"), "New test browser");
        private ITextBox StartTimeTextBox => ElementFactory.GetTextBox(By.Id("startTime"), "New test start time");
        private ITextBox EndTimeTextBox => ElementFactory.GetTextBox(By.Id("endTime"), "New test end time");
        private IButton AttachmentButton => ElementFactory.GetButton(By.Id("attachment"), "Upload dialog");
        protected internal IButton SaveTestButton => ElementFactory.GetButton(By.XPath("//form[@id='addTestForm']/button[contains(@class,'primary')]"), "Save test");
        private ILabel TestSavedLabel => ElementFactory.GetLabel(By.Id("success"), "Test saved");

        public void FillTestNameField()
        {
            TestNameTextBox.ClearAndType(TestModel.TestName);
        }

        public void FillTestMethodField()
        {
            TestMethodTextBox.ClearAndType(TestModel.TestMethod);
        }

        public void FillEnvironmentField()
        {
            EnvironmentTextBox.ClearAndType(TestModel.Environment);
        }

        public void FillBrowserField()
        {
            BrowserTextBox.ClearAndType(TestModel.Browser);
        }

        public void FillStartTimeField()
        {
            StartTimeTextBox.ClearAndType(TestModel.StartTime);
        }

        public void FillEndTimeField()
        {
            EndTimeTextBox.ClearAndType(TestModel.EndTime);
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
