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
    public partial class fmAddPayment : Form
    {
        private List<AddPayment> _addPayments = null; //кэш
        private List<v_AddPayment> _vAddPayments = null; //кэш
        private List<RefTypeAddPayment> _refTypeAddPayment = new List<RefTypeAddPayment>(); //кэш
        private List<PersCard> _persCards = new List<PersCard>(); //кэш

        private AddPaymentRepository _repoAddPayment = new AddPaymentRepository(SetupProgram.Connection);
        private RefTypeAddPaymentRepository _repoTypeAddPayment = new RefTypeAddPaymentRepository(SetupProgram.Connection);
        private PersCardRepository _repoPersCard = new PersCardRepository(SetupProgram.Connection);

        //Параметры запроса
        private int _typeId = 0;
        private DateTime _datBeg = DateTime.MinValue;
        private DateTime _datEnd = DateTime.MinValue;

        //Вставка строки
        private void InsertRecord()
        {
            fmAddPaymentEdit fmEdit = new fmAddPaymentEdit(EnumFormMode.Insert, "Створення додаткової виплати");
            AddPayment addPaymentSet = new AddPayment();
            int month = SalaryHelper.GetMonthByIndex(cmbCalendar.SelectedIndex, true);

            if (month == 0)
            {
                addPaymentSet.AddPayment_Date = DateTime.MinValue.AddYears(DateTime.Today.Year - 1).AddMonths(DateTime.Today.Month - 1);
            }
            else
            {
                int year = SalaryHelper.GetYearByIndex(DateTime.Today.Year - SetupProgram.YearSalary, cmbCalendar.SelectedIndex, true);
                addPaymentSet.AddPayment_Date = DateTime.MinValue.AddYears(year - 1).AddMonths(month - 1);
            }

            if (MenuItemTypeAddPayment.CheckState == CheckState.Checked && dgvTypeAddPayment.CurrentRow != null)
            {
                v_TypeAddPayment type = dgvTypeAddPayment.CurrentRow.DataBoundItem as v_TypeAddPayment;
                if (type != null)
                    addPaymentSet.AddPayment_TypeAddPayment_Id = type.Id;
            }
            fmEdit.SetData(addPaymentSet);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                AddPayment addPaymentGet = fmEdit.GetData();
                int id = _repoAddPayment.AddAddPayment(addPaymentGet, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableAddPayment(_typeId, _datBeg, _datEnd);
                dgvAddPayment.SetPositionRow<v_AddPayment>("AddPayment_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvAddPayment.CurrentRow == null) return;
            v_AddPayment addPaymentSet = dgvAddPayment.CurrentRow.DataBoundItem as v_AddPayment;
            if (addPaymentSet == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmAddPaymentEdit fmEdit = new fmAddPaymentEdit(EnumFormMode.Edit, "Зміна додаткової виплати");
            fmEdit.SetData(addPaymentSet);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                AddPayment addPaymentGet = fmEdit.GetData();
                string error;
                if (!_repoAddPayment.ModifyAddPayment(addPaymentGet, out error))
                {
                    MessageBox.Show("Помилка оновлення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableAddPayment(_typeId, _datBeg, _datEnd);
            }
        }
        //Физическое удаление строки
        private void DeleteRecord()
        {
            List<v_AddPayment> checkedAddPayments = dgvAddPayment.GetCheckedRecords<v_AddPayment>();
            if (checkedAddPayments.Count > 0)
            {
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обрані рядки?",
                    "Видалення", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Coffee.Init("Видалення...");
                    foreach (v_AddPayment addPayment in checkedAddPayments)
                    {
                        string error;
                        if (!_repoAddPayment.DeleteAddPayment(addPayment.AddPayment_Id, out error))
                        {
                            MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                            break;
                        }

                    }
                    Coffee.Term();
                    RefreshTableAddPayment(_typeId, _datBeg, _datEnd);
                }
            }
            else
            {
                if (dgvAddPayment.CurrentRow == null) return;
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                v_AddPayment addPayment = dgvAddPayment.CurrentRow.DataBoundItem as v_AddPayment;
                if (addPayment == null)
                {
                    MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                    return;
                }
                string error;
                if (!_repoAddPayment.DeleteAddPayment(addPayment.AddPayment_Id, out error))
                {
                    MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableAddPayment(_typeId, _datBeg, _datEnd);
            }
        }
        private void RefreshTables()
        {
            if (dgvTypeAddPayment.Focused)
            {
                RefreshTableType();
                RefreshTableAddPayment(_typeId, _datBeg, _datEnd);
            }
            if (dgvAddPayment.Focused)
            {
                RefreshTableAddPayment(_typeId, _datBeg, _datEnd);
            }
        }
        //Перезачитать данные таблицы дополнительные выплати
        private void RefreshTableAddPayment(int typeId, DateTime dtBeg, DateTime dtEnd)
        {
            dgvAddPayment.StorePosition();
            dgvAddPayment.StoreSort();
            LoadDataToGridAddPayment(typeId, dtBeg, dtEnd);
            UpdateAddPaymentResult();
            dgvAddPayment.RestSort<v_AddPayment>();
            dgvAddPayment.RestPosition();
        }
        //Перезачитать данные таблицы Типы дополнительных выплат
        private void RefreshTableType()
        {
            //Отпишемся от событий чтобы предотвратить "лишние" срабатывания
            dgvTypeAddPayment.SelectionChanged -= new EventHandler(dgvTypeAddPayment_SelectionChanged);
            dgvTypeAddPayment.StorePosition();
            LoadDataToGridTypeAddPayment();
            dgvTypeAddPayment.RestPosition();
            dgvTypeAddPayment.SelectionChanged += new EventHandler(dgvTypeAddPayment_SelectionChanged);
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
                dateEnd = dateEnd.AddYears(year - 1).AddMonths(12 - 1);
            }
            else
            {
                datBeg = datBeg.AddYears(year - 1).AddMonths(month - 1);
                dateEnd = dateEnd.AddYears(year - 1).AddMonths(month - 1);
            }
            return true;
        }
        //Инициализация календаря
        private void InitCmbCalendar()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, true);
            cmbCalendar.DataSource = monthNames;
        }
        //Инициализация грида Типы дополнительных выплат
        private void InitGridTypeAddPayment()
        {
            dgvTypeAddPayment.BaseGrigStyle();
        }
        //Инициализация грида Дополнительные выплаты
        private void InitGridAddPayment()
        {
            dgvAddPayment.BaseGrigStyle();
            dgvAddPayment.AddBirdColumn();
            dgvAddPayment.AddRefreshMenu(RefreshMenu);
            dgvAddPayment.AddSortGrid<v_AddPayment>("AddPayment_Id");
            dgvAddPayment.AddSearchGrid();
            dgvAddPayment.AddStatusStripRow(statusStripRow, true);
        }
        //Загрузка данных в грид "Типы дополнительных выплат"
        private bool LoadDataToGridTypeAddPayment()
        {
            string error;
            _refTypeAddPayment = _repoTypeAddPayment.GetAllTypeAddPayments(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження типів додаткових виплат.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            source.DataSource = GetViewTypeAddPayments(_refTypeAddPayment);
            dgvTypeAddPayment.DataSource = source;
            return true;
        }

        //Загрузка данных в грид "Доп. выплаты"
        private bool LoadDataToGridAddPayment(int typeId, DateTime datBeg, DateTime datEnd)
        {
            string error;
            _addPayments = _repoAddPayment.GetAddPaymentsByParams(0, typeId, datBeg, datEnd, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження додаткових виплат.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            _persCards = _repoPersCard.GetAllCards(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження карток обліку.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if (_refTypeAddPayment.Count == 0)
            {
                _refTypeAddPayment = _repoTypeAddPayment.GetAllTypeAddPayments(out error);
                if (error != string.Empty)
                {
                    MessageBox.Show("Помилка завантаження типів додаткових виплат.\nТехнічна інформація: " + error, "Помилка");
                    return false;
                }
            }
            BindingSource source = new BindingSource();
            _vAddPayments = GetViewAddPayments(_addPayments, _persCards, _refTypeAddPayment);
            source.DataSource = _vAddPayments;
            dgvAddPayment.DataSource = source;
            return true;
        }

        //Получить view "Типы доп. выплат"
        private List<v_TypeAddPayment> GetViewTypeAddPayments(List<RefTypeAddPayment> types)
        {
            return types.Select(type => new v_TypeAddPayment
            {
                Id = type.RefTypeAddPayment_Id,
                Name = type.RefTypeAddPayment_Cd + "." + type.RefTypeAddPayment_Nm
            }).ToList();
        }
        //Получить view "Дополнительные выплаты"
        private List<v_AddPayment> GetViewAddPayments(List<AddPayment> addPayments, List<PersCard> cards, List<RefTypeAddPayment> typeAddPayments)
        {
            List<v_AddPayment> res = (from addPayment in addPayments
                                      join card in cards on addPayment.AddPayment_PersCard_Id equals card.PersCard_Id
                                      join typeAddPayment in typeAddPayments on addPayment.AddPayment_TypeAddPayment_Id equals typeAddPayment.RefTypeAddPayment_Id
                                      select new v_AddPayment
                                      {
                                          AddPayment_Id = addPayment.AddPayment_Id,
                                          AddPayment_PersCard_Id = addPayment.AddPayment_PersCard_Id,
                                          AddPayment_Date = addPayment.AddPayment_Date,
                                          AddPayment_TypeAddPayment_Id = addPayment.AddPayment_TypeAddPayment_Id,
                                          AddPayment_Sm = addPayment.AddPayment_Sm,
                                          PersCard_FullName = card.PersCard_LName + " " + card.PersCard_FName.Substring(0, 1) + ". " + card.PersCard_MName.Substring(0, 1) + ".",
                                          PersCard_TIN = card.PersCard_TIN,
                                          TypeAddPayment_Nm = typeAddPayment.RefTypeAddPayment_Nm
                                      }).ToList();
            return res;
        }
        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvAddPayment.CurrentRow != null && dgvAddPayment.Focused ? true : false;
            MenuItemCreate.Enabled = true && dgvAddPayment.Focused;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled;
            ContextMenuEdit.Enabled  = MenuItemEdit.Enabled;
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled; 
        }
        //Показать навигатор типов выплат
        private void ShowNavigatorTypes(bool isShow)
        {
            if (isShow)
            {
                left_pnl.Visible = true;
                if (dgvTypeAddPayment.CurrentRow == null)
                {
                    dgvTypeAddPayment.CurrentCell = dgvTypeAddPayment.Rows[0].Cells[0];
                }
                v_TypeAddPayment type = dgvTypeAddPayment.CurrentRow.DataBoundItem as v_TypeAddPayment;

                if (type == null)
                {
                    MessageBox.Show("Помилка вибору типу додаткової виплати.\nТехнічна інформація: type == null", "Помилка");
                    return;
                }
                _typeId = type.Id;
            }
            else
            {
                _typeId = 0;
                left_pnl.Visible = false;
            }
            LoadDataToGridAddPayment(_typeId, _datBeg, _datEnd);
            UpdateAddPaymentResult();
        }

        //Подсчитать и обновить итоги
        private void UpdateAddPaymentResult()
        {
            StatTotSm.Text = "Всього сума: " + _vAddPayments.Sum(rec => rec.AddPayment_Sm).ToString() + " грн.";
        }
        public fmAddPayment(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Додаткові виплати");
        }

        private void fmAddPayment_Load(object sender, EventArgs e)
        {
            //Отпишемся от событий чтобы предотвратить "лишние" срабатывания при наcтройке
            cmbCalendar.SelectedIndexChanged -= new EventHandler(cmbCalendar_SelectedIndexChanged);
            dgvTypeAddPayment.SelectionChanged -= new EventHandler(dgvTypeAddPayment_SelectionChanged);

            InitCmbCalendar();
            cmbCalendar.SelectedIndex = cmbCalendar.Items.Count - 1;
            InitGridTypeAddPayment();
            if (!LoadDataToGridTypeAddPayment())
                return;

            InitGridAddPayment();

            if (MenuItemTypeAddPayment.CheckState == CheckState.Checked && dgvTypeAddPayment.CurrentRow != null)
            {
                dgvTypeAddPayment.CurrentCell = dgvTypeAddPayment.Rows[0].Cells[0];
                v_TypeAddPayment typeAddPayment = dgvTypeAddPayment.CurrentRow.DataBoundItem as v_TypeAddPayment;
                if (typeAddPayment == null)
                {
                    MessageBox.Show("Помилка вибору типу додаткових виплат.\nТехнічна інформація: typeAddPayment == null", "Помилка");
                    return;
                }
                _typeId = typeAddPayment.Id;
            }
            else
            {
                _typeId = 0;
            }
            GetDateBySelectCmbCalendar(ref _datBeg, ref _datEnd);
            if (_datBeg == DateTime.MinValue || _datEnd == DateTime.MinValue)
            {
                MessageBox.Show("Помилка вибору періоду.\nТехнічна інформація: _datBeg == DateTime.MinValue || _dateEnd == DateTime.MinValue", "Помилка");
                return;
            }
            if (!LoadDataToGridAddPayment(_typeId, _datBeg, _datEnd))
                return;
            UpdateAddPaymentResult();
            //Восстновим подписку на события
            cmbCalendar.SelectedIndexChanged += new EventHandler(cmbCalendar_SelectedIndexChanged);
            dgvTypeAddPayment.SelectionChanged += new EventHandler(dgvTypeAddPayment_SelectionChanged);
        }

        private void fmAddPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvTypeAddPayment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvAddPayment_KeyDown(object sender, KeyEventArgs e)
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
            LoadDataToGridAddPayment(_typeId, _datBeg, _datEnd);
            UpdateAddPaymentResult();
        }

        private void dgvTypeAddPayment_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTypeAddPayment.CurrentRow == null)
                return;

            if (_datBeg == DateTime.MinValue || _datEnd == DateTime.MinValue)
            {
                MessageBox.Show("Помилка вибору періода.\nТехнічна інформація: _datBeg == DateTime.MinValue || _dateEnd == DateTime.MinValue", "Помилка");
                return;
            }

            v_TypeAddPayment type = dgvTypeAddPayment.CurrentRow.DataBoundItem as v_TypeAddPayment;

            if (type == null)
            {
                MessageBox.Show("Помилка вибору типу додаткової виплати.\nТехнічна інформація: dep == null", "Помилка");
                return;
            }

            _typeId = type.Id;
            LoadDataToGridAddPayment(_typeId, _datBeg, _datEnd);
            UpdateAddPaymentResult();
        }
        //---------------------------------------Меню---------------------------------------------------//
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
            RefreshTables();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuItemTypeAddPayment_Click(object sender, EventArgs e)
        {
            MenuItemTypeAddPayment.CheckState = MenuItemTypeAddPayment.CheckState == CheckState.Checked ?
                CheckState.Unchecked : CheckState.Checked;
            ContextMenuTypeAddPayment.CheckState = MenuItemTypeAddPayment.CheckState;
            ShowNavigatorTypes(MenuItemTypeAddPayment.CheckState == CheckState.Checked);
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
            RefreshTables();
        }

        private void ContextMenuTypeAddPayment_Click(object sender, EventArgs e)
        {
            ContextMenuTypeAddPayment.CheckState = ContextMenuTypeAddPayment.CheckState == CheckState.Checked ?
              CheckState.Unchecked : CheckState.Checked;
            MenuItemTypeAddPayment.CheckState = ContextMenuTypeAddPayment.CheckState;
            ShowNavigatorTypes(ContextMenuTypeAddPayment.CheckState == CheckState.Checked);
        }
    }
}
