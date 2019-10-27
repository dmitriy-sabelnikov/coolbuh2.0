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
    public partial class fmRefLivWage : Form
    {
        private RefLivWageRepository _repository = new RefLivWageRepository(SetupProgram.Connection);
        private List<RefLivWage> livWages = null; //Кеширование
        //Вставка строки
        private void InsertRecord()
        {
            fmRefLivWageEdit fmEdit = new fmRefLivWageEdit(EnumFormMode.Insert, "Створення інтервалу прожиткового мінімума");
            fmEdit.AddControlPeriod(livWages);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                RefLivWage refLivWage = fmEdit.GetData();
                int id = _repository.AddRefLivWage(refLivWage, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
                dgvRefLivWage.SetPositionRow<RefLivWage>("RefLivWage_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvRefLivWage.CurrentRow == null) return;
            string error;
            RefLivWage refLivWage = dgvRefLivWage.CurrentRow.DataBoundItem as RefLivWage;
            if (refLivWage == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmRefLivWageEdit fmEdit = new fmRefLivWageEdit(EnumFormMode.Edit, "Зміна інтервалу прожиткового мінімума");
            fmEdit.AddControlPeriod(livWages);
            fmEdit.SetData(refLivWage);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                refLivWage = fmEdit.GetData();
                if (!_repository.ModifyRefLivWage(refLivWage, out error))
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
            if (dgvRefLivWage.CurrentRow == null) return;
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            RefLivWage refLivWage = dgvRefLivWage.CurrentRow.DataBoundItem as RefLivWage;
            if (refLivWage == null)
            {
                MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                return;
            }
            string error;
            if (!_repository.DeleteRefLivWage(refLivWage.RefLivWage_Id, out error))
            {
                MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            RefreshTable();
        }
        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvRefLivWage.CurrentRow == null ? false : true;
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
            dgvRefLivWage.StorePosition();
            dgvRefLivWage.StoreSort();
            LoadDataToGridRefLivWage();
            dgvRefLivWage.RestSort<RefLivWage>();
            dgvRefLivWage.RestPosition();
        }
        //Инициализация грида
        private void InitGridRefLivWage()
        {
            dgvRefLivWage.BaseGrigStyle();
            dgvRefLivWage.AddRefreshMenu(RefreshMenu);
            dgvRefLivWage.AddSortGrid<RefLivWage>("RefLivWage_Id");
            dgvRefLivWage.AddSearchGrid();
            dgvRefLivWage.AddStatusStripRow(statusStripRow, false);
        }
        //Загрузка данных в грид
        private bool LoadDataToGridRefLivWage()
        {
            string error;
            livWages = _repository.GetAllRefLivWages(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження типів додатковиз виплат.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }

            BindingSource source = new BindingSource();
            source.DataSource = livWages;
            dgvRefLivWage.DataSource = source;
            return true;
        }
        public fmRefLivWage(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Прожитковий мінімум");
            InitGridRefLivWage();
            LoadDataToGridRefLivWage();
        }

        private void dgvRefLivWage_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void fmRefLivWage_KeyDown(object sender, KeyEventArgs e)
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
    }
}
