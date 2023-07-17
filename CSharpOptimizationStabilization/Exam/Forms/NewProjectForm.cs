using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Exam
{
    public class NewProjectForm : Form
    {
        public NewProjectForm() : base(By.ClassName("modal-content"), "Add project")
        {
        }
        private ITextBox NewProjectName => ElementFactory.GetTextBox(By.Id("projectName"), "Name of a new project");
        private IButton SaveProjectButton => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "Save project");
        private ILabel ProjectSavedAlert => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'alert-success')]"), "Successfull creation indication");

        public void CreateNewProject(string name)
        {
            NewProjectName.ClearAndType(name);
            SaveProjectButton.Click();
        }

        public bool IsAlertExist()
        {
            return ProjectSavedAlert.State.WaitForDisplayed();
        }
    }
}
