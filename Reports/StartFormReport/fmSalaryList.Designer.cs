namespace Reports.StartFormReport
{
    partial class fmSalaryList
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
            this.pnl1 = new System.Windows.Forms.Panel();
            this.rbFirm = new System.Windows.Forms.RadioButton();
            this.rbPersCard = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCalendar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbDep = new System.Windows.Forms.RadioButton();
            this.btnDep = new System.Windows.Forms.Button();
            this.pnl1.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.btnDep);
            this.pnl1.Controls.Add(this.rbDep);
            this.pnl1.Controls.Add(this.rbFirm);
            this.pnl1.Controls.Add(this.rbPersCard);
            this.pnl1.Controls.Add(this.label1);
            this.pnl1.Controls.Add(this.cmbCalendar);
            this.pnl1.Controls.Add(this.label3);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(284, 176);
            this.pnl1.TabIndex = 65;
            // 
            // rbFirm
            // 
            this.rbFirm.AutoSize = true;
            this.rbFirm.Checked = true;
            this.rbFirm.Location = new System.Drawing.Point(23, 58);
            this.rbFirm.Name = "rbFirm";
            this.rbFirm.Size = new System.Drawing.Size(95, 17);
            this.rbFirm.TabIndex = 56;
            this.rbFirm.TabStop = true;
            this.rbFirm.Text = "Підприємству";
            this.rbFirm.UseVisualStyleBackColor = true;
            this.rbFirm.CheckedChanged += new System.EventHandler(this.rbFirm_CheckedChanged);
            // 
            // rbPersCard
            // 
            this.rbPersCard.AutoSize = true;
            this.rbPersCard.Location = new System.Drawing.Point(23, 104);
            this.rbPersCard.Name = "rbPersCard";
            this.rbPersCard.Size = new System.Drawing.Size(132, 17);
            this.rbPersCard.TabIndex = 57;
            this.rbPersCard.Text = "Обраних працівниках";
            this.rbPersCard.UseVisualStyleBackColor = true;
            this.rbPersCard.CheckedChanged += new System.EventHandler(this.rbPersCard_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Період:";
            // 
            // cmbCalendar
            // 
            this.cmbCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCalendar.FormattingEnabled = true;
            this.cmbCalendar.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbCalendar.Location = new System.Drawing.Point(57, 8);
            this.cmbCalendar.Name = "cmbCalendar";
            this.cmbCalendar.Size = new System.Drawing.Size(215, 21);
            this.cmbCalendar.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Формувати по:";
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.btnOk);
            this.pnl2.Controls.Add(this.btnCancel);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl2.Location = new System.Drawing.Point(0, 176);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(284, 39);
            this.pnl2.TabIndex = 64;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(120, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(201, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Відміна";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbDep
            // 
            this.rbDep.AutoSize = true;
            this.rbDep.Location = new System.Drawing.Point(23, 81);
            this.rbDep.Name = "rbDep";
            this.rbDep.Size = new System.Drawing.Size(84, 17);
            this.rbDep.TabIndex = 60;
            this.rbDep.Text = "Підрозділах";
            this.rbDep.UseVisualStyleBackColor = true;
            this.rbDep.CheckedChanged += new System.EventHandler(this.rbDep_CheckedChanged);
            // 
            // btnDep
            // 
            this.btnDep.Location = new System.Drawing.Point(158, 75);
            this.btnDep.Name = "btnDep";
            this.btnDep.Size = new System.Drawing.Size(114, 23);
            this.btnDep.TabIndex = 61;
            this.btnDep.Text = "Обрати підрозділи";
            this.btnDep.UseVisualStyleBackColor = true;
            this.btnDep.Click += new System.EventHandler(this.btnDep_Click);
            // 
            // fmSalaryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 215);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.pnl2);
            this.Name = "fmSalaryList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметри звіту";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmSalaryList_KeyDown);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.RadioButton rbFirm;
        private System.Windows.Forms.RadioButton rbPersCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCalendar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbDep;
        private System.Windows.Forms.Button btnDep;
    }
}