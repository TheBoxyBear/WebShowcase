using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebShowcase;

public class Page
{
    [Description("Title of the page. Leave blank to fetch automatically.")]
    public string Title { get; set; }

    [Required, Description("URL of the page.")]
    public string URL { get; set; }

    public override string ToString() => URL;
}
