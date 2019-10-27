using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormExtensions;
using DAL;
using Entities;
using BLL;
using EnumType;


namespace WinUI.WinForms
{
    public partial class fmSickList : Form
    {
        private PersCardRepository _repoPersCard = new PersCardRepository(SetupProgram.Connection);
        private SickListRepository _repoSickList = new SickListRepository(SetupProgram.Connection);
        private RefDepRepository _repoDep = new RefDepRepository(SetupProgram.Connection);

        private List<RefDep> _refDeps = new List<RefDep>(); //кэш
        private List<SickList> _sickLists = new List<SickList>(); //кэш
        private List<v_SickList> _vSickLists = new List<v_SickList>(); //кэш
        private List<PersCard> _persCards = new List<PersCard>(); //кэш
        //Параметры запроса
        private int _depId = 0;
        private DateTime _datBeg = DateTime.MinValue;
        private DateTime _datEnd = DateTime.MinValue;

        //Вставка строки
        private void InsertRecord()
        {
            fmSickListEdit fmEdit = new fmSickListEdit(EnumFormMode.Insert, "Створення лікарняного");
            SickList setSickList = new SickList();
            int month = SalaryHelper.GetMonthByIndex(cmbCalendar.SelectedIndex, true);

            if (month == 0)
            {
                setSickList.SickList_Date = DateTime.MinValue.AddYears(DateTime.Today.Year - 1).AddMonths(DateTime.Today.Month - 1);
            }
            else
            {
                int year = SalaryHelper.GetYearByIndex(DateTime.Today.Year - SetupProgram.YearSalary, cmbCalendar.SelectedIndex, true);
                setSickList.SickList_Date = DateTime.MinValue.AddYears(year - 1).AddMonths(month - 1);
            }

            if (MenuItemDeps.CheckState == CheckState.Checked && dgvDep.CurrentRow != null)
            {
                v_Dep dep = dgvDep.CurrentRow.DataBoundItem as v_Dep;
                if (dep != null)
                    setSickList.SickList_RefDep_Id = dep.Id;
            }
            fmEdit.SetData(setSickList);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                SickList getSickList = fmEdit.GetData();
                int id = _repoSickList.AddSickList(getSickList, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableSickList(_depId, _datBeg, _datEnd);
                dgvSickList.SetPositionRow<v_SickList>("SickList_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvSickList.CurrentRow == null) return;
            v_SickList vSickList = dgvSickList.CurrentRow.DataBoundItem as v_SickList;
            if (vSickList == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmSickListEdit fmEdit = new fmSickListEdit(EnumFormMode.Edit, "Зміна лікарняного");
            fmEdit.SetData(vSickList);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                SickList SickList = fmEdit.GetData();
                string error;
                if (!_repoSickList.ModifySickList(SickList, out error))
                {
                    MessageBox.Show("Помилка оновлення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableSickList(_depId, _datBeg, _datEnd);
            }
        }
        //Физическое удаление строки
        private void DeleteRecord()
        {
            List<v_SickList> checkedSickLists = dgvSickList.GetCheckedRecords<v_SickList>();
            if (checkedSickLists.Count > 0)
            {
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обрані рядки?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Coffee.Init("Видалення...");
                    foreach (v_SickList SickList in checkedSickLists)
                    {
                        string error;
                        if (!_repoSickList.DeleteSickList(SickList.SickList_Id, out error))
                        {
                            MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                            break;
                        }

                    }
                    Coffee.Term();
                    RefreshTableSickList(_depId, _datBeg, _datEnd);
                }
            }
            else
            {
                if (dgvSickList.CurrentRow == null) return;
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обаний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                v_SickList SickList = dgvSickList.CurrentRow.DataBoundItem as v_SickList;
                if (SickList == null)
                {
                    MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                    return;
                }
                string error;
                if (!_repoSickList.DeleteSickList(SickList.SickList_Id, out error))
                {
                    MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableSickList(_depId, _datBeg, _datEnd);
            }
        }

        private void RefreshTables()
        {
            if (dgvDep.Focused)
            {
                RefreshTableDep();
                RefreshTableSickList(_depId, _datBeg, _datEnd);
            }
            if (dgvSickList.Focused)
            {
                RefreshTableSickList(_depId, _datBeg, _datEnd);
            }
        }
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
            LoadDataToGridSickList(0, _depId, _datBeg, _datEnd);
            UpdateSickListResult();
        }
        //Перезачитать данные таблицы
        private void RefreshTableSickList(int depId, DateTime dtBeg, DateTime dtEnd)
        {
            dgvSickList.StorePosition();
            dgvSickList.StoreSort();
            LoadDataToGridSickList(0, depId, dtBeg, dtEnd);
            UpdateSickListResult();
            dgvSickList.RestSort<v_SickList>();
            dgvSickList.RestPosition();
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
        //Инициализация грида больничных
        private void InitGridSickList()
        {
            dgvSickList.BaseGrigStyle();
            dgvSickList.AddBirdColumn();
            dgvSickList.AddRefreshMenu(RefreshMenu);
            dgvSickList.AddSortGrid<v_SickList>("SickList_Id");
            dgvSickList.AddSearchGrid();
            dgvSickList.AddStatusStripRow(statusStripRow, true);
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
        //Загрузка данных в грид "Больничные"
        private bool LoadDataToGridSickList(int SickListId, int depId, DateTime datBeg, DateTime datEnd)
        {
            string error;
            _sickLists = _repoSickList.GetSickListsByParams(SickListId, depId, datBeg, datEnd, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження зарплати.\nТехнічна інформація: " + error, "Помилка");
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

            BindingSource source = new BindingSource();
            _vSickLists = GetViewSickLists(_sickLists, _persCards, _refDeps);
            source.DataSource = _vSickLists;
            dgvSickList.DataSource = source;
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

        //Получить view "Больничные"
        private List<v_SickList> GetViewSickLists(List<SickList> sickLists, List<PersCard> cards, List<RefDep> deps)
        {
            List<v_SickList> res = (from sickList in sickLists
                                    join card in cards on sickList.SickList_PersCard_Id equals card.PersCard_Id
                                    join dep in deps on sickList.SickList_RefDep_Id equals dep.RefDep_Id
                                    select new v_SickList
                                    {
                                        SickList_Id = sickList.SickList_Id,
                                        SickList_PersCard_Id = sickList.SickList_PersCard_Id,
                                        SickList_RefDep_Id = sickList.SickList_RefDep_Id,
                                        SickList_Date = sickList.SickList_Date,
                                        SickList_DaysEntprs = sickList.SickList_DaysEntprs,
                                        SickList_SmEntprs = sickList.SickList_SmEntprs,
                                        SickList_DaysSocInsrnc = sickList.SickList_DaysSocInsrnc,
                                        SickList_SmSocInsrnc = sickList.SickList_SmSocInsrnc,
                                        SickList_PayDate = sickList.SickList_PayDate,
                                        SickList_DaysTmpDis = sickList.SickList_DaysTmpDis,
                                        SickList_ResSm = sickList.SickList_ResSm,
                                        PersCard_FullName = card.PersCard_LName + " " + card.PersCard_FName.Substring(0, 1) + ". " + card.PersCard_MName.Substring(0, 1) + ".",
                                        PersCard_TIN = card.PersCard_TIN,
                                        RefDep_Name = dep.RefDep_Nm
                                    }).ToList();
            return res;
        }
        //Обновление меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvSickList.CurrentRow != null && dgvSickList.Focused ? true : false;
            MenuItemCreate.Enabled = true && dgvSickList.Focused;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled; 
            ContextMenuEdit.Enabled = MenuItemEdit.Enabled;   
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled; 
        }

        //Подсчитать и обновить итоги
        private void UpdateSickListResult()
        {
            StatTotDaysEntprs.Text = "Всього дні (підприємство): " + _vSickLists.Sum(rec => rec.SickList_DaysEntprs).ToString();
            StatTotSmEntprs.Text = "Всього сума (підприємство): " + _vSickLists.Sum(rec => rec.SickList_SmEntprs).ToString();
            StatTotDaysSocInsrnc.Text = "Всього дні (соцстрах): " + _vSickLists.Sum(rec => rec.SickList_DaysSocInsrnc).ToString();
            StatTotSmSocInsrnc.Text = "Всього сума (соцстрах): " + _vSickLists.Sum(rec => rec.SickList_SmSocInsrnc).ToString();
            StatTotResDays.Text = "Всього дні: " + _vSickLists.Sum(rec => rec.SickList_DaysTmpDis).ToString();
            StatTotResSm.Text = "Всього сума: " + _vSickLists.Sum(rec => rec.SickList_ResSm).ToString();
        }
        public fmSickList(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Лікарняні");
        }

        private void fmSickList_Load(object sender, EventArgs e)
        {
            //Отпишемся от событий чтобы предотвратить "лишние" срабатывания при наcтройке
            cmbCalendar.SelectedIndexChanged -= new EventHandler(cmbCalendar_SelectedIndexChanged);
            dgvDep.SelectionChanged -= new EventHandler(dgvDep_SelectionChanged);

            InitCmbCalendar();
            cmbCalendar.SelectedIndex = cmbCalendar.Items.Count - 1;
            InitGridDep();
            if (!LoadDataToGridDep())
                return;

            InitGridSickList();

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
                MessageBox.Show("Помилка вибору періоду.\nТехнічна інформація: _datBeg == DateTime.MinValue || _dateEnd == DateTime.MinValue", "Помилка");
                return;
            }
            if (!LoadDataToGridSickList(0, _depId, _datBeg, _datEnd))
                return;
            UpdateSickListResult();
            //Восстновим подписку на события
            cmbCalendar.SelectedIndexChanged += new EventHandler(cmbCalendar_SelectedIndexChanged);
            dgvDep.SelectionChanged += new EventHandler(dgvDep_SelectionChanged);
        }

        private void fmSickList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvSickList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvDep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void cmbCalendar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDateBySelectCmbCalendar(ref _datBeg, ref _datEnd);
            if (_datBeg == DateTime.MinValue || _datEnd == DateTime.MinValue)
            {
                MessageBox.Show("Помилка вибору періоду.\nТехнічна інформація: _datBeg == DateTime.MinValue || _dateEnd == DateTime.MinValue", "Помилка");
                return;
            }
            LoadDataToGridSickList(0, _depId, _datBeg, _datEnd);
            UpdateSickListResult();
        }

        private void dgvDep_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDep.CurrentRow == null)
                return;

            if (_datBeg == DateTime.MinValue || _datEnd == DateTime.MinValue)
            {
                MessageBox.Show("Помилка вибору періоду.\nТехнічна інформація: _datBeg == DateTime.MinValue || _dateEnd == DateTime.MinValue", "Помилка");
                return;
            }

            v_Dep dep = dgvDep.CurrentRow.DataBoundItem as v_Dep;

            if (dep == null)
            {
                MessageBox.Show("Помилка вибору підрозділу.\nТехнічна інформація: dep == null", "Помилка");
                return;
            }

            _depId = dep.Id;
            LoadDataToGridSickList(0, _depId, _datBeg, _datEnd);
            UpdateSickListResult();
        }

        private void MenuItemDeps_Click(object sender, EventArgs e)
        {
            MenuItemDeps.CheckState = MenuItemDeps.CheckState == CheckState.Checked ?
               CheckState.Unchecked : CheckState.Checked;
            ContextMenuDeps.CheckState = MenuItemDeps.CheckState;
            ShowNavigatorDeps(MenuItemDeps.CheckState == CheckState.Checked);
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
