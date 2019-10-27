namespace WinUI.WinForms
{
    partial class fmUSTExport
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
            this.cbTbl7 = new System.Windows.Forms.CheckBox();
            this.cbTbl6 = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.tbPathExport = new System.Windows.Forms.TextBox();
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
            this.pnl1.Controls.Add(this.cbTbl7);
            this.pnl1.Controls.Add(this.cbTbl6);
            this.pnl1.Controls.Add(this.btnExport);
            this.pnl1.Controls.Add(this.tbPathExport);
            this.pnl1.Controls.Add(this.label2);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(364, 92);
            this.pnl1.TabIndex = 16;
            // 
            // cbTbl7
            // 
            this.cbTbl7.AutoSize = true;
            this.cbTbl7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbTbl7.Location = new System.Drawing.Point(6, 62);
            this.cbTbl7.Name = "cbTbl7";
            this.cbTbl7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbTbl7.Size = new System.Drawing.Size(78, 17);
            this.cbTbl7.TabIndex = 48;
            this.cbTbl7.Text = "Таблиця 7";
            this.cbTbl7.UseVisualStyleBackColor = true;
            // 
            // cbTbl6
            // 
            this.cbTbl6.AutoSize = true;
            this.cbTbl6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cbTbl6.Location = new System.Drawing.Point(6, 39);
            this.cbTbl6.Name = "cbTbl6";
            this.cbTbl6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbTbl6.Size = new System.Drawing.Size(78, 17);
            this.cbTbl6.TabIndex = 47;
            this.cbTbl6.Text = "Таблиця 6";
            this.cbTbl6.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(334, 12);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(22, 22);
            this.btnExport.TabIndex = 46;
            this.btnExport.TabStop = false;
            this.btnExport.Text = "...";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // tbPathExport
            // 
            this.tbPathExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPathExport.BackColor = System.Drawing.SystemColors.Window;
            this.tbPathExport.Location = new System.Drawing.Point(70, 13);
            this.tbPathExport.Name = "tbPathExport";
            this.tbPathExport.ReadOnly = true;
            this.tbPathExport.Size = new System.Drawing.Size(262, 20);
            this.tbPathExport.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Шлях:";
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.btnOk);
            this.pnl2.Controls.Add(this.btnCancel);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl2.Location = new System.Drawing.Point(0, 92);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(364, 39);
            this.pnl2.TabIndex = 17;
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
            // fmUSTExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 131);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.pnl2);
            this.Name = "fmUSTExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Експорт ЄСВ";
            this.Load += new System.EventHandler(this.fmUSTExport_Load);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox tbPathExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbTbl7;
        private System.Windows.Forms.CheckBox cbTbl6;
    }
}