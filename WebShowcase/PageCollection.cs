using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebShowcase;

public class PageCollection : ICollection<Page>
{
    private readonly List<Page> _pages;

    [JsonIgnore] public string? Path { get; set; }
    [JsonIgnore] public int Count => _pages.Count;
    bool ICollection<Page>.IsReadOnly => false;

    public PageCollection() => _pages = new();
    public PageCollection(IEnumerable<Page> pages) => _pages = pages.ToList();

    public static PageCollection FromFile(string path) => JsonSerializer.Deserialize<PageCollection>(File.ReadAllText(path)) ?? new() { Path = path };

    public Page this[int index]
    {
        get => _pages[index];
        set => _pages[index] = value;
    }

    public void Replace(Page oldPage, Page newPage)
    {
        var index = _pages.IndexOf(oldPage);

        if (index == -1)
            throw new ArgumentException("Old page is not in the collection.", nameof(oldPage));

        _pages.RemoveAt(index);
        _pages.Insert(index, newPage);
    }

    public void Add(Page item) => _pages.Add(item);
    public void Clear() => _pages.Clear();
    public bool Contains(Page item) => _pages.Contains(item);
    public void CopyTo(Page[] array, int arrayIndex) => _pages.CopyTo(array, arrayIndex);
    public bool Remove(Page item) => _pages.Remove(item);

    public IEnumerator<Page> GetEnumerator() => _pages.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
