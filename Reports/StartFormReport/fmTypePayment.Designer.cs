namespace Reports.StartFormReport
{
    partial class fmTypePayment
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
            this.pnl2 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvTypePayment = new System.Windows.Forms.DataGridView();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypePayment)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.btnOk);
            this.pnl2.Controls.Add(this.btnCancel);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl2.Location = new System.Drawing.Point(0, 222);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(284, 39);
            this.pnl2.TabIndex = 70;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(120, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Обрати";
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
            // dgvTypePayment
            // 
            this.dgvTypePayment.AllowUserToAddRows = false;
            this.dgvTypePayment.AllowUserToDeleteRows = false;
            this.dgvTypePayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTypePayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeName});
            this.dgvTypePayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTypePayment.Location = new System.Drawing.Point(0, 0);
            this.dgvTypePayment.Name = "dgvTypePayment";
            this.dgvTypePayment.ReadOnly = true;
            this.dgvTypePayment.Size = new System.Drawing.Size(284, 261);
            this.dgvTypePayment.TabIndex = 69;
            this.dgvTypePayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTypePayment_KeyDown);
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "Name";
            this.TypeName.HeaderText = "Найменування";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            // 
            // fmTypePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pnl2);
            this.Controls.Add(this.dgvTypePayment);
            this.Name = "fmTypePayment";
            this.Text = "fmTypePayment";
            this.Load += new System.EventHandler(this.fmTypePayment_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmTypePayment_KeyDown);
            this.pnl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypePayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvTypePayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
    }
}