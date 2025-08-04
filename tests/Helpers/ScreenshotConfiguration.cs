using OpenQA.Selenium;
using System;
using System.IO;

namespace TestesAutomatizados.Helpers
{
    public static class ScreenshotConfiguration
    {
        public static void SaveScreenshot(IWebDriver driver)
        {
            var baseDir = Directory.GetCurrentDirectory();
            var projectDir = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "screenshots"));

            if (!Directory.Exists(projectDir))
                Directory.CreateDirectory(projectDir);

            var timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var screenshotPath = Path.Combine(projectDir, $"erro_{timeStamp}.png");

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotPath);
        }
    }
}
