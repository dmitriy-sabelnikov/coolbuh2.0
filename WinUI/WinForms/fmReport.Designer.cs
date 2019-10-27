namespace WinUI
{
    partial class fmReport
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
            this.MenuReport = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.Report_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStripRow = new System.Windows.Forms.StatusStrip();
            this.ContextMenuReport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextMenuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuReport.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.ContextMenuReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuReport
            // 
            this.MenuReport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuReport.Location = new System.Drawing.Point(0, 0);
            this.MenuReport.Name = "MenuReport";
            this.MenuReport.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuReport.Size = new System.Drawing.Size(384, 24);
            this.MenuReport.TabIndex = 6;
            this.MenuReport.Text = "MenuReport";
            // 
            // MenuStripRegister
            // 
            this.MenuStripRegister.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemPrint,
            this.toolStripSeparator2,
            this.MenuItemExit});
            this.MenuStripRegister.Name = "MenuStripRegister";
            this.MenuStripRegister.Size = new System.Drawing.Size(56, 20);
            this.MenuStripRegister.Text = "Реєстр";
            // 
            // MenuItemPrint
            // 
            this.MenuItemPrint.Name = "MenuItemPrint";
            this.MenuItemPrint.ShortcutKeyDisplayString = "Enter";
            this.MenuItemPrint.Size = new System.Drawing.Size(152, 22);
            this.MenuItemPrint.Text = "Друк";
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
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvReport);
            this.pnlGrid.Controls.Add(this.statusStripRow);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 24);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(384, 337);
            this.pnlGrid.TabIndex = 7;
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Report_Name});
            this.dgvReport.ContextMenuStrip = this.ContextMenuReport;
            this.dgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReport.Location = new System.Drawing.Point(0, 0);
            this.dgvReport.Margin = new System.Windows.Forms.Padding(2);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RowTemplate.Height = 24;
            this.dgvReport.Size = new System.Drawing.Size(384, 315);
            this.dgvReport.TabIndex = 1;
            this.dgvReport.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvReport_CellMouseDoubleClick);
            this.dgvReport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvReport_KeyDown);
            // 
            // Report_Name
            // 
            this.Report_Name.DataPropertyName = "Report_Name";
            this.Report_Name.HeaderText = "Найменування звіту";
            this.Report_Name.Name = "Report_Name";
            // 
            // statusStripRow
            // 
            this.statusStripRow.Location = new System.Drawing.Point(0, 315);
            this.statusStripRow.Name = "statusStripRow";
            this.statusStripRow.Size = new System.Drawing.Size(384, 22);
            this.statusStripRow.TabIndex = 4;
            this.statusStripRow.Text = "statusStripRow";
            // 
            // ContextMenuReport
            // 
            this.ContextMenuReport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextMenuPrint,
            this.toolStripSeparator4});
            this.ContextMenuReport.Name = "ContextMenuPersCard";
            this.ContextMenuReport.Size = new System.Drawing.Size(153, 54);
            // 
            // ContextMenuPrint
            // 
            this.ContextMenuPrint.Name = "ContextMenuPrint";
            this.ContextMenuPrint.ShortcutKeyDisplayString = "Enter";
            this.ContextMenuPrint.Size = new System.Drawing.Size(152, 22);
            this.ContextMenuPrint.Text = "Друк";
            this.ContextMenuPrint.Click += new System.EventHandler(this.ContextMenuPrint_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // fmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.MenuReport);
            this.Name = "fmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Звіти";
            this.Load += new System.EventHandler(this.fmReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmReport_KeyDown);
            this.MenuReport.ResumeLayout(false);
            this.MenuReport.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ContextMenuReport.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuReport;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.StatusStrip statusStripRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn Report_Name;
        private System.Windows.Forms.ContextMenuStrip ContextMenuReport;
        private System.Windows.Forms.ToolStripMenuItem ContextMenuPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}