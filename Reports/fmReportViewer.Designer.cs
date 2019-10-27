namespace Reports
{
    partial class fmReportViewer
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
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MenuPersCard = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExportToPdf = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExportToWord = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPersCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer.Location = new System.Drawing.Point(0, 24);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(616, 437);
            this.reportViewer.TabIndex = 0;
            this.reportViewer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.reportViewer_KeyDown);
            // 
            // MenuPersCard
            // 
            this.MenuPersCard.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuPersCard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuPersCard.Location = new System.Drawing.Point(0, 0);
            this.MenuPersCard.Name = "MenuPersCard";
            this.MenuPersCard.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuPersCard.Size = new System.Drawing.Size(616, 24);
            this.MenuPersCard.TabIndex = 6;
            this.MenuPersCard.Text = "MenuPersCard";
            // 
            // MenuStripRegister
            // 
            this.MenuStripRegister.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemExport,
            this.toolStripSeparator2,
            this.MenuItemExit});
            this.MenuStripRegister.Name = "MenuStripRegister";
            this.MenuStripRegister.Size = new System.Drawing.Size(56, 20);
            this.MenuStripRegister.Text = "Реєстр";
            // 
            // MenuItemExport
            // 
            this.MenuItemExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemExportToPdf,
            this.MenuItemExportToWord,
            this.MenuItemExportToExcel});
            this.MenuItemExport.Name = "MenuItemExport";
            this.MenuItemExport.Size = new System.Drawing.Size(152, 22);
            this.MenuItemExport.Text = "Експорт";
            // 
            // MenuItemExportToPdf
            // 
            this.MenuItemExportToPdf.Name = "MenuItemExportToPdf";
            this.MenuItemExportToPdf.Size = new System.Drawing.Size(204, 22);
            this.MenuItemExportToPdf.Text = "PDF (*.pdf)";
            this.MenuItemExportToPdf.Click += new System.EventHandler(this.MenuItemExportToPdf_Click);
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
            // MenuItemExportToWord
            // 
            this.MenuItemExportToWord.Name = "MenuItemExportToWord";
            this.MenuItemExportToWord.Size = new System.Drawing.Size(204, 22);
            this.MenuItemExportToWord.Text = "Документ Word (*.docx)";
            this.MenuItemExportToWord.Click += new System.EventHandler(this.MenuItemExportToWord_Click);
            // 
            // MenuItemExportToExcel
            // 
            this.MenuItemExportToExcel.Name = "MenuItemExportToExcel";
            this.MenuItemExportToExcel.Size = new System.Drawing.Size(204, 22);
            this.MenuItemExportToExcel.Text = "Документ Excel (*.xls)";
            this.MenuItemExportToExcel.Click += new System.EventHandler(this.MenuItemExportToExcel_Click);
            // 
            // fmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 461);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.MenuPersCard);
            this.Name = "fmReportViewer";
            this.Text = "Генератор звітів";
            this.Load += new System.EventHandler(this.fmReportViewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmReportViewer_KeyDown);
            this.MenuPersCard.ResumeLayout(false);
            this.MenuPersCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.MenuStrip MenuPersCard;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExportToPdf;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExportToWord;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExportToExcel;
    }
}