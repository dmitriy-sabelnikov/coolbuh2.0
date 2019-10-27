namespace WinUI.WinForms
{
    partial class fmRefDep
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
            this.MenuRefDep = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvRefDep = new System.Windows.Forms.DataGridView();
            this.RefDep_Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefDep_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.ContextMenuRefDep = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuRefDep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefDep)).BeginInit();
            this.pnlGrid.SuspendLayout();
            this.ContextMenuRefDep.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuRefDep
            // 
            this.MenuRefDep.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuRefDep.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuRefDep.Location = new System.Drawing.Point(0, 0);
            this.MenuRefDep.Name = "MenuRefDep";
            this.MenuRefDep.Size = new System.Drawing.Size(381, 24);
            this.MenuRefDep.TabIndex = 1;
            this.MenuRefDep.Text = "menuRefDep";
            // 
            // MenuStripRegister
            // 
            this.MenuStripRegister.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemCreate,
            this.MenuItemEdit,
            this.MenuItemDelete,
            this.toolStripSeparator3,
            this.MenuItemRefresh,
            this.toolStripSeparator1,
            this.MenuItemExit});
            this.MenuStripRegister.Name = "MenuStripRegister";
            this.MenuStripRegister.Size = new System.Drawing.Size(56, 20);
            this.MenuStripRegister.Text = "Реєстр";
            this.MenuStripRegister.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MenuItemCreate
            // 
            this.MenuItemCreate.Name = "MenuItemCreate";
            this.MenuItemCreate.ShortcutKeyDisplayString = "Ins";
            this.MenuItemCreate.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.MenuItemCreate.Size = new System.Drawing.Size(152, 22);
            this.MenuItemCreate.Text = "Створити";
            this.MenuItemCreate.Click += new System.EventHandler(this.MenuItemCreate_Click);
            // 
            // MenuItemEdit
            // 
            this.MenuItemEdit.Name = "MenuItemEdit";
            this.MenuItemEdit.ShortcutKeyDisplayString = "F4";
            this.MenuItemEdit.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.MenuItemEdit.Size = new System.Drawing.Size(152, 22);
            this.MenuItemEdit.Text = "Змінити";
            this.MenuItemEdit.Click += new System.EventHandler(this.MenuItemEdit_Click);
            // 
            // MenuItemDelete
            // 
            this.MenuItemDelete.Name = "MenuItemDelete";
            this.MenuItemDelete.ShortcutKeyDisplayString = "F8";
            this.MenuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.MenuItemDelete.Size = new System.Drawing.Size(152, 22);
            this.MenuItemDelete.Text = "Видалити";
            this.MenuItemDelete.Click += new System.EventHandler(this.MenuItemDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // MenuItemRefresh
            // 
            this.MenuItemRefresh.Name = "MenuItemRefresh";
            this.MenuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.MenuItemRefresh.Size = new System.Drawing.Size(152, 22);
            this.MenuItemRefresh.Text = "Оновити";
            this.MenuItemRefresh.Click += new System.EventHandler(this.MenuItemRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.ShortcutKeyDisplayString = "Esc";
            this.MenuItemExit.Size = new System.Drawing.Size(152, 22);
            this.MenuItemExit.Text = "Вихід";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // dgvRefDep
            // 
            this.dgvRefDep.AllowUserToAddRows = false;
            this.dgvRefDep.AllowUserToDeleteRows = false;
            this.dgvRefDep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefDep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefDep_Cd,
            this.RefDep_Nm});
            this.dgvRefDep.ContextMenuStrip = this.ContextMenuRefDep;
            this.dgvRefDep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRefDep.Location = new System.Drawing.Point(0, 0);
            this.dgvRefDep.Name = "dgvRefDep";
            this.dgvRefDep.ReadOnly = true;
            this.dgvRefDep.Size = new System.Drawing.Size(381, 325);
            this.dgvRefDep.TabIndex = 2;
            this.dgvRefDep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRefDep_KeyDown);
            // 
            // RefDep_Cd
            // 
            this.RefDep_Cd.DataPropertyName = "RefDep_Cd";
            this.RefDep_Cd.HeaderText = "Код";
            this.RefDep_Cd.Name = "RefDep_Cd";
            this.RefDep_Cd.ReadOnly = true;
            // 
            // RefDep_Nm
            // 
            this.RefDep_Nm.DataPropertyName = "RefDep_Nm";
            this.RefDep_Nm.HeaderText = "Найменування";
            this.RefDep_Nm.Name = "RefDep_Nm";
            this.RefDep_Nm.ReadOnly = true;
            // 
            // statusStripRow
            // 
            this.statusStripRow.Location = new System.Drawing.Point(0, 349);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(381, 22);
            this.statusStripRow.TabIndex = 8;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvRefDep);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 24);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(381, 325);
            this.pnlGrid.TabIndex = 9;
            // 
            // ContextMenuRefDep
            // 
            this.ContextMenuRefDep.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator2,
            this.ContextMenuRefresh,
            this.toolStripSeparator4});
            this.ContextMenuRefDep.Name = "ContextMenuPersCard";
            this.ContextMenuRefDep.Size = new System.Drawing.Size(153, 126);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
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
            // fmRefDep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 371);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.statusStripRow);
            this.Controls.Add(this.MenuRefDep);
            this.MainMenuStrip = this.MenuRefDep;
            this.Name = "fmRefDep";
            this.Text = "Довідник підрозділів";
            this.Load += new System.EventHandler(this.fmRefDep_Load);
            this.MenuRefDep.ResumeLayout(false);
            this.MenuRefDep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefDep)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.ContextMenuRefDep.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuRefDep;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.DataGridView dgvRefDep;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefDep_Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefDep_Nm;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ContextMenuStrip ContextMenuRefDep;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}