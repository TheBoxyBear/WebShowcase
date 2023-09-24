namespace WebShowcase.Edit;

public abstract class EditProvider<T> : IEditProvider<T> where T : new()
{
    public T Data { get; } = new();
    public T Source { get; }

    public abstract string DisplayType { get; }

    public EditProvider(T source) => Source = source;

    public abstract bool ValidateData(out string? error);
}
