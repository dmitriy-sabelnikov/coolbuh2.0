namespace WinUI.WinForms
{
    partial class fmDFRec
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
            this.dgvDFRec = new System.Windows.Forms.DataGridView();
            this.statusStripRowDFRec = new System.Windows.Forms.StatusStrip();
            this.DFRec_USREOU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFRec_TIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFRec_LName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFRec_FName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFRec_MName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFRec_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFRec_AccrIncSm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFRec_PaidIncSm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFRec_AccrTaxSm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFRec_TransfTaxSm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFRec_IncFlg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFRec_DOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFRec_DOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFRec_SocBenefitFlg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DFRec_Flg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDFRec)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDFRec
            // 
            this.dgvDFRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDFRec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DFRec_USREOU,
            this.DFRec_TIN,
            this.DFRec_LName,
            this.DFRec_FName,
            this.DFRec_MName,
            this.DFRec_Type,
            this.DFRec_AccrIncSm,
            this.DFRec_PaidIncSm,
            this.DFRec_AccrTaxSm,
            this.DFRec_TransfTaxSm,
            this.DFRec_IncFlg,
            this.DFRec_DOR,
            this.DFRec_DOD,
            this.DFRec_SocBenefitFlg,
            this.DFRec_Flg});
            this.dgvDFRec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDFRec.Location = new System.Drawing.Point(0, 0);
            this.dgvDFRec.Name = "dgvDFRec";
            this.dgvDFRec.Size = new System.Drawing.Size(579, 367);
            this.dgvDFRec.TabIndex = 1;
            this.dgvDFRec.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDFRec_KeyDown);
            // 
            // statusStripRowDFRec
            // 
            this.statusStripRowDFRec.Location = new System.Drawing.Point(0, 367);
            this.statusStripRowDFRec.Name = "statusStripRowDFRec";
            this.statusStripRowDFRec.Size = new System.Drawing.Size(579, 22);
            this.statusStripRowDFRec.TabIndex = 6;
            this.statusStripRowDFRec.Text = "statusStripRowDFRec";
            // 
            // DFRec_USREOU
            // 
            this.DFRec_USREOU.DataPropertyName = "DFRec_USREOU";
            this.DFRec_USREOU.HeaderText = "ЄДРПОУ\\РНОКПП";
            this.DFRec_USREOU.Name = "DFRec_USREOU";
            // 
            // DFRec_TIN
            // 
            this.DFRec_TIN.DataPropertyName = "DFRec_TIN";
            this.DFRec_TIN.HeaderText = "ІНН";
            this.DFRec_TIN.Name = "DFRec_TIN";
            // 
            // DFRec_LName
            // 
            this.DFRec_LName.DataPropertyName = "DFRec_LName";
            this.DFRec_LName.HeaderText = "Прізвище";
            this.DFRec_LName.Name = "DFRec_LName";
            // 
            // DFRec_FName
            // 
            this.DFRec_FName.DataPropertyName = "DFRec_FName";
            this.DFRec_FName.HeaderText = "Ім\'я";
            this.DFRec_FName.Name = "DFRec_FName";
            // 
            // DFRec_MName
            // 
            this.DFRec_MName.DataPropertyName = "DFRec_MName";
            this.DFRec_MName.HeaderText = "По батькові";
            this.DFRec_MName.Name = "DFRec_MName";
            // 
            // DFRec_Type
            // 
            this.DFRec_Type.DataPropertyName = "DFRec_Type";
            this.DFRec_Type.HeaderText = "Тип";
            this.DFRec_Type.Name = "DFRec_Type";
            // 
            // DFRec_AccrIncSm
            // 
            this.DFRec_AccrIncSm.DataPropertyName = "DFRec_AccrIncSm";
            this.DFRec_AccrIncSm.HeaderText = "Сума нарахованого доходу (грн., коп.)";
            this.DFRec_AccrIncSm.Name = "DFRec_AccrIncSm";
            // 
            // DFRec_PaidIncSm
            // 
            this.DFRec_PaidIncSm.DataPropertyName = "DFRec_PaidIncSm";
            this.DFRec_PaidIncSm.HeaderText = "Сума виплаченого доходу (грн., коп.)";
            this.DFRec_PaidIncSm.Name = "DFRec_PaidIncSm";
            // 
            // DFRec_AccrTaxSm
            // 
            this.DFRec_AccrTaxSm.DataPropertyName = "DFRec_AccrTaxSm";
            this.DFRec_AccrTaxSm.HeaderText = "Сума утриманого податку (грн., коп.) нарахованого";
            this.DFRec_AccrTaxSm.Name = "DFRec_AccrTaxSm";
            // 
            // DFRec_TransfTaxSm
            // 
            this.DFRec_TransfTaxSm.DataPropertyName = "DFRec_TransfTaxSm";
            this.DFRec_TransfTaxSm.HeaderText = "Сума утриманого податку (грн., коп.) перерахованого";
            this.DFRec_TransfTaxSm.Name = "DFRec_TransfTaxSm";
            // 
            // DFRec_IncFlg
            // 
            this.DFRec_IncFlg.DataPropertyName = "DFRec_IncFlg";
            this.DFRec_IncFlg.HeaderText = "Ознака доходу";
            this.DFRec_IncFlg.Name = "DFRec_IncFlg";
            // 
            // DFRec_DOR
            // 
            this.DFRec_DOR.DataPropertyName = "DFRec_DOR";
            this.DFRec_DOR.HeaderText = "Дата прийняття на роботу";
            this.DFRec_DOR.Name = "DFRec_DOR";
            // 
            // DFRec_DOD
            // 
            this.DFRec_DOD.DataPropertyName = "DFRec_DOD";
            this.DFRec_DOD.HeaderText = "Дата звільнення з роботи";
            this.DFRec_DOD.Name = "DFRec_DOD";
            // 
            // DFRec_SocBenefitFlg
            // 
            this.DFRec_SocBenefitFlg.DataPropertyName = "DFRec_SocBenefitFlg";
            this.DFRec_SocBenefitFlg.HeaderText = "Ознака подат. соц. пільги";
            this.DFRec_SocBenefitFlg.Name = "DFRec_SocBenefitFlg";
            // 
            // DFRec_Flg
            // 
            this.DFRec_Flg.DataPropertyName = "DFRec_Flg";
            this.DFRec_Flg.HeaderText = "Ознака (0, 1)";
            this.DFRec_Flg.Name = "DFRec_Flg";
            // 
            // fmDFRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 389);
            this.Controls.Add(this.dgvDFRec);
            this.Controls.Add(this.statusStripRowDFRec);
            this.Name = "fmDFRec";
            this.Text = "1 ДФ";
            this.Load += new System.EventHandler(this.fmDFRec_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmDFRec_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDFRec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDFRec;
        private System.Windows.Forms.StatusStrip statusStripRowDFRec;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_USREOU;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_TIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_LName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_FName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_MName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_AccrIncSm;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_PaidIncSm;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_AccrTaxSm;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_TransfTaxSm;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_IncFlg;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_DOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_DOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_SocBenefitFlg;
        private System.Windows.Forms.DataGridViewTextBoxColumn DFRec_Flg;
    }
}