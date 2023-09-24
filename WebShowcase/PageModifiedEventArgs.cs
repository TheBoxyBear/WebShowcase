namespace WebShowcase;

public class PageModifiedEventArgs : EventArgs
{
    public Page Old { get; }
    public Page New { get; }

    public PageModifiedEventArgs(Page old, Page @new)
    {
        Old = old;
        New = @new;
    }
}
