using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;

namespace WebShowcase.Browsers
{
    internal class ChromeTypeProvider : IBrowserTypeProvider
    {
        public string UserDataDest => "Chrome";

        public ChromiumDriver CreateDriver(ChromiumDriverService service, ChromiumOptions options) => new ChromeDriver((ChromeDriverService)service, (ChromeOptions)options);

        public ChromiumOptions CreateOptions() => new ChromeOptions();

        public ChromiumDriverService CreateService() => ChromeDriverService.CreateDefaultService();
    }
}
