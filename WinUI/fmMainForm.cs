using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinUI.Helper;
using BLL;
using DAL;
using WinUI.WinForms;
using System.Reflection;
using Reports;
using Interfaces;

namespace WinUI
{
    public partial class fmMainForm : Form
    {
        //Настройка отображения дерева меню
        private void SetupStyleMainTreeView(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count != 0)
                    SetupStyleMainTreeView(node.Nodes);
                //Развернем первую ветку("Главное меню") по умолчанию
                if (node.Name == MainMenuName.MainMenu)
                {
                    node.Expand();
                }
                if (node.Name == MainMenuName.MainMenu || node.Name == MainMenuName.Close)
                {
                    node.NodeFont = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0); ;
                    continue;
                }
                if (node.Name == MainMenuName.Service || node.Name == MainMenuName.Ref || node.Name == MainMenuName.Personal ||
                    node.Name == MainMenuName.Accrual || node.Name == MainMenuName.Рaying || node.Name == MainMenuName.Reports)
                { 
                    node.NodeFont = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    continue;
                }
                node.NodeFont = new Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            }
        }
        //Вход в модуль
        private void EnterToModules(string nameModule)
        {
            if (nameModule == MainMenuName.Salary)
            {
                SetupProgram.MainMenuName = MainMenuName.Salary;
                fmSalary salary = new fmSalary(this);
                salary.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.Vocation)
            {
                SetupProgram.MainMenuName = MainMenuName.Vocation;
                fmVocation vocation = new fmVocation(this);
                vocation.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.SickList)
            {
                SetupProgram.MainMenuName = MainMenuName.SickList;
                fmSickList sickList = new fmSickList(this);
                sickList.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.LawContract)
            {
                SetupProgram.MainMenuName = MainMenuName.LawContract;
                fmLawContract lawContract = new fmLawContract(this);
                lawContract.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.AddAccr)
            {
                SetupProgram.MainMenuName = MainMenuName.AddAccr;
                fmAddAccr addAccr = new fmAddAccr(this);
                addAccr.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.IncTax)
            {
                SetupProgram.MainMenuName = MainMenuName.IncTax;
                fmIncTax incTax = new fmIncTax(this);
                incTax.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if(nameModule == MainMenuName.Payment)
            {
                SetupProgram.MainMenuName = MainMenuName.Payment;
                fmPayment payment = new fmPayment(this);
                payment.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if(nameModule == MainMenuName.AddPayment)
            {
                SetupProgram.MainMenuName = MainMenuName.AddPayment;
                fmAddPayment addPayment = new fmAddPayment(this);
                addPayment.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.PersCard)
            {
                SetupProgram.MainMenuName = MainMenuName.PersCard;
                fmPersCard persCard = new fmPersCard(this);
                persCard.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.RefDep)
            {
                SetupProgram.MainMenuName = MainMenuName.RefDep;
                fmRefDep refDep = new fmRefDep(this);
                refDep.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.RefAdm)
            {
                SetupProgram.MainMenuName = MainMenuName.RefAdm;
                fmRefAdm refAdm = new fmRefAdm(this);
                refAdm.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.RefExpAllwnc)
            {
                SetupProgram.MainMenuName = MainMenuName.RefExpAllwnc;
                fmRefExpAllwnc refExpAllwnc = new fmRefExpAllwnc(this);
                refExpAllwnc.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.RefSpecExp)
            {
                SetupProgram.MainMenuName = MainMenuName.RefSpecExp;
                fmRefSpecExp refSpecExp = new fmRefSpecExp(this);
                refSpecExp.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.RefPensAllwnc)
            {
                SetupProgram.MainMenuName = MainMenuName.RefPensAllwnc;
                fmRefPensAllwnc refPensAllwnc = new fmRefPensAllwnc(this);
                refPensAllwnc.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.RefGradeAllwnc)
            {
                SetupProgram.MainMenuName = MainMenuName.RefGradeAllwnc;
                fmRefGradeAllwnc refGradeExp = new fmRefGradeAllwnc(this);
                refGradeExp.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.RefOthAllwnc)
            {
                SetupProgram.MainMenuName = MainMenuName.RefOthAllwnc;
                fmRefOthAllwnc refOthExp = new fmRefOthAllwnc(this);
                refOthExp.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.RefTypeAddAccr)
            {
                SetupProgram.MainMenuName = MainMenuName.RefTypeAddAccr;
                fmRefTypeAddAccr refTypeAddAccr = new fmRefTypeAddAccr(this);
                refTypeAddAccr.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.RefTypeAddPayment)
            {
                SetupProgram.MainMenuName = MainMenuName.RefTypeAddPayment;
                fmRefTypeAddPayment refTypeAddPayment = new fmRefTypeAddPayment(this);
                refTypeAddPayment.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.RefMinSalary)
            {
                SetupProgram.MainMenuName = MainMenuName.RefMinSalary;
                fmRefMinSalary refMinSalary = new fmRefMinSalary(this);
                refMinSalary.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.RefLivWage)
            {
                SetupProgram.MainMenuName = MainMenuName.RefLivWage;
                fmRefLivWage refLivWage = new fmRefLivWage(this);
                refLivWage.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.RefSocBenefit)
            {
                SetupProgram.MainMenuName = MainMenuName.RefSocBenefit;
                fmRefSocBenefit refSocBenefit = new fmRefSocBenefit(this);
                refSocBenefit.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.ReportUST)
            {
                SetupProgram.MainMenuName = MainMenuName.ReportUST;
                fmUSTCt ustCt = new fmUSTCt(this);
                ustCt.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.ReportDF)
            {
                SetupProgram.MainMenuName = MainMenuName.ReportDF;
                fmDFCt dfCt = new fmDFCt(this);
                dfCt.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.AnlCalcStatement)
            {
                SetupProgram.MainMenuName = MainMenuName.AnlCalcStatement;
                fmAnlCalcStatement anlCalcStatement = new fmAnlCalcStatement(this);
                anlCalcStatement.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.UnionReport)
            {
                SetupProgram.MainMenuName = MainMenuName.UnionReport;
                fmUnionReportCt unionReportCt = new fmUnionReportCt(this);
                unionReportCt.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.Report)
            {
                SetupProgram.MainMenuName = MainMenuName.Report;
                fmReport report = new fmReport(this);
                report.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.ImportDB)
            {
                bool bRet = false;
                SetupProgram.MainMenuName = MainMenuName.ImportDB;
                fmPassword password = new fmPassword();
                if(password.ShowDialog() == DialogResult.OK)
                {
                    Password verifyPassword = new Password(password.GetPassword());
                    bRet = verifyPassword.VerifyPassword(EnumType.EnumPassword.Import);
                    if (!bRet)
                    {
                        MessageBox.Show("Не корректний пароль!", "Увага");
                    }                    
                }
                bRet = bRet && Service.ImportDB(SetupProgram.PathToDBFFile, SetupProgram.Connection);
                bRet = bRet && Service.RunSqlSript(SetupProgram.PathToSQLFile, SetupProgram.Connection);
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if(nameModule == MainMenuName.Setup)
            {
                SetupProgram.MainMenuName = MainMenuName.Setup;
                fmSetup setup = new fmSetup(this);
                setup.ShowDialog();
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if(nameModule == MainMenuName.UpdateDB)
            {
                SetupProgram.MainMenuName = MainMenuName.UpdateDB;
                Service.UpdateServerObject(SetupProgram.Connection);
                SetupProgram.MainMenuName = MainMenuName.MainMenu;
            }
            else if (nameModule == MainMenuName.Close)
            {
                Exit();
            }            
        }
        //Выход
        private void Exit()
        {
            if (MessageBox.Show("Ви впевнені, що бажаєте вийти?", "Вихід", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Close();
        }
        //Событие нажатия клавиши Enter на главное дерево
        private void EventEnterNodeTreeView()
        {
            TreeNode selectedNode = tvMainMenu.SelectedNode;
            if (selectedNode.Nodes.Count != 0)
            {
                // Свернуть/развернуть родительские узлы
                if (selectedNode.IsExpanded)
                    selectedNode.Collapse();
                else
                    selectedNode.Expand();
            }
            else
            {
                // Вход в модуль
                EnterToModules(selectedNode.Name);
            }
        }

        private void tvMainMenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           //Разворачивание/сворачивание ветки меню обрабатывается автоматически при клике мышью
           TreeNode selectedNode = e.Node;
           if (selectedNode.Nodes.Count == 0)
           {
               EventEnterNodeTreeView();
           }
        }
        public fmMainForm()
        {
            InitializeComponent();
            Type frmType = this.GetType();
            PropertyInfo piFrm = frmType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            piFrm.SetValue(this, true, null);

            Type trviewType = tvMainMenu.GetType();
            PropertyInfo piTv = frmType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            piTv.SetValue(this, true, null);
        }

        private void fmMainForm_Load(object sender, EventArgs e)
        {
            SetupStyleMainTreeView(tvMainMenu.Nodes);
            this.Text = SetupProgram.CmpNm;
        }

        private void tvMainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EventEnterNodeTreeView();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Exit();
            }
        }
    }
}
