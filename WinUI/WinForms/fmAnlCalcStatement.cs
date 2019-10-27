using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Entities;
using BLL;
using WinFormExtensions;
using EnumType;


namespace WinUI.WinForms
{
    public partial class fmAnlCalcStatement : Form
    {
        private ACSRepository _repoACS = new ACSRepository(SetupProgram.Connection);
        private AddAccrRepository _repoAddAccr = new AddAccrRepository(SetupProgram.Connection);
        private RefTypeAddAccrRepository _repoTypeAddAccr = new RefTypeAddAccrRepository(SetupProgram.Connection);
        private AddPaymentRepository _repoAddPayment = new AddPaymentRepository(SetupProgram.Connection);
        private RefTypeAddPaymentRepository _repoTypeAddPayment = new RefTypeAddPaymentRepository(SetupProgram.Connection);
        private PaymentRepository _repoPayment = new PaymentRepository(SetupProgram.Connection);
        private SalBalanceRepository _salBalance = new SalBalanceRepository(SetupProgram.Connection);

        private List<ACS> _acses = null; //кэш
        private List<AddAccr> _addAccrs = null; //кэш
        private List<v_AddAccr> _vAddAccr = null; //кэш
        private List<RefTypeAddAccr> _typeAddAccrs = null; //кэш
        private List<AddPayment> _addPayments = null; //кэш
        private List<v_AddPayment> _vAddPayments = null; //кэш
        private List<RefTypeAddPayment> _refTypeAddPayment = null; //кэш
        private List<Payment> _payments = null; //кэш
        private List<v_Payment> _vPayments = null; //кэш
        private List<v_TypePayment> _vTypePayment = null; //кэш

        //Параметры запроса
        private DateTime _datClc = DateTime.MinValue;

