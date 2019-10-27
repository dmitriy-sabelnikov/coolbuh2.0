namespace WinUI.WinForms
{
    partial class fmRefAdm
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
            this.MenuRefAdm = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvRefAdm = new System.Windows.Forms.DataGridView();
            this.RefAdm_NmDol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefAdm_TIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefAdm_FIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefAdm_Tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.ContextMenuRefAdm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuRefAdm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefAdm)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.ContextMenuRefAdm.SuspendLayout();
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
            this.MenuRefAdm.Size = new System.Drawing.Size(533, 24);
            this.MenuRefAdm.TabIndex = 1;
            this.MenuRefAdm.Text = "MenuRefAdm";
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
            // dgvRefAdm
            // 
            this.dgvRefAdm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefAdm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefAdm_NmDol,
            this.RefAdm_TIN,
            this.RefAdm_FIO,
            this.RefAdm_Tel});
            this.dgvRefAdm.ContextMenuStrip = this.ContextMenuRefAdm;
            this.dgvRefAdm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRefAdm.Location = new System.Drawing.Point(0, 0);
            this.dgvRefAdm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvRefAdm.Name = "dgvRefAdm";
            this.dgvRefAdm.RowTemplate.Height = 24;
            this.dgvRefAdm.Size = new System.Drawing.Size(533, 328);
            this.dgvRefAdm.TabIndex = 2;
            this.dgvRefAdm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRefAdm_KeyDown);
            // 
            // RefAdm_NmDol
            // 
            this.RefAdm_NmDol.DataPropertyName = "RefAdm_NmDol";
            this.RefAdm_NmDol.HeaderText = "Посада";
            this.RefAdm_NmDol.Name = "RefAdm_NmDol";
            // 
            // RefAdm_TIN
            // 
            this.RefAdm_TIN.DataPropertyName = "RefAdm_TIN";
            this.RefAdm_TIN.HeaderText = "ІПН";
            this.RefAdm_TIN.Name = "RefAdm_TIN";
            // 
            // RefAdm_FIO
            // 
            this.RefAdm_FIO.DataPropertyName = "RefAdm_FIO";
            this.RefAdm_FIO.HeaderText = "Прізвище та ініціали";
            this.RefAdm_FIO.Name = "RefAdm_FIO";
            // 
            // RefAdm_Tel
            // 
            this.RefAdm_Tel.DataPropertyName = "RefAdm_Tel";
            this.RefAdm_Tel.HeaderText = "Телефон";
            this.RefAdm_Tel.Name = "RefAdm_Tel";
            // 
            // statusStripRow
            // 
            this.statusStripRow.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripRow.Location = new System.Drawing.Point(0, 352);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(533, 22);
            this.statusStripRow.TabIndex = 8;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvRefAdm);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 24);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(533, 328);
            this.pnlGrid.TabIndex = 9;
            // 
            // ContextMenuRefAdm
            // 
            this.ContextMenuRefAdm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator3,
            this.ContextMenuRefresh,
            this.toolStripSeparator4});
            this.ContextMenuRefAdm.Name = "ContextMenuPersCard";
            this.ContextMenuRefAdm.Size = new System.Drawing.Size(153, 126);
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
            // fmRefAdm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 374);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.statusStripRow);
            this.Controls.Add(this.MenuRefAdm);
            this.Name = "fmRefAdm";
            this.Text = "Довідник адміністрцій";
            this.Load += new System.EventHandler(this.fmRefAdm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmRefAdm_KeyDown);
            this.MenuRefAdm.ResumeLayout(false);
            this.MenuRefAdm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefAdm)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.ContextMenuRefAdm.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuRefAdm;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.DataGridView dgvRefAdm;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefAdm_NmDol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefAdm_TIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefAdm_FIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefAdm_Tel;
        private System.Windows.Forms.ContextMenuStrip ContextMenuRefAdm;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}