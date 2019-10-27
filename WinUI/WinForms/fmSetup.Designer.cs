namespace WinUI.WinForms
{
    partial class fmSetup
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
            this.tabControlSetup = new System.Windows.Forms.TabControl();
            this.tabImport = new System.Windows.Forms.TabPage();
            this.pnlImport = new System.Windows.Forms.Panel();
            this.cbConvertCp1252To866 = new System.Windows.Forms.CheckBox();
            this.btnChooseSql = new System.Windows.Forms.Button();
            this.txbSqlPath = new System.Windows.Forms.TextBox();
            this.txbDbfPath = new System.Windows.Forms.TextBox();
            this.btnChooseDbf = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabSalary = new System.Windows.Forms.TabPage();
            this.txbYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabCompany = new System.Windows.Forms.TabPage();
            this.tbCmpUSREOU = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCmpNm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControlSetup.SuspendLayout();
            this.tabImport.SuspendLayout();
            this.pnlImport.SuspendLayout();
            this.tabSalary.SuspendLayout();
            this.tabCompany.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSetup
            // 
            this.tabControlSetup.Controls.Add(this.tabImport);
            this.tabControlSetup.Controls.Add(this.tabSalary);
            this.tabControlSetup.Controls.Add(this.tabCompany);
            this.tabControlSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSetup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControlSetup.ItemSize = new System.Drawing.Size(100, 20);
            this.tabControlSetup.Location = new System.Drawing.Point(0, 0);
            this.tabControlSetup.Multiline = true;
            this.tabControlSetup.Name = "tabControlSetup";
            this.tabControlSetup.SelectedIndex = 0;
            this.tabControlSetup.Size = new System.Drawing.Size(498, 352);
            this.tabControlSetup.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlSetup.TabIndex = 1;
            this.tabControlSetup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControlSetup_KeyDown);
            // 
            // tabImport
            // 
            this.tabImport.Controls.Add(this.pnlImport);
            this.tabImport.Location = new System.Drawing.Point(4, 24);
            this.tabImport.Name = "tabImport";
            this.tabImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabImport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabImport.Size = new System.Drawing.Size(490, 324);
            this.tabImport.TabIndex = 0;
            this.tabImport.Text = "Імпорт";
            this.tabImport.UseVisualStyleBackColor = true;
            // 
            // pnlImport
            // 
            this.pnlImport.Controls.Add(this.cbConvertCp1252To866);
            this.pnlImport.Controls.Add(this.btnChooseSql);
            this.pnlImport.Controls.Add(this.txbSqlPath);
            this.pnlImport.Controls.Add(this.txbDbfPath);
            this.pnlImport.Controls.Add(this.btnChooseDbf);
            this.pnlImport.Controls.Add(this.label2);
            this.pnlImport.Controls.Add(this.label1);
            this.pnlImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImport.Location = new System.Drawing.Point(3, 3);
            this.pnlImport.Name = "pnlImport";
            this.pnlImport.Size = new System.Drawing.Size(484, 318);
            this.pnlImport.TabIndex = 0;
            // 
            // cbConvertCp1252To866
            // 
            this.cbConvertCp1252To866.AutoSize = true;
            this.cbConvertCp1252To866.Location = new System.Drawing.Point(8, 53);
            this.cbConvertCp1252To866.Name = "cbConvertCp1252To866";
            this.cbConvertCp1252To866.Size = new System.Drawing.Size(214, 17);
            this.cbConvertCp1252To866.TabIndex = 6;
            this.cbConvertCp1252To866.Text = "Конвертація тексту (cp1252 -> cp866)";
            this.cbConvertCp1252To866.UseVisualStyleBackColor = true;
            // 
            // btnChooseSql
            // 
            this.btnChooseSql.Location = new System.Drawing.Point(310, 26);
            this.btnChooseSql.Name = "btnChooseSql";
            this.btnChooseSql.Size = new System.Drawing.Size(25, 21);
            this.btnChooseSql.TabIndex = 5;
            this.btnChooseSql.Text = "...";
            this.btnChooseSql.UseVisualStyleBackColor = true;
            // 
            // txbSqlPath
            // 
            this.txbSqlPath.Location = new System.Drawing.Point(110, 27);
            this.txbSqlPath.Name = "txbSqlPath";
            this.txbSqlPath.ReadOnly = true;
            this.txbSqlPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbSqlPath.ShortcutsEnabled = false;
            this.txbSqlPath.Size = new System.Drawing.Size(200, 20);
            this.txbSqlPath.TabIndex = 4;
            // 
            // txbDbfPath
            // 
            this.txbDbfPath.Location = new System.Drawing.Point(110, 5);
            this.txbDbfPath.Name = "txbDbfPath";
            this.txbDbfPath.ReadOnly = true;
            this.txbDbfPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txbDbfPath.Size = new System.Drawing.Size(200, 20);
            this.txbDbfPath.TabIndex = 3;
            this.txbDbfPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnChooseDbf
            // 
            this.btnChooseDbf.Location = new System.Drawing.Point(310, 5);
            this.btnChooseDbf.Name = "btnChooseDbf";
            this.btnChooseDbf.Size = new System.Drawing.Size(25, 21);
            this.btnChooseDbf.TabIndex = 2;
            this.btnChooseDbf.Text = "...";
            this.btnChooseDbf.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Шлях до sql файлів";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Шлях до dbf файлів";
            // 
            // tabSalary
            // 
            this.tabSalary.Controls.Add(this.txbYear);
            this.tabSalary.Controls.Add(this.label3);
            this.tabSalary.Location = new System.Drawing.Point(4, 24);
            this.tabSalary.Name = "tabSalary";
            this.tabSalary.Padding = new System.Windows.Forms.Padding(3);
            this.tabSalary.Size = new System.Drawing.Size(490, 324);
            this.tabSalary.TabIndex = 1;
            this.tabSalary.Text = "Зарплата";
            this.tabSalary.UseVisualStyleBackColor = true;
            // 
            // txbYear
            // 
            this.txbYear.Location = new System.Drawing.Point(190, 10);
            this.txbYear.Name = "txbYear";
            this.txbYear.Size = new System.Drawing.Size(100, 20);
            this.txbYear.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Кількість років відображення РЛ:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabCompany
            // 
            this.tabCompany.Controls.Add(this.tbCmpNm);
            this.tabCompany.Controls.Add(this.label5);
            this.tabCompany.Controls.Add(this.tbCmpUSREOU);
            this.tabCompany.Controls.Add(this.label4);
            this.tabCompany.Location = new System.Drawing.Point(4, 24);
            this.tabCompany.Name = "tabCompany";
            this.tabCompany.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompany.Size = new System.Drawing.Size(490, 324);
            this.tabCompany.TabIndex = 2;
            this.tabCompany.Text = "Підприємство";
            this.tabCompany.UseVisualStyleBackColor = true;
            // 
            // tbCmpUSREOU
            // 
            this.tbCmpUSREOU.Location = new System.Drawing.Point(136, 6);
            this.tbCmpUSREOU.Name = "tbCmpUSREOU";
            this.tbCmpUSREOU.Size = new System.Drawing.Size(155, 20);
            this.tbCmpUSREOU.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Код ЄДРПОУ:";
            // 
            // tbCmpNm
            // 
            this.tbCmpNm.Location = new System.Drawing.Point(136, 30);
            this.tbCmpNm.Name = "tbCmpNm";
            this.tbCmpNm.Size = new System.Drawing.Size(346, 20);
            this.tbCmpNm.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Назва підприємства:";
            // 
            // fmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 352);
            this.Controls.Add(this.tabControlSetup);
            this.Name = "fmSetup";
            this.Text = "Налаштування";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmSetup_FormClosed);
            this.Load += new System.EventHandler(this.fmSetup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmSetup_KeyDown);
            this.tabControlSetup.ResumeLayout(false);
            this.tabImport.ResumeLayout(false);
            this.pnlImport.ResumeLayout(false);
            this.pnlImport.PerformLayout();
            this.tabSalary.ResumeLayout(false);
            this.tabSalary.PerformLayout();
            this.tabCompany.ResumeLayout(false);
            this.tabCompany.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSetup;
        private System.Windows.Forms.TabPage tabImport;
        private System.Windows.Forms.Panel pnlImport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChooseSql;
        private System.Windows.Forms.TextBox txbSqlPath;
        private System.Windows.Forms.TextBox txbDbfPath;
        private System.Windows.Forms.Button btnChooseDbf;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox cbConvertCp1252To866;
        private System.Windows.Forms.TabPage tabSalary;
        private System.Windows.Forms.TextBox txbYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabCompany;
        private System.Windows.Forms.TextBox tbCmpNm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCmpUSREOU;
        private System.Windows.Forms.Label label4;
    }
}