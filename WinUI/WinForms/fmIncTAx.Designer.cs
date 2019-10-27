namespace WinUI.WinForms
{
    partial class fmIncTax
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
            this.MenuIncTax = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontal_pnl = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCalendar = new System.Windows.Forms.ComboBox();
            this.dgvIncTax = new System.Windows.Forms.DataGridView();
            this.IncTax_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersCard_TIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersCard_FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncTax_Sm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.statusStripResult = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatTotSm = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.ContextMenuIncTax = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuIncTax.SuspendLayout();
            this.horizontal_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncTax)).BeginInit();
            this.statusStripResult.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.ContextMenuIncTax.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuIncTax
            // 
            this.MenuIncTax.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuIncTax.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuIncTax.Location = new System.Drawing.Point(0, 0);
            this.MenuIncTax.Name = "MenuIncTax";
            this.MenuIncTax.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuIncTax.Size = new System.Drawing.Size(594, 24);
            this.MenuIncTax.TabIndex = 4;
            this.MenuIncTax.Text = "MenuIncTax";
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
            // horizontal_pnl
            // 
            this.horizontal_pnl.Controls.Add(this.label1);
            this.horizontal_pnl.Controls.Add(this.cmbCalendar);
            this.horizontal_pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.horizontal_pnl.Location = new System.Drawing.Point(0, 24);
            this.horizontal_pnl.Name = "horizontal_pnl";
            this.horizontal_pnl.Size = new System.Drawing.Size(594, 31);
            this.horizontal_pnl.TabIndex = 5;
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
            // dgvIncTax
            // 
            this.dgvIncTax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncTax.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IncTax_Date,
            this.PersCard_TIN,
            this.PersCard_FullName,
            this.IncTax_Sm});
            this.dgvIncTax.ContextMenuStrip = this.ContextMenuIncTax;
            this.dgvIncTax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIncTax.Location = new System.Drawing.Point(0, 0);
            this.dgvIncTax.Margin = new System.Windows.Forms.Padding(2);
            this.dgvIncTax.Name = "dgvIncTax";
            this.dgvIncTax.RowTemplate.Height = 24;
            this.dgvIncTax.Size = new System.Drawing.Size(594, 289);
            this.dgvIncTax.TabIndex = 6;
            this.dgvIncTax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvIncTax_KeyDown);
            // 
            // IncTax_Date
            // 
            this.IncTax_Date.DataPropertyName = "IncTax_Date";
            this.IncTax_Date.HeaderText = "Дата";
            this.IncTax_Date.Name = "IncTax_Date";
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
            // IncTax_Sm
            // 
            this.IncTax_Sm.DataPropertyName = "IncTax_Sm";
            this.IncTax_Sm.HeaderText = "Сума";
            this.IncTax_Sm.Name = "IncTax_Sm";
            // 
            // statusStripRow
            // 
            this.statusStripRow.Location = new System.Drawing.Point(0, 366);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(594, 22);
            this.statusStripRow.TabIndex = 7;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // statusStripResult
            // 
            this.statusStripResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.StatTotSm});
            this.statusStripResult.Location = new System.Drawing.Point(0, 344);
            this.statusStripResult.Name = "statusStripResult";
            this.statusStripResult.Size = new System.Drawing.Size(594, 22);
            this.statusStripResult.TabIndex = 8;
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
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvIncTax);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 55);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(594, 289);
            this.pnlGrid.TabIndex = 9;
            // 
            // ContextMenuIncTax
            // 
            this.ContextMenuIncTax.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator3,
            this.ContextMenuRefresh});
            this.ContextMenuIncTax.Name = "ContextMenuPersCard";
            this.ContextMenuIncTax.Size = new System.Drawing.Size(153, 120);
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
            // fmIncTax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 388);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.statusStripResult);
            this.Controls.Add(this.statusStripRow);
            this.Controls.Add(this.horizontal_pnl);
            this.Controls.Add(this.MenuIncTax);
            this.Name = "fmIncTax";
            this.Text = "Корегування прибуткового податку";
            this.Load += new System.EventHandler(this.fmIncTax_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmIncTax_KeyDown);
            this.MenuIncTax.ResumeLayout(false);
            this.MenuIncTax.PerformLayout();
            this.horizontal_pnl.ResumeLayout(false);
            this.horizontal_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncTax)).EndInit();
            this.statusStripResult.ResumeLayout(false);
            this.statusStripResult.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.ContextMenuIncTax.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuIncTax;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.Panel horizontal_pnl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCalendar;
        private System.Windows.Forms.DataGridView dgvIncTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncTax_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersCard_TIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersCard_FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncTax_Sm;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.StatusStrip statusStripResult;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StatTotSm;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ContextMenuStrip ContextMenuIncTax;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRefresh;
    }
}