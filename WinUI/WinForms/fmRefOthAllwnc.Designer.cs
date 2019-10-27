namespace WinUI.WinForms
{
    partial class fmRefOthAllwnc
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
            this.dgvOthAllwnc = new System.Windows.Forms.DataGridView();
            this.RefOthAllwnc_Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefOthAllwnc_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefOthAllwnc_Pct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Використовувати = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MenuRefOthAllwnc = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.ContextMenuRefOthAllwnc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOthAllwnc)).BeginInit();
            this.MenuRefOthAllwnc.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.ContextMenuRefOthAllwnc.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOthAllwnc
            // 
            this.dgvOthAllwnc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOthAllwnc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefOthAllwnc_Cd,
            this.RefOthAllwnc_Nm,
            this.RefOthAllwnc_Pct,
            this.Використовувати});
            this.dgvOthAllwnc.ContextMenuStrip = this.ContextMenuRefOthAllwnc;
            this.dgvOthAllwnc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOthAllwnc.Location = new System.Drawing.Point(0, 0);
            this.dgvOthAllwnc.Margin = new System.Windows.Forms.Padding(2);
            this.dgvOthAllwnc.Name = "dgvOthAllwnc";
            this.dgvOthAllwnc.RowTemplate.Height = 24;
            this.dgvOthAllwnc.Size = new System.Drawing.Size(602, 366);
            this.dgvOthAllwnc.TabIndex = 5;
            this.dgvOthAllwnc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvOthAllwnc_KeyDown);
            // 
            // RefOthAllwnc_Cd
            // 
            this.RefOthAllwnc_Cd.DataPropertyName = "RefOthAllwnc_Cd";
            this.RefOthAllwnc_Cd.HeaderText = "Код";
            this.RefOthAllwnc_Cd.Name = "RefOthAllwnc_Cd";
            // 
            // RefOthAllwnc_Nm
            // 
            this.RefOthAllwnc_Nm.DataPropertyName = "RefOthAllwnc_Nm";
            this.RefOthAllwnc_Nm.HeaderText = "Найменування";
            this.RefOthAllwnc_Nm.Name = "RefOthAllwnc_Nm";
            // 
            // RefOthAllwnc_Pct
            // 
            this.RefOthAllwnc_Pct.DataPropertyName = "RefOthAllwnc_Pct";
            this.RefOthAllwnc_Pct.HeaderText = "Відсоток";
            this.RefOthAllwnc_Pct.Name = "RefOthAllwnc_Pct";
            // 
            // Використовувати
            // 
            this.Використовувати.DataPropertyName = "RefOthAllwnc_Use";
            this.Використовувати.FalseValue = "1";
            this.Використовувати.HeaderText = "Використовувати";
            this.Використовувати.Name = "Використовувати";
            this.Використовувати.TrueValue = "0";
            // 
            // MenuRefOthAllwnc
            // 
            this.MenuRefOthAllwnc.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuRefOthAllwnc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuRefOthAllwnc.Location = new System.Drawing.Point(0, 0);
            this.MenuRefOthAllwnc.Name = "MenuRefOthAllwnc";
            this.MenuRefOthAllwnc.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuRefOthAllwnc.Size = new System.Drawing.Size(602, 24);
            this.MenuRefOthAllwnc.TabIndex = 4;
            this.MenuRefOthAllwnc.Text = "MenuRefOthAllwnc";
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
            this.MenuItemCreate.Size = new System.Drawing.Size(148, 22);
            this.MenuItemCreate.Text = "Створити";
            this.MenuItemCreate.Click += new System.EventHandler(this.MenuItemCreate_Click);
            // 
            // MenuItemEdit
            // 
            this.MenuItemEdit.Name = "MenuItemEdit";
            this.MenuItemEdit.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.MenuItemEdit.Size = new System.Drawing.Size(148, 22);
            this.MenuItemEdit.Text = "Змінити";
            this.MenuItemEdit.Click += new System.EventHandler(this.MenuItemEdit_Click);
            // 
            // MenuItemDelete
            // 
            this.MenuItemDelete.Name = "MenuItemDelete";
            this.MenuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.MenuItemDelete.Size = new System.Drawing.Size(148, 22);
            this.MenuItemDelete.Text = "Видалити";
            this.MenuItemDelete.Click += new System.EventHandler(this.MenuItemDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // MenuItemRefresh
            // 
            this.MenuItemRefresh.Name = "MenuItemRefresh";
            this.MenuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.MenuItemRefresh.Size = new System.Drawing.Size(148, 22);
            this.MenuItemRefresh.Text = "Оновити";
            this.MenuItemRefresh.Click += new System.EventHandler(this.MenuItemRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.ShortcutKeyDisplayString = "Esc";
            this.MenuItemExit.Size = new System.Drawing.Size(148, 22);
            this.MenuItemExit.Text = "Вихід";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // statusStripRow
            // 
            this.statusStripRow.Location = new System.Drawing.Point(0, 390);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(602, 22);
            this.statusStripRow.TabIndex = 8;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvOthAllwnc);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 24);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(602, 366);
            this.pnlGrid.TabIndex = 9;
            // 
            // ContextMenuRefOthAllwnc
            // 
            this.ContextMenuRefOthAllwnc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator3,
            this.ContextMenuRefresh,
            this.toolStripSeparator4});
            this.ContextMenuRefOthAllwnc.Name = "ContextMenuPersCard";
            this.ContextMenuRefOthAllwnc.Size = new System.Drawing.Size(153, 126);
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
            // fmRefOthAllwnc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 412);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.statusStripRow);
            this.Controls.Add(this.MenuRefOthAllwnc);
            this.Name = "fmRefOthAllwnc";
            this.Text = "Довідник інших надбавок";
            this.Load += new System.EventHandler(this.fmRefOthAllwnc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmRefOthAllwnc_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOthAllwnc)).EndInit();
            this.MenuRefOthAllwnc.ResumeLayout(false);
            this.MenuRefOthAllwnc.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.ContextMenuRefOthAllwnc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOthAllwnc;
        private System.Windows.Forms.MenuStrip MenuRefOthAllwnc;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefOthAllwnc_Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefOthAllwnc_Nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefOthAllwnc_Pct;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Використовувати;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ContextMenuStrip ContextMenuRefOthAllwnc;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}