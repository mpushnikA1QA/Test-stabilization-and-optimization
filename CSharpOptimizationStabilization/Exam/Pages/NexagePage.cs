using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Exam
{
    public class NexagePage : Form
    {
        private const int equal = 0;
        public NexagePage() : base(By.XPath("//ol//text()[contains(.,'Nexage')]"), "Nexage project")
        {
        }
        private IList<ILabel> DatesList => ElementFactory.FindElements<ILabel>(By.XPath("//table[@class='table']//td[4]"), "Dates in a 4th column");

        public bool AreDatesSortedInDescendingOrder()
        {
            bool flag = true;
            ILabel previousDate = DatesList[0];
            foreach (var item in DatesList)
            {
                if (string.Compare(previousDate.GetText(), item.GetText())>= equal)
                {
                    previousDate = item;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
    }
}
