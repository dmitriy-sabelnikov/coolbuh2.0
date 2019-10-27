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
using BLL;
using WinFormExtensions;
using EnumType;
using ComboBoxes;
using DAL;


namespace WinUI.WinForms
{
    public partial class fmSickListEdit : Form
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

        private bool CanSaveSickList()
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
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.SickListPayYear, false);
            cmbPayDate.DataSource = monthNames;
        }
        //Итоговая сумма
        private decimal GetResultSm()
        {
            decimal smEntprs = 0;
            decimal smSocInsrnc = 0;
            decimal.TryParse(tbSmEntprs.Text, out smEntprs);
            decimal.TryParse(tbSmSocInsrnc.Text, out smSocInsrnc);
            return smSocInsrnc + smEntprs;
        }

        private int GetDaysTmpDis()
        {
            int daysEntprs = 0;
            int daysSocInsrnc = 0;
            int.TryParse(tbDaysEntprs.Text, out daysEntprs);
            int.TryParse(tbDaysSocInsrnc.Text, out daysSocInsrnc);
            return daysEntprs + daysSocInsrnc;
        }

        public SickList GetData()
        {
            SickList sickList = new SickList();
            sickList.SickList_Id = _id;
            sickList.SickList_PersCard_Id = _cmbCardParams.PersCard_Id;
            sickList.SickList_RefDep_Id = _cmbDepParams.RefDep_Id;
            sickList.SickList_Date = SalaryHelper.GetDateByIndex(cmbCalendar.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);
            sickList.SickList_PayDate = SalaryHelper.GetDateByIndex(cmbPayDate.SelectedIndex, DateTime.Today.Year - SetupProgram.SickListPayYear, false);
            int resInt = 0;
            decimal resDec = 0;
            //Дни, оплаченные предприятием
            if (int.TryParse(tbDaysEntprs.Text, out resInt))
                sickList.SickList_DaysEntprs = resInt;
            //Сумма, оплаченная предприятием
            if (decimal.TryParse(tbSmEntprs.Text, out resDec))
                sickList.SickList_SmEntprs = resDec;
            //Дни, оплаченные соцстахом
            if (int.TryParse(tbDaysSocInsrnc.Text, out resInt))
                sickList.SickList_DaysSocInsrnc = resInt;
            //Сумма, оплаченная соцстахом
            if (decimal.TryParse(tbSmSocInsrnc.Text, out resDec))
                sickList.SickList_SmSocInsrnc = resDec;
            //Дни временной нетрудоспособности
            if (int.TryParse(tbDaysTmpDis.Text, out resInt))
                sickList.SickList_DaysTmpDis = resInt;
            //Итоговая сумма
            if (decimal.TryParse(tbResSm.Text, out resDec))
                sickList.SickList_ResSm = resDec;
            return sickList;
        }
        public void SetData(SickList sickList)
        {
            _id = sickList.SickList_Id;
            cmbCalendar.SelectedIndex = SalaryHelper.GetIndexByDate(
                DateTime.Today.Year - SetupProgram.YearSalary, sickList.SickList_Date, false);

            cmbCard.ReadCombobox(sickList.SickList_PersCard_Id);
            cmbDep.ReadCombobox(sickList.SickList_RefDep_Id);

            cmbPayDate.SelectedIndex = SalaryHelper.GetIndexByDate(
                DateTime.Today.Year - SetupProgram.VocationPayYear, sickList.SickList_PayDate, false);

            tbDaysEntprs.Text = sickList.SickList_DaysEntprs.ToString();
            tbSmEntprs.Text = sickList.SickList_SmEntprs.ToString("0.00");

            tbDaysSocInsrnc.Text = sickList.SickList_DaysSocInsrnc.ToString();
            tbSmSocInsrnc.Text = sickList.SickList_SmSocInsrnc.ToString("0.00");

            tbDaysTmpDis.Text = sickList.SickList_DaysTmpDis.ToString("0.00");

            tbResSm.Text = sickList.SickList_ResSm.ToString("0.00");
        }
        public fmSickListEdit(EnumFormMode mode, string caption)
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

            tbDaysEntprs.AddNumericField();
            tbSmEntprs.AddFloatField(10, 2);

            tbDaysSocInsrnc.AddNumericField();
            tbSmSocInsrnc.AddFloatField(10, 2);

            tbResSm.AddFloatField(10, 2);
        }

        private void fmSickListEdit_Load(object sender, EventArgs e)
        {
            cmbCalendar.IsModifyField(() => { btnOk.Enabled = true; });
            cmbPayDate.IsModifyField(() => { btnOk.Enabled = true; });
            tbDepCd.IsModifyField(() => { btnOk.Enabled = true; });
            tbDepNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbFIO.IsModifyField(() => { btnOk.Enabled = true; });
            tbDaysEntprs.IsModifyField(() => { btnOk.Enabled = true; });
            tbSmEntprs.IsModifyField(() => { btnOk.Enabled = true; });
            tbDaysSocInsrnc.IsModifyField(() => { btnOk.Enabled = true; });
            tbSmSocInsrnc.IsModifyField(() => { btnOk.Enabled = true; });
            tbResSm.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveSickList()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmSickListEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }

        private void tbSmEntprs_TextChanged(object sender, EventArgs e)
        {
            tbResSm.Text = GetResultSm().ToString("0.00");
        }

        private void tbSmSocInsrnc_TextChanged(object sender, EventArgs e)
        {
            tbResSm.Text = GetResultSm().ToString("0.00");
        }

        private void tbDaysEntprs_TextChanged(object sender, EventArgs e)
        {
            tbDaysTmpDis.Text = GetDaysTmpDis().ToString();
        }

        private void tbDaysSocInsrnc_TextChanged(object sender, EventArgs e)
        {
            tbDaysTmpDis.Text = GetDaysTmpDis().ToString();
        }
    }
}
