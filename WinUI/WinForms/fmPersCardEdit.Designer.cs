namespace WinUI.WinForms
{
    partial class fmPersCardEdit
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
            this.components = new System.ComponentModel.Container();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.tabPersCard = new System.Windows.Forms.TabControl();
            this.tabPageCommon = new System.Windows.Forms.TabPage();
            this.tbDOP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbDOD = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbDOR = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDOB = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbGrade = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbExp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTIN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLName = new System.Windows.Forms.TextBox();
            this.tbFName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageChild = new System.Windows.Forms.TabPage();
            this.dgvChild = new System.Windows.Forms.DataGridView();
            this.Child_PerBeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Child_PerEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Child_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageTaxRelief = new System.Windows.Forms.TabPage();
            this.dgvTaxRelief = new System.Windows.Forms.DataGridView();
            this.TaxRelief_PerBeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxRelief_PerEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxRelief_Koef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageStatus = new System.Windows.Forms.TabPage();
            this.dgvCardStatus = new System.Windows.Forms.DataGridView();
            this.CardStatus_PerBeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardStatus_PerEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardStatus_TypeNm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageDisability = new System.Windows.Forms.TabPage();
            this.dgvDisability = new System.Windows.Forms.DataGridView();
            this.Disability_PerBeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disability_PerEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Disability_Attr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageSpecExp = new System.Windows.Forms.TabPage();
            this.dgvCardSpecExp = new System.Windows.Forms.DataGridView();
            this.CardSpecExp_PerBeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardSpecExp_PerEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardSpecExp_RefSpecExp_Nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.pnl2.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.tabPersCard.SuspendLayout();
            this.tabPageCommon.SuspendLayout();
            this.tabPageChild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChild)).BeginInit();
            this.tabPageTaxRelief.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxRelief)).BeginInit();
            this.tabPageStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardStatus)).BeginInit();
            this.tabPageDisability.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisability)).BeginInit();
            this.tabPageSpecExp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardSpecExp)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.btnOk);
            this.pnl2.Controls.Add(this.btnCancel);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl2.Location = new System.Drawing.Point(0, 302);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(384, 39);
            this.pnl2.TabIndex = 9;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(215, 9);
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
            this.btnCancel.Location = new System.Drawing.Point(296, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Відміна";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.tabPersCard);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(0, 0);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(384, 341);
            this.pnl1.TabIndex = 8;
            // 
            // tabPersCard
            // 
            this.tabPersCard.Controls.Add(this.tabPageCommon);
            this.tabPersCard.Controls.Add(this.tabPageChild);
            this.tabPersCard.Controls.Add(this.tabPageTaxRelief);
            this.tabPersCard.Controls.Add(this.tabPageStatus);
            this.tabPersCard.Controls.Add(this.tabPageDisability);
            this.tabPersCard.Controls.Add(this.tabPageSpecExp);
            this.tabPersCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPersCard.Location = new System.Drawing.Point(0, 0);
            this.tabPersCard.Margin = new System.Windows.Forms.Padding(2);
            this.tabPersCard.Name = "tabPersCard";
            this.tabPersCard.SelectedIndex = 0;
            this.tabPersCard.Size = new System.Drawing.Size(384, 341);
            this.tabPersCard.TabIndex = 19;
            // 
            // tabPageCommon
            // 
            this.tabPageCommon.Controls.Add(this.label11);
            this.tabPageCommon.Controls.Add(this.rbMale);
            this.tabPageCommon.Controls.Add(this.rbFemale);
            this.tabPageCommon.Controls.Add(this.tbDOP);
            this.tabPageCommon.Controls.Add(this.label10);
            this.tabPageCommon.Controls.Add(this.tbDOD);
            this.tabPageCommon.Controls.Add(this.label9);
            this.tabPageCommon.Controls.Add(this.tbDOR);
            this.tabPageCommon.Controls.Add(this.label8);
            this.tabPageCommon.Controls.Add(this.tbDOB);
            this.tabPageCommon.Controls.Add(this.label7);
            this.tabPageCommon.Controls.Add(this.tbGrade);
            this.tabPageCommon.Controls.Add(this.label6);
            this.tabPageCommon.Controls.Add(this.tbExp);
            this.tabPageCommon.Controls.Add(this.label5);
            this.tabPageCommon.Controls.Add(this.tbTIN);
            this.tabPageCommon.Controls.Add(this.label4);
            this.tabPageCommon.Controls.Add(this.tbMName);
            this.tabPageCommon.Controls.Add(this.label3);
            this.tabPageCommon.Controls.Add(this.tbLName);
            this.tabPageCommon.Controls.Add(this.tbFName);
            this.tabPageCommon.Controls.Add(this.label1);
            this.tabPageCommon.Controls.Add(this.label2);
            this.tabPageCommon.Location = new System.Drawing.Point(4, 22);
            this.tabPageCommon.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageCommon.Name = "tabPageCommon";
            this.tabPageCommon.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageCommon.Size = new System.Drawing.Size(376, 315);
            this.tabPageCommon.TabIndex = 0;
            this.tabPageCommon.Text = "Загальні відомості";
            this.tabPageCommon.UseVisualStyleBackColor = true;
            // 
            // tbDOP
            // 
            this.tbDOP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDOP.Location = new System.Drawing.Point(135, 226);
            this.tbDOP.Name = "tbDOP";
            this.tbDOP.Size = new System.Drawing.Size(223, 20);
            this.tbDOP.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Дата виходу на пенсію:";
            // 
            // tbDOD
            // 
            this.tbDOD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDOD.Location = new System.Drawing.Point(135, 200);
            this.tbDOD.Name = "tbDOD";
            this.tbDOD.Size = new System.Drawing.Size(223, 20);
            this.tbDOD.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Дата звільнення:";
            // 
            // tbDOR
            // 
            this.tbDOR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDOR.Location = new System.Drawing.Point(135, 176);
            this.tbDOR.Name = "tbDOR";
            this.tbDOR.Size = new System.Drawing.Size(223, 20);
            this.tbDOR.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Дата прийому:";
            // 
            // tbDOB
            // 
            this.tbDOB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDOB.Location = new System.Drawing.Point(135, 151);
            this.tbDOB.Name = "tbDOB";
            this.tbDOB.Size = new System.Drawing.Size(223, 20);
            this.tbDOB.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Дата народження:";
            // 
            // tbGrade
            // 
            this.tbGrade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGrade.Location = new System.Drawing.Point(135, 127);
            this.tbGrade.Name = "tbGrade";
            this.tbGrade.Size = new System.Drawing.Size(223, 20);
            this.tbGrade.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Класність:";
            // 
            // tbExp
            // 
            this.tbExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExp.Location = new System.Drawing.Point(135, 102);
            this.tbExp.Name = "tbExp";
            this.tbExp.Size = new System.Drawing.Size(223, 20);
            this.tbExp.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Стаж:";
            // 
            // tbTIN
            // 
            this.tbTIN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTIN.Location = new System.Drawing.Point(135, 78);
            this.tbTIN.Name = "tbTIN";
            this.tbTIN.Size = new System.Drawing.Size(223, 20);
            this.tbTIN.TabIndex = 25;
            this.tbTIN.Validating += new System.ComponentModel.CancelEventHandler(this.tbTIN_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "ІПН:";
            // 
            // tbMName
            // 
            this.tbMName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMName.Location = new System.Drawing.Point(135, 54);
            this.tbMName.Name = "tbMName";
            this.tbMName.Size = new System.Drawing.Size(223, 20);
            this.tbMName.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "По батькові:";
            // 
            // tbLName
            // 
            this.tbLName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLName.BackColor = System.Drawing.SystemColors.Window;
            this.tbLName.Location = new System.Drawing.Point(135, 7);
            this.tbLName.Name = "tbLName";
            this.tbLName.Size = new System.Drawing.Size(223, 20);
            this.tbLName.TabIndex = 19;
            // 
            // tbFName
            // 
            this.tbFName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFName.Location = new System.Drawing.Point(135, 29);
            this.tbFName.Name = "tbFName";
            this.tbFName.Size = new System.Drawing.Size(223, 20);
            this.tbFName.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Прізвище:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ім\'я:";
            // 
            // tabPageChild
            // 
            this.tabPageChild.Controls.Add(this.dgvChild);
            this.tabPageChild.Location = new System.Drawing.Point(4, 22);
            this.tabPageChild.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageChild.Name = "tabPageChild";
            this.tabPageChild.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageChild.Size = new System.Drawing.Size(376, 315);
            this.tabPageChild.TabIndex = 1;
            this.tabPageChild.Text = "Діти";
            this.tabPageChild.UseVisualStyleBackColor = true;
            // 
            // dgvChild
            // 
            this.dgvChild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChild.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Child_PerBeg,
            this.Child_PerEnd,
            this.Child_Count});
            this.dgvChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChild.Location = new System.Drawing.Point(2, 2);
            this.dgvChild.Margin = new System.Windows.Forms.Padding(2);
            this.dgvChild.Name = "dgvChild";
            this.dgvChild.RowHeadersVisible = false;
            this.dgvChild.RowTemplate.Height = 24;
            this.dgvChild.Size = new System.Drawing.Size(372, 311);
            this.dgvChild.TabIndex = 0;
            // 
            // Child_PerBeg
            // 
            this.Child_PerBeg.DataPropertyName = "Child_PerBeg";
            this.Child_PerBeg.HeaderText = "Дата початку періоду";
            this.Child_PerBeg.Name = "Child_PerBeg";
            this.Child_PerBeg.ReadOnly = true;
            // 
            // Child_PerEnd
            // 
            this.Child_PerEnd.DataPropertyName = "Child_PerEnd";
            this.Child_PerEnd.HeaderText = "Дата кінця періоду";
            this.Child_PerEnd.Name = "Child_PerEnd";
            this.Child_PerEnd.ReadOnly = true;
            // 
            // Child_Count
            // 
            this.Child_Count.DataPropertyName = "Child_Count";
            this.Child_Count.HeaderText = "Кількість дітей";
            this.Child_Count.Name = "Child_Count";
            this.Child_Count.ReadOnly = true;
            // 
            // tabPageTaxRelief
            // 
            this.tabPageTaxRelief.Controls.Add(this.dgvTaxRelief);
            this.tabPageTaxRelief.Location = new System.Drawing.Point(4, 22);
            this.tabPageTaxRelief.Name = "tabPageTaxRelief";
            this.tabPageTaxRelief.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTaxRelief.Size = new System.Drawing.Size(376, 315);
            this.tabPageTaxRelief.TabIndex = 2;
            this.tabPageTaxRelief.Text = "Пільги";
            this.tabPageTaxRelief.UseVisualStyleBackColor = true;
            // 
            // dgvTaxRelief
            // 
            this.dgvTaxRelief.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaxRelief.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaxRelief_PerBeg,
            this.TaxRelief_PerEnd,
            this.TaxRelief_Koef});
            this.dgvTaxRelief.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaxRelief.Location = new System.Drawing.Point(3, 3);
            this.dgvTaxRelief.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTaxRelief.Name = "dgvTaxRelief";
            this.dgvTaxRelief.RowHeadersVisible = false;
            this.dgvTaxRelief.RowTemplate.Height = 24;
            this.dgvTaxRelief.Size = new System.Drawing.Size(370, 309);
            this.dgvTaxRelief.TabIndex = 3;
            // 
            // TaxRelief_PerBeg
            // 
            this.TaxRelief_PerBeg.DataPropertyName = "TaxRelief_PerBeg";
            this.TaxRelief_PerBeg.HeaderText = "Дата початку періоду";
            this.TaxRelief_PerBeg.Name = "TaxRelief_PerBeg";
            this.TaxRelief_PerBeg.ReadOnly = true;
            // 
            // TaxRelief_PerEnd
            // 
            this.TaxRelief_PerEnd.DataPropertyName = "TaxRelief_PerEnd";
            this.TaxRelief_PerEnd.HeaderText = "Дата кінця періоду";
            this.TaxRelief_PerEnd.Name = "TaxRelief_PerEnd";
            this.TaxRelief_PerEnd.ReadOnly = true;
            // 
            // TaxRelief_Koef
            // 
            this.TaxRelief_Koef.DataPropertyName = "TaxRelief_Koef";
            this.TaxRelief_Koef.HeaderText = "Коефіцієнт пільги";
            this.TaxRelief_Koef.Name = "TaxRelief_Koef";
            this.TaxRelief_Koef.ReadOnly = true;
            // 
            // tabPageStatus
            // 
            this.tabPageStatus.Controls.Add(this.dgvCardStatus);
            this.tabPageStatus.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatus.Name = "tabPageStatus";
            this.tabPageStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStatus.Size = new System.Drawing.Size(376, 315);
            this.tabPageStatus.TabIndex = 3;
            this.tabPageStatus.Text = "Статус";
            this.tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // dgvCardStatus
            // 
            this.dgvCardStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CardStatus_PerBeg,
            this.CardStatus_PerEnd,
            this.CardStatus_TypeNm});
            this.dgvCardStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCardStatus.Location = new System.Drawing.Point(3, 3);
            this.dgvCardStatus.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCardStatus.Name = "dgvCardStatus";
            this.dgvCardStatus.RowHeadersVisible = false;
            this.dgvCardStatus.RowTemplate.Height = 24;
            this.dgvCardStatus.Size = new System.Drawing.Size(370, 309);
            this.dgvCardStatus.TabIndex = 4;
            // 
            // CardStatus_PerBeg
            // 
            this.CardStatus_PerBeg.DataPropertyName = "CardStatus_PerBeg";
            this.CardStatus_PerBeg.HeaderText = "Дата початку періоду";
            this.CardStatus_PerBeg.Name = "CardStatus_PerBeg";
            this.CardStatus_PerBeg.ReadOnly = true;
            // 
            // CardStatus_PerEnd
            // 
            this.CardStatus_PerEnd.DataPropertyName = "CardStatus_PerEnd";
            this.CardStatus_PerEnd.HeaderText = "Дата кінця періоду";
            this.CardStatus_PerEnd.Name = "CardStatus_PerEnd";
            this.CardStatus_PerEnd.ReadOnly = true;
            // 
            // CardStatus_TypeNm
            // 
            this.CardStatus_TypeNm.DataPropertyName = "CardStatus_TypeNm";
            this.CardStatus_TypeNm.HeaderText = "Статус";
            this.CardStatus_TypeNm.Name = "CardStatus_TypeNm";
            this.CardStatus_TypeNm.ReadOnly = true;
            // 
            // tabPageDisability
            // 
            this.tabPageDisability.Controls.Add(this.dgvDisability);
            this.tabPageDisability.Location = new System.Drawing.Point(4, 22);
            this.tabPageDisability.Name = "tabPageDisability";
            this.tabPageDisability.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDisability.Size = new System.Drawing.Size(376, 315);
            this.tabPageDisability.TabIndex = 4;
            this.tabPageDisability.Text = "Інвалідність";
            this.tabPageDisability.UseVisualStyleBackColor = true;
            // 
            // dgvDisability
            // 
            this.dgvDisability.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisability.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Disability_PerBeg,
            this.Disability_PerEnd,
            this.Disability_Attr});
            this.dgvDisability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDisability.Location = new System.Drawing.Point(3, 3);
            this.dgvDisability.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDisability.Name = "dgvDisability";
            this.dgvDisability.RowHeadersVisible = false;
            this.dgvDisability.RowTemplate.Height = 24;
            this.dgvDisability.Size = new System.Drawing.Size(370, 309);
            this.dgvDisability.TabIndex = 5;
            // 
            // Disability_PerBeg
            // 
            this.Disability_PerBeg.DataPropertyName = "Disability_PerBeg";
            this.Disability_PerBeg.HeaderText = "Дата початку періоду";
            this.Disability_PerBeg.Name = "Disability_PerBeg";
            this.Disability_PerBeg.ReadOnly = true;
            // 
            // Disability_PerEnd
            // 
            this.Disability_PerEnd.DataPropertyName = "Disability_PerEnd";
            this.Disability_PerEnd.HeaderText = "Дата кінця періоду";
            this.Disability_PerEnd.Name = "Disability_PerEnd";
            this.Disability_PerEnd.ReadOnly = true;
            // 
            // Disability_Attr
            // 
            this.Disability_Attr.DataPropertyName = "Disability_Attr";
            this.Disability_Attr.HeaderText = "Ознака";
            this.Disability_Attr.Name = "Disability_Attr";
            this.Disability_Attr.ReadOnly = true;
            // 
            // tabPageSpecExp
            // 
            this.tabPageSpecExp.Controls.Add(this.dgvCardSpecExp);
            this.tabPageSpecExp.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpecExp.Name = "tabPageSpecExp";
            this.tabPageSpecExp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpecExp.Size = new System.Drawing.Size(376, 315);
            this.tabPageSpecExp.TabIndex = 5;
            this.tabPageSpecExp.Text = "Спецстаж";
            this.tabPageSpecExp.UseVisualStyleBackColor = true;
            // 
            // dgvCardSpecExp
            // 
            this.dgvCardSpecExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardSpecExp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CardSpecExp_PerBeg,
            this.CardSpecExp_PerEnd,
            this.CardSpecExp_RefSpecExp_Nm});
            this.dgvCardSpecExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCardSpecExp.Location = new System.Drawing.Point(3, 3);
            this.dgvCardSpecExp.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCardSpecExp.Name = "dgvCardSpecExp";
            this.dgvCardSpecExp.RowHeadersVisible = false;
            this.dgvCardSpecExp.RowTemplate.Height = 24;
            this.dgvCardSpecExp.Size = new System.Drawing.Size(370, 309);
            this.dgvCardSpecExp.TabIndex = 6;
            // 
            // CardSpecExp_PerBeg
            // 
            this.CardSpecExp_PerBeg.DataPropertyName = "CardSpecExp_PerBeg";
            this.CardSpecExp_PerBeg.HeaderText = "Дата початку періоду";
            this.CardSpecExp_PerBeg.Name = "CardSpecExp_PerBeg";
            this.CardSpecExp_PerBeg.ReadOnly = true;
            // 
            // CardSpecExp_PerEnd
            // 
            this.CardSpecExp_PerEnd.DataPropertyName = "CardSpecExp_PerEnd";
            this.CardSpecExp_PerEnd.HeaderText = "Дата кінця періоду";
            this.CardSpecExp_PerEnd.Name = "CardSpecExp_PerEnd";
            this.CardSpecExp_PerEnd.ReadOnly = true;
            // 
            // CardSpecExp_RefSpecExp_Nm
            // 
            this.CardSpecExp_RefSpecExp_Nm.DataPropertyName = "CardSpecExp_RefSpecExp_Nm";
            this.CardSpecExp_RefSpecExp_Nm.HeaderText = "Спецстаж";
            this.CardSpecExp_RefSpecExp_Nm.Name = "CardSpecExp_RefSpecExp_Nm";
            this.CardSpecExp_RefSpecExp_Nm.ReadOnly = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(19, 19);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemCreate,
            this.MenuItemEdit,
            this.MenuItemDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(149, 70);
            // 
            // MenuItemCreate
            // 
            this.MenuItemCreate.Name = "MenuItemCreate";
            this.MenuItemCreate.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.MenuItemCreate.Size = new System.Drawing.Size(148, 22);
            this.MenuItemCreate.Text = "Створити";
            this.MenuItemCreate.Click += new System.EventHandler(this.MenuItemCreate_Click);
            // 
            // MenuItemEdit
            // 
            this.MenuItemEdit.Name = "MenuItemEdit";
            this.MenuItemEdit.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.MenuItemEdit.Size = new System.Drawing.Size(148, 22);
            this.MenuItemEdit.Text = "Змінити";
            this.MenuItemEdit.Click += new System.EventHandler(this.MenuItemEdit_Click);
            // 
            // MenuItemDelete
            // 
            this.MenuItemDelete.Name = "MenuItemDelete";
            this.MenuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.MenuItemDelete.Size = new System.Drawing.Size(148, 22);
            this.MenuItemDelete.Text = "Видалити";
            this.MenuItemDelete.Click += new System.EventHandler(this.MenuItemDelete_Click);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Checked = true;
            this.rbFemale.Location = new System.Drawing.Point(135, 252);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(67, 17);
            this.rbFemale.TabIndex = 39;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Жіночий";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(273, 252);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(76, 17);
            this.rbMale.TabIndex = 40;
            this.rbMale.Text = "Чоловічий";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Стать:";
            // 
            // fmPersCardEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 341);
            this.Controls.Add(this.pnl2);
            this.Controls.Add(this.pnl1);
            this.Name = "fmPersCardEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fmPersCardEdit";
            this.Load += new System.EventHandler(this.fmPersCardEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmPersCardEdit_KeyDown);
            this.pnl2.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            this.tabPersCard.ResumeLayout(false);
            this.tabPageCommon.ResumeLayout(false);
            this.tabPageCommon.PerformLayout();
            this.tabPageChild.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChild)).EndInit();
            this.tabPageTaxRelief.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxRelief)).EndInit();
            this.tabPageStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardStatus)).EndInit();
            this.tabPageDisability.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisability)).EndInit();
            this.tabPageSpecExp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardSpecExp)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.TabControl tabPersCard;
        private System.Windows.Forms.TabPage tabPageCommon;
        private System.Windows.Forms.TextBox tbDOD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbDOR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDOB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbGrade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbExp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTIN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLName;
        private System.Windows.Forms.TextBox tbFName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageChild;
        private System.Windows.Forms.DataGridView dgvChild;
        private System.Windows.Forms.TextBox tbDOP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Child_PerBeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Child_PerEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Child_Count;
        private System.Windows.Forms.TabPage tabPageTaxRelief;
        private System.Windows.Forms.DataGridView dgvTaxRelief;
        private System.Windows.Forms.TabPage tabPageStatus;
        private System.Windows.Forms.TabPage tabPageDisability;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.DataGridView dgvCardStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxRelief_PerBeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxRelief_PerEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxRelief_Koef;
        private System.Windows.Forms.DataGridView dgvDisability;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disability_PerBeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disability_PerEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Disability_Attr;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardStatus_PerBeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardStatus_PerEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardStatus_TypeNm;
        private System.Windows.Forms.TabPage tabPageSpecExp;
        private System.Windows.Forms.DataGridView dgvCardSpecExp;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardSpecExp_PerBeg;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardSpecExp_PerEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardSpecExp_RefSpecExp_Nm;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.Label label11;
    }
}