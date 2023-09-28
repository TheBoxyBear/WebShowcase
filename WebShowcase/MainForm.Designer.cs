using WebShowcase.Controls;

namespace WebShowcase
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MenuStrip menuStrip;
            menuStrip_File = new ToolStripMenuItem();
            menuStrip_File_Open = new ToolStripMenuItem();
            menuStrip_File_Save = new ToolStripMenuItem();
            menuStrip_File_SaveAs = new ToolStripMenuItem();
            menu_Add = new ToolStripMenuItem();
            menu_Reorder = new ToolStripMenuItem();
            Menu_Settings = new ToolStripMenuItem();
            menu_Configure = new ToolStripMenuItem();
            pageEntries = new StackPanel();
            menuStrip = new MenuStrip();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { menuStrip_File, menu_Add, menu_Reorder, Menu_Settings, menu_Configure });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(4, 1, 0, 1);
            menuStrip.Size = new Size(714, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // menuStrip_File
            // 
            menuStrip_File.DropDownItems.AddRange(new ToolStripItem[] { menuStrip_File_Open, menuStrip_File_Save, menuStrip_File_SaveAs });
            menuStrip_File.Name = "menuStrip_File";
            menuStrip_File.Size = new Size(37, 22);
            menuStrip_File.Text = "File";
            // 
            // menuStrip_File_Open
            // 
            menuStrip_File_Open.Name = "menuStrip_File_Open";
            menuStrip_File_Open.ShortcutKeys = Keys.Control | Keys.O;
            menuStrip_File_Open.Size = new Size(225, 22);
            menuStrip_File_Open.Text = "Open";
            menuStrip_File_Open.Click += Menu_File_Open_Click;
            // 
            // menuStrip_File_Save
            // 
            menuStrip_File_Save.Name = "menuStrip_File_Save";
            menuStrip_File_Save.ShortcutKeys = Keys.Control | Keys.S;
            menuStrip_File_Save.Size = new Size(225, 22);
            menuStrip_File_Save.Text = "Save";
            menuStrip_File_Save.Click += MenuStrip_File_Save_Click;
            // 
            // menuStrip_File_SaveAs
            // 
            menuStrip_File_SaveAs.Name = "menuStrip_File_SaveAs";
            menuStrip_File_SaveAs.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            menuStrip_File_SaveAs.Size = new Size(225, 22);
            menuStrip_File_SaveAs.Text = "Save As...";
            menuStrip_File_SaveAs.Click += MenuStrip_File_SaveAs_Click;
            // 
            // menu_Add
            // 
            menu_Add.Name = "menu_Add";
            menu_Add.Size = new Size(41, 22);
            menu_Add.Text = "Add";
            menu_Add.Click += Menu_Add_Click;
            // 
            // menu_Reorder
            // 
            menu_Reorder.Checked = true;
            menu_Reorder.CheckState = CheckState.Checked;
            menu_Reorder.Name = "menu_Reorder";
            menu_Reorder.Size = new Size(60, 22);
            menu_Reorder.Text = "Reorder";
            menu_Reorder.Click += Menu_Reorder_Click;
            // 
            // Menu_Settings
            // 
            Menu_Settings.Name = "Menu_Settings";
            Menu_Settings.Size = new Size(61, 22);
            Menu_Settings.Text = "Settings";
            Menu_Settings.Click += Menu_Settings_Click;
            // 
            // menu_Configure
            // 
            menu_Configure.Name = "menu_Configure";
            menu_Configure.Size = new Size(117, 22);
            menu_Configure.Text = "Configure browser";
            menu_Configure.Click += Menu_Configure_Click;
            // 
            // pageEntries
            // 
            pageEntries.AutoScroll = true;
            pageEntries.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pageEntries.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 14F));
            pageEntries.Dock = DockStyle.Fill;
            pageEntries.Location = new Point(0, 24);
            pageEntries.Margin = new Padding(2);
            pageEntries.Name = "pageEntries";
            pageEntries.RowHeight = 75;
            pageEntries.Size = new Size(714, 256);
            pageEntries.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 280);
            Controls.Add(pageEntries);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "Web Showcase";
            FormClosing += MainForm_FormClosing;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem menuStrip_File;
        private ToolStripMenuItem menu_Add;
        private StackPanel pageEntries;
        private ToolStripMenuItem menuStrip_File_Open;
        private ToolStripMenuItem menuStrip_File_Save;
        private ToolStripMenuItem menuStrip_File_SaveAs;
        private ToolStripMenuItem Menu_Settings;
        private ToolStripMenuItem menu_Configure;
        private ToolStripMenuItem menu_Reorder;
    }
}