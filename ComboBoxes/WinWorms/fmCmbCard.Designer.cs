namespace ComboBoxes.WinWorms
{
    partial class fmCmbCard
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
            this.dgvCmbCard = new System.Windows.Forms.DataGridView();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.MenuRefAdm = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemChoose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.PersCard_LName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersCard_FName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersCard_MName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersCard_TIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCmbCard)).BeginInit();
            this.pnlControl.SuspendLayout();
            this.MenuRefAdm.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCmbCard
            // 
            this.dgvCmbCard.AllowUserToAddRows = false;
            this.dgvCmbCard.AllowUserToDeleteRows = false;
            this.dgvCmbCard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCmbCard.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PersCard_LName,
            this.PersCard_FName,
            this.PersCard_MName,
            this.PersCard_TIN});
            this.dgvCmbCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCmbCard.Location = new System.Drawing.Point(0, 28);
            this.dgvCmbCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvCmbCard.Name = "dgvCmbCard";
            this.dgvCmbCard.ReadOnly = true;
            this.dgvCmbCard.Size = new System.Drawing.Size(455, 326);
            this.dgvCmbCard.TabIndex = 5;
            this.dgvCmbCard.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCmbCard_CellDoubleClick);
            this.dgvCmbCard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCmbCard_KeyDown);
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnOk);
            this.pnlControl.Controls.Add(this.btnCancel);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 354);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(455, 48);
            this.pnlControl.TabIndex = 12;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(229, 10);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 28);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(337, 10);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Відміна";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MenuRefAdm
            // 
            this.MenuRefAdm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuRefAdm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuRefAdm.Location = new System.Drawing.Point(0, 0);
            this.MenuRefAdm.Name = "MenuRefAdm";
            this.MenuRefAdm.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MenuRefAdm.Size = new System.Drawing.Size(455, 28);
            this.MenuRefAdm.TabIndex = 4;
            this.MenuRefAdm.Text = "MenuRefAdm";
            // 
            // MenuStripRegister
            // 
            this.MenuStripRegister.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemChoose,
            this.toolStripSeparator2,
            this.MenuItemExit});
            this.MenuStripRegister.Name = "MenuStripRegister";
            this.MenuStripRegister.Size = new System.Drawing.Size(66, 24);
            this.MenuStripRegister.Text = "Реєстр";
            // 
            // MenuItemChoose
            // 
            this.MenuItemChoose.Name = "MenuItemChoose";
            this.MenuItemChoose.ShortcutKeyDisplayString = "Enter";
            this.MenuItemChoose.Size = new System.Drawing.Size(185, 26);
            this.MenuItemChoose.Text = "Вибрати";
            this.MenuItemChoose.Click += new System.EventHandler(this.MenuItemChoose_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.ShortcutKeyDisplayString = "Esc";
            this.MenuItemExit.Size = new System.Drawing.Size(185, 26);
            this.MenuItemExit.Text = "Вихід";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvCmbCard);
            this.pnlGrid.Controls.Add(this.MenuRefAdm);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(455, 354);
            this.pnlGrid.TabIndex = 6;
            // 
            // PersCard_LName
            // 
            this.PersCard_LName.DataPropertyName = "PersCard_LName";
            this.PersCard_LName.HeaderText = "Прізвище";
            this.PersCard_LName.Name = "PersCard_LName";
            this.PersCard_LName.ReadOnly = true;
            // 
            // PersCard_FName
            // 
            this.PersCard_FName.DataPropertyName = "PersCard_FName";
            this.PersCard_FName.HeaderText = "Ім\'я";
            this.PersCard_FName.Name = "PersCard_FName";
            this.PersCard_FName.ReadOnly = true;
            // 
            // PersCard_MName
            // 
            this.PersCard_MName.DataPropertyName = "PersCard_MName";
            this.PersCard_MName.HeaderText = "По батькові";
            this.PersCard_MName.Name = "PersCard_MName";
            this.PersCard_MName.ReadOnly = true;
            // 
            // PersCard_TIN
            // 
            this.PersCard_TIN.DataPropertyName = "PersCard_TIN";
            this.PersCard_TIN.HeaderText = "ІПН";
            this.PersCard_TIN.Name = "PersCard_TIN";
            this.PersCard_TIN.ReadOnly = true;
            // 
            // fmCmbCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 402);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlControl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fmCmbCard";
            this.Text = "Довідник карток";
            this.Load += new System.EventHandler(this.fmCmbCard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmCmbCard_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCmbCard)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.MenuRefAdm.ResumeLayout(false);
            this.MenuRefAdm.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip MenuRefAdm;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemChoose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvCmbCard;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersCard_LName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersCard_FName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersCard_MName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersCard_TIN;
    }
}