        private void PrintReport()
        {
            List<int> id_card = new List<int>();
            List<ACS> checkedACS = dgvACS.GetCheckedRecords<ACS>();
            if(checkedACS.Count > 0)
            {
                foreach (ACS acs in checkedACS)
                    id_card.Add(acs.PersCard_Id);
            }
            else
            {
                if (dgvACS.CurrentRow != null)
                {
                    ACS acs = dgvACS.CurrentRow.DataBoundItem as ACS;
                    if(acs != null)
                    {
                        id_card.Add(acs.PersCard_Id);
                    }    
                }
            }

            fmReport report = new fmReport(this, id_card, true);
            report.ShowDialog();
        }
        private void RefreshTables()
        {
            RefreshTableACS(_datClc);
            RefreshTableAddAccr(_datClc);
            RefreshTableAddPayment(_datClc);
            RefreshTablePayment(_datClc);
            ChooseCurrentAcs();
        }
        private void CalcSalBalance()
        {
            if (MessageBox.Show("Виконати розрахунок сальдо?", "Увага", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            fmACSPeriod acsPeriod = new fmACSPeriod("Період розрахунку");
            if(acsPeriod.ShowDialog() == DialogResult.OK)
            {
                Coffee.Init("Розрахунок сальдо...");
                DateTime perBeg = acsPeriod.GetPeriodBeg();
                DateTime perEnd = acsPeriod.GetPeriodEnd();
                string error = string.Empty; 
                if(!_salBalance.CalcBalance(perBeg, perEnd, out error))
                {
                    MessageBox.Show("Помилка розрахунку сальдо.\nТехнічна інформація: " + error, "Помилка");
                }
                Coffee.Term();
            }
            return;
        }

        private List<v_ACS> GetViewAcses(List<ACS> _acses)
        {
            return _acses.Select(acs => new v_ACS
            {
                PersCard_Id = acs.PersCard_Id,
                PersCard_LName = acs.PersCard_LName,
                PersCard_FName = acs.PersCard_FName,
                PersCard_MName = acs.PersCard_MName,
                PersCard_TIN = acs.PersCard_TIN,
                PersCard_Exp = acs.PersCard_Exp,
                PersCard_Grade = acs.PersCard_Grade,
                PersCard_DOB = acs.PersCard_DOB,
                PersCard_DOR = acs.PersCard_DOR,
                PersCard_DOD = acs.PersCard_DOD,
                PersCard_DOP = acs.PersCard_DOP,
                PersCard_Sex = acs.PersCard_Sex,
                CardStatus_Type = acs.CardStatus_Type,
                CardStatus_TypeNm = CardStatusHelper.GetStatusName(acs.CardStatus_Type),
                Child_Count = acs.Child_Count,
                Salary_BaseSm = acs.Salary_BaseSm,
                Salary_PensSm = acs.Salary_PensSm,
                Salary_GradeSm = acs.Salary_GradeSm,
                Salary_ExpSm = acs.Salary_ExpSm,
                Salary_OthSm = acs.Salary_OthSm,
                Salary_KTU = acs.Salary_KTU,
                Salary_KTUSm = acs.Salary_KTUSm,
                Salary_ResSm = acs.Salary_ResSm,
                SickList_DaysTmpDis = acs.SickList_DaysTmpDis,
                SickList_ResSm = acs.SickList_ResSm,
                Vocation_Days = acs.Vocation_Days,
                Vocation_Sm = acs.Vocation_Sm,
                LawContract_Days = acs.LawContract_Days,
                LawContract_Sm = acs.LawContract_Sm,
                AddAccr_SmClc = acs.AddAccr_SmClc,
                AddAccr_SmNoClc = acs.AddAccr_SmNoClc,
                Tax_Sm = acs.Tax_Sm,
                Prof_Sm = acs.Prof_Sm,
                Military_Sm = acs.Military_Sm,
                SalBalance_BegMonthSm = acs.SalBalance_BegMonthSm,
                SalBalance_EndMonthSm = acs.SalBalance_EndMonthSm
            }).ToList();
        }
        //Перезачитать данные таблицы
        private void RefreshTableACS(DateTime datClc)
        {
            dgvACS.StorePosition();
            dgvACS.StoreSort();
            LoadDataToGridACS(datClc);
            dgvACS.RestSort<v_ACS>();
            dgvACS.RestPosition();
        }
        //Перезачитать данные таблицы
        private void RefreshTableAddAccr(DateTime datClc)
        {
            LoadDataToGridAddAccr(datClc);
        }
        //Перезачитать данные таблицы
        private void RefreshTableAddPayment(DateTime datClc)
        {
            LoadDataToGridAddPayment(datClc);
        }
        //Перезачитать данные таблицы
        private void RefreshTablePayment(DateTime datClc)
        {
            LoadDataToGridPayment(datClc);
        }

        //Получение периода на основании выбранного значения из комбика
        private bool GetDateBySelectCmbCalendar(ref DateTime dat)
        {
            dat = DateTime.MinValue;

            int year = SalaryHelper.GetYearByIndex(DateTime.Today.Year - SetupProgram.YearSalary, cmbCalendar.SelectedIndex, false);
            if (year == 0)
                return false;

            int month = SalaryHelper.GetMonthByIndex(cmbCalendar.SelectedIndex, false);
            if (month == 0)
            {
                dat = dat.AddYears(year - 1);
            }
            else
            {
                dat = dat.AddYears(year - 1).AddMonths(month - 1);
            }
            return true;
        }
        //Инициализация календаря
        private void InitCmbCalendar()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, false);
            cmbCalendar.DataSource = monthNames;
        }
        //Инициализация АРВ
        private void InitGridACS()
        {
            dgvACS.BaseGrigStyle(DataGridViewAutoSizeColumnsMode.None);
            dgvACS.AddBirdColumn(true);
            dgvACS.AddSortGrid<v_ACS>("PersCard_Id");
            dgvACS.AddSearchGrid();
            dgvACS.AddStatusStripRow(statusStripRow, true);
        }

        //Инициализация Дополнительные начисления
        private void InitGridAddAccr()
        {
            dgvAddAccr.BaseGrigStyle();
            dgvAddAccr.AddSortGrid<v_AddAccr>("AddAccr_Id");
            dgvAddAccr.AddSearchGrid();
            dgvAddAccr.AddStatusStripRow(statusStripAddAccr, true);
        }

        //Инициализация Дополнительные выплаты
        private void InitGridAddPayment()
        {
            dgvAddPayment.BaseGrigStyle();
            dgvAddPayment.AddSortGrid<v_AddPayment>("AddPayment_Id");
            dgvAddPayment.AddSearchGrid();
            dgvAddPayment.AddStatusStripRow(statusStripAddPayment, true);
        }
        //Инициализация Выплаты
        private void InitGridPayment()
        {
            dgvPayment.BaseGrigStyle();
            dgvPayment.AddSortGrid<v_Payment>("Payment_Id");
            dgvPayment.AddSearchGrid();
            dgvPayment.AddStatusStripRow(statusStripPayment, true);
        }
        private void InitPanel()
        {
            pnlAddGrid.Height = pnlMain.Height / 3;
            pnlAddPayment.Width = pnlAddGrid.Width / 3;
            pnlPayment.Width = pnlAddGrid.Width / 3;
            pnlAddAccr.Width = pnlAddGrid.Width / 3;
        }

