namespace WebShowcase.Edit;

public class PageEditProvider : EditProvider<Page>
{
    public override string DisplayType => "page";

    public PageEditProvider(Page source) : base(source) { }

    public override bool ValidateData(out string? error)
    {
        if (string.IsNullOrEmpty(Data.Title))
        {
            error = "Title is required.";
            return false;
        }
        if (string.IsNullOrEmpty(Data.URL))
        {
            error = "URL is required.";
            return false;
        }

        error = null;
        return true;
    }
}
