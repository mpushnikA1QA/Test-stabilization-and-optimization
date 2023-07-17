using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Exam
{
    public class ProjectsPage : Form
    {
        private const int NameLenght = 5;
        public ProjectsPage() : base(By.Id("addProject"), "Projects")
        {
        }
        public NewProjectForm NewProjectForm { get; private set; } = new();
        private ILabel FooterVersion => ElementFactory.GetLabel(By.XPath("//p[contains(@class,'footer-text')]/span"), "Version text");
        private ILink NexageLink => ElementFactory.GetLink(By.XPath("//a[substring(@href, string-length(@href) - string-length('projectId=1') + 1)  = 'projectId=1']"), "Nexage");
        private IButton AddProject => ElementFactory.GetButton(By.XPath("//button[contains(@class,'pull-right')]"), "New project");
        private IList<ILabel> ProjectList => ElementFactory.FindElements<ILabel>(By.XPath("//a[contains(@href,'allTests?projectId')]"), "All project");

        public bool IsVersionCorrect(string variant)
        {
            return FooterVersion.GetText().Contains(variant);
        }

        public void GoToNexage()
        {
            NexageLink.ClickAndWait();
        }

        public string CreateNewProject()
        {
            AddProject.Click();
            string name = RandomTextGenerator.Generate(NameLenght);
            NewProjectForm.CreateNewProject(name);
            return name;
        }

        public void CloseNewProjectPopUp()
        {
            AqualityServices.Browser.ExecuteScript($"document.getElementById('{Locator.Criteria.Substring(1)}').setAttribute('style', 'display: none;')");
        }

        public bool IsNewProjectInList(string newProjectName)
        {
            bool flag = false;
            foreach (var item in ProjectList)
            {
                if (item.GetText().Contains(newProjectName))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public void GoToNewProject()
        {
            AqualityServices.Browser.Driver.FindElement(By.XPath($"//a[@href='allTests?projectId={ProjectList.Count}']")).Click();
        }

        public bool IsNewProjectFormDisplayed()
        {
            return NewProjectForm.State.IsDisplayed;
        }

    }
}
