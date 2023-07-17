using Aquality.Selenium.Browsers;
using NUnit.Framework;

namespace Exam
{
    public class Tests
    {
        private readonly ConfigData ConfigData = new();
        private readonly TestData TestData = new();
        private const string Http = "http://";
        private const string CookieName = "token";

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
            ProjectsPage projectsPage = new();
            Assert.IsTrue(projectsPage.State.WaitForExist(), "Projects page is not open");
            AqualityServices.Browser.Driver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(CookieName, token));
            AqualityServices.Browser.Refresh();
            Assert.IsTrue(projectsPage.IsVersionCorrect(TestData.Variant), "Variant in a footer doesn't equal to actual variant value");
            projectsPage.GoToNexage();
            NexagePage nexagePage = new();
            Assert.IsTrue(nexagePage.AreDatesSortedInDescendingOrder(), "Tests on the first page of the table are sorted not in ascending order");
            AqualityServices.Browser.GoBack();
            var newProjectName = projectsPage.CreateNewProject();
            Assert.IsTrue(projectsPage.NewProjectForm.IsAlertExist(), "Success message did not appear");
            projectsPage.CloseNewProjectPopUp();
            Assert.IsFalse(projectsPage.IsNewProjectFormDisplayed(), "The Add Project window did not close");
            AqualityServices.Browser.Refresh();
            Assert.IsTrue(projectsPage.IsNewProjectInList(newProjectName), "New project did not appeared in a list");
            projectsPage.GoToNewProject();
            NewProjectPage newProjectPage = new();
            newProjectPage.GoToTestForm();
            newProjectPage.NewTestForm.FillTestNameField();
            newProjectPage.NewTestForm.FillTestMethodField();
            newProjectPage.NewTestForm.FillEnvironmentField();
            newProjectPage.NewTestForm.FillBrowserField();
            newProjectPage.NewTestForm.FillStartTimeField();
            newProjectPage.NewTestForm.FillEndTimeField();
            var screenshotPath = ScreenshotCreator.TakePngScreenshot();
            newProjectPage.NewTestForm.UploadScreenshot(screenshotPath);
            newProjectPage.NewTestForm.SaveTest();
            Assert.IsTrue(newProjectPage.NewTestForm.IsTestSavedMessageAppeared(), "Successful save message did not appeared");
            newProjectPage.ClickOffNewTestForm();
            Assert.IsTrue(newProjectPage.IsNewTestExists(),"New test is not appeared");
            newProjectPage.GoToNewTest();
            TestInfoPage testInfoPage = new();
            Assert.IsTrue(testInfoPage.IsDataCorresponds(newProjectPage.GetEnteredData()),"Data on a test info page don't correspond with data that was entered when test was created");
           Assert.IsTrue(testInfoPage.IsPictureCorresponds(screenshotPath), "Picture on test info page is not equal to picture that was uploaded");
        }

        [TearDown]
        public void TearDown()
        {
            AqualityServices.Browser.Quit();
        }
    }
}