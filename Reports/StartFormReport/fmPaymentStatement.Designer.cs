namespace Reports.StartFormReport
{
    partial class fmPaymentStatement
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
            this.btnPayment = new System.Windows.Forms.Button();
            this.rbConcrPayment = new System.Windows.Forms.RadioButton();
            this.rbAllPayment = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCalendar = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.pnl1.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.btnAddPayment);
            this.pnl1.Controls.Add(this.btnPayment);
            this.pnl1.Controls.Add(this.rbConcrPayment);
            this.pnl1.Controls.Add(this.rbAllPayment);
            this.pnl1.Controls.Add(this.label1);
            this.pnl1.Controls.Add(this.cmbCalendar);
            this.pnl1.Controls.Add(this.label3);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(307, 145);
            this.pnl1.TabIndex = 67;
            // 
            // btnPayment
            // 
            this.btnPayment.Location = new System.Drawing.Point(152, 81);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(148, 23);
            this.btnPayment.TabIndex = 61;
            this.btnPayment.Text = "Обрати виплати";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // rbConcrPayment
            // 
            this.rbConcrPayment.AutoSize = true;
            this.rbConcrPayment.Location = new System.Drawing.Point(23, 81);
            this.rbConcrPayment.Name = "rbConcrPayment";
            this.rbConcrPayment.Size = new System.Drawing.Size(123, 17);
            this.rbConcrPayment.TabIndex = 60;
            this.rbConcrPayment.Text = "Обраним виплатам";
            this.rbConcrPayment.UseVisualStyleBackColor = true;
            this.rbConcrPayment.CheckedChanged += new System.EventHandler(this.rbConcrPayment_CheckedChanged);
            // 
            // rbAllPayment
            // 
            this.rbAllPayment.AutoSize = true;
            this.rbAllPayment.Checked = true;
            this.rbAllPayment.Location = new System.Drawing.Point(23, 58);
            this.rbAllPayment.Name = "rbAllPayment";
            this.rbAllPayment.Size = new System.Drawing.Size(100, 17);
            this.rbAllPayment.TabIndex = 56;
            this.rbAllPayment.TabStop = true;
            this.rbAllPayment.Text = "Всім виплатам";
            this.rbAllPayment.UseVisualStyleBackColor = true;
            this.rbAllPayment.CheckedChanged += new System.EventHandler(this.rbAllPayment_CheckedChanged);
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
            this.cmbCalendar.Location = new System.Drawing.Point(80, 8);
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
            this.pnl2.Location = new System.Drawing.Point(0, 145);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(307, 39);
            this.pnl2.TabIndex = 66;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(143, 8);
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
            this.btnCancel.Location = new System.Drawing.Point(224, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Відміна";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.Location = new System.Drawing.Point(152, 110);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(148, 23);
            this.btnAddPayment.TabIndex = 62;
            this.btnAddPayment.Text = "Обрати додаткові виплати";
            this.btnAddPayment.UseVisualStyleBackColor = true;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // fmPaymentStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 184);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.pnl2);
            this.Name = "fmPaymentStatement";
            this.Text = "fmPaymentStatement";
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.RadioButton rbConcrPayment;
        private System.Windows.Forms.RadioButton rbAllPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCalendar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddPayment;
    }
}