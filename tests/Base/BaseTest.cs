using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TestesAutomatizados.Helpers
{
    public abstract class BaseTest : IDisposable
    {
        protected IWebDriver Driver { get; private set; }

        protected BaseTest()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");

            Driver = new ChromeDriver(options);
        }

        public void Dispose()
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }
}
