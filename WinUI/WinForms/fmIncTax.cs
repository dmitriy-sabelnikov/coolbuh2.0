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
    public partial class fmIncTax : Form
    {
        private PersCardRepository _repoPersCard = new PersCardRepository(SetupProgram.Connection);
        private IncTaxRepository _repoIncTax = new IncTaxRepository(SetupProgram.Connection);

        private List<PersCard> _persCards = new List<PersCard>(); //кэш
        private List<IncTax> _incTaxs = new List<IncTax>(); //кэш
        private List<v_IncTax> _vIncTaxs = new List<v_IncTax>(); //кэш

        //Параметры запроса
        private DateTime _datBeg = DateTime.MinValue;
        private DateTime _datEnd = DateTime.MinValue;

        //Вставка строки
        private void InsertRecord()
        {
            fmIncTaxEdit fmEdit = new fmIncTaxEdit(EnumFormMode.Insert, "Створення корегування прибуткового податку");
            IncTax setIncTax = new IncTax();
            int month = SalaryHelper.GetMonthByIndex(cmbCalendar.SelectedIndex, true);

            if (month == 0)
            {
                setIncTax.IncTax_Date = DateTime.MinValue.AddYears(DateTime.Today.Year - 1).AddMonths(DateTime.Today.Month - 1);
            }
            else
            {
                int year = SalaryHelper.GetYearByIndex(DateTime.Today.Year - SetupProgram.YearSalary, cmbCalendar.SelectedIndex, true);
                setIncTax.IncTax_Date = DateTime.MinValue.AddYears(year - 1).AddMonths(month - 1);
            }

            fmEdit.SetData(setIncTax);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                IncTax getIncTax = fmEdit.GetData();
                int id = _repoIncTax.AddIncTax(getIncTax, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTables();
                dgvIncTax.SetPositionRow<v_IncTax>("IncTax_Id", id.ToString());
            }
        }

        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvIncTax.CurrentRow == null) return;
            v_IncTax vIncTax = dgvIncTax.CurrentRow.DataBoundItem as v_IncTax;
            if (vIncTax == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmIncTaxEdit fmEdit = new fmIncTaxEdit(EnumFormMode.Edit, "Зміна корегування прибуткового податку");
            fmEdit.SetData(vIncTax);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                IncTax IncTax = fmEdit.GetData();
                string error;
                if (!_repoIncTax.ModifyIncTax(IncTax, out error))
                {
                    MessageBox.Show("Помилка оновлення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTables();
            }
        }

        //Физическое удаление строки
        private void DeleteRecord()
        {
            List<v_IncTax> checkedIncTaxs = dgvIncTax.GetCheckedRecords<v_IncTax>();
            if (checkedIncTaxs.Count > 0)
            {
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обрані рядки?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Coffee.Init("Видалення...");
                    foreach (v_IncTax incTax in checkedIncTaxs)
                    {
                        string error;
                        if (!_repoIncTax.DeleteIncTax(incTax.IncTax_Id, out error))
                        {
                            MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                            break;
                        }

                    }
                    Coffee.Term();
                    RefreshTables();
                }
            }
            else
            {
                if (dgvIncTax.CurrentRow == null) return;
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                v_IncTax IncTax = dgvIncTax.CurrentRow.DataBoundItem as v_IncTax;
                if (IncTax == null)
                {
                    MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                    return;
                }
                string error;
                if (!_repoIncTax.DeleteIncTax(IncTax.IncTax_Id, out error))
                {
                    MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTables();
            }
        }
        //Перезачитать данные таблицы
        private void RefreshTables()
        {
            dgvIncTax.StorePosition();
            dgvIncTax.StoreSort();
            LoadDataToGridIncTax(0, _datBeg, _datEnd);
            UpdateIncTaxResult();
            dgvIncTax.RestSort<v_IncTax>();
            dgvIncTax.RestPosition();
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
        //Инициализация грида Корректировка подоходного налога
        private void InitGridIncTax()
        {
            dgvIncTax.BaseGrigStyle();
            dgvIncTax.AddBirdColumn();
            dgvIncTax.AddRefreshMenu(RefreshMenu);
            dgvIncTax.AddSortGrid<v_IncTax>("IncTax_Id");
            dgvIncTax.AddSearchGrid();
            dgvIncTax.AddStatusStripRow(statusStripRow, true);
        }
        //Загрузка данных в грид "Корректировка подоходного налога"
        private bool LoadDataToGridIncTax(int IncTaxId, DateTime datBeg, DateTime datEnd)
        {
            string error;
            _incTaxs = _repoIncTax.GetIncTaxByParams(IncTaxId, datBeg, datEnd, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження прибуткових податків.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            _persCards = _repoPersCard.GetAllCards(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження карток обліку.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            _vIncTaxs = GetViewIncTaxs(_incTaxs, _persCards);
            source.DataSource = _vIncTaxs;
            dgvIncTax.DataSource = source;
            return true;
        }

        //Получить view "Корректировка подоходного налога"
        private List<v_IncTax> GetViewIncTaxs(List<IncTax> incTaxs, List<PersCard> cards)
        {
            List<v_IncTax> res = (from incTax in incTaxs
                                       join card in cards on incTax.IncTax_PersCard_Id equals card.PersCard_Id
                                       select new v_IncTax
                                       {
                                           IncTax_Id = incTax.IncTax_Id,
                                           IncTax_PersCard_Id = incTax.IncTax_PersCard_Id,
                                           IncTax_Date = incTax.IncTax_Date,
                                           IncTax_Sm = incTax.IncTax_Sm,
                                           PersCard_FullName = card.PersCard_LName + " " + card.PersCard_FName.Substring(0, 1) + ". " + card.PersCard_MName.Substring(0, 1) + ".",
                                           PersCard_TIN = card.PersCard_TIN,
                                       }).ToList();
            return res;
        }

        //Обновление меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvIncTax.CurrentRow != null && dgvIncTax.Focused ? true : false;
            MenuItemCreate.Enabled = true && dgvIncTax.Focused;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled;
            ContextMenuEdit.Enabled = MenuItemEdit.Enabled;
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled;
        }

        //Подсчитать и обновить итоги
        private void UpdateIncTaxResult()
        {
            StatTotSm.Text = "Всього сума: " + _vIncTaxs.Sum(rec => rec.IncTax_Sm).ToString() + " грн.";
        }

        public fmIncTax(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Корегування прибуткового податку");
        }

        private void fmIncTax_Load(object sender, EventArgs e)
        {
            //Отпишемся от событий чтобы предотвратить "лишние" срабатывания при наcтройке
            cmbCalendar.SelectedIndexChanged -= new EventHandler(cmbCalendar_SelectedIndexChanged);

            InitCmbCalendar();
            cmbCalendar.SelectedIndex = cmbCalendar.Items.Count - 1;

            InitGridIncTax();
            GetDateBySelectCmbCalendar(ref _datBeg, ref _datEnd);
            if (_datBeg == DateTime.MinValue || _datEnd == DateTime.MinValue)
            {
                MessageBox.Show("Помилка вибору періоду.\nТехнічна інформація: _datBeg == DateTime.MinValue || _dateEnd == DateTime.MinValue", "Помилка");
                return;
            }
            if (!LoadDataToGridIncTax(0, _datBeg, _datEnd))
                return;
            UpdateIncTaxResult();
            //Восстановим подписку на события
            cmbCalendar.SelectedIndexChanged += new EventHandler(cmbCalendar_SelectedIndexChanged);
        }

        private void fmIncTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvIncTax_KeyDown(object sender, KeyEventArgs e)
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
            LoadDataToGridIncTax(0, _datBeg, _datEnd);
            UpdateIncTaxResult();
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
    }
}
