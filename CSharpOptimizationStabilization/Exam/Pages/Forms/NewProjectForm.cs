using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

//The correct namespace name must be specified where each file is located.
//Fix similar cases in other places.
namespace Exam.Pages.Forms
{
    public class NewProjectForm : Form
    {
        //Fix similar cases in other places.
        //The name of the fields must end with the element type Page Object
        private ITextBox NewProjectNameTextBox => ElementFactory.GetTextBox(By.Id("projectName"), "Name of a new project");
        private IButton SaveProjectButton => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "Save project");
        private ILabel ProjectSavedAlertLabel => ElementFactory.GetLabel(By.XPath("//div[contains(@class,'alert-success')]"), "Successfull creation indication");

        public NewProjectForm() : base(By.ClassName("modal-content"), "Add project")
        {
        }

        //Fix similar cases in other places.
        /*
         * The method should perform only one action. It is necessary to break down simple steps into separate methods.
         */
        public void CreateNewProject(string name)
        {
            SetNewProjectName(name);
            SaveProject();
        }

        public void SetNewProjectName(string name)
        {
            NewProjectNameTextBox.ClearAndType(name);
        }

        public void SaveProject()
        {
            SaveProjectButton.Click();
        }

        public bool IsAlertExist()
        {
            return ProjectSavedAlertLabel.State.WaitForDisplayed();
        }
    }
}
