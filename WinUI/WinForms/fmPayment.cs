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
using DAL;
using BLL;
using WinFormExtensions;
using EnumType;


namespace WinUI.WinForms
{
    public partial class fmPayment : Form
    {
        private List<Payment> _payments = null; //кэш
        private List<v_Payment> _vPayment = null; //кэш
        private List<PersCard> _persCards = null; //кэш
        private List<v_TypePayment> _vTypePayment = null; //кэш

        private PersCardRepository _repoPersCard = new PersCardRepository(SetupProgram.Connection);
        private PaymentRepository _repoPayment = new PaymentRepository(SetupProgram.Connection);

        //Параметры запроса
        private int _typeId = 0;
        private DateTime _datBeg = DateTime.MinValue;
        private DateTime _datEnd = DateTime.MinValue;

        //Вставка строки
        private void InsertRecord()
        {
            fmPaymentEdit fmEdit = new fmPaymentEdit(EnumFormMode.Insert, "Створення виплати");
            Payment paymentSet = new Payment();
            int month = SalaryHelper.GetMonthByIndex(cmbCalendar.SelectedIndex, true);
            
            if (month == 0)
            {
                paymentSet.Payment_Date = DateTime.MinValue.AddYears(DateTime.Today.Year - 1).AddMonths(DateTime.Today.Month - 1);
            }
            else
            {
                int year = SalaryHelper.GetYearByIndex(DateTime.Today.Year - SetupProgram.YearSalary, cmbCalendar.SelectedIndex, true);
                paymentSet.Payment_Date = DateTime.MinValue.AddYears(year - 1).AddMonths(month - 1);
            }
            paymentSet.Payment_Type = _typeId;
            fmEdit.SetData(paymentSet);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                Payment paymentGet = fmEdit.GetData();
                int id = _repoPayment.AddPayment(paymentGet, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTablePayment(_typeId, _datBeg, _datEnd);
                dgvPayment.SetPositionRow<v_Payment>("Payment_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvPayment.CurrentRow == null) return;
            v_Payment paymentSet = dgvPayment.CurrentRow.DataBoundItem as v_Payment;
            if (paymentSet == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmPaymentEdit fmEdit = new fmPaymentEdit(EnumFormMode.Edit, "Зміна виплати");
            fmEdit.SetData(paymentSet);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                Payment paymentGet = fmEdit.GetData();
                string error;
                if (!_repoPayment.ModifyPayment(paymentGet, out error))
                {
                    MessageBox.Show("Помилка оновлення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTablePayment(_typeId, _datBeg, _datEnd);
            }
        }
        //Физическое удаление строки
        private void DeleteRecord()
        {
            List<v_Payment> checkedPayments = dgvPayment.GetCheckedRecords<v_Payment>();
            if (checkedPayments.Count > 0)
            {
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обрані рядки?", "Видалення", MessageBoxButtons.YesNo) 
                    == DialogResult.Yes)
                {
                    Coffee.Init("Видалення...");
                    foreach (v_Payment payment in checkedPayments)
                    {
                        string error;
                        if (!_repoPayment.DeletePayment(payment.Payment_Id, out error))
                        {
                            MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                            break;
                        }

                    }
                    Coffee.Term();
                    RefreshTablePayment(_typeId, _datBeg, _datEnd);
                }
            }
            else
            {
                if (dgvPayment.CurrentRow == null) return;
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                v_Payment payment = dgvPayment.CurrentRow.DataBoundItem as v_Payment;
                if (payment == null)
                {
                    MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                    return;
                }
                string error;
                if (!_repoPayment.DeletePayment(payment.Payment_Id, out error))
                {
                    MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTablePayment(_typeId, _datBeg, _datEnd);
            }
        }
        //Перезачитать данные таблицы
        private void RefreshTablePayment(int typeId, DateTime dtBeg, DateTime dtEnd)
        {
            dgvPayment.StorePosition();
            dgvPayment.StoreSort();
            LoadDataToGridPayment(typeId, dtBeg, dtEnd);
            UpdatePaymentResult();
            dgvPayment.RestSort<v_Payment>();
            dgvPayment.RestPosition();
        }
        //Получение периода на основании выбранного значения из комбика
        private bool GetDateBySelectCmbCalendar(ref DateTime datBeg, ref DateTime dateEnd)
        {
            datBeg = DateTime.MinValue;
            dateEnd = DateTime.MinValue;

            int year = SalaryHelper.GetYearByIndex(DateTime.Today.Year - SetupProgram.YearSalary, cmbCalendar.SelectedIndex, true);
            if (year == 0)
                return false;

            int month = SalaryHelper.GetMonthByIndex(cmbCalendar.SelectedIndex, true);
            if (month == 0)
            {
                datBeg = datBeg.AddYears(year - 1);
                dateEnd = dateEnd.AddYears(year - 1).AddMonths(12).AddDays(-1);
            }
            else
            {
                datBeg = datBeg.AddYears(year - 1).AddMonths(month - 1);
                dateEnd = dateEnd.AddYears(year - 1).AddMonths(month).AddDays(-1);
            }
            return true;
        }
        //Инициализация календаря
        private void InitCmbCalendar()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, true);
            cmbCalendar.DataSource = monthNames;
        }
        //Инициализация грида Типы выплат
        private void InitGridTypePayment()
        {
            dgvTypePayment.BaseGrigStyle();
        }
        //Инициализация грида Выплата
        private void InitGridPayment()
        {
            dgvPayment.BaseGrigStyle();
            dgvPayment.AddBirdColumn();
            dgvPayment.AddRefreshMenu(RefreshMenu);
            dgvPayment.AddSortGrid<v_Payment>("Payment_Id");
            dgvPayment.AddSearchGrid();
            dgvPayment.AddStatusStripRow(statusStripRow, true);
        }
        //Загрузка данных в грид "Типы выплта"
        private bool LoadDataToGridTypePayment()
        {
            _vTypePayment = new List<v_TypePayment>();
            _vTypePayment.Add(new v_TypePayment { Id = 0, Name = "Всі виплати" });
            _vTypePayment.AddRange(TypePaymentHelper.GetTypePayment());
            dgvTypePayment.DataSource = _vTypePayment;
            return true;
        }
        //Загрузка данных в грид "Виплати"
        private bool LoadDataToGridPayment(int typePaymentId, DateTime datBeg, DateTime datEnd)
        {
            string error;
            _payments = _repoPayment.GetPaymentByParams(0, typePaymentId, datBeg, datEnd, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження виплат.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            _persCards = _repoPersCard.GetAllCards(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження карток обліку.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            _vPayment = GetViewPayments(_payments, _persCards, _vTypePayment);
            source.DataSource = _vPayment;
            dgvPayment.DataSource = source;
            return true;
        }
        //Получить view "Виплати"
        private List<v_Payment> GetViewPayments(List<Payment> payments, List<PersCard> cards, List<v_TypePayment> typePayments)
        {
            List<v_Payment> res = (from payment in payments
                                   join card in cards on payment.Payment_PersCard_Id equals card.PersCard_Id
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
                                       PersCard_TIN = card.PersCard_TIN,
                                       PersCard_FullName = card.PersCard_LName + " " + card.PersCard_FName.Substring(0, 1) + ". " + card.PersCard_MName.Substring(0, 1) + ".",
                                       Payment_TypeName = types.Name
                                   }).ToList();
            return res;
        }
        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvPayment.CurrentRow != null && dgvPayment.Focused ? true : false;
            MenuItemCreate.Enabled = true && dgvPayment.Focused;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled;
            ContextMenuEdit.Enabled = MenuItemEdit.Enabled;
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled;
        }
        //Подсчитать и обновить итоги
        private void UpdatePaymentResult()
        {
            StatTotAmt.Text = "Всього кількість: " + _vPayment.Sum(rec => rec.Payment_Amt).ToString();
            StatTotSm.Text = "Всього сума: " + _vPayment.Sum(rec => rec.Payment_Sm).ToString() + " грн.";
        }
        public fmPayment(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Виплати");
        }

        private void fmPayment_Load(object sender, EventArgs e)
        {
            //Отпишемся от событий чтобы предотвратить "лишние" срабатывания при наcтройке
            cmbCalendar.SelectedIndexChanged -= new EventHandler(cmbCalendar_SelectedIndexChanged);
            dgvTypePayment.SelectionChanged -= new EventHandler(dgvTypePayment_SelectionChanged);
                
            InitCmbCalendar();
            cmbCalendar.SelectedIndex = cmbCalendar.Items.Count - 1;
            InitGridTypePayment();
            if (!LoadDataToGridTypePayment())
                return;
            
            InitGridPayment();

            GetDateBySelectCmbCalendar(ref _datBeg, ref _datEnd);
            if (_datBeg == DateTime.MinValue || _datEnd == DateTime.MinValue)
            {
                MessageBox.Show("Помилка вибору періода.\nТехнічна інформація: _datBeg == DateTime.MinValue || _dateEnd == DateTime.MinValue", "Помилка");
                return;
            }
            if (!LoadDataToGridPayment(_typeId, _datBeg, _datEnd))
                return;
            UpdatePaymentResult();
            //Восстновим подписку на события
            cmbCalendar.SelectedIndexChanged += new EventHandler(cmbCalendar_SelectedIndexChanged);
            dgvTypePayment.SelectionChanged += new EventHandler(dgvTypePayment_SelectionChanged);
        }

        private void fmPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvTypePayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void cmbCalendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDateBySelectCmbCalendar(ref _datBeg, ref _datEnd);
            if (_datBeg == DateTime.MinValue || _datEnd == DateTime.MinValue)
            {
                MessageBox.Show("Помилка вибору періода.\nТехнічна інформація: _datBeg == DateTime.MinValue || _dateEnd == DateTime.MinValue", "Помилка");
                return;
            }
            LoadDataToGridPayment(_typeId, _datBeg, _datEnd);
            UpdatePaymentResult();
        }

        private void dgvTypePayment_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTypePayment.CurrentRow == null)
                return;

