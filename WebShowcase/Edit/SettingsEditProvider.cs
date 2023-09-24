using WebShowcase.Settings;

namespace WebShowcase.Edit;

public class SettingsEditProvider : EditProvider<SettingsSet>
{
    public override string DisplayType => "settings";

    public SettingsEditProvider(SettingsSet source) : base(source) { }

    public override bool ValidateData(out string? error)
    {
        if (!string.IsNullOrEmpty(Data.YoutubeEmbed) && !Data.YoutubeEmbed.Contains("{0}"))
        {
            error = "YouTube format must be empty or include {0} for the video ID.";
            return false;
        }

        error = null;
        return true;
    }
}
