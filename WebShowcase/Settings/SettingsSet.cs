using System.ComponentModel;

namespace WebShowcase.Settings;

public class SettingsSet
{
    [DisplayName("View size"), Description("Size of the view window. Saves automatically on resize.")]
    public Size ViewSize { get; set; }
    [DisplayName("YouTube link format"), Description("Format of YouTube links for embeds. Include {0} to insert the video ID.")]
    public string YoutubeEmbed { get; set; }
    [DisplayName("Hide title previews")]
    public bool HideTitlePreviews { get; set; }
    [DisplayName("Browser"), Description("Browser backend to use. Must be a different browser if an instance is already running.")]
    public BrowserBackend BrowserBackend { get; set; }
    [DisplayName("Browser profile"), Description("Browser profile to use for extensions, settings and cookies.")]
    public string BrowserProfile { get; set; }
    [DisplayName("Debug console"), Description("Display the debug console.")]
    public bool DebugConsole { get; set; }
    [DisplayName("Hide browser scroll bar"), Description("Automatically hide the browser scroll bar when not in use.")]
    public bool HideScrollBar { get; set; }
}

public enum BrowserBackend { Chrome, Edge };