            if (_datBeg == DateTime.MinValue || _datEnd == DateTime.MinValue)
            {
                MessageBox.Show("Помилка вибору періода.\nТехнічна інформація: _datBeg == DateTime.MinValue || _dateEnd == DateTime.MinValue", "Помилка");
                return;
            }

            v_TypePayment typePayment = dgvTypePayment.CurrentRow.DataBoundItem as v_TypePayment;
            
            if (typePayment == null)
            {
                MessageBox.Show("Помилка вибору типу виплати.\nТехнічна інформація: typePayment == null", "Помилка");
                return;
            }
            
            _typeId = typePayment.Id;
            LoadDataToGridPayment(_typeId, _datBeg, _datEnd);
            UpdatePaymentResult();
        }

        private void MenuItemCreate_Click(object sender, EventArgs e)
        {
            InsertRecord();
        }

        private void MenuItemEdit_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void MenuItemRefresh_Click(object sender, EventArgs e)
        {
            RefreshTablePayment(_typeId, _datBeg, _datEnd);
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Контекстное меню
        private void ContextMenuCreate_Click(object sender, EventArgs e)
        {
            InsertRecord();
        }

        private void ContextMenuEdit_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        private void ContextMenuDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void ContextMenuRefresh_Click(object sender, EventArgs e)
        {
            RefreshTablePayment(_typeId, _datBeg, _datEnd);
        }
    }
}
