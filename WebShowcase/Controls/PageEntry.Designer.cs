namespace WebShowcase.Controls
{
    partial class PageEntry
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label = new Label();
            btnDown = new Button();
            btnUp = new Button();
            btnGo = new Button();
            toolTip = new ToolTip(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoEllipsis = true;
            label.Dock = DockStyle.Fill;
            label.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label.Location = new Point(3, 0);
            label.Name = "label";
            label.Size = new Size(311, 75);
            label.TabIndex = 0;
            label.Text = "{0}";
            label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDown
            // 
            btnDown.Anchor = AnchorStyles.Right;
            btnDown.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnDown.Location = new Point(372, 12);
            btnDown.Margin = new Padding(4, 5, 4, 5);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(43, 50);
            btnDown.TabIndex = 5;
            btnDown.Text = "🞃";
            btnDown.TextAlign = ContentAlignment.TopCenter;
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += BtnDirection_Click;
            // 
            // btnUp
            // 
            btnUp.Anchor = AnchorStyles.Right;
            btnUp.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUp.Location = new Point(321, 12);
            btnUp.Margin = new Padding(4, 5, 4, 5);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(43, 50);
            btnUp.TabIndex = 6;
            btnUp.Text = "🞁";
            btnUp.TextAlign = ContentAlignment.TopCenter;
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += BtnDirection_Click;
            // 
            // btnGo
            // 
            btnGo.Anchor = AnchorStyles.Right;
            btnGo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnGo.Location = new Point(423, 12);
            btnGo.Margin = new Padding(4, 5, 4, 5);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(63, 50);
            btnGo.TabIndex = 7;
            btnGo.Text = "Go";
            btnGo.TextAlign = ContentAlignment.TopCenter;
            btnGo.UseVisualStyleBackColor = true;
            btnGo.Click += Btn_Go_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(btnGo, 3, 0);
            tableLayoutPanel1.Controls.Add(btnUp, 1, 0);
            tableLayoutPanel1.Controls.Add(btnDown, 2, 0);
            tableLayoutPanel1.Controls.Add(label, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(490, 75);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // PageEntry
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "PageEntry";
            Size = new Size(490, 75);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label;
        private Button btnDown;
        private Button btnUp;
        private Button btnGo;
        private ToolTip toolTip;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
