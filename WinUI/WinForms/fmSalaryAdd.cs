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
using WinUI.Helper;
using ComboBoxes;
using BLL;
using WinFormExtensions;
using EnumType;
using DAL;

namespace WinUI.WinForms
{
    public partial class fmSalaryAdd : Form
    {
        private cmbDepParam _cmbDepParams = new cmbDepParam();                           //параметры комбика подразделений                      
        private cmbCardParam _cmbCardParams = new cmbCardParam();                        //параметры комбика карточек работников 
        private cmbPensAllwncParam _cmbPensAllwncParams = new cmbPensAllwncParam();      //параметры комбика надбавка пенсионеру
        private cmbExpAllwncParam _cmbExpAllwncParams = new cmbExpAllwncParam();         //параметры комбика надбавка за стаж 
        private cmbGradeAllwncParam _cmbGradeAllwncParams = new cmbGradeAllwncParam();   //параметры комбика надбавка за классность
        private cmbOthAllwncParam _cmbOthAllwncParams = new cmbOthAllwncParam();         //параметры комбика другие надбавки

        private PersCardRepository _repoPersCard = new PersCardRepository(SetupProgram.Connection);
        private RefDepRepository _repoDep = new RefDepRepository(SetupProgram.Connection);
        private RefPensAllwncRepository _repoPensAllwnc = new RefPensAllwncRepository(SetupProgram.Connection);
        private RefExpAllwncRepository _repoExpAllwnc = new RefExpAllwncRepository(SetupProgram.Connection);
        private RefGradeAllwncRepository _repoGradeAllwnc = new RefGradeAllwncRepository(SetupProgram.Connection);
        private RefOthAllwncRepository _repoOthAllwnc = new RefOthAllwncRepository(SetupProgram.Connection);

        private List<PersCard> _cards = null;                     // Кеш карточки работников
        private List<RefDep> _deps = null;                        // Кеш подразделений
        private List<RefPensAllwnc> _pensAllwncs = null;          // Кеш надбавка пенсионеру
        private List<RefExpAllwnc> _expAllwncs = null;            // Кеш надбавка за стаж 
        private List<RefGradeAllwnc> _gradeAllwncs = null;        // Кеш надбавка за классность
        private List<RefOthAllwnc> _othAllwncs = null;            // Кеш другие надбавки

        private CmbCard cmbCard = new CmbCard();                  
        private CmbDep cmbDep = new CmbDep();
        private CmbPensAllwnc cmbPensAllwnc = new CmbPensAllwnc();
        private CmbExpAllwnc cmbExpAllwnc  = new CmbExpAllwnc();
        private CmbGradeAllwnc cmbGradeAllwnc = new CmbGradeAllwnc();
        private CmbOthAllwnc cmbOthAllwnc = new CmbOthAllwnc();

        StringBuilder clcResultKTUSm = new StringBuilder();
        StringBuilder clcResultExpSm = new StringBuilder();
        StringBuilder clcResultSalarySm = new StringBuilder();

        private int priorDepId = 0;
        private int priorCardId = 0;

        private int _id = 0;
        //Можно ли сохранять зарплату
        private bool CanSaveSalary()
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
            if (tbDays.Text == string.Empty)
            {
                tbDays.Focus();
                return false;
            }

            if (tbHours.Text == string.Empty)
            {
                tbHours.Focus();
                return false;
            }
            if (tbBaseSm.Text == string.Empty)
            {
                tbBaseSm.Focus();
                return false;
            }
            return true;
        }
        //Получить сумму КТУ
        private double GetSmKTUSm()
        {
            double ktu = 0;
            double baseSm = 0;
            double totalSm = 0;
            double totalPct = 0;

            double res = 0;
                
            double.TryParse(tbKTU.Text, out ktu);
            double.TryParse(tbBaseSm.Text, out baseSm);
            if(double.TryParse(tbPensPct.Text, out res))
            {
                totalPct += res;
            }
            if (double.TryParse(tbGradePct.Text, out res))
            {
                totalPct += res;
            }
            if (double.TryParse(tbExpPct.Text, out res))
            {
                totalPct += res;
            }
            if (double.TryParse(tbOthPct.Text, out res))
            {
                totalPct += res;
            }

            if (double.TryParse(tbPensSm.Text, out res))
            {
                totalSm += res;
            }
            if (double.TryParse(tbGradeSm.Text, out res))
            {
                totalSm += res;
            }
            if (double.TryParse(tbExpSm.Text, out res))
            {
                totalSm += res;
            }
            if (double.TryParse(tbOthSm.Text, out res))
            {
                totalSm += res;
            }
            return SalaryHelper.GetKTUSm(ktu, baseSm, totalSm, totalPct, ref clcResultKTUSm);    
        }

