namespace WinUI.WinForms
{
    partial class fmCalcResult
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
            this.pnl2 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.rtbCalcResult = new System.Windows.Forms.RichTextBox();
            this.pnl1.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.rtbCalcResult);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Margin = new System.Windows.Forms.Padding(4);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(482, 405);
            this.pnl1.TabIndex = 8;
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.btnOk);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl2.Location = new System.Drawing.Point(0, 405);
            this.pnl2.Margin = new System.Windows.Forms.Padding(4);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(482, 48);
            this.pnl2.TabIndex = 9;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(192, 8);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rtbCalcResult
            // 
            this.rtbCalcResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbCalcResult.Location = new System.Drawing.Point(0, 0);
            this.rtbCalcResult.Name = "rtbCalcResult";
            this.rtbCalcResult.ReadOnly = true;
            this.rtbCalcResult.Size = new System.Drawing.Size(482, 405);
            this.rtbCalcResult.TabIndex = 0;
            this.rtbCalcResult.Text = "";
            // 
            // fmCalcResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.pnl2);
            this.Name = "fmCalcResult";
            this.Text = "Результат розрахунку";
            this.pnl1.ResumeLayout(false);
            this.pnl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.RichTextBox rtbCalcResult;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Button btnOk;
    }
}