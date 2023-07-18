using System.Reflection;
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace Exam
{
    public class ConfigData
    { 
        //Since the data is used once, you can leave it as it is.
        private static ISettingsFile ConfFile => new JsonSettingsFile(@"Resources.Config.json", Assembly.GetCallingAssembly());

        public string URL => ConfFile.GetValue<string>("URL");
        public string API_URL => ConfFile.GetValue<string>("API_URL");
    }
}
