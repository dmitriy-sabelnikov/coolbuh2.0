namespace WinUI.WinForms
{
    partial class fmUnionReportCt
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
            this.MenuUnionReportCt = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemChoose = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemClc = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvUnionReportCt = new System.Windows.Forms.DataGridView();
            this.UnionReportCt_Qrt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnionReportCt_Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnionReportCt_Nmr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnionReportCt_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnionReportCt_DateClc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.ContextMenuUnionReportCt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuChoose = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuClc = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUnionReportCt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnionReportCt)).BeginInit();
            this.ContextMenuUnionReportCt.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuUnionReportCt
            // 
            this.MenuUnionReportCt.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuUnionReportCt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuUnionReportCt.Location = new System.Drawing.Point(0, 0);
            this.MenuUnionReportCt.Name = "MenuUnionReportCt";
            this.MenuUnionReportCt.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuUnionReportCt.Size = new System.Drawing.Size(594, 27);
            this.MenuUnionReportCt.TabIndex = 8;
            this.MenuUnionReportCt.Text = "MenuUnionReportCt";
            // 
            // MenuStripRegister
            // 
            this.MenuStripRegister.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemCreate,
            this.MenuItemEdit,
            this.MenuItemDelete,
            this.toolStripSeparator1,
            this.MenuItemRefresh,
            this.MenuItemChoose,
            this.MenuItemClc,
            this.MenuItemExport,
            this.toolStripSeparator2,
            this.MenuItemExit});
            this.MenuStripRegister.Name = "MenuStripRegister";
            this.MenuStripRegister.Size = new System.Drawing.Size(62, 23);
            this.MenuStripRegister.Text = "Реєстр";
            // 
            // MenuItemCreate
            // 
            this.MenuItemCreate.Name = "MenuItemCreate";
            this.MenuItemCreate.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.MenuItemCreate.Size = new System.Drawing.Size(216, 24);
            this.MenuItemCreate.Text = "Створити";
            this.MenuItemCreate.Click += new System.EventHandler(this.MenuItemCreate_Click);
            // 
            // MenuItemEdit
            // 
            this.MenuItemEdit.Name = "MenuItemEdit";
            this.MenuItemEdit.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.MenuItemEdit.Size = new System.Drawing.Size(216, 24);
            this.MenuItemEdit.Text = "Змінити";
            this.MenuItemEdit.Click += new System.EventHandler(this.MenuItemEdit_Click);
            // 
            // MenuItemDelete
            // 
            this.MenuItemDelete.Name = "MenuItemDelete";
            this.MenuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.MenuItemDelete.Size = new System.Drawing.Size(216, 24);
            this.MenuItemDelete.Text = "Видалити";
            this.MenuItemDelete.Click += new System.EventHandler(this.MenuItemDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // MenuItemRefresh
            // 
            this.MenuItemRefresh.Name = "MenuItemRefresh";
            this.MenuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.MenuItemRefresh.Size = new System.Drawing.Size(216, 24);
            this.MenuItemRefresh.Text = "Оновити";
            this.MenuItemRefresh.Click += new System.EventHandler(this.MenuItemRefresh_Click);
            // 
            // MenuItemChoose
            // 
            this.MenuItemChoose.Name = "MenuItemChoose";
            this.MenuItemChoose.ShortcutKeyDisplayString = "Enter";
            this.MenuItemChoose.Size = new System.Drawing.Size(216, 24);
            this.MenuItemChoose.Text = "Обрати";
            this.MenuItemChoose.Click += new System.EventHandler(this.MenuItemChoose_Click);
            // 
            // MenuItemClc
            // 
            this.MenuItemClc.Name = "MenuItemClc";
            this.MenuItemClc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.MenuItemClc.Size = new System.Drawing.Size(216, 24);
            this.MenuItemClc.Text = "Розрахувати";
            this.MenuItemClc.Click += new System.EventHandler(this.MenuItemClc_Click);
            // 
            // MenuItemExport
            // 
            this.MenuItemExport.Name = "MenuItemExport";
            this.MenuItemExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.MenuItemExport.Size = new System.Drawing.Size(216, 24);
            this.MenuItemExport.Text = "Експорт";
            this.MenuItemExport.Click += new System.EventHandler(this.MenuItemExport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.ShortcutKeyDisplayString = "Esc";
            this.MenuItemExit.Size = new System.Drawing.Size(216, 24);
            this.MenuItemExit.Text = "Вихід";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // dgvUnionReportCt
            // 
            this.dgvUnionReportCt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnionReportCt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UnionReportCt_Qrt,
            this.UnionReportCt_Year,
            this.UnionReportCt_Nmr,
            this.UnionReportCt_Nm,
            this.UnionReportCt_DateClc});
            this.dgvUnionReportCt.ContextMenuStrip = this.ContextMenuUnionReportCt;
            this.dgvUnionReportCt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnionReportCt.Location = new System.Drawing.Point(0, 27);
            this.dgvUnionReportCt.Margin = new System.Windows.Forms.Padding(2);
            this.dgvUnionReportCt.Name = "dgvUnionReportCt";
            this.dgvUnionReportCt.RowTemplate.Height = 24;
            this.dgvUnionReportCt.Size = new System.Drawing.Size(594, 361);
            this.dgvUnionReportCt.TabIndex = 9;
            this.dgvUnionReportCt.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnionReportCt_CellDoubleClick);
            this.dgvUnionReportCt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUnionReportCt_KeyDown);
            // 
            // UnionReportCt_Qrt
            // 
            this.UnionReportCt_Qrt.DataPropertyName = "UnionReportCt_Qrt";
            this.UnionReportCt_Qrt.HeaderText = "Квартал";
            this.UnionReportCt_Qrt.Name = "UnionReportCt_Qrt";
            // 
            // UnionReportCt_Year
            // 
            this.UnionReportCt_Year.DataPropertyName = "UnionReportCt_Year";
            this.UnionReportCt_Year.HeaderText = "Рік";
            this.UnionReportCt_Year.Name = "UnionReportCt_Year";
            // 
            // UnionReportCt_Nmr
            // 
            this.UnionReportCt_Nmr.DataPropertyName = "UnionReportCt_Nmr";
            this.UnionReportCt_Nmr.HeaderText = "Номер";
            this.UnionReportCt_Nmr.Name = "UnionReportCt_Nmr";
            // 
            // UnionReportCt_Nm
            // 
            this.UnionReportCt_Nm.DataPropertyName = "UnionReportCt_Nm";
            this.UnionReportCt_Nm.HeaderText = "Найменування";
            this.UnionReportCt_Nm.Name = "UnionReportCt_Nm";
            // 
            // UnionReportCt_DateClc
            // 
            this.UnionReportCt_DateClc.DataPropertyName = "UnionReportCt_DateClc";
            this.UnionReportCt_DateClc.HeaderText = "Дата та час розрахунку";
            this.UnionReportCt_DateClc.Name = "UnionReportCt_DateClc";
            // 
            // statusStripRow
            // 
            this.statusStripRow.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStripRow.Location = new System.Drawing.Point(0, 366);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(594, 22);
            this.statusStripRow.TabIndex = 10;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // ContextMenuUnionReportCt
            // 
            this.ContextMenuUnionReportCt.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.ContextMenuUnionReportCt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator3,
            this.ContextMenuRefresh,
            this.ContextMenuChoose,
            this.ContextMenuClc,
            this.ContextMenuExport});
            this.ContextMenuUnionReportCt.Name = "ContextMenuPersCard";
            this.ContextMenuUnionReportCt.Size = new System.Drawing.Size(213, 203);
            // 
            // ContextMenuCreate
            // 
            this.ContextMenuCreate.Name = "ContextMenuCreate";
            this.ContextMenuCreate.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ContextMenuCreate.Size = new System.Drawing.Size(212, 24);
            this.ContextMenuCreate.Text = "Створити";
            this.ContextMenuCreate.Click += new System.EventHandler(this.MenuItemCreate_Click);
            // 
            // ContextMenuEdit
            // 
            this.ContextMenuEdit.Name = "ContextMenuEdit";
            this.ContextMenuEdit.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.ContextMenuEdit.Size = new System.Drawing.Size(212, 24);
            this.ContextMenuEdit.Text = "Змінити";
            this.ContextMenuEdit.Click += new System.EventHandler(this.MenuItemEdit_Click);
            // 
            // ContextMenuDelete
            // 
            this.ContextMenuDelete.Name = "ContextMenuDelete";
            this.ContextMenuDelete.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.ContextMenuDelete.Size = new System.Drawing.Size(212, 24);
            this.ContextMenuDelete.Text = "Видалити";
            this.ContextMenuDelete.Click += new System.EventHandler(this.MenuItemDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(209, 6);
            // 
            // ContextMenuRefresh
            // 
            this.ContextMenuRefresh.Name = "ContextMenuRefresh";
            this.ContextMenuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.ContextMenuRefresh.Size = new System.Drawing.Size(212, 24);
            this.ContextMenuRefresh.Text = "Оновити";
            this.ContextMenuRefresh.Click += new System.EventHandler(this.MenuItemRefresh_Click);
            // 
            // ContextMenuChoose
            // 
            this.ContextMenuChoose.Name = "ContextMenuChoose";
            this.ContextMenuChoose.ShortcutKeyDisplayString = "Enter";
            this.ContextMenuChoose.Size = new System.Drawing.Size(212, 24);
            this.ContextMenuChoose.Text = "Обрати";
            this.ContextMenuChoose.Click += new System.EventHandler(this.MenuItemChoose_Click);
            // 
            // ContextMenuClc
            // 
            this.ContextMenuClc.Name = "ContextMenuClc";
            this.ContextMenuClc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.ContextMenuClc.Size = new System.Drawing.Size(212, 24);
            this.ContextMenuClc.Text = "Розрахувати";
            this.ContextMenuClc.Click += new System.EventHandler(this.MenuItemClc_Click);
            // 
            // ContextMenuExport
            // 
            this.ContextMenuExport.Name = "ContextMenuExport";
            this.ContextMenuExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.ContextMenuExport.Size = new System.Drawing.Size(212, 24);
            this.ContextMenuExport.Text = "Експорт";
            this.ContextMenuExport.Click += new System.EventHandler(this.MenuItemExport_Click);
            // 
            // fmUnionReportCt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 388);
            this.Controls.Add(this.statusStripRow);
            this.Controls.Add(this.dgvUnionReportCt);
            this.Controls.Add(this.MenuUnionReportCt);
            this.Name = "fmUnionReportCt";
            this.Text = "Об\'єднана звітність. Каталог";
            this.Load += new System.EventHandler(this.fmUnionReportCt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmUnionReportCt_KeyDown);
            this.MenuUnionReportCt.ResumeLayout(false);
            this.MenuUnionReportCt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnionReportCt)).EndInit();
            this.ContextMenuUnionReportCt.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuUnionReportCt;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem MenuItemChoose;
        private System.Windows.Forms.ToolStripMenuItem MenuItemClc;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.DataGridView dgvUnionReportCt;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnionReportCt_Qrt;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnionReportCt_Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnionReportCt_Nmr;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnionReportCt_Nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnionReportCt_DateClc;
        private System.Windows.Forms.ContextMenuStrip ContextMenuUnionReportCt;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRefresh;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuChoose;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuClc;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuExport;
    }
}