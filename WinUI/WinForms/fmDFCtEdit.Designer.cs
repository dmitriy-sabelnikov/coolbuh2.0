namespace WinUI.WinForms
{
    partial class fmDFCtEdit
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
            this.label5 = new System.Windows.Forms.Label();
            this.cmbYr = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNm = new System.Windows.Forms.TextBox();
            this.rbNoClc = new System.Windows.Forms.RadioButton();
            this.rbAskClc = new System.Windows.Forms.RadioButton();
            this.tbNmr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbQrt = new System.Windows.Forms.ComboBox();
            this.rbClc = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnl1.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.label5);
            this.pnl1.Controls.Add(this.cmbYr);
            this.pnl1.Controls.Add(this.label2);
            this.pnl1.Controls.Add(this.label4);
            this.pnl1.Controls.Add(this.tbNm);
            this.pnl1.Controls.Add(this.rbNoClc);
            this.pnl1.Controls.Add(this.rbAskClc);
            this.pnl1.Controls.Add(this.tbNmr);
            this.pnl1.Controls.Add(this.label1);
            this.pnl1.Controls.Add(this.cmbQrt);
            this.pnl1.Controls.Add(this.rbClc);
            this.pnl1.Controls.Add(this.label3);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(364, 230);
            this.pnl1.TabIndex = 63;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Рік:";
            // 
            // cmbYr
            // 
            this.cmbYr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbYr.FormattingEnabled = true;
            this.cmbYr.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbYr.Location = new System.Drawing.Point(137, 35);
            this.cmbYr.Name = "cmbYr";
            this.cmbYr.Size = new System.Drawing.Size(215, 21);
            this.cmbYr.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Найменування:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 52;
            this.label4.Text = "Номер:";
            // 
            // tbNm
            // 
            this.tbNm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNm.Location = new System.Drawing.Point(137, 88);
            this.tbNm.Name = "tbNm";
            this.tbNm.Size = new System.Drawing.Size(215, 20);
            this.tbNm.TabIndex = 55;
            this.tbNm.TabStop = false;
            // 
            // rbNoClc
            // 
            this.rbNoClc.AutoSize = true;
            this.rbNoClc.Checked = true;
            this.rbNoClc.Location = new System.Drawing.Point(23, 147);
            this.rbNoClc.Name = "rbNoClc";
            this.rbNoClc.Size = new System.Drawing.Size(117, 17);
            this.rbNoClc.TabIndex = 56;
            this.rbNoClc.TabStop = true;
            this.rbNoClc.Text = "Не розраховувати";
            this.rbNoClc.UseVisualStyleBackColor = true;
            // 
            // rbAskClc
            // 
            this.rbAskClc.AutoSize = true;
            this.rbAskClc.Location = new System.Drawing.Point(23, 170);
            this.rbAskClc.Name = "rbAskClc";
            this.rbAskClc.Size = new System.Drawing.Size(155, 17);
            this.rbAskClc.TabIndex = 57;
            this.rbAskClc.Text = "Питати про розрахування";
            this.rbAskClc.UseVisualStyleBackColor = true;
            // 
            // tbNmr
            // 
            this.tbNmr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNmr.Location = new System.Drawing.Point(137, 62);
            this.tbNmr.Name = "tbNmr";
            this.tbNmr.Size = new System.Drawing.Size(215, 20);
            this.tbNmr.TabIndex = 53;
            this.tbNmr.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Квартал:";
            // 
            // cmbQrt
            // 
            this.cmbQrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbQrt.FormattingEnabled = true;
            this.cmbQrt.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbQrt.Location = new System.Drawing.Point(137, 8);
            this.cmbQrt.Name = "cmbQrt";
            this.cmbQrt.Size = new System.Drawing.Size(215, 21);
            this.cmbQrt.TabIndex = 50;
            // 
            // rbClc
            // 
            this.rbClc.AutoSize = true;
            this.rbClc.Location = new System.Drawing.Point(23, 193);
            this.rbClc.Name = "rbClc";
            this.rbClc.Size = new System.Drawing.Size(101, 17);
            this.rbClc.TabIndex = 58;
            this.rbClc.Text = "Розраховувати";
            this.rbClc.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Дії при входу у документ:";
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.btnOk);
            this.pnl2.Controls.Add(this.btnCancel);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl2.Location = new System.Drawing.Point(0, 230);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(364, 39);
            this.pnl2.TabIndex = 62;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(200, 8);
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
            this.btnCancel.Location = new System.Drawing.Point(281, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Відміна";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fmDFCtEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 269);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.pnl2);
            this.Name = "fmDFCtEdit";
            this.Text = "fmDFCtEdit";
            this.Load += new System.EventHandler(this.fmDFCtEdit_Load);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNm;
        private System.Windows.Forms.RadioButton rbNoClc;
        private System.Windows.Forms.RadioButton rbAskClc;
        private System.Windows.Forms.TextBox tbNmr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbQrt;
        private System.Windows.Forms.RadioButton rbClc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbYr;
    }
}