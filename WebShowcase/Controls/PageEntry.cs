using WebShowcase.Edit;

namespace WebShowcase.Controls;

public partial class PageEntry : UserControl
{
    public event EventHandler<Page>? DeleteRequested;
    public event EventHandler<PageModifiedEventArgs>? PageModified;
    public event EventHandler<PageMoveRequestedEventArgs>? MoveRequested;
    public event EventHandler<PageNavigatedEventArgs>? NavigationRequested;

    private Page _page;
    private readonly PageCollection _pages;
    private Task? _titleFetchTask;

    private string baseText;

    public int Index
    {
        get => _index;
        set
        {
            _index = value;
            _pages[value] = _page;

            UpdateMoveStatus();
            UpdateText();
        }
    }
    private int _index = 0;

    private bool _previewHidden = false;
    public bool PreviewHidden
    {
        get => _previewHidden;
        set
        {
            _previewHidden = value;

            baseText = GetPreviewText();
            UpdateText();
        }
    }

    public bool OrderButtonsVisible
    {
        get => _orderButtonsVisible;
        set
        {
            _orderButtonsVisible = value;

            if (_orderButtonsVisible)
            {
                tableLayoutPanel1.SetColumnSpan(label, 1);

                tableLayoutPanel1.Controls.Add(btnUp, 1, 0);
                tableLayoutPanel1.Controls.Add(btnDown, 2, 0);
            }
            else
            {
                tableLayoutPanel1.Controls.Remove(btnUp);
                tableLayoutPanel1.Controls.Remove(btnDown);

                tableLayoutPanel1.SetColumnSpan(label, 3);
            }
        }
    }
    private bool _orderButtonsVisible = true;

    public PageEntry(PageCollection pages, int index)
    {
        InitializeComponent();

        _page = pages[index];
        _pages = pages;
        _index = index;

        OnPageModified();
        UpdateMoveStatus();

        ContextMenuStrip = new();
        AddContextOption("Edit", BtnEdit_Click);
        AddContextOption("Delete", BtnDelete_Click);

        Disposed += (_, _) => _titleFetchTask?.Dispose();

        btnUp.Tag = PageMoveDirection.Up;
        btnDown.Tag = PageMoveDirection.Down;
    }

    private void BtnDelete_Click(object? sender, EventArgs e) => DeleteRequested?.Invoke(this, _page);
    private void BtnEdit_Click(object? sender, EventArgs e)
    {
        var provider = new PageEditProvider(_page);
        using var edit = new EditForm(provider);

        if (edit.ShowDialog() == DialogResult.OK)
        {
            var old = _page;

            _pages.Replace(old, _page = provider.Data);

            OnPageModified();
            PageModified?.Invoke(this, new(old, provider.Data));
        }
    }
    private void BtnDirection_Click(object sender, EventArgs e)
    {
        var args = new PageMoveRequestedEventArgs(_page, (PageMoveDirection)(sender as Control ?? throw new ArgumentException("Direction button is somehow not a control.")).Tag!);
        MoveRequested?.Invoke(this, args);
    }

    private void OnPageModified()
    {
        toolTip.SetToolTip(label, _page.URL);

        if (string.IsNullOrEmpty(_page.Title))
        {
            baseText = "Fetching title";
            UpdateText();

            _titleFetchTask = FetchTitle();
        }
        else
        {
            baseText = GetPreviewText();
            UpdateText();
        }
    }

    private async Task FetchTitle()
    {
        var response = await new HttpClient().GetAsync(_page.URL);

        if (!response.IsSuccessStatusCode && !PreviewHidden)
        {
            baseText = "Error accessing page";
            UpdateText();

            return;
        }

        var body = await response.Content.ReadAsStringAsync();

        string title = RegexHelper.HtmlTitle().Match(body).Groups["Title"].Value;

        _page.Title = title;
        UpdateText();
    }

    public void UpdateText() => label.Text = $"{Index + 1} - {baseText}";
    private string GetPreviewText() => PreviewHidden ? "Hidden preview" : _page.Title;

    private void AddContextOption(string text, EventHandler handler)
    {
        var option = new ToolStripMenuItem(text);
        option.Click += handler;

        ContextMenuStrip!.Items.Add(option);
    }

    public void UpdateMoveStatus()
    {
        btnUp.Enabled = Index > 0;
        btnDown.Enabled = Index < _pages.Count - 1;
    }

    private void Btn_Go_Click(object sender, EventArgs e) => NavigationRequested?.Invoke(this, new(_page, Index));
}
