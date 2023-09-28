//using CefSharp;
//using CefSharp.WinForms.Experimental;

//using System.Web;

//using WebShowcase.Settings;

//namespace WebShowcase;
//public partial class PageView_Old : Form
//{
//    public static string[] Scripts => Directory.EnumerateFiles("Scripts").Where(file => file.EndsWith(".js")).Select(File.ReadAllText).ToArray();
//    public Page CurrentPage { get; private set; }
//    private ChromiumWidgetNativeWindow? NativeWindow;

//    public double ZoomLevel
//    {
//        get => _zoomLevel;
//        set => browser.SetZoomLevel(_zoomLevel = value);
//    }
//    private double _zoomLevel = 1d;

//    public PageView_Old()
//    {
//        InitializeComponent();
//        Size = GlobalSettings.Values.ViewSize;
//    }

//    public async Task Navigate(Page page, int index)
//    {
//        CurrentPage = page;

//        var url = page.URL;

//        if (url.Contains("youtube.com") || url.Contains("youtu.be"))
//        {
//            var uri = new Uri(url);
//            var query = HttpUtility.ParseQueryString(uri.Query);
//            var id = query.AllKeys.Contains("v") ? query["v"] : uri.Segments.Last();

//            url = string.Format(GlobalSettings.Values.YoutubeEmbed, id);
//        }

//        browser.LoadUrl(url);
//        await browser.WaitForNavigationAsync().ContinueWith(t =>
//        {
//            if (NativeWindow is null)
//            {
//                ChromiumRenderWidgetHandleFinder.TryFindHandle(browser, out var chromeWidgetHostHandle);
//                NativeWindow = new ChromiumWidgetNativeWindow(browser, chromeWidgetHostHandle);
//                NativeWindow.OnWndProc(Browser_WndProc);
//            }

//            foreach (var script in Scripts)
//                browser.ExecuteScriptAsync(script);
//        });

//        Text = $"({index + 1}) {page.Title}";
//        File.WriteAllText("title.txt", page.Title);
//    }

//    protected override void OnClosed(EventArgs e)
//    {
//        base.OnClosed(e);
//        GlobalSettings.Values.ViewSize = Size;
//    }

//    private bool Browser_WndProc(Message m)
//    {
//        if (m.Msg is not 0x020A or 0x020E) // Mouse wheel
//            return false;

//        if ((m.WParam & 0x0008) == 0) // Ctrl pressed
//            return false;

//        short delta = (short)((short)(m.WParam >> 16 & 0xFFFF) / 120);
//        //ZoomLevel += GlobalSettings.Values.ZoomRate * delta;

//        return true;
//    }
//}
