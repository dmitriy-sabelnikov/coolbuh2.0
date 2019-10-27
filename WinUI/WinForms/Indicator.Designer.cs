namespace WinUI
{
    partial class Indicator
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
            this.pbIndicator = new System.Windows.Forms.ProgressBar();
            this.lblIndicator = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbIndicator
            // 
            this.pbIndicator.BackColor = System.Drawing.Color.White;
            this.pbIndicator.Location = new System.Drawing.Point(12, 33);
            this.pbIndicator.Name = "pbIndicator";
            this.pbIndicator.Size = new System.Drawing.Size(356, 23);
            this.pbIndicator.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbIndicator.TabIndex = 0;
            // 
            // lblIndicator
            // 
            this.lblIndicator.AutoSize = true;
            this.lblIndicator.Location = new System.Drawing.Point(15, 12);
            this.lblIndicator.Name = "lblIndicator";
            this.lblIndicator.Size = new System.Drawing.Size(62, 13);
            this.lblIndicator.TabIndex = 1;
            this.lblIndicator.Text = "Индикатор";
            // 
            // Indicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(387, 68);
            this.Controls.Add(this.lblIndicator);
            this.Controls.Add(this.pbIndicator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Indicator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indicator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbIndicator;
        private System.Windows.Forms.Label lblIndicator;
    }
}