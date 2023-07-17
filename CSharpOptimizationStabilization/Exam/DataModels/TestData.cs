using System.Reflection;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace Exam
{
    public class TestData
    {
        private static ISettingsFile ConfFile => new JsonSettingsFile(@"Resources.TestData.json", Assembly.GetCallingAssembly());

        public string Variant => ConfFile.GetValue<string>("Variant");
        public string Username => ConfFile.GetValue<string>("Username");
        public string Password => ConfFile.GetValue<string>("Password");
    }
}
