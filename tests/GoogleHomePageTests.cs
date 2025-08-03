using System;
using System.IO;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using FluentAssertions;

namespace TestesAutomatizados
{
    public class GoogleHomePageTests
    {
        [Fact]
        public void GoogleHomePage_DeveConterTituloGoogle()
        {
            using var driver = new ChromeDriver();

            try
            {
                driver.Navigate().GoToUrl("https://www.google.com");
                driver.Title.Should().Contain("Google");
            }
            catch (Exception e)
            {
                SaveScreenshot(driver);

                throw new Xunit.Sdk.XunitException($"Teste falhou por causa de: {e.Message}");
            }
        }

        private void SaveScreenshot(IWebDriver driver)
        {
            var baseDir = Directory.GetCurrentDirectory();
            var projectDir = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "screenshots"));

            if (!Directory.Exists(projectDir))
                Directory.CreateDirectory(projectDir);

            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var screenshotPath = Path.Combine(projectDir, $"erro_{timestamp}.png");

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(screenshotPath);
        }
    }
}
