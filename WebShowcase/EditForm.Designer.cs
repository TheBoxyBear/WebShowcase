namespace WebShowcase
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TableLayoutPanel table;
            Panel controlPanel;
            btnCancel = new Button();
            btnOK = new Button();
            propertyGrid = new PropertyGrid();
            table = new TableLayoutPanel();
            controlPanel = new Panel();
            table.SuspendLayout();
            controlPanel.SuspendLayout();
            SuspendLayout();
            // 
            // table
            // 
            table.ColumnCount = 1;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            table.Controls.Add(controlPanel, 0, 1);
            table.Controls.Add(propertyGrid, 0, 0);
            table.Dock = DockStyle.Fill;
            table.Location = new Point(0, 0);
            table.Margin = new Padding(2, 2, 2, 2);
            table.Name = "table";
            table.RowCount = 2;
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            table.Size = new Size(386, 452);
            table.TabIndex = 0;
            // 
            // controlPanel
            // 
            controlPanel.Controls.Add(btnCancel);
            controlPanel.Controls.Add(btnOK);
            controlPanel.Dock = DockStyle.Fill;
            controlPanel.Location = new Point(0, 416);
            controlPanel.Margin = new Padding(0);
            controlPanel.Name = "controlPanel";
            controlPanel.Size = new Size(386, 36);
            controlPanel.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(299, 8);
            btnCancel.Margin = new Padding(2, 2, 2, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(78, 20);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnClose_Click;
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Right;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(216, 8);
            btnOK.Margin = new Padding(2, 2, 2, 2);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(78, 20);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += BtnClose_Click;
            // 
            // propertyGrid
            // 
            propertyGrid.Dock = DockStyle.Fill;
            propertyGrid.Location = new Point(2, 2);
            propertyGrid.Margin = new Padding(2, 2, 2, 2);
            propertyGrid.Name = "propertyGrid";
            propertyGrid.Size = new Size(382, 412);
            propertyGrid.TabIndex = 1;
            // 
            // PageEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(386, 452);
            Controls.Add(table);
            Margin = new Padding(2, 2, 2, 2);
            Name = "PageEditForm";
            Text = "Edit page";
            table.ResumeLayout(false);
            controlPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnCancel;
        private Button btnOK;
        private PropertyGrid propertyGrid;
    }
}