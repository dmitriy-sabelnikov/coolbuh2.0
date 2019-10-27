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
    public partial class fmLawContract : Form
    {
        private PersCardRepository _repoPersCard = new PersCardRepository(SetupProgram.Connection);
        private LawContractRepository _repoLawContract = new LawContractRepository(SetupProgram.Connection);
        private RefDepRepository _repoDep = new RefDepRepository(SetupProgram.Connection);

        private List<RefDep> _refDeps = new List<RefDep>(); //кэш
        private List<LawContract> _lawContracts = new List<LawContract>(); //кэш
        private List<v_LawContract> _vLawContracts = new List<v_LawContract>(); //кэш
        private List<PersCard> _persCards = new List<PersCard>(); //кэш
        //Параметры запроса
        private int _depId = 0;
        private DateTime _datBeg = DateTime.MinValue;
        private DateTime _datEnd = DateTime.MinValue;

        //Вставка строки
        private void InsertRecord()
        {
            fmLawContractEdit fmEdit = new fmLawContractEdit(EnumFormMode.Insert, "Створення договора ЦПХ");
            LawContract setLawContract = new LawContract();
            int month = SalaryHelper.GetMonthByIndex(cmbCalendar.SelectedIndex, true);

            if (month == 0)
            {
                setLawContract.LawContract_Date = DateTime.MinValue.AddYears(DateTime.Today.Year - 1).AddMonths(DateTime.Today.Month - 1);
            }
            else
            {
                int year = SalaryHelper.GetYearByIndex(DateTime.Today.Year - SetupProgram.YearSalary, cmbCalendar.SelectedIndex, true);
                setLawContract.LawContract_Date = DateTime.MinValue.AddYears(year - 1).AddMonths(month - 1);
            }

            if (MenuItemDeps.CheckState == CheckState.Checked && dgvDep.CurrentRow != null)
            {
                v_Dep dep = dgvDep.CurrentRow.DataBoundItem as v_Dep;
                if (dep != null)
                    setLawContract.LawContract_RefDep_Id = dep.Id;
            }
            fmEdit.SetData(setLawContract);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                LawContract getLawContract = fmEdit.GetData();
                int id = _repoLawContract.AddLawContract(getLawContract, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableLawContract(_depId, _datBeg, _datEnd);
                dgvLawContract.SetPositionRow<v_LawContract>("LawContract_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvLawContract.CurrentRow == null) return;
            v_LawContract vLawContract = dgvLawContract.CurrentRow.DataBoundItem as v_LawContract;
            if (vLawContract == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmLawContractEdit fmEdit = new fmLawContractEdit(EnumFormMode.Edit, "Зміна договора ЦПХ");
            fmEdit.SetData(vLawContract);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                LawContract LawContract = fmEdit.GetData();
                string error;
                if (!_repoLawContract.ModifyLawContract(LawContract, out error))
                {
                    MessageBox.Show("Помилка оновлення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableLawContract(_depId, _datBeg, _datEnd);
            }
        }
        //Физическое удаление строки
        private void DeleteRecord()
        {
            List<v_LawContract> checkedLawContracts = dgvLawContract.GetCheckedRecords<v_LawContract>();
            if (checkedLawContracts.Count > 0)
            {
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обрані рядки?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Coffee.Init("Видалення...");
                    foreach (v_LawContract LawContract in checkedLawContracts)
                    {
                        string error;
                        if (!_repoLawContract.DeleteLawContract(LawContract.LawContract_Id, out error))
                        {
                            MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                            break;
                        }

                    }
                    Coffee.Term();
                    RefreshTableLawContract(_depId, _datBeg, _datEnd);
                }
            }
            else
            {
                if (dgvLawContract.CurrentRow == null) return;
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                v_LawContract LawContract = dgvLawContract.CurrentRow.DataBoundItem as v_LawContract;
                if (LawContract == null)
                {
                    MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                    return;
                }
                string error;
                if (!_repoLawContract.DeleteLawContract(LawContract.LawContract_Id, out error))
                {
                    MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableLawContract(_depId, _datBeg, _datEnd);
            }
        }
        private void RefreshTables()
        {
            if (dgvDep.Focused)
            {
                RefreshTableDep();
                RefreshTableLawContract(_depId, _datBeg, _datEnd);
            }
            if (dgvLawContract.Focused)
            {
                RefreshTableLawContract(_depId, _datBeg, _datEnd);
            }
        }
        //Перезачитать данные таблицы
        private void RefreshTableLawContract(int depId, DateTime dtBeg, DateTime dtEnd)
        {
            dgvLawContract.StorePosition();
            dgvLawContract.StoreSort();
            LoadDataToGridLawContract(0, depId, dtBeg, dtEnd);
            UpdateLawContractResult();
            dgvLawContract.RestSort<v_LawContract>();
            dgvLawContract.RestPosition();
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
        //Инициализация грида договора ГПХ
        private void InitGridLawContract()
        {
            dgvLawContract.BaseGrigStyle();
            dgvLawContract.AddBirdColumn();
            dgvLawContract.AddRefreshMenu(RefreshMenu);
            dgvLawContract.AddSortGrid<v_LawContract>("LawContract_Id");
            dgvLawContract.AddSearchGrid();
            dgvLawContract.AddStatusStripRow(statusStripRow, true);
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
        //Загрузка данных в грид "Договора ЦПХ"
        private bool LoadDataToGridLawContract(int LawContractId, int depId, DateTime datBeg, DateTime datEnd)
        {
            string error;
            _lawContracts = _repoLawContract.GetLawContractsByParams(LawContractId, depId, datBeg, datEnd, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження договорів ЦПХ.\nТехнічна інформація: " + error, "Помилка");
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
            _vLawContracts = GetViewLawContracts(_lawContracts, _persCards, _refDeps);
            source.DataSource = _vLawContracts;
            dgvLawContract.DataSource = source;
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
        //Получить view "Договора ЦПХ"
        private List<v_LawContract> GetViewLawContracts(List<LawContract> lawContracts, List<PersCard> cards, List<RefDep> deps)
        {
            List<v_LawContract> res = (from lawContract in lawContracts
                                      join card in cards on lawContract.LawContract_PersCard_Id equals card.PersCard_Id
                                      join dep in deps on lawContract.LawContract_RefDep_Id equals dep.RefDep_Id
                                    select new v_LawContract
                                    {
                                        LawContract_Id = lawContract.LawContract_Id,
                                        LawContract_PersCard_Id = lawContract.LawContract_PersCard_Id,
                                        LawContract_RefDep_Id = lawContract.LawContract_RefDep_Id,
                                        LawContract_Date = lawContract.LawContract_Date,
                                        LawContract_Days = lawContract.LawContract_Days,
                                        LawContract_Sm = lawContract.LawContract_Sm,
                                        LawContract_PayDate = lawContract.LawContract_PayDate,

                                        PersCard_FullName = card.PersCard_LName + " " + card.PersCard_FName.Substring(0, 1) + ". " + card.PersCard_MName.Substring(0, 1) + ".",
                                        PersCard_TIN = card.PersCard_TIN,
                                        RefDep_Name = dep.RefDep_Nm
                                    }).ToList();
            return res;
        }
        //Обновление меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvLawContract.CurrentRow != null && dgvLawContract.Focused ? true : false;
            MenuItemCreate.Enabled = true && dgvLawContract.Focused;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled;
            ContextMenuEdit.Enabled = MenuItemEdit.Enabled;
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled;
        }
        //Показать навигатор подразделений
        private void ShowNavigatorDeps(bool isShow)
        {
            _depId = 0;
            if (MenuItemDeps.CheckState == CheckState.Checked)
            {
                left_pnl.Visible = true;
                if (dgvDep.RowCount != 0)
                {
                    if (dgvDep.CurrentRow != null)
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
            LoadDataToGridLawContract(0, _depId, _datBeg, _datEnd);
            UpdateLawContractResult();
        }
        //Подсчитать и обновить итоги
        private void UpdateLawContractResult()
        {
            StatTotDays.Text = "Всього дні: " + _vLawContracts.Sum(rec => rec.LawContract_Days).ToString();
            StatTotSm.Text = "Всього сума: " + _vLawContracts.Sum(rec => rec.LawContract_Sm).ToString() + " грн.";
        }
        public fmLawContract(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Договора ЦПХ");
        }

        private void fmLawContract_Load(object sender, EventArgs e)
        {
            //Отпишемся от событий чтобы предотвратить "лишние" срабатывания при наcтройке
            cmbCalendar.SelectedIndexChanged -= new EventHandler(cmbCalendar_SelectedIndexChanged);
            dgvDep.SelectionChanged -= new EventHandler(dgvDep_SelectionChanged);

            InitCmbCalendar();
            cmbCalendar.SelectedIndex = cmbCalendar.Items.Count - 1;
            InitGridDep();
            if (!LoadDataToGridDep())
                return;

            InitGridLawContract();

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
            if (!LoadDataToGridLawContract(0, _depId, _datBeg, _datEnd))
                return;
            UpdateLawContractResult();
            //Восстновим подписку на события
            cmbCalendar.SelectedIndexChanged += new EventHandler(cmbCalendar_SelectedIndexChanged);
            dgvDep.SelectionChanged += new EventHandler(dgvDep_SelectionChanged);
        }

        private void fmLawContract_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvDep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvLawContract_KeyDown(object sender, KeyEventArgs e)
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
            LoadDataToGridLawContract(0, _depId, _datBeg, _datEnd);
            UpdateLawContractResult();
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
            LoadDataToGridLawContract(0, _depId, _datBeg, _datEnd);
            UpdateLawContractResult();
        }
        //--------------------События меню----------------------------
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
        //--------------------------------------------------------------
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
