﻿namespace ComboBoxes.WinWorms
{
    partial class fmCmbExpAllwnc
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
            this.pnlControl = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvExpAllwnc = new System.Windows.Forms.DataGridView();
            this.RefExpAllwnc_Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefExpAllwnc_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefExpAllwnc_Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefExpAllwnc_Mech = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefExpAllwnc_Oth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuRefAdm = new System.Windows.Forms.MenuStrip();
            this.MenuStripRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemChoose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpAllwnc)).BeginInit();
            this.MenuRefAdm.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnOk);
            this.pnlControl.Controls.Add(this.btnCancel);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 288);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(341, 39);
            this.pnlControl.TabIndex = 19;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(172, 8);
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
            this.btnCancel.Location = new System.Drawing.Point(253, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Відміна";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvExpAllwnc
            // 
            this.dgvExpAllwnc.AllowUserToAddRows = false;
            this.dgvExpAllwnc.AllowUserToDeleteRows = false;
            this.dgvExpAllwnc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpAllwnc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RefExpAllwnc_Cd,
            this.RefExpAllwnc_Nm,
            this.RefExpAllwnc_Year,
            this.RefExpAllwnc_Mech,
            this.RefExpAllwnc_Oth});
            this.dgvExpAllwnc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExpAllwnc.Location = new System.Drawing.Point(0, 24);
            this.dgvExpAllwnc.Name = "dgvExpAllwnc";
            this.dgvExpAllwnc.ReadOnly = true;
            this.dgvExpAllwnc.Size = new System.Drawing.Size(341, 264);
            this.dgvExpAllwnc.TabIndex = 18;
            this.dgvExpAllwnc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpAllwnc_CellDoubleClick);
            this.dgvExpAllwnc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvExpAllwnc_KeyDown);
            // 
            // RefExpAllwnc_Cd
            // 
            this.RefExpAllwnc_Cd.DataPropertyName = "RefExpAllwnc_Cd";
            this.RefExpAllwnc_Cd.HeaderText = "Код";
            this.RefExpAllwnc_Cd.Name = "RefExpAllwnc_Cd";
            this.RefExpAllwnc_Cd.ReadOnly = true;
            // 
            // RefExpAllwnc_Nm
            // 
            this.RefExpAllwnc_Nm.DataPropertyName = "RefExpAllwnc_Nm";
            this.RefExpAllwnc_Nm.HeaderText = "Найменування";
            this.RefExpAllwnc_Nm.Name = "RefExpAllwnc_Nm";
            this.RefExpAllwnc_Nm.ReadOnly = true;
            // 
            // RefExpAllwnc_Year
            // 
            this.RefExpAllwnc_Year.DataPropertyName = "RefExpAllwnc_Year";
            this.RefExpAllwnc_Year.HeaderText = "Рік";
            this.RefExpAllwnc_Year.Name = "RefExpAllwnc_Year";
            this.RefExpAllwnc_Year.ReadOnly = true;
            // 
            // RefExpAllwnc_Mech
            // 
            this.RefExpAllwnc_Mech.DataPropertyName = "RefExpAllwnc_Mech";
            this.RefExpAllwnc_Mech.HeaderText = "Відсоток механікам";
            this.RefExpAllwnc_Mech.Name = "RefExpAllwnc_Mech";
            this.RefExpAllwnc_Mech.ReadOnly = true;
            // 
            // RefExpAllwnc_Oth
            // 
            this.RefExpAllwnc_Oth.DataPropertyName = "RefExpAllwnc_Oth";
            this.RefExpAllwnc_Oth.HeaderText = "Відсоток іншим";
            this.RefExpAllwnc_Oth.Name = "RefExpAllwnc_Oth";
            this.RefExpAllwnc_Oth.ReadOnly = true;
            // 
            // MenuRefAdm
            // 
            this.MenuRefAdm.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuRefAdm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStripRegister});
            this.MenuRefAdm.Location = new System.Drawing.Point(0, 0);
            this.MenuRefAdm.Name = "MenuRefAdm";
            this.MenuRefAdm.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MenuRefAdm.Size = new System.Drawing.Size(341, 24);
            this.MenuRefAdm.TabIndex = 17;
            this.MenuRefAdm.Text = "MenuRefAdm";
            // 
            // MenuStripRegister
            // 
            this.MenuStripRegister.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemChoose,
            this.toolStripSeparator2,
            this.MenuItemExit});
            this.MenuStripRegister.Name = "MenuStripRegister";
            this.MenuStripRegister.Size = new System.Drawing.Size(56, 20);
            this.MenuStripRegister.Text = "Реєстр";
            // 
            // MenuItemChoose
            // 
            this.MenuItemChoose.Name = "MenuItemChoose";
            this.MenuItemChoose.ShortcutKeyDisplayString = "Enter";
            this.MenuItemChoose.Size = new System.Drawing.Size(154, 22);
            this.MenuItemChoose.Text = "Вибрати";
            this.MenuItemChoose.Click += new System.EventHandler(this.MenuItemChoose_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.ShortcutKeyDisplayString = "Esc";
            this.MenuItemExit.Size = new System.Drawing.Size(154, 22);
            this.MenuItemExit.Text = "Вихід";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvExpAllwnc);
            this.pnlGrid.Controls.Add(this.MenuRefAdm);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(341, 288);
            this.pnlGrid.TabIndex = 20;
            // 
            // fmCmbExpAllwnc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 327);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlControl);
            this.Name = "fmCmbExpAllwnc";
            this.Text = "Довідник надбавок за стаж";
            this.Load += new System.EventHandler(this.fmCmbExpAllwnc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmCmbExpAllwnc_KeyDown);
            this.pnlControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpAllwnc)).EndInit();
            this.MenuRefAdm.ResumeLayout(false);
            this.MenuRefAdm.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvExpAllwnc;
        private System.Windows.Forms.MenuStrip MenuRefAdm;
        private System.Windows.Forms.ToolStripMenuItem MenuStripRegister;
        private System.Windows.Forms.ToolStripMenuItem MenuItemChoose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefExpAllwnc_Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefExpAllwnc_Nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefExpAllwnc_Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefExpAllwnc_Mech;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefExpAllwnc_Oth;
        private System.Windows.Forms.Panel pnlGrid;
    }
}