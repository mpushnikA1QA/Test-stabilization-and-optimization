using System;
using System.Drawing;
using System.IO;
using Aquality.Selenium.Browsers;
using Syroot.Windows.IO;

namespace Exam.Utility
{
    public static class ScreenshotCreator
    {
        //The name of the constants must correspond to the naming convention
        //Fix similar cases in other places.
        public const int ScreenshotNameLenght = 5;
        public static string TakePngScreenshot()
        {
            MemoryStream memoryStream = new MemoryStream(AqualityServices.Browser.GetScreenshot());
            Image screenshot = Image.FromStream(memoryStream);
            string path = $"{new KnownFolder(KnownFolderType.Downloads).Path}\\{RandomTextGenerator.Generate(ScreenshotNameLenght)}.png";
            screenshot.Save(path, System.Drawing.Imaging.ImageFormat.Png);
            return path;
        }
        
        public static string ReadPictureBase64(string path)
        {
            Image image = Image.FromFile(path);
            using MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] fileFromDisc = memoryStream.ToArray();
            string fileFromDiscBase64 = Convert.ToBase64String(fileFromDisc);
            return fileFromDiscBase64;
        }

        public static bool IsPictureBase64AreTheSame(string param1, string param2)
        {
            return false; //Todo
        }
    }
}
