namespace WinUI.WinForms
{
    partial class fmRefOthAllwncEdit
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
            this.cbUse = new System.Windows.Forms.CheckBox();
            this.tbNm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnl1.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.cbUse);
            this.pnl1.Controls.Add(this.tbNm);
            this.pnl1.Controls.Add(this.label5);
            this.pnl1.Controls.Add(this.tbCd);
            this.pnl1.Controls.Add(this.label4);
            this.pnl1.Controls.Add(this.tbPct);
            this.pnl1.Controls.Add(this.label2);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(349, 118);
            this.pnl1.TabIndex = 14;
            // 
            // cbUse
            // 
            this.cbUse.AutoSize = true;
            this.cbUse.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbUse.Location = new System.Drawing.Point(12, 87);
            this.cbUse.Name = "cbUse";
            this.cbUse.Size = new System.Drawing.Size(135, 17);
            this.cbUse.TabIndex = 7;
            this.cbUse.Text = "Використовувати       ";
            this.cbUse.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cbUse.UseVisualStyleBackColor = true;
            // 
            // tbNm
            // 
            this.tbNm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNm.BackColor = System.Drawing.SystemColors.Window;
            this.tbNm.Location = new System.Drawing.Point(128, 37);
            this.tbNm.Name = "tbNm";
            this.tbNm.Size = new System.Drawing.Size(213, 20);
            this.tbNm.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Найменування:";
            // 
            // tbCd
            // 
            this.tbCd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCd.BackColor = System.Drawing.SystemColors.Window;
            this.tbCd.Location = new System.Drawing.Point(128, 11);
            this.tbCd.Name = "tbCd";
            this.tbCd.Size = new System.Drawing.Size(213, 20);
            this.tbCd.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Код:";
            // 
            // tbPct
            // 
            this.tbPct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPct.Location = new System.Drawing.Point(128, 62);
            this.tbPct.Name = "tbPct";
            this.tbPct.Size = new System.Drawing.Size(213, 20);
            this.tbPct.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Відсоток:";
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.btnOk);
            this.pnl2.Controls.Add(this.btnCancel);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl2.Location = new System.Drawing.Point(0, 118);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(349, 39);
            this.pnl2.TabIndex = 15;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(180, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(261, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Відміна";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fmRefOthAllwncEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 157);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.pnl2);
            this.Name = "fmRefOthAllwncEdit";
            this.Text = "fmRefOthAllwncEdit";
            this.Load += new System.EventHandler(this.fmRefOthAllwncEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmRefOthAllwncEdit_KeyDown);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.CheckBox cbUse;
        private System.Windows.Forms.TextBox tbNm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}