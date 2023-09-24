namespace WebShowcase;

public class PageNavigatedEventArgs : EventArgs
{
    public Page Page { get; }
    public int Index { get; }

    public PageNavigatedEventArgs(Page page, int index)
    {
        Page = page;
        Index = index;
    }
}
