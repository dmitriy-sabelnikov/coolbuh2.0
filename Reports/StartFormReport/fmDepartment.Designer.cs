namespace Reports.StartFormReport
{
    partial class fmDepartment
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
            this.dgvRefDep = new System.Windows.Forms.DataGridView();
            this.RefDep_Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefDep_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefDep)).BeginInit();
            this.pnl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.dgvRefDep);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(284, 222);
            this.pnl1.TabIndex = 67;
            // 
            // dgvRefDep
            // 
            this.dgvRefDep.AllowUserToAddRows = false;
            this.dgvRefDep.AllowUserToDeleteRows = false;
            this.dgvRefDep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefDep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefDep_Cd,
            this.RefDep_Nm});
            this.dgvRefDep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRefDep.Location = new System.Drawing.Point(0, 0);
            this.dgvRefDep.Name = "dgvRefDep";
            this.dgvRefDep.ReadOnly = true;
            this.dgvRefDep.Size = new System.Drawing.Size(284, 222);
            this.dgvRefDep.TabIndex = 3;
            this.dgvRefDep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvRefDep_KeyDown);
            // 
            // RefDep_Cd
            // 
            this.RefDep_Cd.DataPropertyName = "RefDep_Cd";
            this.RefDep_Cd.HeaderText = "Код";
            this.RefDep_Cd.Name = "RefDep_Cd";
            this.RefDep_Cd.ReadOnly = true;
            // 
            // RefDep_Nm
            // 
            this.RefDep_Nm.DataPropertyName = "RefDep_Nm";
            this.RefDep_Nm.HeaderText = "Найменування";
            this.RefDep_Nm.Name = "RefDep_Nm";
            this.RefDep_Nm.ReadOnly = true;
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.btnOk);
            this.pnl2.Controls.Add(this.btnCancel);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl2.Location = new System.Drawing.Point(0, 222);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(284, 39);
            this.pnl2.TabIndex = 66;
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
            // fmDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.pnl2);
            this.Name = "fmDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fmDepartment";
            this.Load += new System.EventHandler(this.fmDepartment_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmDepartment_KeyDown);
            this.pnl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefDep)).EndInit();
            this.pnl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvRefDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefDep_Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefDep_Nm;
    }
}