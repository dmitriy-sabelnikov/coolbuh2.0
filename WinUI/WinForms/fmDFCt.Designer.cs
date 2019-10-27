namespace WinUI.WinForms
{
    partial class fmDFCt
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
            this.MenuDFCt = new System.Windows.Forms.MenuStrip();
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
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.dgvDFCt = new System.Windows.Forms.DataGridView();
            this.DFCt_Qrt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFCt_Yr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFCt_Nmr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFCt_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFCt_DateClc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContextMenuDFCt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuChoose = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuClc = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuDFCt.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDFCt)).BeginInit();
            this.ContextMenuDFCt.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuDFCt
            // 
            this.MenuDFCt.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuDFCt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuDFCt.Location = new System.Drawing.Point(0, 0);
            this.MenuDFCt.Name = "MenuDFCt";
            this.MenuDFCt.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuDFCt.Size = new System.Drawing.Size(594, 24);
            this.MenuDFCt.TabIndex = 7;
            this.MenuDFCt.Text = "MenuDFCt";
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
            this.MenuStripRegister.Size = new System.Drawing.Size(56, 20);
            this.MenuStripRegister.Text = "Реєстр";
            // 
            // MenuItemCreate
            // 
            this.MenuItemCreate.Name = "MenuItemCreate";
            this.MenuItemCreate.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.MenuItemCreate.Size = new System.Drawing.Size(187, 22);
            this.MenuItemCreate.Text = "Створити";
            this.MenuItemCreate.Click += new System.EventHandler(this.MenuItemCreate_Click);
            // 
            // MenuItemEdit
            // 
            this.MenuItemEdit.Name = "MenuItemEdit";
            this.MenuItemEdit.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.MenuItemEdit.Size = new System.Drawing.Size(187, 22);
            this.MenuItemEdit.Text = "Змінити";
            this.MenuItemEdit.Click += new System.EventHandler(this.MenuItemEdit_Click);
            // 
            // MenuItemDelete
            // 
            this.MenuItemDelete.Name = "MenuItemDelete";
            this.MenuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.MenuItemDelete.Size = new System.Drawing.Size(187, 22);
            this.MenuItemDelete.Text = "Видалити";
            this.MenuItemDelete.Click += new System.EventHandler(this.MenuItemDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // MenuItemRefresh
            // 
            this.MenuItemRefresh.Name = "MenuItemRefresh";
            this.MenuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.MenuItemRefresh.Size = new System.Drawing.Size(187, 22);
            this.MenuItemRefresh.Text = "Оновити";
            this.MenuItemRefresh.Click += new System.EventHandler(this.MenuItemRefresh_Click);
            // 
            // MenuItemChoose
            // 
            this.MenuItemChoose.Name = "MenuItemChoose";
            this.MenuItemChoose.ShortcutKeyDisplayString = "Enter";
            this.MenuItemChoose.Size = new System.Drawing.Size(187, 22);
            this.MenuItemChoose.Text = "Обрати";
            this.MenuItemChoose.Click += new System.EventHandler(this.MenuItemChoose_Click);
            // 
            // MenuItemClc
            // 
            this.MenuItemClc.Name = "MenuItemClc";
            this.MenuItemClc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.MenuItemClc.Size = new System.Drawing.Size(187, 22);
            this.MenuItemClc.Text = "Розрахувати";
            this.MenuItemClc.Click += new System.EventHandler(this.MenuItemClc_Click);
            // 
            // MenuItemExport
            // 
            this.MenuItemExport.Name = "MenuItemExport";
            this.MenuItemExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.MenuItemExport.Size = new System.Drawing.Size(187, 22);
            this.MenuItemExport.Text = "Експорт";
            this.MenuItemExport.Click += new System.EventHandler(this.MenuItemExport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.ShortcutKeyDisplayString = "Esc";
            this.MenuItemExit.Size = new System.Drawing.Size(187, 22);
            this.MenuItemExit.Text = "Вихід";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.statusStripRow);
            this.pnlGrid.Controls.Add(this.dgvDFCt);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 24);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(594, 364);
            this.pnlGrid.TabIndex = 8;
            // 
            // statusStripRow
            // 
            this.statusStripRow.Location = new System.Drawing.Point(0, 342);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(594, 22);
            this.statusStripRow.TabIndex = 4;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // dgvDFCt
            // 
            this.dgvDFCt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDFCt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DFCt_Qrt,
            this.DFCt_Yr,
            this.DFCt_Nmr,
            this.DFCt_Nm,
            this.DFCt_DateClc});
            this.dgvDFCt.ContextMenuStrip = this.ContextMenuDFCt;
            this.dgvDFCt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDFCt.Location = new System.Drawing.Point(0, 0);
            this.dgvDFCt.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDFCt.Name = "dgvDFCt";
            this.dgvDFCt.RowTemplate.Height = 24;
            this.dgvDFCt.Size = new System.Drawing.Size(594, 364);
            this.dgvDFCt.TabIndex = 1;
            this.dgvDFCt.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDFCt_CellDoubleClick);
            this.dgvDFCt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDFCt_KeyDown);
            // 
            // DFCt_Qrt
            // 
            this.DFCt_Qrt.DataPropertyName = "DFCt_Qrt";
            this.DFCt_Qrt.HeaderText = "Квартал";
            this.DFCt_Qrt.Name = "DFCt_Qrt";
            // 
            // DFCt_Yr
            // 
            this.DFCt_Yr.DataPropertyName = "DFCt_Yr";
            this.DFCt_Yr.HeaderText = "Рік";
            this.DFCt_Yr.Name = "DFCt_Yr";
            // 
            // DFCt_Nmr
            // 
            this.DFCt_Nmr.DataPropertyName = "DFCt_Nmr";
            this.DFCt_Nmr.HeaderText = "Номер";
            this.DFCt_Nmr.Name = "DFCt_Nmr";
            // 
            // DFCt_Nm
            // 
            this.DFCt_Nm.DataPropertyName = "DFCt_Nm";
            this.DFCt_Nm.HeaderText = "Найменування";
            this.DFCt_Nm.Name = "DFCt_Nm";
            // 
            // DFCt_DateClc
            // 
            this.DFCt_DateClc.DataPropertyName = "DFCt_DateClc";
            this.DFCt_DateClc.HeaderText = "Дата та час розрахунку";
            this.DFCt_DateClc.Name = "DFCt_DateClc";
            // 
            // ContextMenuDFCt
            // 
            this.ContextMenuDFCt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator3,
            this.ContextMenuRefresh,
            this.ContextMenuChoose,
            this.ContextMenuClc,
            this.ContextMenuExport});
            this.ContextMenuDFCt.Name = "ContextMenuPersCard";
            this.ContextMenuDFCt.Size = new System.Drawing.Size(188, 164);
            // 
            // ContextMenuCreate
            // 
            this.ContextMenuCreate.Name = "ContextMenuCreate";
            this.ContextMenuCreate.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ContextMenuCreate.Size = new System.Drawing.Size(187, 22);
            this.ContextMenuCreate.Text = "Створити";
            this.ContextMenuCreate.Click += new System.EventHandler(this.ContextMenuCreate_Click);
            // 
            // ContextMenuEdit
            // 
            this.ContextMenuEdit.Name = "ContextMenuEdit";
            this.ContextMenuEdit.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.ContextMenuEdit.Size = new System.Drawing.Size(187, 22);
            this.ContextMenuEdit.Text = "Змінити";
            this.ContextMenuEdit.Click += new System.EventHandler(this.ContextMenuEdit_Click);
            // 
            // ContextMenuDelete
            // 
            this.ContextMenuDelete.Name = "ContextMenuDelete";
            this.ContextMenuDelete.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.ContextMenuDelete.Size = new System.Drawing.Size(187, 22);
            this.ContextMenuDelete.Text = "Видалити";
            this.ContextMenuDelete.Click += new System.EventHandler(this.ContextMenuDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(184, 6);
            // 
            // ContextMenuRefresh
            // 
            this.ContextMenuRefresh.Name = "ContextMenuRefresh";
            this.ContextMenuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.ContextMenuRefresh.Size = new System.Drawing.Size(187, 22);
            this.ContextMenuRefresh.Text = "Оновити";
            this.ContextMenuRefresh.Click += new System.EventHandler(this.ContextMenuRefresh_Click);
            // 
            // ContextMenuChoose
            // 
            this.ContextMenuChoose.Name = "ContextMenuChoose";
            this.ContextMenuChoose.ShortcutKeyDisplayString = "Enter";
            this.ContextMenuChoose.Size = new System.Drawing.Size(187, 22);
            this.ContextMenuChoose.Text = "Обрати";
            this.ContextMenuChoose.Click += new System.EventHandler(this.ContextMenuChoose_Click);
            // 
            // ContextMenuClc
            // 
            this.ContextMenuClc.Name = "ContextMenuClc";
            this.ContextMenuClc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.ContextMenuClc.Size = new System.Drawing.Size(187, 22);
            this.ContextMenuClc.Text = "Розрахувати";
            this.ContextMenuClc.Click += new System.EventHandler(this.ContextMenuClc_Click);
            // 
            // ContextMenuExport
            // 
            this.ContextMenuExport.Name = "ContextMenuExport";
            this.ContextMenuExport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.ContextMenuExport.Size = new System.Drawing.Size(187, 22);
            this.ContextMenuExport.Text = "Експорт";
            this.ContextMenuExport.Click += new System.EventHandler(this.ContextMenuExport_Click);
            // 
            // fmDFCt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 388);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.MenuDFCt);
            this.Name = "fmDFCt";
            this.Text = "Форма 1 ДФ. Каталог";
            this.Load += new System.EventHandler(this.fmDFCt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmDFCt_KeyDown);
            this.MenuDFCt.ResumeLayout(false);
            this.MenuDFCt.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDFCt)).EndInit();
            this.ContextMenuDFCt.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuDFCt;
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
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.DataGridView dgvDFCt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFCt_Qrt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFCt_Yr;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFCt_Nmr;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFCt_Nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFCt_DateClc;
        private System.Windows.Forms.ContextMenuStrip ContextMenuDFCt;
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