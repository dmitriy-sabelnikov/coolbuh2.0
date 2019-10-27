namespace WinUI.WinForms
{
    partial class fmAddAccr
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
            this.horizontal_pnl = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCalendar = new System.Windows.Forms.ComboBox();
            this.MenuAddAccr = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripView = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDeps = new System.Windows.Forms.ToolStripMenuItem();
            this.left_pnl = new System.Windows.Forms.Panel();
            this.dgvDep = new System.Windows.Forms.DataGridView();
            this.DepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.rigth_pnl = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvAddAccr = new System.Windows.Forms.DataGridView();
            this.AddAccr_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersCard_TIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersCard_FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefDep_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddAccr_RefTypeAddAccr_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddAccr_Sm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContextMenuAddAccr = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuDeps = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripResult = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatTotSm = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.horizontal_pnl.SuspendLayout();
            this.MenuAddAccr.SuspendLayout();
            this.left_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDep)).BeginInit();
            this.rigth_pnl.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddAccr)).BeginInit();
            this.ContextMenuAddAccr.SuspendLayout();
            this.statusStripResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // horizontal_pnl
            // 
            this.horizontal_pnl.Controls.Add(this.label1);
            this.horizontal_pnl.Controls.Add(this.cmbCalendar);
            this.horizontal_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.horizontal_pnl.Location = new System.Drawing.Point(0, 24);
            this.horizontal_pnl.Name = "horizontal_pnl";
            this.horizontal_pnl.Size = new System.Drawing.Size(594, 31);
            this.horizontal_pnl.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Період:";
            // 
            // cmbCalendar
            // 
            this.cmbCalendar.ForeColor = System.Drawing.Color.Black;
            this.cmbCalendar.FormattingEnabled = true;
            this.cmbCalendar.Location = new System.Drawing.Point(51, 3);
            this.cmbCalendar.Name = "cmbCalendar";
            this.cmbCalendar.Size = new System.Drawing.Size(159, 21);
            this.cmbCalendar.TabIndex = 0;
            this.cmbCalendar.SelectedIndexChanged += new System.EventHandler(this.cmbCalendar_SelectedIndexChanged);
            // 
            // MenuAddAccr
            // 
            this.MenuAddAccr.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuAddAccr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister,
            this.MenuStripView});
            this.MenuAddAccr.Location = new System.Drawing.Point(0, 0);
            this.MenuAddAccr.Name = "MenuAddAccr";
            this.MenuAddAccr.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuAddAccr.Size = new System.Drawing.Size(594, 24);
            this.MenuAddAccr.TabIndex = 5;
            this.MenuAddAccr.Text = "MenuAddAccr";
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
            // MenuStripView
            // 
            this.MenuStripView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemDeps});
            this.MenuStripView.Name = "MenuStripView";
            this.MenuStripView.Size = new System.Drawing.Size(39, 20);
            this.MenuStripView.Text = "Вид";
            // 
            // MenuItemDeps
            // 
            this.MenuItemDeps.Checked = true;
            this.MenuItemDeps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItemDeps.Name = "MenuItemDeps";
            this.MenuItemDeps.Size = new System.Drawing.Size(191, 22);
            this.MenuItemDeps.Text = "Навігатор підрозділів";
            this.MenuItemDeps.Click += new System.EventHandler(this.MenuItemDeps_Click);
            // 
            // left_pnl
            // 
            this.left_pnl.Controls.Add(this.dgvDep);
            this.left_pnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.left_pnl.Location = new System.Drawing.Point(0, 55);
            this.left_pnl.Name = "left_pnl";
            this.left_pnl.Size = new System.Drawing.Size(210, 333);
            this.left_pnl.TabIndex = 7;
            // 
            // dgvDep
            // 
            this.dgvDep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DepName});
            this.dgvDep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDep.Location = new System.Drawing.Point(0, 0);
            this.dgvDep.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDep.Name = "dgvDep";
            this.dgvDep.RowTemplate.Height = 24;
            this.dgvDep.Size = new System.Drawing.Size(210, 333);
            this.dgvDep.TabIndex = 2;
            this.dgvDep.SelectionChanged += new System.EventHandler(this.dgvDep_SelectionChanged);
            this.dgvDep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDep_KeyDown);
            // 
            // DepName
            // 
            this.DepName.DataPropertyName = "Name";
            this.DepName.HeaderText = "Найменування";
            this.DepName.Name = "DepName";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(210, 55);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 333);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // rigth_pnl
            // 
            this.rigth_pnl.Controls.Add(this.pnlGrid);
            this.rigth_pnl.Controls.Add(this.statusStripResult);
            this.rigth_pnl.Controls.Add(this.statusStripRow);
            this.rigth_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rigth_pnl.Location = new System.Drawing.Point(211, 55);
            this.rigth_pnl.Name = "rigth_pnl";
            this.rigth_pnl.Size = new System.Drawing.Size(383, 333);
            this.rigth_pnl.TabIndex = 9;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvAddAccr);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(383, 289);
            this.pnlGrid.TabIndex = 5;
            // 
            // dgvAddAccr
            // 
            this.dgvAddAccr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddAccr.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AddAccr_Date,
            this.PersCard_TIN,
            this.PersCard_FullName,
            this.RefDep_Name,
            this.AddAccr_RefTypeAddAccr_Nm,
            this.AddAccr_Sm});
            this.dgvAddAccr.ContextMenuStrip = this.ContextMenuAddAccr;
            this.dgvAddAccr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAddAccr.Location = new System.Drawing.Point(0, 0);
            this.dgvAddAccr.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAddAccr.Name = "dgvAddAccr";
            this.dgvAddAccr.RowTemplate.Height = 24;
            this.dgvAddAccr.Size = new System.Drawing.Size(383, 289);
            this.dgvAddAccr.TabIndex = 1;
            this.dgvAddAccr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAddAccr_KeyDown);
            // 
            // AddAccr_Date
            // 
            this.AddAccr_Date.DataPropertyName = "AddAccr_Date";
            this.AddAccr_Date.HeaderText = "Дата";
            this.AddAccr_Date.Name = "AddAccr_Date";
            // 
            // PersCard_TIN
            // 
            this.PersCard_TIN.DataPropertyName = "PersCard_TIN";
            this.PersCard_TIN.HeaderText = "Код";
            this.PersCard_TIN.Name = "PersCard_TIN";
            // 
            // PersCard_FullName
            // 
            this.PersCard_FullName.DataPropertyName = "PersCard_FullName";
            this.PersCard_FullName.HeaderText = "Прізвище та ініціали";
            this.PersCard_FullName.Name = "PersCard_FullName";
            // 
            // RefDep_Name
            // 
            this.RefDep_Name.DataPropertyName = "RefDep_Name";
            this.RefDep_Name.HeaderText = "Підрозділ";
            this.RefDep_Name.Name = "RefDep_Name";
            // 
            // AddAccr_RefTypeAddAccr_Nm
            // 
            this.AddAccr_RefTypeAddAccr_Nm.DataPropertyName = "AddAccr_RefTypeAddAccr_Nm";
            this.AddAccr_RefTypeAddAccr_Nm.HeaderText = "Тип";
            this.AddAccr_RefTypeAddAccr_Nm.Name = "AddAccr_RefTypeAddAccr_Nm";
            // 
            // AddAccr_Sm
            // 
            this.AddAccr_Sm.DataPropertyName = "AddAccr_Sm";
            this.AddAccr_Sm.HeaderText = "Сума";
            this.AddAccr_Sm.Name = "AddAccr_Sm";
            // 
            // ContextMenuAddAccr
            // 
            this.ContextMenuAddAccr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator3,
            this.ContextMenuRefresh,
            this.toolStripSeparator4,
            this.ContextMenuDeps});
            this.ContextMenuAddAccr.Name = "ContextMenuPersCard";
            this.ContextMenuAddAccr.Size = new System.Drawing.Size(192, 126);
            // 
            // ContextMenuCreate
            // 
            this.ContextMenuCreate.Name = "ContextMenuCreate";
            this.ContextMenuCreate.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ContextMenuCreate.Size = new System.Drawing.Size(191, 22);
            this.ContextMenuCreate.Text = "Створити";
            this.ContextMenuCreate.Click += new System.EventHandler(this.ContextMenuCreate_Click);
            // 
            // ContextMenuEdit
            // 
            this.ContextMenuEdit.Name = "ContextMenuEdit";
            this.ContextMenuEdit.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.ContextMenuEdit.Size = new System.Drawing.Size(191, 22);
            this.ContextMenuEdit.Text = "Змінити";
            this.ContextMenuEdit.Click += new System.EventHandler(this.ContextMenuEdit_Click);
            // 
            // ContextMenuDelete
            // 
            this.ContextMenuDelete.Name = "ContextMenuDelete";
            this.ContextMenuDelete.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.ContextMenuDelete.Size = new System.Drawing.Size(191, 22);
            this.ContextMenuDelete.Text = "Видалити";
            this.ContextMenuDelete.Click += new System.EventHandler(this.ContextMenuDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
            // 
            // ContextMenuRefresh
            // 
            this.ContextMenuRefresh.Name = "ContextMenuRefresh";
            this.ContextMenuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.ContextMenuRefresh.Size = new System.Drawing.Size(191, 22);
            this.ContextMenuRefresh.Text = "Оновити";
            this.ContextMenuRefresh.Click += new System.EventHandler(this.ContextMenuRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(188, 6);
            // 
            // ContextMenuDeps
            // 
            this.ContextMenuDeps.Checked = true;
            this.ContextMenuDeps.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ContextMenuDeps.Name = "ContextMenuDeps";
            this.ContextMenuDeps.Size = new System.Drawing.Size(191, 22);
            this.ContextMenuDeps.Text = "Навігатор підрозділів";
            this.ContextMenuDeps.Click += new System.EventHandler(this.ContextMenuDeps_Click);
            // 
            // statusStripResult
            // 
            this.statusStripResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.StatTotSm});
            this.statusStripResult.Location = new System.Drawing.Point(0, 289);
            this.statusStripResult.Name = "statusStripResult";
            this.statusStripResult.Size = new System.Drawing.Size(383, 22);
            this.statusStripResult.TabIndex = 4;
            this.statusStripResult.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // StatTotSm
            // 
            this.StatTotSm.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatTotSm.ForeColor = System.Drawing.Color.Navy;
            this.StatTotSm.Name = "StatTotSm";
            this.StatTotSm.Size = new System.Drawing.Size(81, 17);
            this.StatTotSm.Text = "Всього сума: ";
            // 
            // statusStripRow
            // 
            this.statusStripRow.Location = new System.Drawing.Point(0, 311);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(383, 22);
            this.statusStripRow.TabIndex = 3;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // fmAddAccr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 388);
            this.Controls.Add(this.rigth_pnl);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.left_pnl);
            this.Controls.Add(this.horizontal_pnl);
            this.Controls.Add(this.MenuAddAccr);
            this.Name = "fmAddAccr";
            this.Text = "Додаткові нарахування";
            this.Load += new System.EventHandler(this.fmAddAccr_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmAddAccr_KeyDown);
            this.horizontal_pnl.ResumeLayout(false);
            this.horizontal_pnl.PerformLayout();
            this.MenuAddAccr.ResumeLayout(false);
            this.MenuAddAccr.PerformLayout();
            this.left_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDep)).EndInit();
            this.rigth_pnl.ResumeLayout(false);
            this.rigth_pnl.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddAccr)).EndInit();
            this.ContextMenuAddAccr.ResumeLayout(false);
            this.statusStripResult.ResumeLayout(false);
            this.statusStripResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel horizontal_pnl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCalendar;
        private System.Windows.Forms.MenuStrip MenuAddAccr;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem MenuStripView;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDeps;
        private System.Windows.Forms.Panel left_pnl;
        private System.Windows.Forms.DataGridView dgvDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepName;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel rigth_pnl;
        private System.Windows.Forms.DataGridView dgvAddAccr;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddAccr_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersCard_TIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersCard_FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefDep_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddAccr_RefTypeAddAccr_Nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddAccr_Sm;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.StatusStrip statusStripResult;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StatTotSm;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ContextMenuStrip ContextMenuAddAccr;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDeps;
    }
}