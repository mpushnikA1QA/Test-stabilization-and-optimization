using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class TestModel
    {
        private const int StringLenght = 10;
        private const string BrowserName = "chrome";
        private const string TimeFormat = "yyyy-MM-dd HH:mm:ss";

        public string TestName { get; set; }
        public string TestMethod { get; set; } 
        public string Environment { get; set; } 
        public string Browser => BrowserName;
        public string StartTime { get; set; } 
        public string EndTime { get; set; } 

        public TestModel()
        {
            TestName = RandomTextGenerator.Generate(StringLenght);
            TestMethod = RandomTextGenerator.Generate(StringLenght);
            Environment = RandomTextGenerator.Generate(StringLenght);
            StartTime = DateTime.Now.ToString(TimeFormat);
            EndTime = DateTime.Now.ToString(TimeFormat);
        }

       

    }
}
