using OpenQA.Selenium;
using OpenQA.Selenium.Chromium;

namespace WebShowcase.Browsers;

internal interface IBrowserTypeProvider
{
    public string UserDataDest { get; }
    public ChromiumOptions CreateOptions();
    public ChromiumDriverService CreateService();
    public ChromiumDriver CreateDriver(ChromiumDriverService service, ChromiumOptions options);
}
