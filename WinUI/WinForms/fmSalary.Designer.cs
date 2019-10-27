namespace WinUI.WinForms
{
    partial class fmSalary
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
            this.MenuSalary = new System.Windows.Forms.MenuStrip();
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
            this.rigth_pnl = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvSalary = new System.Windows.Forms.DataGridView();
            this.Salary_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersCard_TIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersCard_FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefDep_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary_Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary_Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary_BaseSm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary_PensSm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary_ExpSm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary_GradeSm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary_OthSm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary_KTU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary_KTUSm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary_ResSm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStripResult = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatTotDays = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatTotHours = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatTotBaseSm = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatTotAllwncSm = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatTotKTUSm = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatTotResSm = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.ContextMenuSalary = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuDeps = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSalary.SuspendLayout();
            this.horizontal_pnl.SuspendLayout();
            this.left_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDep)).BeginInit();
            this.rigth_pnl.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).BeginInit();
            this.statusStripResult.SuspendLayout();
            this.ContextMenuSalary.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuSalary
            // 
            this.MenuSalary.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuSalary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister,
            this.MenuStripView});
            this.MenuSalary.Location = new System.Drawing.Point(0, 0);
            this.MenuSalary.Name = "MenuSalary";
            this.MenuSalary.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuSalary.Size = new System.Drawing.Size(839, 24);
            this.MenuSalary.TabIndex = 1;
            this.MenuSalary.Text = "MenuSalary";
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
            this.horizontal_pnl.Size = new System.Drawing.Size(839, 31);
            this.horizontal_pnl.TabIndex = 2;
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
            this.left_pnl.Size = new System.Drawing.Size(210, 333);
            this.left_pnl.TabIndex = 3;
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
            // rigth_pnl
            // 
            this.rigth_pnl.Controls.Add(this.pnlGrid);
            this.rigth_pnl.Controls.Add(this.statusStripResult);
            this.rigth_pnl.Controls.Add(this.statusStripRow);
            this.rigth_pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rigth_pnl.Location = new System.Drawing.Point(211, 55);
            this.rigth_pnl.Name = "rigth_pnl";
            this.rigth_pnl.Size = new System.Drawing.Size(628, 333);
            this.rigth_pnl.TabIndex = 4;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvSalary);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(628, 289);
            this.pnlGrid.TabIndex = 12;
            // 
            // dgvSalary
            // 
            this.dgvSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Salary_Date,
            this.PersCard_TIN,
            this.PersCard_FullName,
            this.RefDep_Name,
            this.Salary_Days,
            this.Salary_Hours,
            this.Salary_BaseSm,
            this.Salary_PensSm,
            this.Salary_ExpSm,
            this.Salary_GradeSm,
            this.Salary_OthSm,
            this.Salary_KTU,
            this.Salary_KTUSm,
            this.Salary_ResSm});
            this.dgvSalary.ContextMenuStrip = this.ContextMenuSalary;
            this.dgvSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalary.Location = new System.Drawing.Point(0, 0);
            this.dgvSalary.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSalary.Name = "dgvSalary";
            this.dgvSalary.RowTemplate.Height = 24;
            this.dgvSalary.Size = new System.Drawing.Size(628, 289);
            this.dgvSalary.TabIndex = 1;
            this.dgvSalary.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSalary_KeyDown);
            // 
            // Salary_Date
            // 
            this.Salary_Date.DataPropertyName = "Salary_Date";
            this.Salary_Date.HeaderText = "Дата";
            this.Salary_Date.Name = "Salary_Date";
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
            // Salary_Days
            // 
            this.Salary_Days.DataPropertyName = "Salary_Days";
            this.Salary_Days.HeaderText = "Дні";
            this.Salary_Days.Name = "Salary_Days";
            // 
            // Salary_Hours
            // 
            this.Salary_Hours.DataPropertyName = "Salary_Hours";
            this.Salary_Hours.HeaderText = "Години";
            this.Salary_Hours.Name = "Salary_Hours";
            // 
            // Salary_BaseSm
            // 
            this.Salary_BaseSm.DataPropertyName = "Salary_BaseSm";
            this.Salary_BaseSm.HeaderText = "Основна зарплата";
            this.Salary_BaseSm.Name = "Salary_BaseSm";
            // 
            // Salary_PensSm
            // 
            this.Salary_PensSm.DataPropertyName = "Salary_PensSm";
            this.Salary_PensSm.HeaderText = "Доплата пенсіонеру";
            this.Salary_PensSm.Name = "Salary_PensSm";
            // 
            // Salary_ExpSm
            // 
            this.Salary_ExpSm.DataPropertyName = "Salary_ExpSm";
            this.Salary_ExpSm.HeaderText = "Доплата за стаж";
            this.Salary_ExpSm.Name = "Salary_ExpSm";
            // 
            // Salary_GradeSm
            // 
            this.Salary_GradeSm.DataPropertyName = "Salary_GradeSm";
            this.Salary_GradeSm.HeaderText = "Доплата за класність";
            this.Salary_GradeSm.Name = "Salary_GradeSm";
            // 
            // Salary_OthSm
            // 
            this.Salary_OthSm.DataPropertyName = "Salary_OthSm";
            this.Salary_OthSm.HeaderText = "Інші доплати";
            this.Salary_OthSm.Name = "Salary_OthSm";
            // 
            // Salary_KTU
            // 
            this.Salary_KTU.DataPropertyName = "Salary_KTU";
            this.Salary_KTU.HeaderText = "КТУ";
            this.Salary_KTU.Name = "Salary_KTU";
            // 
            // Salary_KTUSm
            // 
            this.Salary_KTUSm.DataPropertyName = "Salary_KTUSm";
            this.Salary_KTUSm.HeaderText = "Доплата за КТУ";
            this.Salary_KTUSm.Name = "Salary_KTUSm";
            // 
            // Salary_ResSm
            // 
            this.Salary_ResSm.DataPropertyName = "Salary_ResSm";
            this.Salary_ResSm.HeaderText = "Всього";
            this.Salary_ResSm.Name = "Salary_ResSm";
            // 
            // statusStripResult
            // 
            this.statusStripResult.ImageScalingSize = new System.Drawing.Size(19, 19);
            this.statusStripResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.StatTotDays,
            this.StatTotHours,
            this.StatTotBaseSm,
            this.StatTotAllwncSm,
            this.StatTotKTUSm,
            this.StatTotResSm});
            this.statusStripResult.Location = new System.Drawing.Point(0, 289);
            this.statusStripResult.Name = "statusStripResult";
            this.statusStripResult.Size = new System.Drawing.Size(628, 22);
            this.statusStripResult.TabIndex = 11;
            this.statusStripResult.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // StatTotDays
            // 
            this.StatTotDays.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatTotDays.ForeColor = System.Drawing.Color.Navy;
            this.StatTotDays.Name = "StatTotDays";
            this.StatTotDays.Size = new System.Drawing.Size(71, 17);
            this.StatTotDays.Text = "Всього дні: ";
            // 
            // StatTotHours
            // 
            this.StatTotHours.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.StatTotHours.ForeColor = System.Drawing.Color.Navy;
            this.StatTotHours.Name = "StatTotHours";
            this.StatTotHours.Size = new System.Drawing.Size(91, 17);
            this.StatTotHours.Text = "Всього години:";
            // 
            // StatTotBaseSm
            // 
            this.StatTotBaseSm.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.StatTotBaseSm.ForeColor = System.Drawing.Color.Navy;
            this.StatTotBaseSm.Name = "StatTotBaseSm";
            this.StatTotBaseSm.Size = new System.Drawing.Size(101, 17);
            this.StatTotBaseSm.Text = "Всього зарплата:";
            // 
            // StatTotAllwncSm
            // 
            this.StatTotAllwncSm.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.StatTotAllwncSm.ForeColor = System.Drawing.Color.Navy;
            this.StatTotAllwncSm.Name = "StatTotAllwncSm";
            this.StatTotAllwncSm.Size = new System.Drawing.Size(120, 17);
            this.StatTotAllwncSm.Text = "Всього сума доплат:";
            // 
            // StatTotKTUSm
            // 
            this.StatTotKTUSm.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.StatTotKTUSm.ForeColor = System.Drawing.Color.Navy;
            this.StatTotKTUSm.Name = "StatTotKTUSm";
            this.StatTotKTUSm.Size = new System.Drawing.Size(149, 17);
            this.StatTotKTUSm.Text = "Всього сума згідно з КТУ:";
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
            this.statusStripRow.Location = new System.Drawing.Point(0, 311);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(628, 22);
            this.statusStripRow.TabIndex = 8;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(210, 55);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 333);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // ContextMenuSalary
            // 
            this.ContextMenuSalary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator3,
            this.ContextMenuRefresh,
            this.toolStripSeparator4,
            this.ContextMenuDeps});
            this.ContextMenuSalary.Name = "ContextMenuPersCard";
            this.ContextMenuSalary.Size = new System.Drawing.Size(192, 148);
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
            // fmSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 388);
            this.Controls.Add(this.rigth_pnl);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.left_pnl);
            this.Controls.Add(this.horizontal_pnl);
            this.Controls.Add(this.MenuSalary);
            this.Name = "fmSalary";
            this.Text = "Заробітна плата";
            this.Load += new System.EventHandler(this.fmSalary_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmSalary_KeyDown);
            this.MenuSalary.ResumeLayout(false);
            this.MenuSalary.PerformLayout();
            this.horizontal_pnl.ResumeLayout(false);
            this.horizontal_pnl.PerformLayout();
            this.left_pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDep)).EndInit();
            this.rigth_pnl.ResumeLayout(false);
            this.rigth_pnl.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalary)).EndInit();
            this.statusStripResult.ResumeLayout(false);
            this.statusStripResult.PerformLayout();
            this.ContextMenuSalary.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuSalary;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.Panel horizontal_pnl;
        private System.Windows.Forms.Panel left_pnl;
        private System.Windows.Forms.Panel rigth_pnl;
        private System.Windows.Forms.DataGridView dgvDep;
        private System.Windows.Forms.DataGridView dgvSalary;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCalendar;
        private System.Windows.Forms.ToolStripMenuItem MenuStripView;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDeps;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersCard_TIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersCard_FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefDep_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary_Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary_Hours;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary_BaseSm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary_PensSm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary_ExpSm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary_GradeSm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary_OthSm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary_KTU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary_KTUSm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary_ResSm;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepName;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.StatusStrip statusStripResult;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StatTotDays;
        private System.Windows.Forms.ToolStripStatusLabel StatTotHours;
        private System.Windows.Forms.ToolStripStatusLabel StatTotBaseSm;
        private System.Windows.Forms.ToolStripStatusLabel StatTotResSm;
        private System.Windows.Forms.ToolStripStatusLabel StatTotAllwncSm;
        private System.Windows.Forms.ToolStripStatusLabel StatTotKTUSm;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ContextMenuStrip ContextMenuSalary;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDeps;
    }
}