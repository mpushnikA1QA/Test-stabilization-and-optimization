using System;
using Exam.Constants;
using Exam.Utility;
//It is advisable to remove unused using libraries
//Fix similar cases in other places.

namespace Exam.DataModels
{
    public class TestModel
    {
        public string TestName { get; set; }
        public string TestMethod { get; set; } 
        public string Environment { get; set; } 
        public string Browser => ProjectConstants.BrowserName;
        public string StartTime { get; set; } 
        public string EndTime { get; set; } 

        public TestModel()
        {
            TestName = RandomTextGenerator.Generate(ProjectConstants.StringLenght);
            TestMethod = RandomTextGenerator.Generate(ProjectConstants.StringLenght);
            Environment = RandomTextGenerator.Generate(ProjectConstants.StringLenght);
            StartTime = DateTime.Now.ToString(ProjectConstants.TimeFormat);
            EndTime = DateTime.Now.ToString(ProjectConstants.TimeFormat);
        }
        //it is better to remove unnecessary margins
        /*IsModelTheSame is not very well defined in Page Object. 
         * it is better to redefine the Equals method of the base class in the model class
         * 
        public bool IsModelTheSame(TestModel testModel)
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
        }
        */
        public override bool Equals(Object obj)
        {
            TestModel testModel = obj as TestModel;
            if (testModel == null)
                return false;
            else
                //TODO - Add logic by comparing class fields
                return true;
        }
    }
}
