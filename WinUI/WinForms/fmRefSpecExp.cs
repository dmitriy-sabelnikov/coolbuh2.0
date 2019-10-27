using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinUI.Helper;
using Entities;
using DAL;
using BLL;
using WinFormExtensions;
using EnumType;

namespace WinUI.WinForms
{
    public partial class fmRefSpecExp : Form
    {
        private List<RefSpecExp> specExps = null; //Кеширование
        private RefSpecExpRepository _repository = new RefSpecExpRepository(SetupProgram.Connection);

        //Вставка строки
        private void InsertRecord()
        {
            fmRefSpecExpEdit fmEdit = new fmRefSpecExpEdit(EnumFormMode.Insert, "Створення спецстажу");
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                RefSpecExp specExp = fmEdit.GetData();
                int id = _repository.AddSpecExp(specExp, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
                dgvRefSpecExp.SetPositionRow<RefSpecExp>("RefSpecExp_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvRefSpecExp.CurrentRow == null) return;
            RefSpecExp specExp = dgvRefSpecExp.CurrentRow.DataBoundItem as RefSpecExp;
            if (specExp == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmRefSpecExpEdit fmEdit = new fmRefSpecExpEdit(EnumFormMode.Edit, "Зміна спецстажу");
            fmEdit.SetData(specExp);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                specExp = fmEdit.GetData();
                if (!_repository.ModifySpecExp(specExp, out error))
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
            if (dgvRefSpecExp.CurrentRow == null) return;
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            RefSpecExp specExp = dgvRefSpecExp.CurrentRow.DataBoundItem as RefSpecExp;
            string error;
            if (!_repository.DeleteSpecExp(specExp.RefSpecExp_Id, out error))
            {
                MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            RefreshTable();
        }
        //Перезачитать данные таблицы
        private void RefreshTable()
        {
            dgvRefSpecExp.StorePosition();
            dgvRefSpecExp.StoreSort();
            LoadDataToGridSpecExp();
            dgvRefSpecExp.RestSort<RefSpecExp>();
            dgvRefSpecExp.RestPosition();
        }
        //Инициализация грида
        private void InitGridSpecExp()
        {
            dgvRefSpecExp.BaseGrigStyle();
            dgvRefSpecExp.AddRefreshMenu(RefreshMenu);
            dgvRefSpecExp.AddSortGrid<RefSpecExp>("RefSpecExp_Id");
            dgvRefSpecExp.AddSearchGrid();
            dgvRefSpecExp.AddStatusStripRow(statusStripRow, false);
        }
        //Загрузка данных в грид
        private bool LoadDataToGridSpecExp()
        {
            string error;
            specExps = _repository.GetAllSpecExps(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження спецстажів.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            dgvRefSpecExp.DataSource = specExps;
            return true;
        }
        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvRefSpecExp.CurrentRow == null ? false : true;
            MenuItemCreate.Enabled = true;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled;
            ContextMenuEdit.Enabled = MenuItemEdit.Enabled;
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled;    
        }

        public fmRefSpecExp(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Довідник спецстажів");
        }

        private void fmRefSpecExp_Load(object sender, EventArgs e)
        {
            InitGridSpecExp();
            LoadDataToGridSpecExp();
        }

        private void fmRefSpecExp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvRefSpecExp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        //--------------------События меню----------------------------
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
            RefreshTable();
        }
        //-------------------------------------------------------------
    }
}
