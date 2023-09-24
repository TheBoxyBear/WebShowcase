namespace WebShowcase.Edit;

public interface IEditProvider
{
    public object Data { get; }
    public object Source { get; }
    public string DisplayType { get; }
    public Type DataType { get; }

    public bool ValidateData(out string? error);
}
public interface IEditProvider<out T> : IEditProvider
{
    public new T Data { get; }
    public new T Source { get; }

    object IEditProvider.Data => Data!;
    object IEditProvider.Source => Source!;
    Type IEditProvider.DataType => typeof(T);
}
