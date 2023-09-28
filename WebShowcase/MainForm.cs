using OpenQA.Selenium;

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

using WebShowcase.Browsers;
using WebShowcase.Controls;
using WebShowcase.Edit;
using WebShowcase.Settings;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WebShowcase;

public enum FileSelectMode : byte { Open, Save }

public partial class MainForm : Form
{
    private PageCollection _pages;
    private PageView _view;
    private bool _unsavedChanges = false;

    public MainForm()
    {
        InitializeComponent();

        _pages = new();
    }

    private static IWebDriver CreateDriver(string url, bool editMode)
    {
        var creator = new BrowserCreator(GlobalSettings.Values.BrowserBackend switch
        {
            BrowserBackend.Chrome => new ChromeTypeProvider(),
            BrowserBackend.Edge => new EdgeTypeProvider()
        }, url, editMode);

        return creator.Driver;
    }

    #region Menu events
    private void Menu_File_Open_Click(object sender, EventArgs e)
    {
        if (SelectPath(FileSelectMode.Open, out var path))
            OpenFile(path);
    }
    private void Menu_Add_Click(object sender, EventArgs e)
    {
        var provider = new PageEditProvider(new());
        using var edit = new EditForm(provider);

        if (edit.ShowDialog() == DialogResult.OK)
        {
            _pages!.Add(provider.Data);

            if (_pages.Count > 1)
                UpdatePageEntryMoveStatus(_pages.Count - 2);

            CreatePageEntry(_pages.Count - 1);
            MarkSaved(false);
        }
    }

    private void MenuStrip_File_Save_Click(object sender, EventArgs e) => SaveListFile();
    private void MenuStrip_File_SaveAs_Click(object sender, EventArgs e)
    {
        if (SelectPath(FileSelectMode.Save, out var path))
            Save(path);
    }

    private void Menu_Settings_Click(object sender, EventArgs e)
    {
        var provider = new SettingsEditProvider(GlobalSettings.Values);
        using var edit = new EditForm(provider);

        if (edit.ShowDialog() == DialogResult.OK)
        {
            GlobalSettings.Values = provider.Data;
            GlobalSettings.Save();

            //if (_view is not null)
            //    _view.Size = GlobalSettings.Values.ViewSize;

            foreach (PageEntry entry in pageEntries.Controls)
                entry.PreviewHidden = GlobalSettings.Values.HideTitlePreviews;
        }
    }

    private void Menu_Reorder_Click(object sender, EventArgs e)
    {
        menu_Reorder.Checked = !menu_Reorder.Checked;

        foreach (PageEntry entry in pageEntries.Controls)
            entry.OrderButtonsVisible = menu_Reorder.Checked;
    }

    private async void Menu_Configure_Click(object sender, EventArgs e)
    {
        _view?.Dispose();
        _view = await PageView.CreateAsync("https://google.com", true);
    }
    #endregion

    #region Page events
    private void Page_Modified(object? sender, PageModifiedEventArgs args) => MarkSaved(false);
    private void Page_DeleteRequested(object? sender, Page counter)
    {
        var view = (sender as PageEntry)!;

        if (!_pages!.Remove(counter))
            return;

        pageEntries.Controls.Remove(view);
        view.Dispose();

        UpdatePageEntryMoveStatus(_pages.Count - 1);
        MarkSaved(false);
    }
    private void Page_MoveRequested(object? sender, PageMoveRequestedEventArgs e)
    {
        if (_pages is null)
            throw new Exception("No page list loaded.");

        var view = sender as PageEntry ?? throw new ArgumentException($"Sender is not a {nameof(PageEntry)}.");
        var otherIndex = e.Direction switch
        {
            PageMoveDirection.Up => view.Index - 1,
            PageMoveDirection.Down => view.Index + 1,
            _ => throw new IndexOutOfRangeException("Direction not defined.")
        };
        var otherView = (PageEntry)pageEntries.Controls[otherIndex];
        var page = _pages[view.Index];
        var otherPage = _pages[otherView.Index];

        otherView.Index = view.Index;
        view.Index = otherIndex;

        pageEntries.SuspendLayout();
        pageEntries.Controls.SetChildIndex(view, view.Index);
        pageEntries.Controls.SetChildIndex(otherView, otherView.Index);
        pageEntries.ResumeLayout(true);

        MarkSaved(false);
    }
    private async void Page_NavigationRequested(object? sender, PageNavigatedEventArgs e)
    {
        //if (_view is null)
        //{
        //    _view = new();
        //    _view.Disposed += (_, _) => _view = null;
        //    _view.Show();
        //    _view.Focus();
        //}

        //await _view.Navigate(e.Page, e.Index);

        var url = e.Page.URL;

        if (url.Contains("youtube.com") || url.Contains("youtu.be"))
        {
            var uri = new Uri(url);
            var query = HttpUtility.ParseQueryString(uri.Query);
            var id = query.AllKeys.Contains("v") ? query["v"] : uri.Segments.Last();

            url = string.Format(GlobalSettings.Values.YoutubeEmbed, id);
        }

        if (_view is null)
            _view = await PageView.CreateAsync(url);
        else
        {
            _view.EditMode = false;
            await _view.NavigateAsync(url);
        }

        File.WriteAllText("title.txt", e.Page.Title);
    }
    #endregion

    private static bool SelectPath(FileSelectMode mode, out string path)
    {
        path = string.Empty;

        using FileDialog dialog = mode switch
        {
            FileSelectMode.Open => new OpenFileDialog(),
            FileSelectMode.Save => new SaveFileDialog(),
            _ => throw new ArgumentException("Invalid file mode.")
        };

        dialog.AddToRecent = true;
        dialog.Filter = "Json files|*.json";

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            path = dialog.FileName;
            return true;
        }

        return false;
    }
    private void OpenFile(string path)
    {
        pageEntries.Controls.Clear();

        _pages = PageCollection.FromFile(path);

        if (_pages is not null && _pages.Count > 0)
            for (int i = 0; i < _pages.Count; i++)
                CreatePageEntry(i);
        else
            _pages = new();

        _pages.Path = path;
    }
    private void SaveListFile()
    {
        string? path = _pages.Path;

        if (path is null)
            if (SelectPath(FileSelectMode.Save, out path))
                _pages.Path = path;
            else
                return;

        Save(path);
    }
    private void Save(string path)
    {
        var json = JsonSerializer.Serialize(_pages, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault });
        File.WriteAllText(path, json);

        MarkSaved(true);
    }

    private void MarkSaved(bool saved)
    {
        _unsavedChanges = !saved;

        var text = "Web Showcase";

        if (!saved)
            text += " *";

        Text = text;
    }

    private PageEntry CreatePageEntry(int index)
    {
        var entry = new PageEntry(_pages!, index)
        {
            Anchor = AnchorStyles.Left | AnchorStyles.Right,
            PreviewHidden = GlobalSettings.Values.HideTitlePreviews
        };

        entry.PageModified += Page_Modified;
        entry.DeleteRequested += Page_DeleteRequested;
        entry.MoveRequested += Page_MoveRequested;
        entry.NavigationRequested += Page_NavigationRequested;

        pageEntries.Controls.Add(entry);

        return entry;
    }

    private void UpdatePageEntryMoveStatus(int index) => ((PageEntry)pageEntries.Controls[index]).UpdateMoveStatus();

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (_unsavedChanges)
        {
            var pick = MessageBox.Show("Save changes to file?", "Web Showcase", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            switch (pick)
            {
                case DialogResult.Yes:
                    SaveListFile();
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        _view?.Dispose();
    }
}