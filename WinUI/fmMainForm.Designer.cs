namespace WinUI
{
    partial class fmMainForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Заробітна плата");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Відпускні");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Лікарняні");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Договір ЦПХ");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Додаткові нарахування");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Корегування прибуткового податку");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Нарахування", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Виплати");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Додаткові виплати");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Виплати", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Картки обліку");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Кадри", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Єдиний соціальний внесок");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Форма 1ДФ");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Аналітична розрахункова відомість");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Об\'єднана звітність");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Звіти");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Звіти", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Адміністрація");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Інші надбавки");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Надбавка пенсіонеру");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Надбавки за стаж");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Надбавка за классність");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Підрозділи");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Спецстаж");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Типи додаткових виплат");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Типи додаткових нарахувань");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Мінімальна зарплата");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Прожитковий мінімум");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Соціальна пільга");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Довідники", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27,
            treeNode28,
            treeNode29,
            treeNode30});
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Імпорт бази");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Налаштування");
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("Оновлення серверних об\'єктів");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("Сервіс", new System.Windows.Forms.TreeNode[] {
            treeNode32,
            treeNode33,
            treeNode34});
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Головне меню", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode10,
            treeNode12,
            treeNode18,
            treeNode31,
            treeNode35});
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("Вихід");
            this.tvMainMenu = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvMainMenu
            // 
            this.tvMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvMainMenu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvMainMenu.FullRowSelect = true;
            this.tvMainMenu.Location = new System.Drawing.Point(0, 0);
            this.tvMainMenu.Name = "tvMainMenu";
            treeNode1.Name = "Salary";
            treeNode1.Text = "Заробітна плата";
            treeNode2.Name = "Vocation";
            treeNode2.Text = "Відпускні";
            treeNode3.Name = "SickList";
            treeNode3.Text = "Лікарняні";
            treeNode4.Name = "LawContract";
            treeNode4.Text = "Договір ЦПХ";
            treeNode5.Name = "AddAccr";
            treeNode5.Text = "Додаткові нарахування";
            treeNode6.Name = "IncTax";
            treeNode6.Text = "Корегування прибуткового податку";
            treeNode7.Name = "Accrual";
            treeNode7.Text = "Нарахування";
            treeNode8.Name = "Payment";
            treeNode8.Text = "Виплати";
            treeNode9.Name = "AddPayment";
            treeNode9.Text = "Додаткові виплати";
            treeNode10.Name = "Рaying";
            treeNode10.Text = "Виплати";
            treeNode11.Name = "PersCard";
            treeNode11.Text = "Картки обліку";
            treeNode12.Name = "Personal";
            treeNode12.Text = "Кадри";
            treeNode13.Name = "ReportUST";
            treeNode13.Text = "Єдиний соціальний внесок";
            treeNode14.Name = "ReportDF";
            treeNode14.Text = "Форма 1ДФ";
            treeNode15.Name = "AnlCalcStatement";
            treeNode15.Text = "Аналітична розрахункова відомість";
            treeNode16.Name = "UnionReport";
            treeNode16.Text = "Об\'єднана звітність";
            treeNode17.Name = "Report";
            treeNode17.Text = "Звіти";
            treeNode18.Name = "Reports";
            treeNode18.Text = "Звіти";
            treeNode19.Name = "RefAdm";
            treeNode19.Text = "Адміністрація";
            treeNode20.Name = "RefOthAllwnc";
            treeNode20.Text = "Інші надбавки";
            treeNode21.Name = "RefPensAllwnc";
            treeNode21.Text = "Надбавка пенсіонеру";
            treeNode22.Name = "RefExpAllwnc";
            treeNode22.Text = "Надбавки за стаж";
            treeNode23.Name = "RefGradeAllwnc";
            treeNode23.Text = "Надбавка за классність";
            treeNode24.Name = "RefDep";
            treeNode24.Text = "Підрозділи";
            treeNode25.Name = "RefSpecExp";
            treeNode25.Text = "Спецстаж";
            treeNode26.Name = "RefTypeAddPayment";
            treeNode26.Text = "Типи додаткових виплат";
            treeNode27.Name = "RefTypeAddAccr";
            treeNode27.Text = "Типи додаткових нарахувань";
            treeNode28.Name = "RefMinSalary";
            treeNode28.Text = "Мінімальна зарплата";
            treeNode29.Name = "RefLivWage";
            treeNode29.Text = "Прожитковий мінімум";
            treeNode30.Name = "RefSocBenefit";
            treeNode30.Text = "Соціальна пільга";
            treeNode31.Name = "Ref";
            treeNode31.Text = "Довідники";
            treeNode32.Name = "ImportDB";
            treeNode32.Text = "Імпорт бази";
            treeNode33.Name = "Setup";
            treeNode33.Text = "Налаштування";
            treeNode34.Name = "UpdateDB";
            treeNode34.Text = "Оновлення серверних об\'єктів";
            treeNode35.Name = "Service";
            treeNode35.Text = "Сервіс";
            treeNode36.Name = "MainMenu";
            treeNode36.NodeFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode36.Text = "Головне меню";
            treeNode37.Name = "Close";
            treeNode37.NodeFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode37.Text = "Вихід";
            this.tvMainMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode36,
            treeNode37});
            this.tvMainMenu.Size = new System.Drawing.Size(508, 447);
            this.tvMainMenu.TabIndex = 0;
            this.tvMainMenu.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvMainMenu_NodeMouseDoubleClick);
            this.tvMainMenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvMainMenu_KeyDown);
            // 
            // fmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 447);
            this.Controls.Add(this.tvMainMenu);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "fmMainForm";
            this.Text = "coolbuh2.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fmMainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvMainMenu;
    }
}

