using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Exam.Pages.Forms;
using Exam.Utility;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Exam.Pages
{
    public class ProjectsPage : Form
    {
        private const int NameLenght = 5;

        public NewProjectForm NewProjectForm { get; private set; } = new();

        //The locator doesn't look reliable.we need to make sure that there is a better option.
        //Fix similar cases in other places.
        private ILabel FooterVersionLabel => ElementFactory.GetLabel(By.XPath("//p[contains(@class,'footer-text')]/span"), "Version text");

        //The locator doesn't look reliable.we need to make sure that there is a better option.
        //Fix similar cases in other places.
        private ILink NexageLink => ElementFactory.GetLink(By.XPath("//a[substring(@href, string-length(@href) - string-length('projectId=1') + 1)  = 'projectId=1']"), "Nexage");
        private IButton AddProjectButton => ElementFactory.GetButton(By.XPath("//button[contains(@class,'pull-right')]"), "New project");
        private IList<ILabel> ProjectListOfLabels => ElementFactory.FindElements<ILabel>(By.XPath("//a[contains(@href,'allTests?projectId')]"), "All project");

        public ProjectsPage() : base(By.Id("addProject"), "Projects")
        {
        }

        // The method does only one action. First get the text. And what would the correct text take out in Assert
        public bool IsVersionCorrect(string variant)
        {
            return FooterVersionLabel.GetText().Contains(variant);
        }

        public void GoToNexage()
        {
            NexageLink.ClickAndWait();
        }

        //The method does only one action. First get the text. I would divide it into a few simple steps
        public string CreateNewProject()
        {
            AddProjectButton.Click();
            string name = RandomTextGenerator.Generate(NameLenght);
            NewProjectForm.CreateNewProject(name);
            return name;
        }

        //This code looks like some generic code. I would put it in the base class, or in the browser utils class.
        public void CloseNewProjectPopUp()
        {
            AqualityServices.Browser.ExecuteScript($"document.getElementById('{Locator.Criteria.Substring(1)}').setAttribute('style', 'display: none;')");
        }

        // The method does only one action. I would divide it into a few simple steps
        // What the new test present would bring to the test (Assert)
        public bool IsNewProjectInList(string newProjectName)
        {
            bool flag = false;
            foreach (var item in ProjectListOfLabels)
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
            //In page object, you should put the elements as a separate field of the class.
            AqualityServices.Browser.Driver.FindElement(By.XPath($"//a[@href='allTests?projectId={ProjectListOfLabels.Count}']")).Click();
        }

        public bool IsNewProjectFormDisplayed()
        {
            return NewProjectForm.State.IsDisplayed;
        }
    }
}
