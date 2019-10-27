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
    public partial class fmRefSocBenefit : Form
    {
        private RefSocBenefitRepository _repository = new RefSocBenefitRepository(SetupProgram.Connection);
        private List<RefSocBenefit> socBenefits = null; //Кеширование
        //Вставка строки
        private void InsertRecord()
        {
            fmRefSocBenefitEdit fmEdit = new fmRefSocBenefitEdit(EnumFormMode.Insert,"Створення інтервалу соціальної пільги");
            fmEdit.AddControlPeriod(socBenefits);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                RefSocBenefit socBenefits = fmEdit.GetData();
                int id = _repository.AddRefSocBenefit(socBenefits, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
                dgvRefSocBenefit.SetPositionRow<RefSocBenefit>("RefSocBenefit_Id", id.ToString());
            }
        }

        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvRefSocBenefit.CurrentRow == null) return;
            string error;
            RefSocBenefit refSocBenefit = dgvRefSocBenefit.CurrentRow.DataBoundItem as RefSocBenefit;
            if (refSocBenefit == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmRefSocBenefitEdit fmEdit = new fmRefSocBenefitEdit(EnumFormMode.Edit, "Зміна інтервалу соціальної пільги");
            fmEdit.AddControlPeriod(socBenefits);
            fmEdit.SetData(refSocBenefit);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                refSocBenefit = fmEdit.GetData();
                if (!_repository.ModifyRefSocBenefit(refSocBenefit, out error))
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
            if (dgvRefSocBenefit.CurrentRow == null) return;
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            RefSocBenefit refSocBenefit = dgvRefSocBenefit.CurrentRow.DataBoundItem as RefSocBenefit;
            if (refSocBenefit == null)
            {
                MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                return;
            }
            string error;
            if (!_repository.DeleteRefSocBenefit(refSocBenefit.RefSocBenefit_Id, out error))
            {
                MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            RefreshTable();
        }
        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvRefSocBenefit.CurrentRow == null ? false : true;
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
            dgvRefSocBenefit.StorePosition();
            dgvRefSocBenefit.StoreSort();
            LoadDataToGridRefSocBenefit();
            dgvRefSocBenefit.RestSort<RefSocBenefit>();
            dgvRefSocBenefit.RestPosition();
        }
        //Инициализация грида
        private void InitGridRefSocBenefit()
        {
            dgvRefSocBenefit.BaseGrigStyle();
            dgvRefSocBenefit.AddRefreshMenu(RefreshMenu);
            dgvRefSocBenefit.AddSortGrid<RefSocBenefit>("RefSocBenefit_Id");
            dgvRefSocBenefit.AddSearchGrid();
            dgvRefSocBenefit.AddStatusStripRow(statusStripRow, false);
        }
        //Загрузка данных в грид
        private bool LoadDataToGridRefSocBenefit()
        {
            string error;
            socBenefits = _repository.GetAllRefSocBenefits(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження типів додатковиз виплат.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }

            BindingSource source = new BindingSource();
            source.DataSource = socBenefits;
            dgvRefSocBenefit.DataSource = source;
            return true;
        }
        public fmRefSocBenefit(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Соціальна пільга");
            InitGridRefSocBenefit();
            LoadDataToGridRefSocBenefit();
        }

        private void dgvRefSocBenefit_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void fmRefSocBenefit_KeyDown(object sender, KeyEventArgs e)
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
