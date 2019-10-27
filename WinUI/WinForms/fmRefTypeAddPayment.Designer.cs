namespace WinUI.WinForms
{
    partial class fmRefTypeAddPayment
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
            this.dgvRefTypeAddPayment = new System.Windows.Forms.DataGridView();
            this.RefTypeAddPayment_Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefTypeAddPayment_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuRefTypeAddPayment = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.ContextMenuRefTypeAddPayment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefTypeAddPayment)).BeginInit();
            this.MenuRefTypeAddPayment.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.ContextMenuRefTypeAddPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRefTypeAddPayment
            // 
            this.dgvRefTypeAddPayment.AllowUserToAddRows = false;
            this.dgvRefTypeAddPayment.AllowUserToDeleteRows = false;
            this.dgvRefTypeAddPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefTypeAddPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefTypeAddPayment_Cd,
            this.RefTypeAddPayment_Nm});
            this.dgvRefTypeAddPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRefTypeAddPayment.Location = new System.Drawing.Point(0, 0);
            this.dgvRefTypeAddPayment.Name = "dgvRefTypeAddPayment";
            this.dgvRefTypeAddPayment.ReadOnly = true;
            this.dgvRefTypeAddPayment.Size = new System.Drawing.Size(381, 325);
            this.dgvRefTypeAddPayment.TabIndex = 4;
            this.dgvRefTypeAddPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRefTypeAddPayment_KeyDown);
            // 
            // RefTypeAddPayment_Cd
            // 
            this.RefTypeAddPayment_Cd.DataPropertyName = "RefTypeAddPayment_Cd";
            this.RefTypeAddPayment_Cd.HeaderText = "Код";
            this.RefTypeAddPayment_Cd.Name = "RefTypeAddPayment_Cd";
            this.RefTypeAddPayment_Cd.ReadOnly = true;
            // 
            // RefTypeAddPayment_Nm
            // 
            this.RefTypeAddPayment_Nm.DataPropertyName = "RefTypeAddPayment_Nm";
            this.RefTypeAddPayment_Nm.HeaderText = "Найменування";
            this.RefTypeAddPayment_Nm.Name = "RefTypeAddPayment_Nm";
            this.RefTypeAddPayment_Nm.ReadOnly = true;
            // 
            // MenuRefTypeAddPayment
            // 
            this.MenuRefTypeAddPayment.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuRefTypeAddPayment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuRefTypeAddPayment.Location = new System.Drawing.Point(0, 0);
            this.MenuRefTypeAddPayment.Name = "MenuRefTypeAddPayment";
            this.MenuRefTypeAddPayment.Size = new System.Drawing.Size(381, 24);
            this.MenuRefTypeAddPayment.TabIndex = 3;
            this.MenuRefTypeAddPayment.Text = "menuRefTypeAddPayment";
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
            this.MenuItemCreate.Size = new System.Drawing.Size(148, 22);
            this.MenuItemCreate.Text = "Створити";
            this.MenuItemCreate.Click += new System.EventHandler(this.MenuItemCreate_Click);
            // 
            // MenuItemEdit
            // 
            this.MenuItemEdit.Name = "MenuItemEdit";
            this.MenuItemEdit.ShortcutKeyDisplayString = "F4";
            this.MenuItemEdit.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.MenuItemEdit.Size = new System.Drawing.Size(148, 22);
            this.MenuItemEdit.Text = "Змінити";
            this.MenuItemEdit.Click += new System.EventHandler(this.MenuItemEdit_Click);
            // 
            // MenuItemDelete
            // 
            this.MenuItemDelete.Name = "MenuItemDelete";
            this.MenuItemDelete.ShortcutKeyDisplayString = "F8";
            this.MenuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.MenuItemDelete.Size = new System.Drawing.Size(148, 22);
            this.MenuItemDelete.Text = "Видалити";
            this.MenuItemDelete.Click += new System.EventHandler(this.MenuItemDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // MenuItemRefresh
            // 
            this.MenuItemRefresh.Name = "MenuItemRefresh";
            this.MenuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.MenuItemRefresh.Size = new System.Drawing.Size(148, 22);
            this.MenuItemRefresh.Text = "Оновити";
            this.MenuItemRefresh.Click += new System.EventHandler(this.MenuItemRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.ShortcutKeyDisplayString = "Esc";
            this.MenuItemExit.Size = new System.Drawing.Size(148, 22);
            this.MenuItemExit.Text = "Вихід";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
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
            this.pnlGrid.Controls.Add(this.dgvRefTypeAddPayment);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 24);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(381, 325);
            this.pnlGrid.TabIndex = 9;
            // 
            // ContextMenuRefTypeAddPayment
            // 
            this.ContextMenuRefTypeAddPayment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator2,
            this.ContextMenuRefresh,
            this.toolStripSeparator4});
            this.ContextMenuRefTypeAddPayment.Name = "ContextMenuPersCard";
            this.ContextMenuRefTypeAddPayment.Size = new System.Drawing.Size(153, 126);
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
            // fmRefTypeAddPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 371);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.statusStripRow);
            this.Controls.Add(this.MenuRefTypeAddPayment);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fmRefTypeAddPayment";
            this.Text = "Довідник типів додаткових виплат";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmRefTypeAddPayment_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefTypeAddPayment)).EndInit();
            this.MenuRefTypeAddPayment.ResumeLayout(false);
            this.MenuRefTypeAddPayment.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.ContextMenuRefTypeAddPayment.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRefTypeAddPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefTypeAddPayment_Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefTypeAddPayment_Nm;
        private System.Windows.Forms.MenuStrip MenuRefTypeAddPayment;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ContextMenuStrip ContextMenuRefTypeAddPayment;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}