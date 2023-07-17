using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Exam
{
    public class NewProjectPage : Form
    {
        private const int offsetX = -100;
        private const int offsetY = 0;
        public NewProjectPage() : base(By.Id("pie"), "New project")
        {
        }
        public NewTestForm NewTestForm { get; private set; } = new();
        private IButton AddTestButton => ElementFactory.GetButton(By.XPath("//button[contains(@class,'pull-right')]"), "Add test");
        private ILabel ErrorExclamationLabel => ElementFactory.GetLabel(By.XPath("//span[contains(@class,'glyphicon-exclamation-sign')]"), "Exclamation sign glyph in error");
        private ILink NewTestlink => ElementFactory.GetLink(By.XPath("//a[contains(@href,'testInfo?testId')]"),"To a new test");

        public void GoToTestForm()
        {
            AddTestButton.ClickAndWait();
        }

        public void ClickOffNewTestForm()
        {
            Actions action = new(AqualityServices.Browser.Driver);
            action.MoveToElement(AqualityServices.Browser.Driver.FindElement(NewTestForm.SaveTestButton.Locator)).MoveByOffset(offsetX, offsetY).Click().Perform();
        }

        public bool IsNewTestExists()
        {
            ErrorExclamationLabel.State.WaitForNotDisplayed();
            return AqualityServices.Browser.Driver.FindElement(By.XPath($"//td[contains(.,'{NewTestForm.TestModel.TestName}')]")).Displayed;
        }

        public void GoToNewTest()
        {
            NewTestlink.ClickAndWait();
        }

        public TestModel GetEnteredData()
        {
            return NewTestForm.TestModel;
        }
    }
}
