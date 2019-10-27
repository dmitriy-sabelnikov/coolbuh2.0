using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using EnumType;
using BLL;
using ComboBoxes;
using WinFormExtensions;
using DAL;

namespace WinUI.WinForms
{
    public partial class fmLawContractEdit : Form
    {
        private List<PersCard> _cards = null;                     // Кеш карточки работников
        private List<RefDep> _deps = null;                        // Кеш подразделений

        private cmbDepParam _cmbDepParams = new cmbDepParam();    //параметры комбика подразделений                      
        private cmbCardParam _cmbCardParams = new cmbCardParam(); //параметры комбика карточек работников 

        private CmbCard cmbCard = new CmbCard();
        private CmbDep cmbDep = new CmbDep();

        private PersCardRepository _repoPersCard = new PersCardRepository(SetupProgram.Connection);
        private RefDepRepository _repoDep = new RefDepRepository(SetupProgram.Connection);

        private int _id = 0;

        private bool CanSaveVocation()
        {
            if (tbFIO.Text == string.Empty)
            {
                tbFIO.Focus();
                return false;
            }
            if (tbDepCd.Text == string.Empty)
            {
                tbDepCd.Focus();
                return false;
            }
            return true;
        }
        //Инициализация календарей
        private void InitCmbCalendar()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, false);
            cmbCalendar.DataSource = monthNames;
        }
        private void InitCmbPayDate()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.VocationPayYear, false);
            cmbPayDate.DataSource = monthNames;
        }
        public LawContract GetData()
        {
            LawContract lawContract = new LawContract();
            lawContract.LawContract_Id = _id;
            lawContract.LawContract_PersCard_Id = _cmbCardParams.PersCard_Id;
            lawContract.LawContract_RefDep_Id = _cmbDepParams.RefDep_Id;
            lawContract.LawContract_Date = SalaryHelper.GetDateByIndex(cmbCalendar.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);
            lawContract.LawContract_PayDate = SalaryHelper.GetDateByIndex(cmbPayDate.SelectedIndex, DateTime.Today.Year - SetupProgram.LawContractPayYear, false);
            int resInt = 0;
            decimal resDec = 0;
            //Дни
            if (int.TryParse(tbDays.Text, out resInt))
                lawContract.LawContract_Days = resInt;
            //Сумма
            if (decimal.TryParse(tbSm.Text, out resDec))
                lawContract.LawContract_Sm = resDec;
            return lawContract;
        }
        public void SetData(LawContract lawContract)
        {
            _id = lawContract.LawContract_Id;
            cmbCalendar.SelectedIndex = SalaryHelper.GetIndexByDate(
                DateTime.Today.Year - SetupProgram.YearSalary, lawContract.LawContract_Date, false);

            cmbCard.ReadCombobox(lawContract.LawContract_PersCard_Id);
            cmbDep.ReadCombobox(lawContract.LawContract_RefDep_Id);

            cmbPayDate.SelectedIndex = SalaryHelper.GetIndexByDate(
                DateTime.Today.Year - SetupProgram.VocationPayYear, lawContract.LawContract_PayDate, false);

            tbDays.Text = lawContract.LawContract_Days.ToString();
            tbSm.Text = lawContract.LawContract_Sm.ToString("0.00");
        }
        public fmLawContractEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;

            string error;
            _cards = _repoPersCard.GetAllCards(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження довідника особових карток.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            _cmbCardParams.persCards = _cards;
            _cmbCardParams.tbFio = tbFIO;
            _cmbCardParams.tbTIN = tbTIN;
            cmbCard.AddCombobox(btnCard, _cmbCardParams);

            _deps = _repoDep.GetAllDeps(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження довідника підрозділів.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            _cmbDepParams.refDeps = _deps;
            _cmbDepParams.tbCd = tbDepCd;
            _cmbDepParams.tbNm = tbDepNm;
            cmbDep.AddCombobox(btnDep, _cmbDepParams);

            InitCmbCalendar();
            InitCmbPayDate();

            tbDepCd.NecessaryField();
            tbDepNm.NecessaryField(30);

            tbFIO.NecessaryField(30);

            tbDays.AddNumericField();
            tbSm.AddFloatField(10, 2);
        }

        private void fmLawContractEdit_Load(object sender, EventArgs e)
        {
            cmbCalendar.IsModifyField(() => { btnOk.Enabled = true; });
            cmbPayDate.IsModifyField(() => { btnOk.Enabled = true; });
            tbDepCd.IsModifyField(() => { btnOk.Enabled = true; });
            tbDepNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbFIO.IsModifyField(() => { btnOk.Enabled = true; });
            tbDays.IsModifyField(() => { btnOk.Enabled = true; });
            tbSm.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void fmLawContractEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveVocation()) return;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