        //Загрузка данных в грид "АРВ"
        private bool LoadDataToGridACS(DateTime datClc)
        {
            string error;
            _acses = _repoACS.GetAllACSByParam(datClc, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження аналітичної розрахункової відомості.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
        
            BindingSource source = new BindingSource();
            source.DataSource = GetViewAcses(_acses);
            dgvACS.DataSource = source;
            return true;
        }

        //Загрузка данных в грид "Дополнительные начисления"
        private bool LoadDataToGridAddAccr(DateTime datClc)
        {
            string error;
            _addAccrs = _repoAddAccr.GetAddAccrByParams(0, 0, datClc, datClc, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження додаткових нарахуваннь.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if(_typeAddAccrs == null)
            {
                _typeAddAccrs = _repoTypeAddAccr.GetAllTypeAddAccr(out error);
                if (error != string.Empty)
                {
                    MessageBox.Show("Помилка завантаження додаткових типів нарахувань.\nТехнічна інформація: " + error, "Помилка");
                    return false;
                }
            }
            _vAddAccr = GetViewAddAccrs(_addAccrs, _typeAddAccrs);
            return true;
        }

        private void FilterGridAddAccr(int cardId, List<v_AddAccr> addAccrs)
        {
            if (addAccrs == null)
                return;

            List<v_AddAccr> dataSource = addAccrs.Where(rec => rec.AddAccr_PersCard_Id == cardId).ToList();
            BindingSource source = new BindingSource();
            source.DataSource = dataSource;
            dgvAddAccr.DataSource = source;
        }
        //Получить view "Дополнительные начисления"
        private List<v_AddAccr> GetViewAddAccrs(List<AddAccr> addAccrs, List<RefTypeAddAccr> typeAddAccrs)
        {
            List<v_AddAccr> res = (from addAccr in addAccrs
                                   join typeAddAccr in typeAddAccrs on addAccr.AddAccr_RefTypeAddAccr_Id equals typeAddAccr.RefTypeAddAccr_Id
                                   select new v_AddAccr
                                   {
                                       AddAccr_Id = addAccr.AddAccr_Id,
                                       AddAccr_PersCard_Id = addAccr.AddAccr_PersCard_Id,
                                       AddAccr_RefDep_Id = addAccr.AddAccr_RefDep_Id,
                                       AddAccr_RefTypeAddAccr_Id = addAccr.AddAccr_RefTypeAddAccr_Id,
                                       AddAccr_Date = addAccr.AddAccr_Date,
                                       AddAccr_Sm = addAccr.AddAccr_Sm,
                                       AddAccr_RefTypeAddAccr_Nm = typeAddAccr.RefTypeAddAccr_Nm
                                   }).ToList();
            return res;
        }

        //Загрузка данных в грид "Дополнительные выплаты"
        private bool LoadDataToGridAddPayment(DateTime datClc)
        {
            string error;
            _addPayments = _repoAddPayment.GetAddPaymentsByParams(0, 0, datClc, datClc, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження додаткових виплат.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if (_refTypeAddPayment == null)
            {
                _refTypeAddPayment = _repoTypeAddPayment.GetAllTypeAddPayments(out error);
                if (error != string.Empty)
                {
                    MessageBox.Show("Помилка завантаження типів додаткових виплат.\nТехнічна інформація: " + error, "Помилка");
                    return false;
                }
            }
            _vAddPayments = GetViewAddPayments(_addPayments, _refTypeAddPayment);
            return true;
        }
        //Получить view "Дополнительные выплаты"
        private List<v_AddPayment> GetViewAddPayments(List<AddPayment> addPayments, List<RefTypeAddPayment> typeAddPayments)
        {
            List<v_AddPayment> res = (from addPayment in addPayments
                                      join typeAddPayment in typeAddPayments on addPayment.AddPayment_TypeAddPayment_Id equals typeAddPayment.RefTypeAddPayment_Id
                                      select new v_AddPayment
                                      {
                                          AddPayment_Id = addPayment.AddPayment_Id,
                                          AddPayment_PersCard_Id = addPayment.AddPayment_PersCard_Id,
                                          AddPayment_Date = addPayment.AddPayment_Date,
                                          AddPayment_TypeAddPayment_Id = addPayment.AddPayment_TypeAddPayment_Id,
                                          AddPayment_Sm = addPayment.AddPayment_Sm,
                                          TypeAddPayment_Nm = typeAddPayment.RefTypeAddPayment_Nm
                                      }).ToList();
            return res;
        }
        private void FilterGridAddPayment(int cardId, List<v_AddPayment> addPayments)
        {
            if (addPayments == null)
                return;

            List<v_AddPayment> dataSource = addPayments.Where(rec => rec.AddPayment_PersCard_Id == cardId).ToList();
            BindingSource source = new BindingSource();
            source.DataSource = dataSource;
            dgvAddPayment.DataSource = source;
        }

        //Загрузка данных в грид "Виплати"
        private bool LoadDataToGridPayment(DateTime datClc)
        {
            string error;
            _payments = _repoPayment.GetPaymentByParams(0, 0, datClc, datClc, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження виплат.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if (_vTypePayment == null)
            {
                _vTypePayment = TypePaymentHelper.GetTypePayment();
            }
            _vPayments = GetViewPayments(_payments, _vTypePayment);
            return true;
        }
        //Получить view "Виплати"
        private List<v_Payment> GetViewPayments(List<Payment> payments, List<v_TypePayment> typePayments)
        {
            List<v_Payment> res = (from payment in payments
                                   join types in typePayments on payment.Payment_Type equals types.Id
                                   select new v_Payment
                                   {
                                       Payment_Id = payment.Payment_Id,
                                       Payment_PersCard_Id = payment.Payment_PersCard_Id,
                                       Payment_Date = payment.Payment_Date,
                                       Payment_Type = payment.Payment_Type,
                                       Payment_Amt = payment.Payment_Amt,
                                       Payment_Price = payment.Payment_Price,
                                       Payment_Sm = payment.Payment_Sm,
                                       Payment_TypeName = types.Name
                                   }).ToList();
            return res;
        }

        private void FilterGridPayment(int cardId, List<v_Payment> payments)
        {
            if (payments == null)
                return;

            List<v_Payment> dataSource = payments.Where(rec => rec.Payment_PersCard_Id == cardId).ToList();
            BindingSource source = new BindingSource();
            source.DataSource = dataSource;
            dgvPayment.DataSource = source;
        }

        public fmAnlCalcStatement(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Аналітична розрахункова відомість");
        }

        private void fmAnlCalcStatement_Load(object sender, EventArgs e)
        {
            //Отпишемся от событий чтобы предотвратить "лишние" срабатывания при наcтройке
            cmbCalendar.SelectedIndexChanged -= new EventHandler(cmbCalendar_SelectedIndexChanged);

            CalcSalBalance();

            InitCmbCalendar();
            cmbCalendar.SelectedIndex = cmbCalendar.Items.Count - 1;

            InitGridACS();
            InitGridAddAccr();
            InitGridAddPayment();
            InitGridPayment();

            GetDateBySelectCmbCalendar(ref _datClc);
            if (_datClc == DateTime.MinValue)
            {
                MessageBox.Show("Помилка вибору періоду.\nТехнічна інформація: _datBeg == DateTime.MinValue || _dateEnd == DateTime.MinValue", "Помилка");
                return;
            }
            if (!LoadDataToGridACS(_datClc))
                return;
            if (!LoadDataToGridAddAccr(_datClc))
                return;
            if (!LoadDataToGridAddPayment(_datClc))
                return;
            if (!LoadDataToGridPayment(_datClc))
                return;
            //Восстновим подписку на события
            cmbCalendar.SelectedIndexChanged += new EventHandler(cmbCalendar_SelectedIndexChanged);
        }

        private void cmbCalendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDateBySelectCmbCalendar(ref _datClc);
            if (_datClc == DateTime.MinValue)
            {
                MessageBox.Show("Помилка вибору періоду.\nТехнічна інформація: _datBeg == DateTime.MinValue || _dateEnd == DateTime.MinValue", "Помилка");
                return;
            }
            LoadDataToGridACS(_datClc);
            LoadDataToGridAddAccr(_datClc);
            LoadDataToGridAddPayment(_datClc);
            LoadDataToGridPayment(_datClc);
        }
        private void ChooseCurrentAcs()
        {
            if (dgvACS.CurrentRow == null)
                return;
            v_ACS acs = dgvACS.CurrentRow.DataBoundItem as v_ACS;
            if (acs == null)
            {
                MessageBox.Show("Помилка вибору картки.\nТехнічна інформація: dep == null", "Помилка");
                return;
            }
            FilterGridAddAccr(acs.PersCard_Id, _vAddAccr);
            FilterGridAddPayment(acs.PersCard_Id, _vAddPayments);
            FilterGridPayment(acs.PersCard_Id, _vPayments);
        }

        private void fmAnlCalcStatement_Shown(object sender, EventArgs e)
        {
            InitPanel();
        }

        private void dgvACS_SelectionChanged(object sender, EventArgs e)
        {
            ChooseCurrentAcs();
        }


        private void fmAnlCalcStatement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvACS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvAddAccr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvAddPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        //Основное меню
        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuItemReport_Click(object sender, EventArgs e)
        {
            PrintReport();
        }
        private void MenuItemRefresh_Click(object sender, EventArgs e)
        {
            RefreshTables();
        }

        //Контекстное меню
        private void ContextMenuReport_Click(object sender, EventArgs e)
        {
            PrintReport();
        }

        private void ContextMenuRefresh_Click(object sender, EventArgs e)
        {
            RefreshTables();
        }
    }
}
