namespace WinUI.WinForms
{
    partial class fmRefExpAllwnc
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
            this.MenuRefExpAllwnc = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvRefExpAllwnc = new System.Windows.Forms.DataGridView();
            this.ContextMenuRefExpAllwnc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.RefExpAllwnc_Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefExpAllwnc_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefExpAllwnc_Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefExpAllwnc_Mech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefExpAllwncMech_RefDep_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefExpAllwnc_Oth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefExpAllwnc_Use = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MenuRefExpAllwnc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefExpAllwnc)).BeginInit();
            this.ContextMenuRefExpAllwnc.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuRefExpAllwnc
            // 
            this.MenuRefExpAllwnc.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuRefExpAllwnc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuRefExpAllwnc.Location = new System.Drawing.Point(0, 0);
            this.MenuRefExpAllwnc.Name = "MenuRefExpAllwnc";
            this.MenuRefExpAllwnc.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuRefExpAllwnc.Size = new System.Drawing.Size(581, 24);
            this.MenuRefExpAllwnc.TabIndex = 1;
            this.MenuRefExpAllwnc.Text = "MenuRefExpAllwnc";
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
            // dgvRefExpAllwnc
            // 
            this.dgvRefExpAllwnc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefExpAllwnc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefExpAllwnc_Cd,
            this.RefExpAllwnc_Nm,
            this.RefExpAllwnc_Year,
            this.RefExpAllwnc_Mech,
            this.RefExpAllwncMech_RefDep_Nm,
            this.RefExpAllwnc_Oth,
            this.RefExpAllwnc_Use});
            this.dgvRefExpAllwnc.ContextMenuStrip = this.ContextMenuRefExpAllwnc;
            this.dgvRefExpAllwnc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRefExpAllwnc.Location = new System.Drawing.Point(0, 0);
            this.dgvRefExpAllwnc.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRefExpAllwnc.Name = "dgvRefExpAllwnc";
            this.dgvRefExpAllwnc.RowTemplate.Height = 24;
            this.dgvRefExpAllwnc.Size = new System.Drawing.Size(581, 333);
            this.dgvRefExpAllwnc.TabIndex = 3;
            this.dgvRefExpAllwnc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRefExpAllwnc_KeyDown);
            // 
            // ContextMenuRefExpAllwnc
            // 
            this.ContextMenuRefExpAllwnc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuCreate,
            this.ContextMenuEdit,
            this.ContextMenuDelete,
            this.toolStripSeparator3,
            this.ContextMenuRefresh,
            this.toolStripSeparator4});
            this.ContextMenuRefExpAllwnc.Name = "ContextMenuPersCard";
            this.ContextMenuRefExpAllwnc.Size = new System.Drawing.Size(149, 104);
            // 
            // ContextMenuCreate
            // 
            this.ContextMenuCreate.Name = "ContextMenuCreate";
            this.ContextMenuCreate.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.ContextMenuCreate.Size = new System.Drawing.Size(148, 22);
            this.ContextMenuCreate.Text = "Створити";
            this.ContextMenuCreate.Click += new System.EventHandler(this.ContextMenuCreate_Click);
            // 
            // ContextMenuEdit
            // 
            this.ContextMenuEdit.Name = "ContextMenuEdit";
            this.ContextMenuEdit.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.ContextMenuEdit.Size = new System.Drawing.Size(148, 22);
            this.ContextMenuEdit.Text = "Змінити";
            this.ContextMenuEdit.Click += new System.EventHandler(this.ContextMenuEdit_Click);
            // 
            // ContextMenuDelete
            // 
            this.ContextMenuDelete.Name = "ContextMenuDelete";
            this.ContextMenuDelete.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.ContextMenuDelete.Size = new System.Drawing.Size(148, 22);
            this.ContextMenuDelete.Text = "Видалити";
            this.ContextMenuDelete.Click += new System.EventHandler(this.ContextMenuDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // ContextMenuRefresh
            // 
            this.ContextMenuRefresh.Name = "ContextMenuRefresh";
            this.ContextMenuRefresh.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.ContextMenuRefresh.Size = new System.Drawing.Size(148, 22);
            this.ContextMenuRefresh.Text = "Оновити";
            this.ContextMenuRefresh.Click += new System.EventHandler(this.ContextMenuRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // statusStripRow
            // 
            this.statusStripRow.Location = new System.Drawing.Point(0, 357);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(581, 22);
            this.statusStripRow.TabIndex = 8;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvRefExpAllwnc);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 24);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(581, 333);
            this.pnlGrid.TabIndex = 9;
            // 
            // RefExpAllwnc_Cd
            // 
            this.RefExpAllwnc_Cd.DataPropertyName = "RefExpAllwnc_Cd";
            this.RefExpAllwnc_Cd.HeaderText = "Код";
            this.RefExpAllwnc_Cd.Name = "RefExpAllwnc_Cd";
            // 
            // RefExpAllwnc_Nm
            // 
            this.RefExpAllwnc_Nm.DataPropertyName = "RefExpAllwnc_Nm";
            this.RefExpAllwnc_Nm.HeaderText = "Найменування";
            this.RefExpAllwnc_Nm.Name = "RefExpAllwnc_Nm";
            // 
            // RefExpAllwnc_Year
            // 
            this.RefExpAllwnc_Year.DataPropertyName = "RefExpAllwnc_Year";
            this.RefExpAllwnc_Year.HeaderText = "Рік стажу";
            this.RefExpAllwnc_Year.Name = "RefExpAllwnc_Year";
            // 
            // RefExpAllwnc_Mech
            // 
            this.RefExpAllwnc_Mech.DataPropertyName = "RefExpAllwnc_Mech";
            this.RefExpAllwnc_Mech.HeaderText = "Відсоток механикам";
            this.RefExpAllwnc_Mech.Name = "RefExpAllwnc_Mech";
            // 
            // RefExpAllwncMech_RefDep_Nm
            // 
            this.RefExpAllwncMech_RefDep_Nm.DataPropertyName = "RefExpAllwncMech_RefDep_Nm";
            this.RefExpAllwncMech_RefDep_Nm.HeaderText = "Підрозділ механиків";
            this.RefExpAllwncMech_RefDep_Nm.Name = "RefExpAllwncMech_RefDep_Nm";
            // 
            // RefExpAllwnc_Oth
            // 
            this.RefExpAllwnc_Oth.DataPropertyName = "RefExpAllwnc_Oth";
            this.RefExpAllwnc_Oth.HeaderText = "Відсоток іншим";
            this.RefExpAllwnc_Oth.Name = "RefExpAllwnc_Oth";
            // 
            // RefExpAllwnc_Use
            // 
            this.RefExpAllwnc_Use.DataPropertyName = "RefExpAllwnc_Use";
            this.RefExpAllwnc_Use.FalseValue = "0";
            this.RefExpAllwnc_Use.HeaderText = "Використовувати";
            this.RefExpAllwnc_Use.Name = "RefExpAllwnc_Use";
            this.RefExpAllwnc_Use.TrueValue = "1";
            // 
            // fmRefExpAllwnc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 379);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.statusStripRow);
            this.Controls.Add(this.MenuRefExpAllwnc);
            this.Name = "fmRefExpAllwnc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Надбавки за стаж";
            this.Load += new System.EventHandler(this.fmRefExpAllwnc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmRefExpAllwnc_KeyDown);
            this.MenuRefExpAllwnc.ResumeLayout(false);
            this.MenuRefExpAllwnc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefExpAllwnc)).EndInit();
            this.ContextMenuRefExpAllwnc.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuRefExpAllwnc;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.DataGridView dgvRefExpAllwnc;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.ContextMenuStrip ContextMenuRefExpAllwnc;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuCreate;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefExpAllwnc_Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefExpAllwnc_Nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefExpAllwnc_Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefExpAllwnc_Mech;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefExpAllwncMech_RefDep_Nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefExpAllwnc_Oth;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RefExpAllwnc_Use;
    }
}