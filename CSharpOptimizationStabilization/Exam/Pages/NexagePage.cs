using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Exam.Pages
{
    public class NexagePage : Form
    {

        //The name of the constants must be correct with camelCase
        //Fix similar cases in other places.
        private const int Equal = 0;

        private IList<ILabel> DatesList => ElementFactory.FindElements<ILabel>(By.XPath("//table[@class='table']//td[4]"), "Dates in a 4th column");

        public NexagePage() : base(By.XPath("//ol//text()[contains(.,'Nexage')]"), "Nexage project")
        {
        }
        //The sorting check should be placed in a separate utility class, an extension method.
        public bool AreDatesSortedInDescendingOrder()
        {
            bool flag = true;
            ILabel previousDate = DatesList[0];
            foreach (var item in DatesList)
            {
                if (string.Compare(previousDate.GetText(), item.GetText())>= Equal)
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
