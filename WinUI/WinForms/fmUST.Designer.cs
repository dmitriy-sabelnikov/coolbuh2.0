namespace WinUI.WinForms
{
    partial class fmUST
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
            this.tabUST = new System.Windows.Forms.TabControl();
            this.tabPageTable6 = new System.Windows.Forms.TabPage();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvUST6 = new System.Windows.Forms.DataGridView();
            this.UST6_SEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST6_Accr_Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST6_TIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST6_LName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST6_FName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST6_MName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST6_Category_Cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST6_Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST6_Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST6_DisabDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST6_EmplDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST6_TotalSm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST6_WithHeldUSTSm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST6_WB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST6_SpecExp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCaption = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageTable7 = new System.Windows.Forms.TabPage();
            this.dgvUST7 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStripRowUST6 = new System.Windows.Forms.StatusStrip();
            this.statusStripRowUST7 = new System.Windows.Forms.StatusStrip();
            this.UST7_TIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST7_LName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST7_FName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST7_MName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST7_C_Pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST7_Start_Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST7_Stop_Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST7_Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UST7_Norm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabUST.SuspendLayout();
            this.tabPageTable6.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUST6)).BeginInit();
            this.pnlCaption.SuspendLayout();
            this.tabPageTable7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUST7)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabUST
            // 
            this.tabUST.Controls.Add(this.tabPageTable6);
            this.tabUST.Controls.Add(this.tabPageTable7);
            this.tabUST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabUST.Location = new System.Drawing.Point(0, 0);
            this.tabUST.Name = "tabUST";
            this.tabUST.SelectedIndex = 0;
            this.tabUST.Size = new System.Drawing.Size(579, 389);
            this.tabUST.TabIndex = 0;
            // 
            // tabPageTable6
            // 
            this.tabPageTable6.Controls.Add(this.pnlGrid);
            this.tabPageTable6.Controls.Add(this.pnlCaption);
            this.tabPageTable6.Location = new System.Drawing.Point(4, 22);
            this.tabPageTable6.Name = "tabPageTable6";
            this.tabPageTable6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTable6.Size = new System.Drawing.Size(571, 363);
            this.tabPageTable6.TabIndex = 0;
            this.tabPageTable6.Text = "Таблиця 6";
            this.tabPageTable6.UseVisualStyleBackColor = true;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.statusStripRowUST6);
            this.pnlGrid.Controls.Add(this.dgvUST6);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(3, 25);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(565, 335);
            this.pnlGrid.TabIndex = 1;
            // 
            // dgvUST6
            // 
            this.dgvUST6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUST6.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UST6_SEX,
            this.UST6_Accr_Cd,
            this.UST6_TIN,
            this.UST6_LName,
            this.UST6_FName,
            this.UST6_MName,
            this.UST6_Category_Cd,
            this.UST6_Month,
            this.UST6_Year,
            this.UST6_DisabDays,
            this.UST6_EmplDays,
            this.UST6_TotalSm,
            this.UST6_WithHeldUSTSm,
            this.UST6_WB,
            this.UST6_SpecExp});
            this.dgvUST6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUST6.Location = new System.Drawing.Point(0, 0);
            this.dgvUST6.Name = "dgvUST6";
            this.dgvUST6.Size = new System.Drawing.Size(565, 335);
            this.dgvUST6.TabIndex = 0;
            this.dgvUST6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUST6_KeyDown);
            // 
            // UST6_SEX
            // 
            this.UST6_SEX.DataPropertyName = "UST6_SEX";
            this.UST6_SEX.HeaderText = "Стать (0 - Ж, 1 - М)";
            this.UST6_SEX.Name = "UST6_SEX";
            // 
            // UST6_Accr_Cd
            // 
            this.UST6_Accr_Cd.DataPropertyName = "UST6_Accr_Cd";
            this.UST6_Accr_Cd.HeaderText = "Код типу нарахувань";
            this.UST6_Accr_Cd.Name = "UST6_Accr_Cd";
            // 
            // UST6_TIN
            // 
            this.UST6_TIN.DataPropertyName = "UST6_TIN";
            this.UST6_TIN.HeaderText = "ІНН";
            this.UST6_TIN.Name = "UST6_TIN";
            // 
            // UST6_LName
            // 
            this.UST6_LName.DataPropertyName = "UST6_LName";
            this.UST6_LName.HeaderText = "Прізвище ЗО";
            this.UST6_LName.Name = "UST6_LName";
            // 
            // UST6_FName
            // 
            this.UST6_FName.DataPropertyName = "UST6_FName";
            this.UST6_FName.HeaderText = "Ім’я ЗО";
            this.UST6_FName.Name = "UST6_FName";
            // 
            // UST6_MName
            // 
            this.UST6_MName.DataPropertyName = "UST6_MName";
            this.UST6_MName.HeaderText = "По батькові ЗО";
            this.UST6_MName.Name = "UST6_MName";
            // 
            // UST6_Category_Cd
            // 
            this.UST6_Category_Cd.DataPropertyName = "UST6_Category_Cd";
            this.UST6_Category_Cd.HeaderText = "Код категорії ЗО";
            this.UST6_Category_Cd.Name = "UST6_Category_Cd";
            // 
            // UST6_Month
            // 
            this.UST6_Month.DataPropertyName = "UST6_Month";
            this.UST6_Month.HeaderText = "Місяць, за який проведено нарахування";
            this.UST6_Month.Name = "UST6_Month";
            // 
            // UST6_Year
            // 
            this.UST6_Year.DataPropertyName = "UST6_Year";
            this.UST6_Year.HeaderText = "Рік, за який проведено нарахування";
            this.UST6_Year.Name = "UST6_Year";
            // 
            // UST6_DisabDays
            // 
            this.UST6_DisabDays.DataPropertyName = "UST6_DisabDays";
            this.UST6_DisabDays.HeaderText = "Кількість календарних днів тимчасової непрацездатності";
            this.UST6_DisabDays.Name = "UST6_DisabDays";
            // 
            // UST6_EmplDays
            // 
            this.UST6_EmplDays.DataPropertyName = "UST6_EmplDays";
            this.UST6_EmplDays.HeaderText = "Кількість днів перебування у трудових/ЦП відносинах";
            this.UST6_EmplDays.Name = "UST6_EmplDays";
            // 
            // UST6_TotalSm
            // 
            this.UST6_TotalSm.DataPropertyName = "UST6_TotalSm";
            this.UST6_TotalSm.HeaderText = "Загальна сума нарахованої зарплати/доходу";
            this.UST6_TotalSm.Name = "UST6_TotalSm";
            // 
            // UST6_WithHeldUSTSm
            // 
            this.UST6_WithHeldUSTSm.DataPropertyName = "UST6_WithHeldUSTSm";
            this.UST6_WithHeldUSTSm.HeaderText = "Сума утриманого єдиного внеску за звітний місяць";
            this.UST6_WithHeldUSTSm.Name = "UST6_WithHeldUSTSm";
            // 
            // UST6_WB
            // 
            this.UST6_WB.DataPropertyName = "UST6_WB";
            this.UST6_WB.HeaderText = "Ознака наявності трудової книжки";
            this.UST6_WB.Name = "UST6_WB";
            // 
            // UST6_SpecExp
            // 
            this.UST6_SpecExp.DataPropertyName = "UST6_SpecExp";
            this.UST6_SpecExp.HeaderText = "Ознака наявності спец. стажу";
            this.UST6_SpecExp.Name = "UST6_SpecExp";
            // 
            // pnlCaption
            // 
            this.pnlCaption.Controls.Add(this.label1);
            this.pnlCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCaption.Location = new System.Drawing.Point(3, 3);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Size = new System.Drawing.Size(565, 22);
            this.pnlCaption.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(467, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Відомості про нарахування заробітної плати (доходу) застрахованим особам";
            // 
            // tabPageTable7
            // 
            this.tabPageTable7.Controls.Add(this.statusStripRowUST7);
            this.tabPageTable7.Controls.Add(this.dgvUST7);
            this.tabPageTable7.Controls.Add(this.panel1);
            this.tabPageTable7.Location = new System.Drawing.Point(4, 22);
            this.tabPageTable7.Name = "tabPageTable7";
            this.tabPageTable7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTable7.Size = new System.Drawing.Size(571, 363);
            this.tabPageTable7.TabIndex = 1;
            this.tabPageTable7.Text = "Таблиця 7";
            this.tabPageTable7.UseVisualStyleBackColor = true;
            // 
            // dgvUST7
            // 
            this.dgvUST7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUST7.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UST7_TIN,
            this.UST7_LName,
            this.UST7_FName,
            this.UST7_MName,
            this.UST7_C_Pid,
            this.UST7_Start_Days,
            this.UST7_Stop_Days,
            this.UST7_Days,
            this.UST7_Norm});
            this.dgvUST7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUST7.Location = new System.Drawing.Point(3, 25);
            this.dgvUST7.Name = "dgvUST7";
            this.dgvUST7.Size = new System.Drawing.Size(565, 335);
            this.dgvUST7.TabIndex = 1;
            this.dgvUST7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvUST7_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 22);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(553, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Наявність підстав для обліку стажу окремим категоріям осіб відповідно до законода" +
    "вства";
            // 
            // statusStripRowUST6
            // 
            this.statusStripRowUST6.Location = new System.Drawing.Point(0, 313);
            this.statusStripRowUST6.Name = "statusStripRowUST6";
            this.statusStripRowUST6.Size = new System.Drawing.Size(565, 22);
            this.statusStripRowUST6.TabIndex = 5;
            this.statusStripRowUST6.Text = "statusStripRowUST6";
            // 
            // statusStripRowUST7
            // 
            this.statusStripRowUST7.Location = new System.Drawing.Point(3, 338);
            this.statusStripRowUST7.Name = "statusStripRowUST7";
            this.statusStripRowUST7.Size = new System.Drawing.Size(565, 22);
            this.statusStripRowUST7.TabIndex = 5;
            this.statusStripRowUST7.Text = "statusStripRowUST7";
            // 
            // UST7_TIN
            // 
            this.UST7_TIN.DataPropertyName = "UST7_TIN";
            this.UST7_TIN.HeaderText = "ІНН";
            this.UST7_TIN.Name = "UST7_TIN";
            // 
            // UST7_LName
            // 
            this.UST7_LName.DataPropertyName = "UST7_LName";
            this.UST7_LName.HeaderText = "Прізвище ЗО";
            this.UST7_LName.Name = "UST7_LName";
            // 
            // UST7_FName
            // 
            this.UST7_FName.DataPropertyName = "UST7_FName";
            this.UST7_FName.HeaderText = "Ім’я ЗО";
            this.UST7_FName.Name = "UST7_FName";
            // 
            // UST7_MName
            // 
            this.UST7_MName.DataPropertyName = "UST7_MName";
            this.UST7_MName.HeaderText = "По батькові ЗО";
            this.UST7_MName.Name = "UST7_MName";
            // 
            // UST7_C_Pid
            // 
            this.UST7_C_Pid.DataPropertyName = "UST7_C_Pid";
            this.UST7_C_Pid.HeaderText = "Код підстави для обліку спец стажу";
            this.UST7_C_Pid.Name = "UST7_C_Pid";
            // 
            // UST7_Start_Days
            // 
            this.UST7_Start_Days.DataPropertyName = "UST7_Start_Days";
            this.UST7_Start_Days.HeaderText = "Початок періоду";
            this.UST7_Start_Days.Name = "UST7_Start_Days";
            // 
            // UST7_Stop_Days
            // 
            this.UST7_Stop_Days.DataPropertyName = "UST7_Stop_Days";
            this.UST7_Stop_Days.HeaderText = "Кінець періоду";
            this.UST7_Stop_Days.Name = "UST7_Stop_Days";
            // 
            // UST7_Days
            // 
            this.UST7_Days.DataPropertyName = "UST7_Days";
            this.UST7_Days.HeaderText = "Кількість днів";
            this.UST7_Days.Name = "UST7_Days";
            // 
            // UST7_Norm
            // 
            this.UST7_Norm.DataPropertyName = "UST7_Norm";
            this.UST7_Norm.HeaderText = "Норма тривалості роботи для її зарахування за повний місяць спецстажу";
            this.UST7_Norm.Name = "UST7_Norm";
            // 
            // fmUST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 389);
            this.Controls.Add(this.tabUST);
            this.Name = "fmUST";
            this.Text = "Единий соціальний внесок. Таблиці";
            this.Load += new System.EventHandler(this.fmUST_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmUST_KeyDown);
            this.tabUST.ResumeLayout(false);
            this.tabPageTable6.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUST6)).EndInit();
            this.pnlCaption.ResumeLayout(false);
            this.pnlCaption.PerformLayout();
            this.tabPageTable7.ResumeLayout(false);
            this.tabPageTable7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUST7)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabUST;
        private System.Windows.Forms.TabPage tabPageTable6;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvUST6;
        private System.Windows.Forms.Panel pnlCaption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageTable7;
        private System.Windows.Forms.DataGridView dgvUST7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_SEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_Accr_Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_TIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_LName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_FName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_MName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_Category_Cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_DisabDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_EmplDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_TotalSm;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_WithHeldUSTSm;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_WB;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST6_SpecExp;
        private System.Windows.Forms.StatusStrip statusStripRowUST6;
        private System.Windows.Forms.StatusStrip statusStripRowUST7;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST7_TIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST7_LName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST7_FName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST7_MName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST7_C_Pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST7_Start_Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST7_Stop_Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST7_Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn UST7_Norm;
    }
}