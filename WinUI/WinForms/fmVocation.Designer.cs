namespace WinUI.WinForms
{
    partial class fmVocation
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
            this.MenuVocation = new System.Windows.Forms.MenuStrip();
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
            this.horizontal_pnl = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCalendar = new System.Windows.Forms.ComboBox();
            this.left_pnl = new System.Windows.Forms.Panel();
            this.dgvDep = new System.Windows.Forms.DataGridView();
            this.DepName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.rigth_pnl = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvVocation = new System.Windows.Forms.DataGridView();
            this.ContextMenuVocation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuDeps = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripResult = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatTotDays = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatTotSm = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatTotResSm = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.Vocation_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersCard_TIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersCard_FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefDep_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vocation_PayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vocation_Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vocation_Sm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuVocation.SuspendLayout();
            this.horizontal_pnl.SuspendLayout();
            this.left_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDep)).BeginInit();
            this.rigth_pnl.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVocation)).BeginInit();
            this.ContextMenuVocation.SuspendLayout();
            this.statusStripResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuVocation
            // 
            this.MenuVocation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuVocation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister,
            this.MenuStripView});
            this.MenuVocation.Location = new System.Drawing.Point(0, 0);
            this.MenuVocation.Name = "MenuVocation";
            this.MenuVocation.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuVocation.Size = new System.Drawing.Size(864, 24);
            this.MenuVocation.TabIndex = 2;
            this.MenuVocation.Text = "MenuVocation";
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
            // horizontal_pnl
            // 
            this.horizontal_pnl.Controls.Add(this.label1);
            this.horizontal_pnl.Controls.Add(this.cmbCalendar);
            this.horizontal_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.horizontal_pnl.Location = new System.Drawing.Point(0, 24);
            this.horizontal_pnl.Name = "horizontal_pnl";
            this.horizontal_pnl.Size = new System.Drawing.Size(864, 31);
            this.horizontal_pnl.TabIndex = 3;
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
            this.cmbCalendar.FormattingEnabled = true;
            this.cmbCalendar.Location = new System.Drawing.Point(51, 3);
            this.cmbCalendar.Name = "cmbCalendar";
            this.cmbCalendar.Size = new System.Drawing.Size(159, 21);
            this.cmbCalendar.TabIndex = 0;
            this.cmbCalendar.SelectedIndexChanged += new System.EventHandler(this.cmbCalendar_SelectedIndexChanged);
            // 
            // left_pnl
            // 
            this.left_pnl.Controls.Add(this.dgvDep);
            this.left_pnl.Dock = System.Windows.Forms.DockStyle.Left;
            this.left_pnl.Location = new System.Drawing.Point(0, 55);
            this.left_pnl.Name = "left_pnl";
            this.left_pnl.Size = new System.Drawing.Size(210, 424);
            this.left_pnl.TabIndex = 4;
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
            this.dgvDep.Size = new System.Drawing.Size(210, 424);
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
            this.splitter1.Size = new System.Drawing.Size(1, 424);
            this.splitter1.TabIndex = 5;
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
            this.rigth_pnl.Size = new System.Drawing.Size(653, 424);
            this.rigth_pnl.TabIndex = 6;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvVocation);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(653, 380);
            this.pnlGrid.TabIndex = 11;
            // 
            // dgvVocation
            // 
            this.dgvVocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVocation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vocation_Date,
            this.PersCard_TIN,
            this.PersCard_FullName,
            this.RefDep_Name,
            this.Vocation_PayDate,
            this.Vocation_Days,
            this.Vocation_Sm});
            this.dgvVocation.ContextMenuStrip = this.ContextMenuVocation;
            this.dgvVocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVocation.Location = new System.Drawing.Point(0, 0);
            this.dgvVocation.Margin = new System.Windows.Forms.Padding(2);
            this.dgvVocation.Name = "dgvVocation";
            this.dgvVocation.RowTemplate.Height = 24;
            this.dgvVocation.Size = new System.Drawing.Size(653, 380);
            this.dgvVocation.TabIndex = 1;
            this.dgvVocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvVocation_KeyDown);
            // 
            // ContextMenuVocation
            // 
            this.ContextMenuVocation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator3,
            this.ContextMenuRefresh,
            this.toolStripSeparator4,
            this.ContextMenuDeps});
            this.ContextMenuVocation.Name = "ContextMenuPersCard";
            this.ContextMenuVocation.Size = new System.Drawing.Size(192, 126);
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
            this.statusStripResult.ImageScalingSize = new System.Drawing.Size(19, 19);
            this.statusStripResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.StatTotDays,
            this.StatTotSm,
            this.StatTotResSm});
            this.statusStripResult.Location = new System.Drawing.Point(0, 380);
            this.statusStripResult.Name = "statusStripResult";
            this.statusStripResult.Size = new System.Drawing.Size(653, 22);
            this.statusStripResult.TabIndex = 10;
            this.statusStripResult.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // StatTotDays
            // 
            this.StatTotDays.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.StatTotDays.ForeColor = System.Drawing.Color.Navy;
            this.StatTotDays.Name = "StatTotDays";
            this.StatTotDays.Size = new System.Drawing.Size(68, 17);
            this.StatTotDays.Text = "Всього дні:";
            // 
            // StatTotSm
            // 
            this.StatTotSm.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.StatTotSm.ForeColor = System.Drawing.Color.Navy;
            this.StatTotSm.Name = "StatTotSm";
            this.StatTotSm.Size = new System.Drawing.Size(78, 17);
            this.StatTotSm.Text = "Всього сума:";
            // 
            // StatTotResSm
            // 
            this.StatTotResSm.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.StatTotResSm.ForeColor = System.Drawing.Color.Navy;
            this.StatTotResSm.Name = "StatTotResSm";
            this.StatTotResSm.Size = new System.Drawing.Size(78, 17);
            this.StatTotResSm.Text = "Всього сума:";
            // 
            // statusStripRow
            // 
            this.statusStripRow.ImageScalingSize = new System.Drawing.Size(19, 19);
            this.statusStripRow.Location = new System.Drawing.Point(0, 402);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(653, 22);
            this.statusStripRow.TabIndex = 8;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // Vocation_Date
            // 
            this.Vocation_Date.DataPropertyName = "Vocation_Date";
            this.Vocation_Date.HeaderText = "Дата";
            this.Vocation_Date.Name = "Vocation_Date";
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
            // Vocation_PayDate
            // 
            this.Vocation_PayDate.DataPropertyName = "Vocation_PayDate";
            this.Vocation_PayDate.HeaderText = "Дата, за яку проводиться нарахування";
            this.Vocation_PayDate.Name = "Vocation_PayDate";
            // 
            // Vocation_Days
            // 
            this.Vocation_Days.DataPropertyName = "Vocation_Days";
            this.Vocation_Days.HeaderText = "Дні";
            this.Vocation_Days.Name = "Vocation_Days";
            // 
            // Vocation_Sm
            // 
            this.Vocation_Sm.DataPropertyName = "Vocation_Sm";
            this.Vocation_Sm.HeaderText = "Сума";
            this.Vocation_Sm.Name = "Vocation_Sm";
            // 
            // fmVocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 479);
            this.Controls.Add(this.rigth_pnl);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.left_pnl);
            this.Controls.Add(this.horizontal_pnl);
            this.Controls.Add(this.MenuVocation);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fmVocation";
            this.Text = "Відпускні";
            this.Load += new System.EventHandler(this.fmVocation_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmVocation_KeyDown);
            this.MenuVocation.ResumeLayout(false);
            this.MenuVocation.PerformLayout();
            this.horizontal_pnl.ResumeLayout(false);
            this.horizontal_pnl.PerformLayout();
            this.left_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDep)).EndInit();
            this.rigth_pnl.ResumeLayout(false);
            this.rigth_pnl.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVocation)).EndInit();
            this.ContextMenuVocation.ResumeLayout(false);
            this.statusStripResult.ResumeLayout(false);
            this.statusStripResult.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuVocation;
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
        private System.Windows.Forms.Panel horizontal_pnl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCalendar;
        private System.Windows.Forms.Panel left_pnl;
        private System.Windows.Forms.DataGridView dgvDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepName;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel rigth_pnl;
        private System.Windows.Forms.DataGridView dgvVocation;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.StatusStrip statusStripResult;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StatTotDays;
        private System.Windows.Forms.ToolStripStatusLabel StatTotSm;
        private System.Windows.Forms.ToolStripStatusLabel StatTotResSm;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ContextMenuStrip ContextMenuVocation;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDeps;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vocation_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersCard_TIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersCard_FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefDep_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vocation_PayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vocation_Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vocation_Sm;
    }
}