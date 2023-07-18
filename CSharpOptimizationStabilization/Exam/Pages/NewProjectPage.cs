using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Exam.Pages.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Exam.Pages
{
    public class NewProjectPage : Form
    {
        //The name of the constants must be correct with camelCase
        //Fix similar cases in other places.
        private const int OffSetX = -100;
        private const int OffSetY = 0;

        public NewTestForm NewTestForm { get; private set; } = new();
        private IButton AddTestButton => ElementFactory.GetButton(By.XPath("//button[contains(@class,'pull-right')]"), "Add test");
        private ILabel ErrorExclamationLabel => ElementFactory.GetLabel(By.XPath("//span[contains(@class,'glyphicon-exclamation-sign')]"), "Exclamation sign glyph in error");
        private ILink NewTestLink => ElementFactory.GetLink(By.XPath("//a[contains(@href,'testInfo?testId')]"),"To a new test");

        public NewProjectPage() : base(By.Id("pie"), "New project")
        {
        }

        public void GoToTestForm()
        {
            AddTestButton.ClickAndWait();
        }

        public void ClickOffNewTestForm()
        {
            Actions action = new(AqualityServices.Browser.Driver);
            action.MoveToElement(AqualityServices.Browser.Driver.FindElement(NewTestForm.SaveTestButton.Locator)).MoveByOffset(OffSetX, OffSetY).Click().Perform();
        }

        public bool IsNewTestExists()
        {
            ErrorExclamationLabel.State.WaitForNotDisplayed();
            return AqualityServices.Browser.Driver.FindElement(By.XPath($"//td[contains(.,'{NewTestForm.TestModel.TestName}')]")).Displayed;
        }

        public void GoToNewTest()
        {
            NewTestLink.ClickAndWait();
        }

        /*This code is not needed here.
        public TestModel GetEnteredData()
        {
            return NewTestForm.TestModel;
        }*/
    }
}
