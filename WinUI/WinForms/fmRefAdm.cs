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
    public partial class fmRefAdm : Form
    {
        private List<RefAdm> refAdms = null; //Кеширование
        private List<v_RefAdm> v_refAdms = null; //Кеширование
        private RefAdmRepository _repository = new RefAdmRepository(SetupProgram.Connection);

        //Вставка строки
        private void InsertRecord()
        {
            fmRefAdmEdit fmEdit = new fmRefAdmEdit(EnumFormMode.Insert, "Створення адміністрації");
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                RefAdm adm = fmEdit.GetData();
                int id = _repository.AddAdm(adm, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
                dgvRefAdm.SetPositionRow<v_RefAdm>("RefAdm_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvRefAdm.CurrentRow == null) return;
            v_RefAdm set_adm = dgvRefAdm.CurrentRow.DataBoundItem as v_RefAdm;
            if (set_adm == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmRefAdmEdit fmEdit = new fmRefAdmEdit(EnumFormMode.Edit, "Зміна адміністрації");
            fmEdit.SetData(set_adm);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                RefAdm get_adm = fmEdit.GetData();
                string error;
                if (!_repository.ModifyAdm(get_adm, out error))
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
            if (dgvRefAdm.CurrentRow == null) return;
            if (MessageBox.Show("Ви впевнені, що бажаєте обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            v_RefAdm adm = dgvRefAdm.CurrentRow.DataBoundItem as v_RefAdm;
            if (adm == null)
            {
                MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                return;
            }
            string error;
            if (!_repository.DeleteAdm(adm.RefAdm_Id, out error))
            {
                MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            RefreshTable();
        }
        //Перезачитать данные таблицы
        private void RefreshTable()
        {
            dgvRefAdm.StorePosition();
            dgvRefAdm.StoreSort();
            LoadDataToGridRefAdm();
            dgvRefAdm.RestSort<v_RefAdm>();
            dgvRefAdm.RestPosition();
        }
        //Инициализация грида
        private void InitGridRefAdm()
        {
            dgvRefAdm.BaseGrigStyle();
            dgvRefAdm.AddRefreshMenu(RefreshMenu);
            dgvRefAdm.AddSortGrid<v_RefAdm>("RefAdm_Id");
            dgvRefAdm.AddSearchGrid();
            dgvRefAdm.AddStatusStripRow(statusStripRow, false);
        }
        //Загрузка данных в таблицу
        private bool LoadDataToGridRefAdm()
        {
            string error;
            refAdms = _repository.GetAllAdms(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження адміністрацій.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            v_refAdms = GetViewAllowance(refAdms);
            BindingSource source = new BindingSource();
            source.DataSource = v_refAdms;
            dgvRefAdm.DataSource = source;
            return true;
        }
        private List<v_RefAdm> GetViewAllowance(List<RefAdm> refAdms)
        {
            List<v_RefAdm> v_adms = new List<v_RefAdm>();
            foreach (RefAdm adm in refAdms)
            {
                v_RefAdm v_refAdm = new v_RefAdm();
                v_refAdm.RefAdm_Id = adm.RefAdm_Id;
                v_refAdm.RefAdm_FIO = adm.RefAdm_FIO;
                v_refAdm.RefAdm_TIN = adm.RefAdm_TIN;
                v_refAdm.RefAdm_Tel = adm.RefAdm_Tel;
                v_refAdm.RefAdm_TypDol = adm.RefAdm_TypDol;
                v_refAdm.RefAdm_NmDol = PositionHelper.GetNamePosByCd(adm.RefAdm_TypDol);
                v_adms.Add(v_refAdm);
            }
            return v_adms;
        }
        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvRefAdm.CurrentRow == null ? false : true;
            MenuItemCreate.Enabled = true;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled;
            ContextMenuEdit.Enabled = MenuItemEdit.Enabled;
            ContextMenuDelete.Enabled =MenuItemDelete.Enabled;
        }
        public fmRefAdm(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Довідник адміністрцій");
        }

        private void fmRefAdm_Load(object sender, EventArgs e)
        {
            InitGridRefAdm();
            LoadDataToGridRefAdm();
        }

        private void dgvRefAdm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void fmRefAdm_KeyDown(object sender, KeyEventArgs e)
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
        //-----------------------------------------------------------
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
