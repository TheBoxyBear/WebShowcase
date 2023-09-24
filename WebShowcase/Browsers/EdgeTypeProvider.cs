using OpenQA.Selenium;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Edge;

namespace WebShowcase.Browsers;

internal class EdgeTypeProvider : IBrowserTypeProvider
{
    public string UserDataDest => "Edge";
    public ChromiumDriver CreateDriver(ChromiumDriverService service, ChromiumOptions options) => new EdgeDriver((EdgeDriverService)service, (EdgeOptions)options);

    public ChromiumOptions CreateOptions() => new EdgeOptions();

    public ChromiumDriverService CreateService() => EdgeDriverService.CreateDefaultService();
}
