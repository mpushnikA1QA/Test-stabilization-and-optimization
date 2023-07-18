using Aquality.Selenium.Browsers;
using Exam.DataModels;
using Exam.Pages;
using Exam.Utility;
using NUnit.Framework;

namespace Exam
{
    public class Tests
    {
        private readonly ConfigData ConfigData = new();
        private readonly TestData TestData = new();
        private const string Http = "http://";
        private const string CookieName = "token";
        //It is better to transmit test data as an external parameter. To have access from all places in the test to this data.
        private readonly TestModel testModel = new();

        //It is better to create page objects instances right away
        private readonly ProjectsPage projectsPage = new();
        private readonly NexagePage nexagePage = new();
        private readonly NewProjectPage newProjectPage = new();
        private readonly TestInfoPage testInfoPage = new();

        [SetUp]
        public void Setup()
        {
            AqualityServices.Browser.Maximize();
        }

        [Test]
        public void Test1()
        {
            string token = API_TokenCreator.GenerateToken(ConfigData.API_URL, TestData.Variant).Result;
            Assert.IsNotNull(token, "Token was not generated");
            AqualityServices.Browser.GoTo($"{Http}{TestData.Username}:{TestData.Password}@{ConfigData.URL}");
            AqualityServices.Browser.WaitForPageToLoad();
            Assert.IsTrue(projectsPage.State.WaitForExist(), "Projects page is not open");
            AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(CookieName, token));
            AqualityServices.Browser.Refresh();
            Assert.IsTrue(projectsPage.IsVersionCorrect(TestData.Variant), "Variant in a footer doesn't equal to actual variant value");
            projectsPage.GoToNexage();
            Assert.IsTrue(nexagePage.AreDatesSortedInDescendingOrder(), "Tests on the first page of the table are sorted not in ascending order");
            AqualityServices.Browser.GoBack();
            var newProjectName = projectsPage.CreateNewProject();
            Assert.IsTrue(projectsPage.NewProjectForm.IsAlertExist(), "Success message did not appear");
            projectsPage.CloseNewProjectPopUp();
            Assert.IsFalse(projectsPage.IsNewProjectFormDisplayed(), "The Add Project window did not close");
            AqualityServices.Browser.Refresh();
            Assert.IsTrue(projectsPage.IsNewProjectInList(newProjectName), "New project did not appeared in a list");
            // For all transitions to new pages, I would add checks that there really was a transition to a specific page or the form is open
            projectsPage.GoToNewProject();
            newProjectPage.GoToTestForm();
            newProjectPage.NewTestForm.FillAllTestData(testModel);
            var screenshotPath = ScreenshotCreator.TakePngScreenshot();
            newProjectPage.NewTestForm.UploadScreenshot(screenshotPath);
            newProjectPage.NewTestForm.SaveTest();
            Assert.IsTrue(newProjectPage.NewTestForm.IsTestSavedMessageAppeared(), "Successful save message did not appeared");
            newProjectPage.ClickOffNewTestForm();
            // For all transitions to new pages, I would add checks that there really was a transition to a specific page or the form is open
            Assert.IsTrue(newProjectPage.IsNewTestExists(),"New test is not appeared");
            newProjectPage.GoToNewTest();
            // For all transitions to new pages, I would add checks that there really was a transition to a specific page or the form is open
            Assert.IsTrue(testModel.Equals(testInfoPage.GetCreatedTestModel()),"Data on a test info page don't correspond with data that was entered when test was created");
            Assert.IsTrue(testInfoPage.IsPictureCorresponds(screenshotPath), "Picture on test info page is not equal to picture that was uploaded");
        }

        [TearDown]
        public void TearDown()
        {
            AqualityServices.Browser.Quit();
        }
    }
}