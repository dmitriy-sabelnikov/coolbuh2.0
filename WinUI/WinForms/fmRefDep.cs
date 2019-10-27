using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DAL;
using Entities;
using BLL;
using WinFormExtensions;

namespace WinUI.WinForms
{
    public partial class fmRefDep : Form
    {
        private RefDepRepository _repository = new RefDepRepository(SetupProgram.Connection);
        private List<RefDep> refDeps = null; //Кеширование
        //Вставка строки
        private void InsertRecord()
        {
            fmRefDepEdit fmEdit = new fmRefDepEdit("Створення підрозділу");
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                RefDep refDep = fmEdit.GetData();
                int id = _repository.AddDep(refDep, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
                dgvRefDep.SetPositionRow<RefDep>("RefDep_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvRefDep.CurrentRow == null) return;
            string error;
            RefDep findDep = dgvRefDep.CurrentRow.DataBoundItem as RefDep;
            if (findDep == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmRefDepEdit fmEdit = new fmRefDepEdit("Зміна підрозділу");
            fmEdit.SetData(findDep);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                findDep = fmEdit.GetData();
                if (!_repository.ModifyDep(findDep, out error))
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
            if (dgvRefDep.CurrentRow == null) return;
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            RefDep findDep = dgvRefDep.CurrentRow.DataBoundItem as RefDep;
            if (findDep == null)
            {
                MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                return;
            }
            string error;
            if (!_repository.DeleteDep(findDep.RefDep_Id, out error))
            {
                MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            RefreshTable();
        }
        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvRefDep.CurrentRow == null ? false : true;
            MenuItemCreate.Enabled = true;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled;
            ContextMenuEdit.Enabled   = MenuItemEdit.Enabled;
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled;
        }
        //Перезачитать данные таблицы
        private void RefreshTable()
        {
            dgvRefDep.StorePosition();
            dgvRefDep.StoreSort();
            LoadDataToGridRefDep();
            dgvRefDep.RestSort<RefAdm>();
            dgvRefDep.RestPosition();
        }
        //Инициализация грида
        private void InitGridRefDep()
        {
            dgvRefDep.BaseGrigStyle();
            dgvRefDep.AddRefreshMenu(RefreshMenu);
            dgvRefDep.AddSortGrid<RefDep>("RefDep_Id");
            dgvRefDep.AddSearchGrid();
            dgvRefDep.AddStatusStripRow(statusStripRow, false);
        }
        //Загрузка данных в таблицу
        private bool LoadDataToGridRefDep()
        {
            string error;
            refDeps = _repository.GetAllDeps(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження підрозділів.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            dgvRefDep.DataSource = refDeps;
            return true;
        }
        //Функция сортировки грида
        private void SortGrid(DataGridViewCellMouseEventArgs e)
        {
            string strColumnName = dgvRefDep.Columns[e.ColumnIndex].Name;
            SortOrder strSortOrder = dgvRefDep.getSortOrder(e.ColumnIndex);

            if (strSortOrder == SortOrder.Ascending)
            {
                refDeps = refDeps.OrderBy(x => typeof(RefDep).GetProperty(strColumnName).GetValue(x, null)).ToList();
            }
            else
            if (strSortOrder == SortOrder.Descending)
            {
                refDeps = refDeps.OrderByDescending(x => typeof(RefDep).GetProperty(strColumnName).GetValue(x, null)).ToList();
            }
            if (strSortOrder == SortOrder.None)
            {
                refDeps = refDeps.OrderBy(x => typeof(RefDep).GetProperty("RefDep_Id").GetValue(x, null)).ToList();
            }
            dgvRefDep.DataSource = refDeps;
            dgvRefDep.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
        }
        public fmRefDep(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Довідник підрозділів");
        }
        private void fmRefDep_Load(object sender, EventArgs e)
        {
            InitGridRefDep();
            LoadDataToGridRefDep();
        }
        private void dgvRefDep_KeyDown(object sender, KeyEventArgs e)
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
        //---------------------------------------------------------------------------------
    }
}
