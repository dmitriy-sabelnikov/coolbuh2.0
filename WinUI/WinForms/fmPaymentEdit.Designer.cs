namespace WinUI.WinForms
{
    partial class fmPaymentEdit
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
            this.label7 = new System.Windows.Forms.Label();
            this.tbSm = new System.Windows.Forms.TextBox();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAmt = new System.Windows.Forms.TextBox();
            this.btnCard = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTIN = new System.Windows.Forms.TextBox();
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
            this.pnl1.Controls.Add(this.label7);
            this.pnl1.Controls.Add(this.tbSm);
            this.pnl1.Controls.Add(this.tbDate);
            this.pnl1.Controls.Add(this.cmbType);
            this.pnl1.Controls.Add(this.label5);
            this.pnl1.Controls.Add(this.tbPrice);
            this.pnl1.Controls.Add(this.label4);
            this.pnl1.Controls.Add(this.tbAmt);
            this.pnl1.Controls.Add(this.btnCard);
            this.pnl1.Controls.Add(this.label6);
            this.pnl1.Controls.Add(this.tbFIO);
            this.pnl1.Controls.Add(this.label2);
            this.pnl1.Controls.Add(this.label1);
            this.pnl1.Controls.Add(this.tbTIN);
            this.pnl1.Controls.Add(this.label3);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(364, 180);
            this.pnl1.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "Сума:";
            // 
            // tbSm
            // 
            this.tbSm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSm.Location = new System.Drawing.Point(141, 151);
            this.tbSm.Name = "tbSm";
            this.tbSm.Size = new System.Drawing.Size(215, 20);
            this.tbSm.TabIndex = 60;
            this.tbSm.TabStop = false;
            // 
            // tbDate
            // 
            this.tbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDate.Location = new System.Drawing.Point(141, 82);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(215, 20);
            this.tbDate.TabIndex = 58;
            this.tbDate.TabStop = false;
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Каса",
            "Виписка",
            "Список",
            "Натуроплата"});
            this.cmbType.Location = new System.Drawing.Point(141, 58);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(215, 21);
            this.cmbType.TabIndex = 57;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Ціна:";
            // 
            // tbPrice
            // 
            this.tbPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPrice.Location = new System.Drawing.Point(141, 128);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(215, 20);
            this.tbPrice.TabIndex = 51;
            this.tbPrice.TabStop = false;
            this.tbPrice.TextChanged += new System.EventHandler(this.tbPrice_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Кількість:";
            // 
            // tbAmt
            // 
            this.tbAmt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAmt.Location = new System.Drawing.Point(141, 105);
            this.tbAmt.Name = "tbAmt";
            this.tbAmt.Size = new System.Drawing.Size(215, 20);
            this.tbAmt.TabIndex = 49;
            this.tbAmt.TabStop = false;
            this.tbAmt.TextChanged += new System.EventHandler(this.tbAmt_TextChanged);
            // 
            // btnCard
            // 
            this.btnCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCard.Location = new System.Drawing.Point(335, 11);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(22, 22);
            this.btnCard.TabIndex = 46;
            this.btnCard.TabStop = false;
            this.btnCard.Text = "...";
            this.btnCard.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "ІПН:";
            // 
            // tbFIO
            // 
            this.tbFIO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFIO.BackColor = System.Drawing.SystemColors.Window;
            this.tbFIO.Location = new System.Drawing.Point(141, 12);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.ReadOnly = true;
            this.tbFIO.Size = new System.Drawing.Size(192, 20);
            this.tbFIO.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Працівник:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Дата виплати:";
            // 
            // tbTIN
            // 
            this.tbTIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTIN.Location = new System.Drawing.Point(141, 35);
            this.tbTIN.Name = "tbTIN";
            this.tbTIN.ReadOnly = true;
            this.tbTIN.Size = new System.Drawing.Size(215, 20);
            this.tbTIN.TabIndex = 47;
            this.tbTIN.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Тип:";
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.btnOk);
            this.pnl2.Controls.Add(this.btnCancel);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl2.Location = new System.Drawing.Point(0, 180);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(364, 39);
            this.pnl2.TabIndex = 19;
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
            // fmPaymentEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 219);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.pnl2);
            this.Name = "fmPaymentEdit";
            this.Text = "fmPaymentEdit";
            this.Load += new System.EventHandler(this.fmPaymentEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmPaymentEdit_KeyDown);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAmt;
        private System.Windows.Forms.Button btnCard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTIN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSm;
    }
}