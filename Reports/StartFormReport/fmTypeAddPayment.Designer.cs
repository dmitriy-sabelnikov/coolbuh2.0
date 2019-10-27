namespace Reports.StartFormReport
{
    partial class fmTypeAddPayment
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
            this.dgvTypeAddPayment = new System.Windows.Forms.DataGridView();
            this.RefTypeAddPayment_Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefTypeAddPayment_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypeAddPayment)).BeginInit();
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
            this.pnl2.TabIndex = 68;
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
            // dgvTypeAddPayment
            // 
            this.dgvTypeAddPayment.AllowUserToAddRows = false;
            this.dgvTypeAddPayment.AllowUserToDeleteRows = false;
            this.dgvTypeAddPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTypeAddPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefTypeAddPayment_Cd,
            this.RefTypeAddPayment_Nm});
            this.dgvTypeAddPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTypeAddPayment.Location = new System.Drawing.Point(0, 0);
            this.dgvTypeAddPayment.Name = "dgvTypeAddPayment";
            this.dgvTypeAddPayment.ReadOnly = true;
            this.dgvTypeAddPayment.Size = new System.Drawing.Size(284, 261);
            this.dgvTypeAddPayment.TabIndex = 67;
            this.dgvTypeAddPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvTypeAddPayment_KeyDown);
            // 
            // RefTypeAddPayment_Cd
            // 
            this.RefTypeAddPayment_Cd.DataPropertyName = "RefTypeAddPayment_Cd";
            this.RefTypeAddPayment_Cd.HeaderText = "Код";
            this.RefTypeAddPayment_Cd.Name = "RefTypeAddPayment_Cd";
            this.RefTypeAddPayment_Cd.ReadOnly = true;
            // 
            // RefTypeAddPayment_Nm
            // 
            this.RefTypeAddPayment_Nm.DataPropertyName = "RefTypeAddPayment_Nm";
            this.RefTypeAddPayment_Nm.HeaderText = "Найменування";
            this.RefTypeAddPayment_Nm.Name = "RefTypeAddPayment_Nm";
            this.RefTypeAddPayment_Nm.ReadOnly = true;
            // 
            // fmTypeAddPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pnl2);
            this.Controls.Add(this.dgvTypeAddPayment);
            this.Name = "fmTypeAddPayment";
            this.Text = "fmTypeAddPayment";
            this.Load += new System.EventHandler(this.fmTypeAddPayment_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmTypeAddPayment_KeyDown);
            this.pnl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypeAddPayment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvTypeAddPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefTypeAddPayment_Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefTypeAddPayment_Nm;
    }
}