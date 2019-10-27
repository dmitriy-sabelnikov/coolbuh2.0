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
    public partial class fmRefMinSalary : Form
    {
        private RefMinSalaryRepository _repository = new RefMinSalaryRepository(SetupProgram.Connection);
        private List<RefMinSalary> minSalaries = null; //Кеширование
        //Вставка строки
        private void InsertRecord()
        {
            fmRefMinSalaryEdit fmEdit = new fmRefMinSalaryEdit(EnumFormMode.Insert, "Створення інтервалу мінімальної зарплати");
            fmEdit.AddControlPeriod(minSalaries);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                RefMinSalary refMinSalary = fmEdit.GetData();
                int id = _repository.AddRefMinSalary(refMinSalary, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
                dgvRefMinSalary.SetPositionRow<RefMinSalary>("RefMinSalary_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvRefMinSalary.CurrentRow == null) return;
            string error;
            RefMinSalary refMinSalary = dgvRefMinSalary.CurrentRow.DataBoundItem as RefMinSalary;
            if (refMinSalary == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmRefMinSalaryEdit fmEdit = new fmRefMinSalaryEdit(EnumFormMode.Edit, "Зміна інтервалу мінімальної зарплати");
            fmEdit.SetData(refMinSalary);
            fmEdit.AddControlPeriod(minSalaries);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                refMinSalary = fmEdit.GetData();
                if (!_repository.ModifyRefMinSalary(refMinSalary, out error))
                {
                    MessageBox.Show("Помилка оновлення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
            }
        }
        //Физическое удаление строки
        private void DeleteRecord()
        {
            if (dgvRefMinSalary.CurrentRow == null) return;
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            RefMinSalary refMinSalary = dgvRefMinSalary.CurrentRow.DataBoundItem as RefMinSalary;
            if (refMinSalary == null)
            {
                MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                return;
            }
            string error;
            if (!_repository.DeleteRefMinSalary(refMinSalary.RefMinSalary_Id, out error))
            {
                MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            RefreshTable();
        }
        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvRefMinSalary.CurrentRow == null ? false : true;
            MenuItemCreate.Enabled = true;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled;
            ContextMenuEdit.Enabled = MenuItemEdit.Enabled;
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled;
        }

        //Перезачитать данные таблицы
        private void RefreshTable()
        {
            dgvRefMinSalary.StorePosition();
            dgvRefMinSalary.StoreSort();
            LoadDataToGridRefMinSalary();
            dgvRefMinSalary.RestSort<RefMinSalary>();
            dgvRefMinSalary.RestPosition();
        }
        //Инициализация грида
        private void InitGridRefMinSalary()
        {
            dgvRefMinSalary.BaseGrigStyle();
            dgvRefMinSalary.AddRefreshMenu(RefreshMenu);
            dgvRefMinSalary.AddSortGrid<RefMinSalary>("RefMinSalary_Id");
            dgvRefMinSalary.AddSearchGrid();
            dgvRefMinSalary.AddStatusStripRow(statusStripRow, false);
        }
        //Загрузка данных в грид
        private bool LoadDataToGridRefMinSalary()
        {
            string error;
            minSalaries = _repository.GetAllRefMinSalaries(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження типів додатковиз виплат.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }

            BindingSource source = new BindingSource();
            source.DataSource = minSalaries;
            dgvRefMinSalary.DataSource = source;
            return true;
        }
        public fmRefMinSalary(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Мінімальна зарплата");
            InitGridRefMinSalary();
            LoadDataToGridRefMinSalary();
        }

        private void fmRefMinSalary_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void dgvRefMinSalary_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        //-----------------------------------События меню--------------------------------------
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
            RefreshTable();
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
            RefreshTable();
        }
    }
}
