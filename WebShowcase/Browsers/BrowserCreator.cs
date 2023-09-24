using OpenQA.Selenium;
using OpenQA.Selenium.Chromium;

using WebShowcase.Settings;

namespace WebShowcase.Browsers;

internal class BrowserCreator : IDisposable
{
    public ChromiumDriverService DriverService { get; }
    public IWebDriver Driver { get; }

    public BrowserCreator(IBrowserTypeProvider typeProvider, string url, bool editMode)
    {
        DriverService = typeProvider.CreateService();
        DriverService.HideCommandPromptWindow = !GlobalSettings.Values.DebugConsole;

        var options = typeProvider.CreateOptions();
        options.AddExcludedArgument("enable-automation");
        options.AddArguments(
            $@"user-data-dir={Environment.CurrentDirectory}\UserData\{typeProvider.UserDataDest}",
            $"profile-directory={(string.IsNullOrEmpty(GlobalSettings.Values.BrowserProfile) ? "Default" : GlobalSettings.Values.BrowserProfile)}");

        if (!editMode)
            options.AddArgument($"app={url}");

        Driver = typeProvider.CreateDriver(DriverService, options);
        Driver.Manage().Window.Size = GlobalSettings.Values.ViewSize;
    }

    public void Dispose()
    {
        Driver.Close();
        Driver.Dispose();
        DriverService.Dispose();
    }
}