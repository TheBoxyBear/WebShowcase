using System.Text.Json;

namespace WebShowcase.Settings;

public static class GlobalSettings
{
    public const string FileName = "settings.json";
    public static SettingsSet Values { get; set; }

    static GlobalSettings()
    {
        Values = File.Exists(FileName)
            ? JsonSerializer.Deserialize<SettingsSet>(File.ReadAllText(FileName))!
            : new() { ViewSize = new(760, 620) };
    }

    public static void Save() => File.WriteAllText(FileName, JsonSerializer.Serialize(Values));
}
