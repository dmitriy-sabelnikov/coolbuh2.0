namespace WinUI.WinForms
{
    partial class fmRefLivWage
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
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.dgvRefLivWage = new System.Windows.Forms.DataGridView();
            this.RefLivWage_PerBeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefLivWage_PerEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefLivWage_Sm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuRefLivWage = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuRefLivWage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefLivWage)).BeginInit();
            this.MenuRefLivWage.SuspendLayout();
            this.ContextMenuRefLivWage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.statusStripRow);
            this.pnlGrid.Controls.Add(this.dgvRefLivWage);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 24);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(381, 347);
            this.pnlGrid.TabIndex = 10;
            // 
            // statusStripRow
            // 
            this.statusStripRow.Location = new System.Drawing.Point(0, 325);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(381, 22);
            this.statusStripRow.TabIndex = 4;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // dgvRefLivWage
            // 
            this.dgvRefLivWage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefLivWage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefLivWage_PerBeg,
            this.RefLivWage_PerEnd,
            this.RefLivWage_Sm});
            this.dgvRefLivWage.ContextMenuStrip = this.ContextMenuRefLivWage;
            this.dgvRefLivWage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRefLivWage.Location = new System.Drawing.Point(0, 0);
            this.dgvRefLivWage.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRefLivWage.Name = "dgvRefLivWage";
            this.dgvRefLivWage.RowTemplate.Height = 24;
            this.dgvRefLivWage.Size = new System.Drawing.Size(381, 347);
            this.dgvRefLivWage.TabIndex = 1;
            this.dgvRefLivWage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRefLivWage_KeyDown);
            // 
            // RefLivWage_PerBeg
            // 
            this.RefLivWage_PerBeg.DataPropertyName = "RefLivWage_PerBeg";
            this.RefLivWage_PerBeg.HeaderText = "Дата початку";
            this.RefLivWage_PerBeg.Name = "RefLivWage_PerBeg";
            // 
            // RefLivWage_PerEnd
            // 
            this.RefLivWage_PerEnd.DataPropertyName = "RefLivWage_PerEnd";
            this.RefLivWage_PerEnd.HeaderText = "Дата закінчення";
            this.RefLivWage_PerEnd.Name = "RefLivWage_PerEnd";
            // 
            // RefLivWage_Sm
            // 
            this.RefLivWage_Sm.DataPropertyName = "RefLivWage_Sm";
            this.RefLivWage_Sm.HeaderText = "Сума";
            this.RefLivWage_Sm.Name = "RefLivWage_Sm";
            // 
            // MenuRefLivWage
            // 
            this.MenuRefLivWage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuRefLivWage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuRefLivWage.Location = new System.Drawing.Point(0, 0);
            this.MenuRefLivWage.Name = "MenuRefLivWage";
            this.MenuRefLivWage.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuRefLivWage.Size = new System.Drawing.Size(381, 24);
            this.MenuRefLivWage.TabIndex = 8;
            this.MenuRefLivWage.Text = "MenuRefLivWage";
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
            // ContextMenuRefLivWage
            // 
            this.ContextMenuRefLivWage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator3,
            this.ContextMenuRefresh,
            this.toolStripSeparator4});
            this.ContextMenuRefLivWage.Name = "ContextMenuPersCard";
            this.ContextMenuRefLivWage.Size = new System.Drawing.Size(153, 126);
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
            // fmRefLivWage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 371);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.MenuRefLivWage);
            this.Name = "fmRefLivWage";
            this.Text = "Прожитковий мінімум";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmRefLivWage_KeyDown);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefLivWage)).EndInit();
            this.MenuRefLivWage.ResumeLayout(false);
            this.MenuRefLivWage.PerformLayout();
            this.ContextMenuRefLivWage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.DataGridView dgvRefLivWage;
        private System.Windows.Forms.MenuStrip MenuRefLivWage;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefLivWage_PerBeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefLivWage_PerEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefLivWage_Sm;
        private System.Windows.Forms.ContextMenuStrip ContextMenuRefLivWage;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}