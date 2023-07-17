using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Exam
{
    public class TestInfoPage : Form
    {
        public TestInfoPage() : base(By.XPath("//span[contains(@class,'glyphicon-info-sign')]"), "Test Info")
        {
        }
        private IList<ILabel> DataList => ElementFactory.FindElements<ILabel>(By.XPath("//div[@class='list-group-item']"), "Common info tabel");
        private ILink Picture => ElementFactory.GetLink(By.XPath("//a[@target='_blank']"), "Picture");

        public bool IsDataCorresponds(TestModel testModel)
        {
            string[] correctData = { testModel.TestName, testModel.TestMethod, testModel.Environment, testModel.Browser, testModel.StartTime, testModel.EndTime };
            int counter = 0;
            foreach (var item in correctData)
            {
                foreach (var chunk in DataList)
                {
                    if (chunk.GetText().Contains(item))
                    {
                        counter++;
                        break;
                    }
                }
            }
            if (counter == correctData.Count())
            {
                return true;
            }
            else
            {
                return false;
            }        
        }

        public bool IsPictureCorresponds(string path)
        {
            var fileFromInfoPage = Picture.GetAttribute("href");
            string fileFromDiscBase64 = ScreenshotCreator.ReadPictureBase64(path);
            return fileFromInfoPage.Contains(fileFromDiscBase64);
        }
    }
}
