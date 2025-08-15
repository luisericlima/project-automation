using Xunit;
using FluentAssertions;
using TestesAutomatizados.Helpers;

namespace TestesAutomatizados
{
    public class GoogleHomePageTests : BaseTest
    {
        private string? urlVisited;

        [Fact]
        public void GoogleHomePageDeveConterTituloGoogle()
        {
            urlVisited = TestConstants.ValidGoogleUrl;

            try
            {
                Driver.Navigate().GoToUrl(urlVisited);
                Driver.Title.Should().Contain(TestConstants.GoogleTitle);
            }
            catch
            {
                ScreenshotConfiguration.SaveScreenshot(Driver);
                throw;
            }
        }

        [Fact]
        public void GoogleHomePageDeveFalharComUrlIncorreta()
        {
            urlVisited = TestConstants.InvalidGoogleUrl;

            try
            {
                Driver.Navigate().GoToUrl(urlVisited);
                Driver.Title.Should().NotContain(TestConstants.GoogleTitle);
            }
            catch
            {
                ScreenshotConfiguration.SaveScreenshot(Driver);
                throw;
            }
        }
    }
}
