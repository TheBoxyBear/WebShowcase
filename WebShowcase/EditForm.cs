using WebShowcase.Edit;

namespace WebShowcase;

public partial class EditForm : Form
{
    private bool confirmClose = true;
    private readonly IEditProvider provider;

    public EditForm(IEditProvider provider)
    {
        InitializeComponent();

        this.provider = provider;

        var dataType = provider.DataType;

        foreach (var prop in dataType.GetProperties().Where(p => p.SetMethod is not null))
            prop.SetValue(provider.Data, prop.GetValue(provider.Source));

        propertyGrid.SelectedObject = provider.Data;
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (confirmClose)
        {
            e.Cancel = MessageBox.Show("Discard changes?", $"Edit {provider.DisplayType}", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No;
            return;
        }

        if (DialogResult == DialogResult.OK && !provider.ValidateData(out var error))
        {
            MessageBox.Show(error, $"Edit {provider.DisplayType}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.Cancel = true;
        }
    }

    private void Close(DialogResult result)
    {
        DialogResult = result;
        Close();
    }

    private void BtnClose_Click(object sender, EventArgs e)
    {
        confirmClose = false;
        Close((sender as Button)!.DialogResult);
    }
}