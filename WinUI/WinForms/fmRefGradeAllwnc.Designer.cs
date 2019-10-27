namespace WinUI.WinForms
{
    partial class fmRefGradeAllwnc
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
            this.components = new System.ComponentModel.Container();
            this.MenuRefGradeAllwnc = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvGradeAllwnc = new System.Windows.Forms.DataGridView();
            this.RefGradeAllwnc_Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefGradeAllwnc_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefGradeAllwnc_Pct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefGradeAllwnc_Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefGradeAllwnc_RefDep_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Використовувати = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.ContextMenuRefGradeAllwnc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuRefGradeAllwnc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradeAllwnc)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.ContextMenuRefGradeAllwnc.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuRefGradeAllwnc
            // 
            this.MenuRefGradeAllwnc.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuRefGradeAllwnc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuRefGradeAllwnc.Location = new System.Drawing.Point(0, 0);
            this.MenuRefGradeAllwnc.Name = "MenuRefGradeAllwnc";
            this.MenuRefGradeAllwnc.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuRefGradeAllwnc.Size = new System.Drawing.Size(525, 24);
            this.MenuRefGradeAllwnc.TabIndex = 1;
            this.MenuRefGradeAllwnc.Text = "MenuAllowance";
            // 
            // MenuStripRegister
            // 
            this.MenuStripRegister.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemCreate,
            this.MenuItemEdit,
            this.MenuItemDelete,
            this.toolStripSeparator1,
            this.MenuItemRefresh,
            this.toolStripSeparator2,
            this.MenuItemExit});
            this.MenuStripRegister.Name = "MenuStripRegister";
            this.MenuStripRegister.Size = new System.Drawing.Size(56, 20);
            this.MenuStripRegister.Text = "Реєстр";
            // 
            // MenuItemCreate
            // 
            this.MenuItemCreate.Name = "MenuItemCreate";
            this.MenuItemCreate.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.MenuItemCreate.Size = new System.Drawing.Size(152, 22);
            this.MenuItemCreate.Text = "Створити";
            this.MenuItemCreate.Click += new System.EventHandler(this.MenuItemCreate_Click);
            // 
            // MenuItemEdit
            // 
            this.MenuItemEdit.Name = "MenuItemEdit";
            this.MenuItemEdit.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.MenuItemEdit.Size = new System.Drawing.Size(152, 22);
            this.MenuItemEdit.Text = "Змінити";
            this.MenuItemEdit.Click += new System.EventHandler(this.MenuItemEdit_Click);
            // 
            // MenuItemDelete
            // 
            this.MenuItemDelete.Name = "MenuItemDelete";
            this.MenuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.MenuItemDelete.Size = new System.Drawing.Size(152, 22);
            this.MenuItemDelete.Text = "Видалити";
            this.MenuItemDelete.Click += new System.EventHandler(this.MenuItemDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // MenuItemRefresh
            // 
            this.MenuItemRefresh.Name = "MenuItemRefresh";
            this.MenuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.MenuItemRefresh.Size = new System.Drawing.Size(152, 22);
            this.MenuItemRefresh.Text = "Оновити";
            this.MenuItemRefresh.Click += new System.EventHandler(this.MenuItemRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.ShortcutKeyDisplayString = "Esc";
            this.MenuItemExit.Size = new System.Drawing.Size(152, 22);
            this.MenuItemExit.Text = "Вихід";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // dgvGradeAllwnc
            // 
            this.dgvGradeAllwnc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGradeAllwnc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefGradeAllwnc_Cd,
            this.RefGradeAllwnc_Nm,
            this.RefGradeAllwnc_Pct,
            this.RefGradeAllwnc_Grade,
            this.RefGradeAllwnc_RefDep_Nm,
            this.Використовувати});
            this.dgvGradeAllwnc.ContextMenuStrip = this.ContextMenuRefGradeAllwnc;
            this.dgvGradeAllwnc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGradeAllwnc.Location = new System.Drawing.Point(0, 0);
            this.dgvGradeAllwnc.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGradeAllwnc.Name = "dgvGradeAllwnc";
            this.dgvGradeAllwnc.RowTemplate.Height = 24;
            this.dgvGradeAllwnc.Size = new System.Drawing.Size(525, 241);
            this.dgvGradeAllwnc.TabIndex = 2;
            this.dgvGradeAllwnc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAllowance_KeyDown);
            // 
            // RefGradeAllwnc_Cd
            // 
            this.RefGradeAllwnc_Cd.DataPropertyName = "RefGradeAllwnc_Cd";
            this.RefGradeAllwnc_Cd.HeaderText = "Код";
            this.RefGradeAllwnc_Cd.Name = "RefGradeAllwnc_Cd";
            // 
            // RefGradeAllwnc_Nm
            // 
            this.RefGradeAllwnc_Nm.DataPropertyName = "RefGradeAllwnc_Nm";
            this.RefGradeAllwnc_Nm.HeaderText = "Найменування";
            this.RefGradeAllwnc_Nm.Name = "RefGradeAllwnc_Nm";
            // 
            // RefGradeAllwnc_Pct
            // 
            this.RefGradeAllwnc_Pct.DataPropertyName = "RefGradeAllwnc_Pct";
            this.RefGradeAllwnc_Pct.HeaderText = "Відсоток";
            this.RefGradeAllwnc_Pct.Name = "RefGradeAllwnc_Pct";
            // 
            // RefGradeAllwnc_Grade
            // 
            this.RefGradeAllwnc_Grade.DataPropertyName = "RefGradeAllwnc_Grade";
            this.RefGradeAllwnc_Grade.HeaderText = "Класність";
            this.RefGradeAllwnc_Grade.Name = "RefGradeAllwnc_Grade";
            // 
            // RefGradeAllwnc_RefDep_Nm
            // 
            this.RefGradeAllwnc_RefDep_Nm.DataPropertyName = "RefGradeAllwnc_RefDep_Nm";
            this.RefGradeAllwnc_RefDep_Nm.HeaderText = "Підрозділ";
            this.RefGradeAllwnc_RefDep_Nm.Name = "RefGradeAllwnc_RefDep_Nm";
            // 
            // Використовувати
            // 
            this.Використовувати.DataPropertyName = "RefGradeAllwnc_Use";
            this.Використовувати.FalseValue = "1";
            this.Використовувати.HeaderText = "Використовувати";
            this.Використовувати.Name = "Використовувати";
            this.Використовувати.TrueValue = "0";
            // 
            // statusStripRow
            // 
            this.statusStripRow.Location = new System.Drawing.Point(0, 265);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(525, 22);
            this.statusStripRow.TabIndex = 8;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvGradeAllwnc);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 24);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(525, 241);
            this.pnlGrid.TabIndex = 9;
            // 
            // ContextMenuRefGradeAllwnc
            // 
            this.ContextMenuRefGradeAllwnc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator3,
            this.ContextMenuRefresh,
            this.toolStripSeparator4});
            this.ContextMenuRefGradeAllwnc.Name = "ContextMenuPersCard";
            this.ContextMenuRefGradeAllwnc.Size = new System.Drawing.Size(153, 126);
            // 
            // ContextMenuCreate
            // 
            this.ContextMenuCreate.Name = "ContextMenuCreate";
            this.ContextMenuCreate.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ContextMenuCreate.Size = new System.Drawing.Size(152, 22);
            this.ContextMenuCreate.Text = "Створити";
            this.ContextMenuCreate.Click += new System.EventHandler(this.ContextMenuCreate_Click);
            // 
            // ContextMenuEdit
            // 
            this.ContextMenuEdit.Name = "ContextMenuEdit";
            this.ContextMenuEdit.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.ContextMenuEdit.Size = new System.Drawing.Size(152, 22);
            this.ContextMenuEdit.Text = "Змінити";
            this.ContextMenuEdit.Click += new System.EventHandler(this.ContextMenuEdit_Click);
            // 
            // ContextMenuDelete
            // 
            this.ContextMenuDelete.Name = "ContextMenuDelete";
            this.ContextMenuDelete.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.ContextMenuDelete.Size = new System.Drawing.Size(152, 22);
            this.ContextMenuDelete.Text = "Видалити";
            this.ContextMenuDelete.Click += new System.EventHandler(this.ContextMenuDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // ContextMenuRefresh
            // 
            this.ContextMenuRefresh.Name = "ContextMenuRefresh";
            this.ContextMenuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.ContextMenuRefresh.Size = new System.Drawing.Size(152, 22);
            this.ContextMenuRefresh.Text = "Оновити";
            this.ContextMenuRefresh.Click += new System.EventHandler(this.ContextMenuRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // fmRefGradeAllwnc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 287);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.statusStripRow);
            this.Controls.Add(this.MenuRefGradeAllwnc);
            this.Name = "fmRefGradeAllwnc";
            this.Text = "Довідник надбавок за класність";
            this.Load += new System.EventHandler(this.fmAllowance_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmAllowance_KeyDown);
            this.MenuRefGradeAllwnc.ResumeLayout(false);
            this.MenuRefGradeAllwnc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradeAllwnc)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.ContextMenuRefGradeAllwnc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuRefGradeAllwnc;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.DataGridView dgvGradeAllwnc;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefGradeAllwnc_Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefGradeAllwnc_Nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefGradeAllwnc_Pct;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefGradeAllwnc_Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefGradeAllwnc_RefDep_Nm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Використовувати;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ContextMenuStrip ContextMenuRefGradeAllwnc;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}