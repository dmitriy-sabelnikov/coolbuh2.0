namespace WinUI.WinForms
{
    partial class fmRefSpecExp
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
            this.MenuRefSpecExp = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvRefSpecExp = new System.Windows.Forms.DataGridView();
            this.RefSpecExp_Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefSpecExp_C_Pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefSpecExp_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.ContextMenuRefSpecExp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuRefSpecExp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefSpecExp)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.ContextMenuRefSpecExp.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuRefSpecExp
            // 
            this.MenuRefSpecExp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuRefSpecExp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuRefSpecExp.Location = new System.Drawing.Point(0, 0);
            this.MenuRefSpecExp.Name = "MenuRefSpecExp";
            this.MenuRefSpecExp.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuRefSpecExp.Size = new System.Drawing.Size(589, 24);
            this.MenuRefSpecExp.TabIndex = 1;
            this.MenuRefSpecExp.Text = "MenuRefSpecExp";
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
            // dgvRefSpecExp
            // 
            this.dgvRefSpecExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefSpecExp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefSpecExp_Cd,
            this.RefSpecExp_C_Pid,
            this.RefSpecExp_Name});
            this.dgvRefSpecExp.ContextMenuStrip = this.ContextMenuRefSpecExp;
            this.dgvRefSpecExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRefSpecExp.Location = new System.Drawing.Point(0, 0);
            this.dgvRefSpecExp.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRefSpecExp.Name = "dgvRefSpecExp";
            this.dgvRefSpecExp.RowTemplate.Height = 24;
            this.dgvRefSpecExp.Size = new System.Drawing.Size(589, 331);
            this.dgvRefSpecExp.TabIndex = 3;
            this.dgvRefSpecExp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRefSpecExp_KeyDown);
            // 
            // RefSpecExp_Cd
            // 
            this.RefSpecExp_Cd.DataPropertyName = "RefSpecExp_Cd";
            this.RefSpecExp_Cd.HeaderText = "Код";
            this.RefSpecExp_Cd.Name = "RefSpecExp_Cd";
            // 
            // RefSpecExp_C_Pid
            // 
            this.RefSpecExp_C_Pid.DataPropertyName = "RefSpecExp_C_Pid";
            this.RefSpecExp_C_Pid.HeaderText = "Код підстави";
            this.RefSpecExp_C_Pid.Name = "RefSpecExp_C_Pid";
            // 
            // RefSpecExp_Name
            // 
            this.RefSpecExp_Name.DataPropertyName = "RefSpecExp_Name";
            this.RefSpecExp_Name.HeaderText = "Повне найменування";
            this.RefSpecExp_Name.Name = "RefSpecExp_Name";
            // 
            // statusStripRow
            // 
            this.statusStripRow.Location = new System.Drawing.Point(0, 355);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(589, 22);
            this.statusStripRow.TabIndex = 8;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvRefSpecExp);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 24);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(589, 331);
            this.pnlGrid.TabIndex = 9;
            // 
            // ContextMenuRefSpecExp
            // 
            this.ContextMenuRefSpecExp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator3,
            this.ContextMenuRefresh,
            this.toolStripSeparator4});
            this.ContextMenuRefSpecExp.Name = "ContextMenuPersCard";
            this.ContextMenuRefSpecExp.Size = new System.Drawing.Size(153, 126);
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
            // fmRefSpecExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 377);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.statusStripRow);
            this.Controls.Add(this.MenuRefSpecExp);
            this.Name = "fmRefSpecExp";
            this.Text = "Довідник спецстажів";
            this.Load += new System.EventHandler(this.fmRefSpecExp_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmRefSpecExp_KeyDown);
            this.MenuRefSpecExp.ResumeLayout(false);
            this.MenuRefSpecExp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefSpecExp)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.ContextMenuRefSpecExp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuRefSpecExp;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.DataGridView dgvRefSpecExp;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefSpecExp_Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefSpecExp_C_Pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefSpecExp_Name;
        private System.Windows.Forms.ContextMenuStrip ContextMenuRefSpecExp;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}