        //Расчет суммы процента от исходной суммы
        private void CalcSmByPct(TextBox tbPct, TextBox tbSm, TextBox tbBaseSm)
        {
            if (tbPct == null || tbSm == null || tbBaseSm == null)
                return;

            double pct;
            double baseSm;
            if (double.TryParse(tbPct.Text, out pct)
                && double.TryParse(tbBaseSm.Text, out baseSm))
            {
                tbSm.Text = SalaryHelper.GetSmByPct(baseSm, pct).ToString("0.00");
            }
        }
        //Получить итоговую сумму
        private double GetResultSm()
        {
            double ktu;
            double.TryParse(tbKTU.Text, out ktu);
            double baseSm = 0;
            double.TryParse(tbBaseSm.Text, out baseSm);

            double allwncSm = 0;
            double allwncPct = 0;
            double res = 0;
            if (double.TryParse(tbPensSm.Text, out res))
                allwncSm += res;
            if (double.TryParse(tbExpSm.Text, out res))
                allwncSm += res;
            if (double.TryParse(tbGradeSm.Text, out res))
                allwncSm += res;
            if (double.TryParse(tbOthSm.Text, out res))
                allwncSm += res;

            if (double.TryParse(tbPensPct.Text, out res))
                allwncPct += res;
            if (double.TryParse(tbExpPct.Text, out res))
                allwncPct += res;
            if (double.TryParse(tbGradePct.Text, out res))
                allwncPct += res;
            if (double.TryParse(tbOthPct.Text, out res))
                allwncPct += res;

            return SalaryHelper.GetResultSmSalary(ktu, baseSm, allwncSm, allwncPct, ref clcResultSalarySm);
        }
        //Расчет суммы надбавки за стаж
        private void CalcExpSm()
        {
            double baseSm = 0;
            double allwncSm = 0;
            double sm = 0;
            double pct = 0;
            double.TryParse(tbBaseSm.Text, out baseSm);
            if (double.TryParse(tbPensSm.Text, out sm))
                allwncSm += sm;
            if (double.TryParse(tbGradeSm.Text, out sm))
                allwncSm += sm;
            //if (double.TryParse(tbOthSm.Text, out sm))
            //    allwncSm += sm;
            double.TryParse(tbExpPct.Text, out pct);
            tbExpSm.Text = SalaryHelper.GetExpSmByPct(baseSm,allwncSm,pct, ref clcResultExpSm) .ToString("0.00");
        }
        //Расчет суммы другие надбавки
        private void CalcOthSm()
        {
            double resSm = 0;
            double sm = 0;
            double pct = 0;
            if (double.TryParse(tbBaseSm.Text, out sm))
                resSm += sm;
            if (double.TryParse(tbPensSm.Text, out sm))
                resSm += sm;
            if (double.TryParse(tbGradeSm.Text, out sm))
                resSm += sm;
            double.TryParse(tbOthPct.Text, out pct);
            tbOthSm.Text = Math.Round(resSm * pct / 100.00, 2).ToString("0.00");
        }
        //Инициализация календаря
        private void InitCmbCalendar()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, false);
            cmbCalendar.DataSource = monthNames;
        }
        //получить индекс комбика календаря
        private int GetCmdIndexCalendar(Salary salary)
        {
            return SalaryHelper.GetIndexByDate(DateTime.Today.Year - SetupProgram.YearSalary, salary.Salary_Date, false);
        }
        //Получить дату по выбранному индексу календаря
        private DateTime GetDateByIndexCalendar(int selectedIndex)
        {
            int year = SalaryHelper.GetYearByIndex(DateTime.Today.Year - SetupProgram.YearSalary, selectedIndex, false);
            int month = SalaryHelper.GetMonthByIndex(selectedIndex, false);
            return DateTime.MinValue.AddYears(year - 1).AddMonths(month-1);
        }
        //Видимость элементов контроля надбавки за классность
        private void SetVisibleCmbGradeAllwnc()
        {
            PersCard card = _cards.FirstOrDefault(rec => rec.PersCard_Id == _cmbCardParams.PersCard_Id);
            //Работник не выбран
            if (card == null)
            {
                tbGradePct.Enabled = false;
                tbGradeCd.Enabled = false;
                tbGradeNm.Enabled = false;
                tbGradeSm.Enabled = false;
                btnGrade.Enabled = false;
            }
            else
            {
                tbGradePct.Enabled = true;
                tbGradeCd.Enabled = true;
                tbGradeNm.Enabled = true;
                tbGradeSm.Enabled = true;
                btnGrade.Enabled = true;
            }
        }
        //Формирование датасета надбавки за классность
        private void SetDataSetCmbGradeAllwnc()
        {
            PersCard card = _cards.FirstOrDefault(rec => rec.PersCard_Id == _cmbCardParams.PersCard_Id);
            //Работник не выбран
            if (card == null)
            {
                _cmbGradeAllwncParams.gradeAllwncs = _gradeAllwncs;
                return;
            }
            else
            {
                List<RefGradeAllwnc> allwncs = _gradeAllwncs.Where(
                rec => (rec.RefGradeAllwnc_RefDep_Id == _cmbDepParams.RefDep_Id || rec.RefGradeAllwnc_RefDep_Id == 0)
                && (rec.RefGradeAllwnc_Grade == card.PersCard_Grade || rec.RefGradeAllwnc_Grade == 0))
                .ToList();
                _cmbGradeAllwncParams.gradeAllwncs = allwncs;
            }
        }
        //Зачитка комбика надбавки за классность
        private void SetDataGradeAllwnc()
        {
            PersCard card = _cards.FirstOrDefault(rec => rec.PersCard_Id == _cmbCardParams.PersCard_Id);
            //Работник не выбран
            if (card == null)
            {
                cmbGradeAllwnc.ReadCombobox(0);
                tbGradeSm.Text = string.Empty;
                return;
            }

            if (_cmbGradeAllwncParams.gradeAllwncs.Count == 1)
            {
                cmbGradeAllwnc.ReadCombobox(_cmbGradeAllwncParams.gradeAllwncs[0].RefGradeAllwnc_Id);
            }
            else
            {
                cmbGradeAllwnc.ReadCombobox(0);
                tbGradeSm.Text = string.Empty;
            }
        }
        //Видимость элементов контроля надбавки пенсионеру
        private void SetVisibleCmbPensAllwnc()
        {
            PersCard card = _cards.FirstOrDefault(rec => rec.PersCard_Id == _cmbCardParams.PersCard_Id);
            //Работник не выбран
            if (card == null)
            {
                tbPensPct.Enabled = false;
                tbPensCd.Enabled = false;
                tbPensNm.Enabled = false;
                tbPensSm.Enabled = false;
                btnPens.Enabled = false;
                return;
            }

            DateTime clcDate = GetDateByIndexCalendar(cmbCalendar.SelectedIndex);
            if (SalaryHelper.IsPensWorker(clcDate, card.PersCard_DOP))
            {
                tbPensPct.Enabled = true;
                tbPensCd.Enabled = true;
                tbPensNm.Enabled = true;
                tbPensSm.Enabled = true;
                btnPens.Enabled = true;
            }
            else
            {
                tbPensPct.Enabled = false;
                tbPensCd.Enabled = false;
                tbPensNm.Enabled = false;
                tbPensSm.Enabled = false;
                btnPens.Enabled = false;
            }
        }
        //Зачитка комбика надбавки пенсионеру
        private void SetDataPensAllwnc()
        {
            PersCard card = _cards.FirstOrDefault(rec => rec.PersCard_Id == _cmbCardParams.PersCard_Id);
            //Работник не выбран
            if (card == null)
            {
                cmbPensAllwnc.ReadCombobox(0);
                tbPensSm.Text = string.Empty;
                return;
            }
            DateTime clcDate = GetDateByIndexCalendar(cmbCalendar.SelectedIndex);
            if (!SalaryHelper.IsPensWorker(clcDate, card.PersCard_DOP))
            {
                cmbPensAllwnc.ReadCombobox(0);
                tbPensSm.Text = string.Empty;
                return;
            }

            if (_cmbPensAllwncParams.pensAllwncs.Count > 1)
            {
                cmbPensAllwnc.ReadCombobox(0);
                tbPensSm.Text = string.Empty;
                return;
            }

            cmbPensAllwnc.ReadCombobox(_cmbPensAllwncParams.pensAllwncs[0].RefPensAllwnc_Id);
        }
        //Видимость элементов контроля надбавки за стаж
        private void SetVisibleCmbExpAllwnc()
        {
            PersCard card = _cards.FirstOrDefault(rec => rec.PersCard_Id == _cmbCardParams.PersCard_Id);
            //Работник не выбран
            if (card == null)
            {
                tbExpPct.Enabled = false;
                tbExpCd.Enabled = false;
                tbExpNm.Enabled = false;
                tbExpSm.Enabled = false;
                btnExp.Enabled = false;
            }
            else
            {
                tbExpPct.Enabled = true;
                tbExpCd.Enabled = true;
                tbExpNm.Enabled = true;
                tbExpSm.Enabled = true;
                btnExp.Enabled = true;
            }
        }

        //Формирование датасета надбавки за классность
        private void SetDataSetCmbExpAllwnc()
        {
            PersCard card = _cards.FirstOrDefault(rec => rec.PersCard_Id == _cmbCardParams.PersCard_Id);
            //Работник не выбран
            if (card == null)
            {
                _cmbExpAllwncParams.expAllwncs = _expAllwncs;
                return;
            }
            else
            {
                List<RefExpAllwnc> exps = _expAllwncs.Where(
                rec => (rec.RefExpAllwnc_Year == card.PersCard_Exp))
                .ToList();
                _cmbExpAllwncParams.expAllwncs = exps;
            }
        }
        //Зачитка комбика надбавки за стаж
        private void SetDataExpAllwnc()
        {
            PersCard card = _cards.FirstOrDefault(rec => rec.PersCard_Id == _cmbCardParams.PersCard_Id);
            if (card == null)
            {
                cmbExpAllwnc.ReadCombobox(0);
                tbExpSm.Text = string.Empty;
                return;
            }
            _cmbExpAllwncParams.RefDep_MechId = _cmbDepParams.RefDep_Id;

            RefExpAllwnc allwmc = _cmbExpAllwncParams.expAllwncs.FirstOrDefault(
                rec => rec.RefExpAllwnc_Year == card.PersCard_Exp
                );

            if (allwmc != null)
            {
                cmbExpAllwnc.ReadCombobox(allwmc.RefExpAllwnc_Id);
            }
            else
            {
                cmbExpAllwnc.ReadCombobox(0);
                tbExpSm.Text = string.Empty;
            }
        }
        //Видимость элементов контроля надбавки другие
        private void SetVisibleCmbOthAllwnc()
        {
            PersCard card = _cards.FirstOrDefault(rec => rec.PersCard_Id == _cmbCardParams.PersCard_Id);
            //Работник не выбран
            if (card == null)
            {
                tbOthPct.Enabled = false;
                tbOthCd.Enabled = false;
                tbOthNm.Enabled = false;
                tbOthSm.Enabled = false;
                btnOth.Enabled = false;
            }
            else
            {
                tbOthPct.Enabled = true;
                tbOthCd.Enabled = true;
                tbOthNm.Enabled = true;
                tbOthSm.Enabled = true;
                btnOth.Enabled = true;
            }
        }
        //Зачитка комбика надбавки другие
        private void SetDataOthAllwnc()
        {
            cmbOthAllwnc.ReadCombobox(0);
            tbOthSm.Text = string.Empty;
        }

        public void SetData(Salary salary)
        {
            _id = salary.Salary_Id;
            priorDepId = salary.Salary_RefDep_Id;
            priorCardId = salary.Salary_PersCard_Id;

            cmbCalendar.SelectedIndex = GetCmdIndexCalendar(salary);

            cmbCard.ReadCombobox(salary.Salary_PersCard_Id);
            cmbDep.ReadCombobox(salary.Salary_RefDep_Id);
            cmbPensAllwnc.ReadCombobox(salary.Salary_PensId);
            cmbGradeAllwnc.ReadCombobox(salary.Salary_GradeId);
            cmbExpAllwnc.ReadCombobox(salary.Salary_ExpId);
            cmbOthAllwnc.ReadCombobox(salary.Salary_OthId);

            tbDays.Text = salary.Salary_Days.ToString();
            tbHours.Text = salary.Salary_Hours.ToString("0.00");
            tbKTU.Text = salary.Salary_KTU.ToString("0.00");
            tbKTUSm.Text = salary.Salary_KTUSm.ToString("0.00");

            tbBaseSm.Text = salary.Salary_BaseSm.ToString("0.00");
            tbPensSm.Text = salary.Salary_PensSm.ToString("0.00");
            tbExpSm.Text = salary.Salary_ExpSm.ToString("0.00");
            tbGradeSm.Text = salary.Salary_GradeSm.ToString("0.00");
            tbOthSm.Text = salary.Salary_OthSm.ToString("0.00");
            tbKTUSm.Text = salary.Salary_KTUSm.ToString("0.00");
            tbResultSm.Text = salary.Salary_ResSm.ToString("0.00");
        }
        public Salary GetData()
        {
            decimal resDec = 0;
            int resInt = 0;

            Salary salary = new Salary();

            salary.Salary_Id = _id;
            salary.Salary_PersCard_Id = _cmbCardParams.PersCard_Id;
            salary.Salary_RefDep_Id = _cmbDepParams.RefDep_Id;
            salary.Salary_Date = GetDateByIndexCalendar(cmbCalendar.SelectedIndex);
            //Дни
            if (int.TryParse(tbDays.Text, out resInt))
                salary.Salary_Days = resInt;
            //Часы
            if (decimal.TryParse(tbHours.Text, out resDec))
                salary.Salary_Hours = resDec;
            //Основная зарплата
            if (decimal.TryParse(tbBaseSm.Text, out resDec))
                salary.Salary_BaseSm = resDec;
            //КТУ
            if (decimal.TryParse(tbKTU.Text, out resDec))
                salary.Salary_KTU = resDec;
            //Сумма согласно КТУ
            if (decimal.TryParse(tbKTUSm.Text, out resDec))
                salary.Salary_KTUSm = resDec;
            //Надбавка пенсионеру
            salary.Salary_PensId = _cmbPensAllwncParams.RefPensAllwnc_Id;
            if (decimal.TryParse(tbPensPct.Text, out resDec))
                salary.Salary_PensPct = resDec;
            if (decimal.TryParse(tbPensSm.Text, out resDec))
                salary.Salary_PensSm = resDec;
            //Надбавка за стаж
            salary.Salary_ExpId = _cmbExpAllwncParams.RefExpAllwnc_Id;
            if (decimal.TryParse(tbExpPct.Text, out resDec))
                salary.Salary_ExpPct = resDec;
            if (decimal.TryParse(tbExpSm.Text, out resDec))
                salary.Salary_ExpSm = resDec;
            //Надбавка за классность
            salary.Salary_GradeId = _cmbGradeAllwncParams.RefGradeAllwnc_Id;
            if (decimal.TryParse(tbGradePct.Text, out resDec))
                salary.Salary_GradePct = resDec;
            if (decimal.TryParse(tbGradeSm.Text, out resDec))
                salary.Salary_GradeSm = resDec;
            //Другая надбавка
            salary.Salary_OthId = _cmbOthAllwncParams.RefOthAllwnc_Id;
            if (decimal.TryParse(tbOthPct.Text, out resDec))
                salary.Salary_OthPct = resDec;
            if (decimal.TryParse(tbOthSm.Text, out resDec))
                salary.Salary_OthSm = resDec;
            //КТУ и сумма согласно КТУ
            if (decimal.TryParse(tbKTU.Text, out resDec))
                salary.Salary_KTU = resDec;
            if (decimal.TryParse(tbKTUSm.Text, out resDec))
                salary.Salary_KTUSm = resDec;
            if (decimal.TryParse(tbResultSm.Text, out resDec))
                salary.Salary_ResSm = resDec;
            return salary;
        }

        public fmSalaryAdd(EnumFormMode mode, string caption)
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
            _cmbCardParams.tbExp = tbExp;
            _cmbCardParams.tbGrade = tbGrade;
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
            //Надбавка пенсионерам
            _pensAllwncs = _repoPensAllwnc.GetAllPensAllwnc(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження довідника доплат пенсіонеру.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            _pensAllwncs = _pensAllwncs.Where(
                rec => (rec.RefPensAllwnc_Flg & (int)EnumPensAllwnc_Flg.ALLWNC_NOTUSE) == 0)
                .ToList();
            _cmbPensAllwncParams.tbCd = tbPensCd;
            _cmbPensAllwncParams.tbNm = tbPensNm;
            _cmbPensAllwncParams.tbPct = tbPensPct;
            _cmbPensAllwncParams.pensAllwncs = _pensAllwncs;
            cmbPensAllwnc.AddCombobox(btnPens, _cmbPensAllwncParams);
            //Надбавка за классность
            _gradeAllwncs = _repoGradeAllwnc.GetAllGradeAllwnc(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження довідника доплат за класність.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            _gradeAllwncs = _gradeAllwncs.Where(
                rec => (rec.RefGradeAllwnc_Flg & (int)EnumGradeAllwnc_Flg.ALLWNC_NOTUSE) == 0)
                .ToList();
            _cmbGradeAllwncParams.tbCd  = tbGradeCd;
            _cmbGradeAllwncParams.tbNm  = tbGradeNm;
            _cmbGradeAllwncParams.tbPct = tbGradePct;
            _cmbGradeAllwncParams.gradeAllwncs = _gradeAllwncs;
            cmbGradeAllwnc.AddCombobox(btnGrade, _cmbGradeAllwncParams);
            //Надбавка за стаж
            _expAllwncs = _repoExpAllwnc.GetAllExpAllwnc(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження довідника доплат за стаж.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            _expAllwncs = _expAllwncs.Where(
                rec => (rec.RefExpAllwnc_Flg & (int)EnumExpAllwnc_Flg.ALLWNC_NOTUSE) == 0)
                .ToList();
            _cmbExpAllwncParams.tbCd = tbExpCd;
            _cmbExpAllwncParams.tbNm = tbExpNm;
            _cmbExpAllwncParams.tbPct = tbExpPct;
            _cmbExpAllwncParams.expAllwncs = _expAllwncs;
            cmbExpAllwnc.AddCombobox(btnExp, _cmbExpAllwncParams);
            //Другие надбавки
            _othAllwncs = _repoOthAllwnc.GetAllOthAllwnc(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження довідника інші доплати .\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            _othAllwncs = _othAllwncs.Where(
                rec => (rec.RefOthAllwnc_Flg & (int)EnumOthAllwnc_Flg.ALLWNC_NOTUSE) == 0)
                .ToList();
            _cmbOthAllwncParams.tbCd = tbOthCd;
            _cmbOthAllwncParams.tbNm = tbOthNm;
            _cmbOthAllwncParams.tbPct = tbOthPct;
            _cmbOthAllwncParams.othAllwncs = _othAllwncs;
            cmbOthAllwnc.AddCombobox(btnOth, _cmbOthAllwncParams);

            InitCmbCalendar();

            tbDepCd.NecessaryField();
            tbDepNm.NecessaryField(30);
            tbDays.NecessaryField();
            tbHours.NecessaryField();
            tbFIO.NecessaryField(30);
            tbBaseSm.NecessaryField();

            tbBaseSm.AddFloatField(10, 2);

            tbPensSm.AddFloatField(10, 2);
            tbExpSm.AddFloatField(10, 2);
            tbGradeSm.AddFloatField(10, 2);
            tbOthSm.AddFloatField(10, 2);

            tbKTU.AddFloatField(5, 2);
            tbGrade.AddNumericField();
            tbKTUSm.AddFloatField(10, 2);
            tbDays.AddNumericField();
            tbHours.AddFloatField(5, 2);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveSalary()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void fmSalaryAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }

        private void fmSalaryAdd_Load(object sender, EventArgs e)
        {
            SetVisibleCmbPensAllwnc();
            SetVisibleCmbGradeAllwnc();
            SetVisibleCmbExpAllwnc();
            SetVisibleCmbOthAllwnc();

            cmbCalendar.IsModifyField(() => { btnOk.Enabled = true; });
            tbDepCd.IsModifyField(() => { btnOk.Enabled = true; });
            tbDays.IsModifyField(() => { btnOk.Enabled = true; });
            tbHours.IsModifyField(() => { btnOk.Enabled = true; });
            tbFIO.IsModifyField(() => { btnOk.Enabled = true; });
            tbBaseSm.IsModifyField(() => { btnOk.Enabled = true; });
            tbKTU.IsModifyField(() => { btnOk.Enabled = true; });

            tbPensCd.IsModifyField(() => { btnOk.Enabled = true; });
            tbPensNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbPensPct.IsModifyField(() => { btnOk.Enabled = true; });
            tbPensSm.IsModifyField(() => { btnOk.Enabled = true; });

            tbGradeCd.IsModifyField(() => { btnOk.Enabled = true; });
            tbGradeNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbGradePct.IsModifyField(() => { btnOk.Enabled = true; });
            tbGradeSm.IsModifyField(() => { btnOk.Enabled = true; });

            tbExpCd.IsModifyField(() => { btnOk.Enabled = true; });
            tbExpNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbExpPct.IsModifyField(() => { btnOk.Enabled = true; });
            tbExpSm.IsModifyField(() => { btnOk.Enabled = true; });

            tbOthCd.IsModifyField(() => { btnOk.Enabled = true; });
            tbOthNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbOthPct.IsModifyField(() => { btnOk.Enabled = true; });
            tbOthSm.IsModifyField(() => { btnOk.Enabled = true; });

            tbGrade.IsModifyField(() => { btnOk.Enabled = true; });
            tbKTUSm.IsModifyField(() => { btnOk.Enabled = true; });

            btnPens.IsModifyField(() => { btnOk.Enabled = true; });
            btnGrade.IsModifyField(() => { btnOk.Enabled = true; });
            btnExp.IsModifyField(() => { btnOk.Enabled = true; });
            btnOth.IsModifyField(() => { btnOk.Enabled = true; });
        }
        //изменили базовую сумму
        private void tbBaseSm_TextChanged(object sender, EventArgs e)
        {
            if (_cmbPensAllwncParams.RefPensAllwnc_Id != 0)
                CalcSmByPct(tbPensPct, tbPensSm, tbBaseSm);
            if (_cmbGradeAllwncParams.RefGradeAllwnc_Id != 0)
                CalcSmByPct(tbGradePct, tbGradeSm, tbBaseSm);
            if (_cmbOthAllwncParams.RefOthAllwnc_Id != 0)
                //CalcSmByPct(tbOthPct, tbOthSm, tbBaseSm);
                CalcOthSm();
            if (_cmbExpAllwncParams.RefExpAllwnc_Id != 0)
                CalcExpSm();

            if (tbKTU.Text != string.Empty)
                tbKTUSm.Text = GetSmKTUSm().ToString("0.00");

            tbResultSm.Text = GetResultSm().ToString("0.00"); 
        }
        //Выбрали надбавку пенсионеру
        private void tbPensPct_TextChanged(object sender, EventArgs e)
        {
            if (_cmbPensAllwncParams.RefPensAllwnc_Id != 0)
            {
                CalcSmByPct(tbPensPct, tbPensSm, tbBaseSm);
            }
        }
        private void tbPensSm_TextChanged(object sender, EventArgs e)
        {
            if (_cmbExpAllwncParams.RefExpAllwnc_Id != 0)
                CalcExpSm();
            if(_cmbOthAllwncParams.RefOthAllwnc_Id !=0)
                CalcOthSm();

            if (tbKTU.Text != string.Empty)
                tbKTUSm.Text = GetSmKTUSm().ToString("0.00");

            tbResultSm.Text = GetResultSm().ToString("0.00");
        }
        //Выбрали надбавку за стаж
        private void tbExpPct_TextChanged(object sender, EventArgs e)
        {
            if (_cmbExpAllwncParams.RefExpAllwnc_Id != 0)
            {
                CalcExpSm();
            }
        }
        private void tbExpSm_TextChanged(object sender, EventArgs e)
        {
            tbResultSm.Text = GetResultSm().ToString("0.00");
            if (tbKTU.Text != string.Empty)
                tbKTUSm.Text = GetSmKTUSm().ToString("0.00");
        }
        //Выбрали надбавку за классность
        private void tbGradePct_TextChanged(object sender, EventArgs e)
        {
            if (_cmbGradeAllwncParams.RefGradeAllwnc_Id != 0)
            {
                CalcSmByPct(tbGradePct, tbGradeSm, tbBaseSm);
            }
        }
        private void tbGradeSm_TextChanged(object sender, EventArgs e)
        {
            if (_cmbExpAllwncParams.RefExpAllwnc_Id != 0)
                CalcExpSm();
            if (_cmbOthAllwncParams.RefOthAllwnc_Id != 0)
                CalcOthSm();
            if (tbKTU.Text != string.Empty)
                tbKTUSm.Text = GetSmKTUSm().ToString("0.00");
            tbResultSm.Text = GetResultSm().ToString("0.00");
        }
        //Выбрали другую надбавку
        private void tbOthPct_TextChanged(object sender, EventArgs e)
        {
            if (_cmbOthAllwncParams.RefOthAllwnc_Id != 0)
            {
                CalcOthSm();
                //CalcSmByPct(tbOthPct, tbOthSm, tbBaseSm);
            }
        }
        private void tbOthSm_TextChanged(object sender, EventArgs e)
        {
            //if (_cmbExpAllwncParams.RefExpAllwnc_Id != 0)
            //    CalcExpSm();
            if (tbKTU.Text != string.Empty)
                tbKTUSm.Text = GetSmKTUSm().ToString("0.00");
            tbResultSm.Text = GetResultSm().ToString("0.00");
        }
        //Сумма КТУ
        private void tbKTUSm_TextChanged(object sender, EventArgs e)
        {
            tbResultSm.Text = GetResultSm().ToString("0.00");
        }

        //Выбор периода
        private void cmbCalendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetVisibleCmbPensAllwnc();
        }

        //Выбор нового работника
        private void tbFIO_TextChanged(object sender, EventArgs e)
        {
            SetVisibleCmbPensAllwnc();
            SetVisibleCmbGradeAllwnc();
            SetVisibleCmbExpAllwnc();
            SetVisibleCmbOthAllwnc();

            SetDataSetCmbGradeAllwnc();
            SetDataSetCmbExpAllwnc();
            if (priorCardId != _cmbCardParams.PersCard_Id)
            {
                SetDataPensAllwnc();
                SetDataGradeAllwnc();
                SetDataExpAllwnc();
                SetDataOthAllwnc();
                priorCardId = _cmbCardParams.PersCard_Id;
            }
        }
        //Выбор нового подразделения
        private void tbDepNm_TextChanged(object sender, EventArgs e)
        {
            SetDataSetCmbGradeAllwnc();
            if (priorDepId != _cmbDepParams.RefDep_Id)
            {
                SetDataGradeAllwnc();
                SetDataExpAllwnc();
                priorDepId = _cmbDepParams.RefDep_Id;
            }
        }
        //Изменение КТУ
        private void tbKTU_TextChanged(object sender, EventArgs e)
        {
            tbKTUSm.Text = GetSmKTUSm().ToString("0.00");
        }

        private void btnInfoKTUSm_Click(object sender, EventArgs e)
        {
            fmCalcResult info = new fmCalcResult(clcResultKTUSm);
            info.ShowDialog();
        }

        private void btnInfoExpSm_Click(object sender, EventArgs e)
        {
            fmCalcResult info = new fmCalcResult(clcResultExpSm);
            info.ShowDialog();
        }

        private void btnInfoResultSm_Click(object sender, EventArgs e)
        {
            fmCalcResult info = new fmCalcResult(clcResultSalarySm);
            info.ShowDialog();
        }
    }
}
