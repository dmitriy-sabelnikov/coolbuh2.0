namespace WinUI.WinForms
{
    partial class fmUSTCt
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
            this.MenuUSTCt = new System.Windows.Forms.MenuStrip();
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
            this.dgvUSTCt = new System.Windows.Forms.DataGridView();
            this.ContextMenuUSTCt = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuChoose = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuClc = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.USTCt_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USTCt_Nmr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USTCt_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USTCt_DateClc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuUSTCt.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUSTCt)).BeginInit();
            this.ContextMenuUSTCt.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuUSTCt
            // 
            this.MenuUSTCt.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuUSTCt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuUSTCt.Location = new System.Drawing.Point(0, 0);
            this.MenuUSTCt.Name = "MenuUSTCt";
            this.MenuUSTCt.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuUSTCt.Size = new System.Drawing.Size(594, 24);
            this.MenuUSTCt.TabIndex = 6;
            this.MenuUSTCt.Text = "MenuUSTCt";
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
            this.pnlGrid.Controls.Add(this.dgvUSTCt);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 24);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(594, 364);
            this.pnlGrid.TabIndex = 7;
            // 
            // statusStripRow
            // 
            this.statusStripRow.Location = new System.Drawing.Point(0, 342);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(594, 22);
            this.statusStripRow.TabIndex = 4;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // dgvUSTCt
            // 
            this.dgvUSTCt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUSTCt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.USTCt_Date,
            this.USTCt_Nmr,
            this.USTCt_Nm,
            this.USTCt_DateClc});
            this.dgvUSTCt.ContextMenuStrip = this.ContextMenuUSTCt;
            this.dgvUSTCt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUSTCt.Location = new System.Drawing.Point(0, 0);
            this.dgvUSTCt.Margin = new System.Windows.Forms.Padding(2);
            this.dgvUSTCt.Name = "dgvUSTCt";
            this.dgvUSTCt.RowTemplate.Height = 24;
            this.dgvUSTCt.Size = new System.Drawing.Size(594, 364);
            this.dgvUSTCt.TabIndex = 1;
            this.dgvUSTCt.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUSTCt_CellDoubleClick);
            this.dgvUSTCt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUSTCt_KeyDown);
            // 
            // ContextMenuUSTCt
            // 
            this.ContextMenuUSTCt.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator3,
            this.ContextMenuRefresh,
            this.ContextMenuChoose,
            this.ContextMenuClc,
            this.ContextMenuExport});
            this.ContextMenuUSTCt.Name = "ContextMenuPersCard";
            this.ContextMenuUSTCt.Size = new System.Drawing.Size(188, 164);
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
            // USTCt_Date
            // 
            this.USTCt_Date.DataPropertyName = "USTCt_Date";
            this.USTCt_Date.HeaderText = "Дата ЄСВ";
            this.USTCt_Date.Name = "USTCt_Date";
            // 
            // USTCt_Nmr
            // 
            this.USTCt_Nmr.DataPropertyName = "USTCt_Nmr";
            this.USTCt_Nmr.HeaderText = "Номер";
            this.USTCt_Nmr.Name = "USTCt_Nmr";
            // 
            // USTCt_Nm
            // 
            this.USTCt_Nm.DataPropertyName = "USTCt_Nm";
            this.USTCt_Nm.HeaderText = "Найменування";
            this.USTCt_Nm.Name = "USTCt_Nm";
            // 
            // USTCt_DateClc
            // 
            this.USTCt_DateClc.DataPropertyName = "USTCt_DateClc";
            this.USTCt_DateClc.HeaderText = "Дата та час розрахунку";
            this.USTCt_DateClc.Name = "USTCt_DateClc";
            // 
            // fmUSTCt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 388);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.MenuUSTCt);
            this.Name = "fmUSTCt";
            this.Text = "Єдиний соціальний внесок. Каталог";
            this.Load += new System.EventHandler(this.fmUSTCt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmUSTCt_KeyDown);
            this.MenuUSTCt.ResumeLayout(false);
            this.MenuUSTCt.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUSTCt)).EndInit();
            this.ContextMenuUSTCt.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuUSTCt;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvUSTCt;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.ToolStripMenuItem MenuItemClc;
        private System.Windows.Forms.ToolStripMenuItem MenuItemChoose;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExport;
        private System.Windows.Forms.ContextMenuStrip ContextMenuUSTCt;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRefresh;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuChoose;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuClc;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn USTCt_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn USTCt_Nmr;
        private System.Windows.Forms.DataGridViewTextBoxColumn USTCt_Nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn USTCt_DateClc;
    }
}