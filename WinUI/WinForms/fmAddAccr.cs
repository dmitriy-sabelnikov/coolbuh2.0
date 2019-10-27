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
    public partial class fmAddAccr : Form
    {
        private List<AddAccr> _addAccrs = null; //кэш
        private List<v_AddAccr> _vAddAccr = null; //кэш
        private List<RefDep> _refDeps = new List<RefDep>(); //кэш
        private List<PersCard> _persCards = new List<PersCard>(); //кэш
        private List<RefTypeAddAccr> _typeAddAccrs = new List<RefTypeAddAccr>(); //кэш

        private AddAccrRepository _repoAddAccr = new AddAccrRepository(SetupProgram.Connection);
        private PersCardRepository _repoPersCard = new PersCardRepository(SetupProgram.Connection);
        private RefDepRepository _repoDep = new RefDepRepository(SetupProgram.Connection);
        private RefTypeAddAccrRepository _repoTypeAddAccr = new RefTypeAddAccrRepository(SetupProgram.Connection);

        //Параметры запроса
        private int _depId = 0;
        private DateTime _datBeg = DateTime.MinValue;
        private DateTime _datEnd = DateTime.MinValue;

        //Вставка строки
        private void InsertRecord()
        {
            fmAddAccrEdit fmEdit = new fmAddAccrEdit(EnumFormMode.Insert, "Створення додаткового нарахування");
            AddAccr accrSet = new AddAccr();
            int month = SalaryHelper.GetMonthByIndex(cmbCalendar.SelectedIndex, true);

            if (month == 0)
            {
                accrSet.AddAccr_Date = DateTime.MinValue.AddYears(DateTime.Today.Year - 1).AddMonths(DateTime.Today.Month - 1);
            }
            else
            {
                int year = SalaryHelper.GetYearByIndex(DateTime.Today.Year - SetupProgram.YearSalary, cmbCalendar.SelectedIndex, true);
                accrSet.AddAccr_Date = DateTime.MinValue.AddYears(year - 1).AddMonths(month - 1);
            }

            if (MenuItemDeps.CheckState == CheckState.Checked && dgvDep.CurrentRow != null)
            {
                v_Dep dep = dgvDep.CurrentRow.DataBoundItem as v_Dep;
                if (dep != null)
                    accrSet.AddAccr_RefDep_Id = dep.Id;
            }
            fmEdit.SetData(accrSet);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                AddAccr accrGet = fmEdit.GetData();
                int id = _repoAddAccr.AddAddAccr(accrGet, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableAddAccr(_depId, _datBeg, _datEnd);
                dgvAddAccr.SetPositionRow<v_AddAccr>("AddAccr_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvAddAccr.CurrentRow == null) return;
            v_AddAccr addAccrSet = dgvAddAccr.CurrentRow.DataBoundItem as v_AddAccr;
            if (addAccrSet == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmAddAccrEdit fmEdit = new fmAddAccrEdit(EnumFormMode.Edit, "Зміна додаткового нарахування");
            fmEdit.SetData(addAccrSet);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                AddAccr addAccrGet = fmEdit.GetData();
                string error;
                if (!_repoAddAccr.ModifyAddAccr(addAccrGet, out error))
                {
                    MessageBox.Show("Помилка оновлення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableAddAccr(_depId, _datBeg, _datEnd);
            }
        }
        //Физическое удаление строки
        private void DeleteRecord()
        {
            List<v_AddAccr> checkedAddAccrs = dgvAddAccr.GetCheckedRecords<v_AddAccr>();
            if (checkedAddAccrs.Count > 0)
            {
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обрані рядки?", 
                    "Видалення", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Coffee.Init("Видалення...");
                    foreach (v_AddAccr addAccr in checkedAddAccrs)
                    {
                        string error;
                        if (!_repoAddAccr.DeleteAddAccr(addAccr.AddAccr_Id, out error))
                        {
                            MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                            break;
                        }

                    }
                    Coffee.Term();
                    RefreshTableAddAccr(_depId, _datBeg, _datEnd);
                }
            }
            else
            {
                if (dgvAddAccr.CurrentRow == null) return;
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                v_AddAccr addAccr = dgvAddAccr.CurrentRow.DataBoundItem as v_AddAccr;
                if (addAccr == null)
                {
                    MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                    return;
                }
                string error;
                if (!_repoAddAccr.DeleteAddAccr(addAccr.AddAccr_Id, out error))
                {
                    MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableAddAccr(_depId, _datBeg, _datEnd);
            }
        }

        private void RefreshTables()
        {
            if (dgvDep.Focused)
            {
                RefreshTableDep();
                RefreshTableAddAccr(_depId, _datBeg, _datEnd);
            }
            if (dgvAddAccr.Focused)
            {
                RefreshTableAddAccr(_depId, _datBeg, _datEnd);
            }
        }
        //Перезачитать данные таблицы
        private void RefreshTableAddAccr(int depId, DateTime dtBeg, DateTime dtEnd)
        {
            dgvAddAccr.StorePosition();
            dgvAddAccr.StoreSort();
            LoadDataToGridAddAccr(0, depId, dtBeg, dtEnd);
            UpdateAddAccrResult();
            dgvAddAccr.RestSort<v_AddAccr>();
            dgvAddAccr.RestPosition();
        }
        //Перезачитать данные таблицы
        private void RefreshTableDep()
        {
            //Отпишемся от событий чтобы предотвратить "лишние" срабатывания
            dgvDep.SelectionChanged -= new EventHandler(dgvDep_SelectionChanged);

            dgvDep.StorePosition();
            LoadDataToGridDep();
            dgvDep.RestPosition();

            dgvDep.SelectionChanged += new EventHandler(dgvDep_SelectionChanged);
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
        //Инициализация грида подразделений
        private void InitGridDep()
        {
            dgvDep.BaseGrigStyle();
        }
        //Инициализация грида дополнительные начисления
        private void InitGridAddAccr()
        {
            dgvAddAccr.BaseGrigStyle();
            dgvAddAccr.AddBirdColumn();
            dgvAddAccr.AddRefreshMenu(RefreshMenu);
            dgvAddAccr.AddSortGrid<v_AddAccr>("AddAccr_Id");
            dgvAddAccr.AddSearchGrid();
            dgvAddAccr.AddStatusStripRow(statusStripRow, true);
        }

        //Загрузка данных в грид "Подразделения"
        private bool LoadDataToGridDep()
        {
            string error;
            _refDeps = _repoDep.GetAllDeps(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження підрозділів.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            source.DataSource = GetViewDeps(_refDeps);
            dgvDep.DataSource = source;
            return true;
        }
        //Загрузка данных в грид "Доп. начисления"
        private bool LoadDataToGridAddAccr(int addAccrId, int depId, DateTime datBeg, DateTime datEnd)
        {
            string error;
            _addAccrs = _repoAddAccr.GetAddAccrByParams(addAccrId, depId, datBeg, datEnd, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження додаткових нарахуваннь.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            _persCards = _repoPersCard.GetAllCards(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження карток обліку.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if (_refDeps.Count == 0)
            {
                _refDeps = _repoDep.GetAllDeps(out error);
                if (error != string.Empty)
                {
                    MessageBox.Show("Помилка завантаження підрозділів.\nТехнічна інформація: " + error, "Помилка");
                    return false;
                }
            }
            _typeAddAccrs = _repoTypeAddAccr.GetAllTypeAddAccr(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження додаткових типів нарахувань.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }

            BindingSource source = new BindingSource();
            _vAddAccr = GetViewAddAccrs(_addAccrs, _persCards, _refDeps, _typeAddAccrs);
            source.DataSource = _vAddAccr;
            dgvAddAccr.DataSource = source;
            return true;
        }
        //Получить view "Подразделения"
        private List<v_Dep> GetViewDeps(List<RefDep> deps)
        {
            return deps.Select(dep => new v_Dep
            {
                Id = dep.RefDep_Id,
                Name = dep.RefDep_Cd + "." + dep.RefDep_Nm
            }).ToList();
        }
        //Получить view "Дополнительные начисления"
        private List<v_AddAccr> GetViewAddAccrs(List<AddAccr> addAccrs, List<PersCard> cards, List<RefDep> deps, List<RefTypeAddAccr> typeAddAccrs)
        {
            List<v_AddAccr> res = (from addAccr in addAccrs
                                   join card in cards on addAccr.AddAccr_PersCard_Id equals card.PersCard_Id
                                  join dep in deps on addAccr.AddAccr_RefDep_Id equals dep.RefDep_Id
                                  join typeAddAccr in typeAddAccrs on addAccr.AddAccr_RefTypeAddAccr_Id equals typeAddAccr.RefTypeAddAccr_Id
                                   select new v_AddAccr
                                  {
                                      AddAccr_Id = addAccr.AddAccr_Id,
                                      AddAccr_PersCard_Id = addAccr.AddAccr_PersCard_Id,
                                      AddAccr_RefDep_Id = addAccr.AddAccr_RefDep_Id,
                                      AddAccr_RefTypeAddAccr_Id = addAccr.AddAccr_RefTypeAddAccr_Id,
                                      AddAccr_Date = addAccr.AddAccr_Date,
                                      AddAccr_Sm = addAccr.AddAccr_Sm,
                                      PersCard_FullName = card.PersCard_LName + " " + card.PersCard_FName.Substring(0, 1) + ". " + card.PersCard_MName.Substring(0, 1) + ".",
                                      PersCard_TIN = card.PersCard_TIN,
                                      RefDep_Name = dep.RefDep_Nm,
                                      AddAccr_RefTypeAddAccr_Nm = typeAddAccr.RefTypeAddAccr_Nm
                                   }).ToList();
            return res;
        }
        //Показать навигатор подразделений
        private void ShowNavigatorDeps(bool isShow)
        {
            _depId = 0;
            if (isShow)
            {
                left_pnl.Visible = true;
                if (dgvDep.RowCount != 0)
                {
                    if (dgvDep.CurrentRow == null)
                    {
                        dgvDep.CurrentCell = dgvDep.Rows[0].Cells[0];
                    }
                    v_Dep dep = dgvDep.CurrentRow.DataBoundItem as v_Dep;

                    if (dep == null)
                    {
                        MessageBox.Show("Помилка вибору підрозділу.\nТехнічна інформація: dep == null", "Помилка");
                        return;
                    }
                    _depId = dep.Id;
                }
            }
            else
            {
                left_pnl.Visible = false;
            }
            LoadDataToGridAddAccr(0, _depId, _datBeg, _datEnd);
            UpdateAddAccrResult();
        }

        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvAddAccr.CurrentRow != null && dgvAddAccr.Focused ? true : false;
            MenuItemCreate.Enabled = true && dgvAddAccr.Focused;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled;
            ContextMenuEdit.Enabled = MenuItemEdit.Enabled;
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled;
        }
        //Подсчитать и обновить итоги
        private void UpdateAddAccrResult()
        {
            StatTotSm.Text = "Всього сума: " + _vAddAccr.Sum(rec => rec.AddAccr_Sm).ToString() + " грн."; 
        } 
        public fmAddAccr(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Додаткові нарахування");
        }

        private void fmAddAccr_Load(object sender, EventArgs e)
        {
            //Отпишемся от событий чтобы предотвратить "лишние" срабатывания при наcтройке
            cmbCalendar.SelectedIndexChanged -= new EventHandler(cmbCalendar_SelectedIndexChanged);
            dgvDep.SelectionChanged -= new EventHandler(dgvDep_SelectionChanged);

            InitCmbCalendar();
            cmbCalendar.SelectedIndex = cmbCalendar.Items.Count - 1;
            InitGridDep();
            if (!LoadDataToGridDep())
                return;

            InitGridAddAccr();

            if (MenuItemDeps.CheckState == CheckState.Checked && dgvDep.RowCount != 0)
            {
                dgvDep.CurrentCell = dgvDep.Rows[0].Cells[0];
                v_Dep dep = dgvDep.CurrentRow.DataBoundItem as v_Dep;
                if (dep == null)
                {
                    MessageBox.Show("Помилка вибору підрозділу.\nТехнічна інформація: dep == null", "Помилка");
                    return;
                }
                _depId = dep.Id;
            }
            else
            {
                _depId = 0;
            }
            GetDateBySelectCmbCalendar(ref _datBeg, ref _datEnd);
            if (_datBeg == DateTime.MinValue || _datEnd == DateTime.MinValue)
            {
                MessageBox.Show("Помилка вибору підрозділу.\nТехнічна інформація: _datBeg == DateTime.MinValue || _dateEnd == DateTime.MinValue", "Помилка");
                return;
            }
            if (!LoadDataToGridAddAccr(0, _depId, _datBeg, _datEnd))
                return;
            UpdateAddAccrResult();
            //Восстновим подписку на события
            cmbCalendar.SelectedIndexChanged += new EventHandler(cmbCalendar_SelectedIndexChanged);
            dgvDep.SelectionChanged += new EventHandler(dgvDep_SelectionChanged);
        }

        private void fmAddAccr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvDep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvAddAccr_KeyDown(object sender, KeyEventArgs e)
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
            LoadDataToGridAddAccr(0, _depId, _datBeg, _datEnd);
            UpdateAddAccrResult();
        }

        private void dgvDep_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDep.CurrentRow == null)
                return;

            if (_datBeg == DateTime.MinValue || _datEnd == DateTime.MinValue)
            {
                MessageBox.Show("Помилка вибору періода.\nТехнічна інформація: _datBeg == DateTime.MinValue || _dateEnd == DateTime.MinValue", "Помилка");
                return;
            }

            v_Dep dep = dgvDep.CurrentRow.DataBoundItem as v_Dep;

            if (dep == null)
            {
                MessageBox.Show("Помилка вибору підрозділу.\nТехнічна інформація: dep == null", "Помилка");
                return;
            }

            _depId = dep.Id;
            LoadDataToGridAddAccr(0, _depId, _datBeg, _datEnd);
            UpdateAddAccrResult();
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
            RefreshTables();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuItemDeps_Click(object sender, EventArgs e)
        {
            MenuItemDeps.CheckState = MenuItemDeps.CheckState == CheckState.Checked ?
               CheckState.Unchecked : CheckState.Checked;
            ContextMenuDeps.CheckState = MenuItemDeps.CheckState;
            ShowNavigatorDeps(MenuItemDeps.CheckState == CheckState.Checked);
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

        private void ContextMenuDeps_Click(object sender, EventArgs e)
        {
            ContextMenuDeps.CheckState = ContextMenuDeps.CheckState == CheckState.Checked ?
               CheckState.Unchecked : CheckState.Checked;
            MenuItemDeps.CheckState = ContextMenuDeps.CheckState;
            ShowNavigatorDeps(ContextMenuDeps.CheckState == CheckState.Checked);
        }
    }
}
