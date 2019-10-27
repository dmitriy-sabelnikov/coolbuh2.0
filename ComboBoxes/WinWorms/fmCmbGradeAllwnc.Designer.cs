namespace ComboBoxes.WinWorms
{
    partial class fmCmbGradeAllwnc
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
            this.MenuRefAdm = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemChoose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvGradeAllwnc = new System.Windows.Forms.DataGridView();
            this.RefGradeAllwnc_Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefGradeAllwnc_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefGradeAllwnc_Pct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.MenuRefAdm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradeAllwnc)).BeginInit();
            this.pnlControl.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuRefAdm
            // 
            this.MenuRefAdm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuRefAdm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuRefAdm.Location = new System.Drawing.Point(0, 0);
            this.MenuRefAdm.Name = "MenuRefAdm";
            this.MenuRefAdm.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuRefAdm.Size = new System.Drawing.Size(341, 24);
            this.MenuRefAdm.TabIndex = 5;
            this.MenuRefAdm.Text = "MenuRefAdm";
            // 
            // MenuStripRegister
            // 
            this.MenuStripRegister.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemChoose,
            this.toolStripSeparator2,
            this.MenuItemExit});
            this.MenuStripRegister.Name = "MenuStripRegister";
            this.MenuStripRegister.Size = new System.Drawing.Size(56, 20);
            this.MenuStripRegister.Text = "Реєстр";
            // 
            // MenuItemChoose
            // 
            this.MenuItemChoose.Name = "MenuItemChoose";
            this.MenuItemChoose.ShortcutKeyDisplayString = "Enter";
            this.MenuItemChoose.Size = new System.Drawing.Size(154, 22);
            this.MenuItemChoose.Text = "Вибрати";
            this.MenuItemChoose.Click += new System.EventHandler(this.MenuItemChoose_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.ShortcutKeyDisplayString = "Esc";
            this.MenuItemExit.Size = new System.Drawing.Size(154, 22);
            this.MenuItemExit.Text = "Вихід";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // dgvGradeAllwnc
            // 
            this.dgvGradeAllwnc.AllowUserToAddRows = false;
            this.dgvGradeAllwnc.AllowUserToDeleteRows = false;
            this.dgvGradeAllwnc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGradeAllwnc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefGradeAllwnc_Cd,
            this.RefGradeAllwnc_Nm,
            this.RefGradeAllwnc_Pct});
            this.dgvGradeAllwnc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGradeAllwnc.Location = new System.Drawing.Point(0, 24);
            this.dgvGradeAllwnc.Name = "dgvGradeAllwnc";
            this.dgvGradeAllwnc.ReadOnly = true;
            this.dgvGradeAllwnc.Size = new System.Drawing.Size(341, 264);
            this.dgvGradeAllwnc.TabIndex = 6;
            this.dgvGradeAllwnc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGradeAllwnc_CellDoubleClick);
            // 
            // RefGradeAllwnc_Cd
            // 
            this.RefGradeAllwnc_Cd.DataPropertyName = "RefGradeAllwnc_Cd";
            this.RefGradeAllwnc_Cd.HeaderText = "Код";
            this.RefGradeAllwnc_Cd.Name = "RefGradeAllwnc_Cd";
            this.RefGradeAllwnc_Cd.ReadOnly = true;
            // 
            // RefGradeAllwnc_Nm
            // 
            this.RefGradeAllwnc_Nm.DataPropertyName = "RefGradeAllwnc_Nm";
            this.RefGradeAllwnc_Nm.HeaderText = "Найменування";
            this.RefGradeAllwnc_Nm.Name = "RefGradeAllwnc_Nm";
            this.RefGradeAllwnc_Nm.ReadOnly = true;
            // 
            // RefGradeAllwnc_Pct
            // 
            this.RefGradeAllwnc_Pct.DataPropertyName = "RefGradeAllwnc_Pct";
            this.RefGradeAllwnc_Pct.HeaderText = "Відсоток";
            this.RefGradeAllwnc_Pct.Name = "RefGradeAllwnc_Pct";
            this.RefGradeAllwnc_Pct.ReadOnly = true;
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnOk);
            this.pnlControl.Controls.Add(this.btnCancel);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 288);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(341, 39);
            this.pnlControl.TabIndex = 13;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(172, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(253, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Відміна";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvGradeAllwnc);
            this.pnlGrid.Controls.Add(this.MenuRefAdm);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(341, 288);
            this.pnlGrid.TabIndex = 14;
            // 
            // fmCmbGradeAllwnc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 327);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlControl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fmCmbGradeAllwnc";
            this.Text = "Довідник надбавок за класність";
            this.Load += new System.EventHandler(this.fmCmbAllwnc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmCmbAllwnc_KeyDown);
            this.MenuRefAdm.ResumeLayout(false);
            this.MenuRefAdm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradeAllwnc)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuRefAdm;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemChoose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.DataGridView dgvGradeAllwnc;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefGradeAllwnc_Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefGradeAllwnc_Nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefGradeAllwnc_Pct;
        private System.Windows.Forms.Panel pnlGrid;
    }
}