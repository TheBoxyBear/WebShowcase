namespace WebShowcase;

public enum PageMoveDirection { Up, Down }

public class PageMoveRequestedEventArgs : EventArgs
{
    public Page Page { get; }
    public PageMoveDirection Direction { get; }

    public PageMoveRequestedEventArgs(Page page, PageMoveDirection direction)
    {
        Page = page;
        Direction = direction;
    }
}
