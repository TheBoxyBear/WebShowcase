using OpenQA.Selenium.Chromium;

using WebShowcase.Browsers;
using WebShowcase.Settings;

namespace WebShowcase;

public class PageView : IDisposable
{
    private ChromiumDriver _driver;
    private readonly ChromiumDriverService _driverService;
    private ChromiumOptions _options;
    private readonly IBrowserTypeProvider _provider;

    public bool EditMode
    {
        get => _editMode;
        set
        {
            _editMode = value;

            if (_options.Arguments.Contains("app"))
                _options = _provider.CreateOptions();

            if (!_editMode)
                _options.AddArgument($"app={Url}");
        }
    }
    private bool _editMode;

    public string Url { get; private set; }

    public static async Task<PageView> CreateAsync(string url, bool editMode = false)
    {
        var view = new PageView(url, editMode);
        await view.InitDriver();

        return view;
    }
    private async Task InitDriver()
    {
        await Task.Run(() => _driver = _provider.CreateDriver(_driverService, _options));
        _driver.Manage().Window.Size = GlobalSettings.Values.ViewSize;

        if (!EditMode)
            await NavigateAsync(Url);
    }

    private PageView(string url, bool editMode)
    {
        _provider = GlobalSettings.Values.BrowserBackend switch
        {
            BrowserBackend.Edge => new EdgeTypeProvider(),
            BrowserBackend.Chrome => new ChromeTypeProvider(),
        };

        if (!Directory.Exists(_provider.UserDataDest))
            Directory.CreateDirectory(_provider.UserDataDest);

        _driverService = _provider.CreateService();
        _driverService.HideCommandPromptWindow = !GlobalSettings.Values.DebugConsole;

        _options = _provider.CreateOptions();

        _options.AddExcludedArgument("enable-automation");
        _options.AddArguments(
            $@"user-data-dir={Environment.CurrentDirectory}\UserData\{_provider.UserDataDest}",
            $"profile-directory={(string.IsNullOrEmpty(GlobalSettings.Values.BrowserProfile) ? "Default" : GlobalSettings.Values.BrowserProfile)}");

        Url = url;
        EditMode = editMode;
    }

    public async Task NavigateAsync(string url)
    {
        Url = url;

        await Task.Run(async () =>
        {
            try { _driver.Navigate().GoToUrl(url); }
            catch { await InitDriver(); }
        });
    }

    public void Dispose()
    {
        _driver.Dispose();
        _driverService.Dispose();
    }
}
