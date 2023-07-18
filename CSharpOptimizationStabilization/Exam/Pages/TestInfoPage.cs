using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using Exam.DataModels;
using Exam.Utility;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Exam.Pages
{
    public class TestInfoPage : Form
    {
        private IList<ILabel> DataListOfLabels => ElementFactory.FindElements<ILabel>(By.XPath("//div[@class='list-group-item']"), "Common info tabel");
        private ILink PictureLink => ElementFactory.GetLink(By.XPath("//a[@target='_blank']"), "Picture");
        public TestInfoPage() : base(By.XPath("//span[contains(@class,'glyphicon-info-sign')]"), "Test Info")
        {
        }
        //To compare test data, you need to get a model from page object
        public TestModel GetCreatedTestModel()
        {
            foreach (var chunk in DataListOfLabels)
            {
             // TODO
            }
            return new TestModel(); // TODO
        }

        /* checking that the objects are the same is better done through the equals method in the target class
        public bool IsDataCorresponds(TestModel testModel)
        {
            string[] correctData = { testModel.TestName, testModel.TestMethod, testModel.Environment, testModel.Browser, testModel.StartTime, testModel.EndTime };
            int counter = 0;
            foreach (var item in correctData)
            {
                foreach (var chunk in DataListOfLabels)
                {
                    if (chunk.GetText().Contains(item))
                    {
                        counter++;
                        break;
                    }
                }
            }
            //Use language constructs to make the code smaller and more readable
            return counter == correctData.Count() ? true : false;
        }*/

        // Get...
        // The method is divided into several separate simple methods.
        // The logic would be divided into the GetHrefLink method.
        // The base64 comparison method would be taken out in utils and used in test assets
        public bool IsPictureCorresponds(string path)
        {
            var fileFromInfoPage = PictureLink.GetAttribute("href");
            string fileFromDiscBase64 = ScreenshotCreator.ReadPictureBase64(path);
            return fileFromInfoPage.Contains(fileFromDiscBase64);
        }
    }
}
