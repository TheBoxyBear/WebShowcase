using System.ComponentModel;
using System.Windows.Forms;

namespace WebShowcase.Controls;

///// <summary>
///// A stackpanel similar to the Wpf stackpanel.
///// </summary>
///// <remarks>Sourced from Teolazza on StackOverflow. <see href="https://stackoverflow.com/a/43363989/8078210"/></remarks>
//public class StackPanel : FlowLayoutPanel
//{
//    private readonly Dictionary<Control, Size> startingSizes = new();

//    public StackPanel() : base()
//    {
//        InitializeComponent();
//        ForceAutoResizeOfControls = true;
//    }

//    private void InitializeComponent()
//    {
//        SuspendLayout();
//        AutoSizeMode = AutoSizeMode.GrowAndShrink;
//        WrapContents = false;
//        ResumeLayout(false);
//    }

//    /// <summary>
//    /// Override it just in order to hide it in design mode.
//    /// </summary>
//    [Browsable(false)]
//    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
//    public new bool WrapContents
//    {
//        get => base.WrapContents;
//        set => base.WrapContents = value;
//    }

//    /// <summary>
//    /// Override it just in order to set its default value.
//    /// </summary>
//    [DefaultValue(typeof(AutoSizeMode), "GrowAndShrink")]
//    public override AutoSizeMode AutoSizeMode
//    {
//        get => base.AutoSizeMode;
//        set => base.AutoSizeMode = value;
//    }

//    /// <summary>
//    /// Get or set a value that when is true forces the resizing of each control.
//    /// </summary>
//    /// <remarks>
//    /// If this value is false then only control that have AutoSize == true will be resized to
//    /// fit the client size of this container.
//    /// </remarks>
//    [DefaultValue(true)]
//    public bool ForceAutoResizeOfControls { get; set; }

//    //protected override void OnSizeChanged(EventArgs e)
//    //{
//    //    base.OnSizeChanged(e);
//    //    SuspendLayout();

//    //    switch (FlowDirection)
//    //    {
//    //        case FlowDirection.TopDown or FlowDirection.BottomUp:
//    //            foreach (Control control in Controls)
//    //                if (ForceAutoResizeOfControls || control.AutoSize)
//    //                    control.Width = ClientSize.Width - control.Margin.Left - control.Margin.Right;
//    //            break;
//    //        case FlowDirection.LeftToRight or FlowDirection.RightToLeft:
//    //            foreach (Control control in Controls)
//    //                if (ForceAutoResizeOfControls || control.AutoSize)
//    //                    control.Height = ClientSize.Height - control.Margin.Top - control.Margin.Bottom;
//    //            break;
//    //    }

//    //    ResumeLayout();
//    //}

//    protected override void OnLayout(LayoutEventArgs levent)
//    {
//        if (!ForceAutoResizeOfControls)
//        {
//            base.OnLayout(levent);
//            return;
//        }

//        SuspendLayout();

//        // When a control is added, OnLayout gets called before OnControlAdded.
//        if (Controls.Count > startingSizes.Count)
//            startingSizes.Add(Controls[^1], Controls[^1].Size);

//        foreach (Control c in Controls)
//            c.Size = startingSizes[c];

//        base.OnLayout(levent);

//        foreach (Control control in Controls)
//            control.Size /= 2;

//        //ResumeLayout(false);

//        //if (levent?.AffectedControl is Control control && control != this && (ForceAutoResizeOfControls || control.AutoSize))
//        //    switch (FlowDirection)
//        //    {
//        //        case FlowDirection.TopDown or FlowDirection.BottomUp:
//        //            control.Width = ClientSize.Width - control.Margin.Left - control.Margin.Right;
//        //            break;
//        //        case FlowDirection.LeftToRight or FlowDirection.RightToLeft:
//        //            control.Height = ClientSize.Height - control.Margin.Top - control.Margin.Bottom;
//        //            break;
//        //    }
//    }

//    protected override void OnControlRemoved(ControlEventArgs e)
//    {
//        if (e.Control is null)
//            return;

//        base.OnControlRemoved(e);

//        startingSizes.Remove(e.Control);
//    }
//}

public class StackPanel : TableLayoutPanel
{
    private readonly Dictionary<Control, int> startingWidths = new();
    private Size previousCells;

    const int defualtRowHeight = 100;
    [Browsable(true), Category("Behavior"), DefaultValue(defualtRowHeight)]
    public int RowHeight { get; set; } = defualtRowHeight;

    protected override void OnControlRemoved(ControlEventArgs e)
    {
        if (e.Control is null)
            return;

        base.OnControlRemoved(e);
        startingWidths.Remove(e.Control);
    }

    protected override void OnLayout(LayoutEventArgs levent)
    {
        if (Controls.Count == 0)
            return;

        SuspendLayout();

        //When a control is added, OnLayout gets called before OnControlAdded.
        if (Controls.Count > startingWidths.Count)
            startingWidths.Add(Controls[^1], Controls[^1].Width);

        RowCount = Math.Clamp(ClientSize.Height / RowHeight, 1, Controls.Count);
        ColumnCount = Controls.Count / RowCount;

        if (Controls.Count % RowCount != 0)
            ColumnCount++;

        if (previousCells.Height != RowCount)
        {
            RowStyles.Clear();

            var division = 100 / (float)RowCount;

            for (int i = 0; i < RowCount; i++)
                RowStyles.Add(new(SizeType.Percent, division));
        }
        if (previousCells.Width != ColumnCount)
        {
            ColumnStyles.Clear();

            var division = 100 / (float)ColumnCount;

            for (int i = 0; i < ColumnCount; i++)
                ColumnStyles.Add(new(SizeType.Percent, division));
        }

        previousCells = new(ColumnCount, RowCount);

        for (int i = 0; i < Controls.Count; i++)
        {
            var c = Controls[i];

            SetRow(c, i % RowCount);
            SetColumn(c, i / RowCount);
        }

        ResumeLayout(false);

        base.OnLayout(levent);
    }
}
