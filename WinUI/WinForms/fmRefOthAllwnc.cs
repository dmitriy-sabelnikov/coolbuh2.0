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
using Entities;
using EnumType;
using DAL;
using BLL;

namespace WinUI.WinForms
{
    public partial class fmRefOthAllwnc : Form
    {
        private List<RefOthAllwnc> _refOthAllwncs = null; //Кеширование
        private List<v_RefOthAllwnc> _vRefOthAllwncs = null; //Кеширование

        private RefOthAllwncRepository _repository = new RefOthAllwncRepository(SetupProgram.Connection);

        private List<v_RefOthAllwnc> GetViewAllowance(List<RefOthAllwnc> Allowance)
        {
            List<v_RefOthAllwnc> v_allwncs = new List<v_RefOthAllwnc>();
            foreach (RefOthAllwnc allwnc in Allowance)
            {
                v_RefOthAllwnc v_allwnc = new v_RefOthAllwnc();
                v_allwnc.RefOthAllwnc_Id = allwnc.RefOthAllwnc_Id;
                v_allwnc.RefOthAllwnc_Cd = allwnc.RefOthAllwnc_Cd;
                v_allwnc.RefOthAllwnc_Nm = allwnc.RefOthAllwnc_Nm;
                v_allwnc.RefOthAllwnc_Pct = allwnc.RefOthAllwnc_Pct;
                v_allwnc.RefOthAllwnc_Flg = allwnc.RefOthAllwnc_Flg;
                v_allwnc.RefOthAllwnc_Use = (allwnc.RefOthAllwnc_Flg & (int)EnumOthAllwnc_Flg.ALLWNC_NOTUSE) > 0 ? 0 : 1;
                v_allwncs.Add(v_allwnc);
            }
            return v_allwncs;
        }
        //Вставка строки
        private void InsertRecord()
        {
            fmRefOthAllwncEdit fmEdit = new fmRefOthAllwncEdit(EnumFormMode.Insert, "Створення іншої надбавки");
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                RefOthAllwnc othAllwnc = fmEdit.GetData();
                int id = _repository.AddOthAllwnc(othAllwnc, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
                dgvOthAllwnc.SetPositionRow<v_RefOthAllwnc>("RefOthAllwnc_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvOthAllwnc.CurrentRow == null) return;
            string error;
            v_RefOthAllwnc v_othAllwnc = dgvOthAllwnc.CurrentRow.DataBoundItem as v_RefOthAllwnc;
            if (v_othAllwnc == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }

            fmRefOthAllwncEdit fmEdit = new fmRefOthAllwncEdit(EnumFormMode.Edit, "Зміна іншої надбавки");
            fmEdit.SetData(v_othAllwnc);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                RefOthAllwnc OthAllwnc = fmEdit.GetData();
                if (!_repository.ModifyOthAllwnc(OthAllwnc, out error))
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
            if (dgvOthAllwnc.CurrentRow == null) return;
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            v_RefOthAllwnc v_othAllwnc = dgvOthAllwnc.CurrentRow.DataBoundItem as v_RefOthAllwnc;
            if (v_othAllwnc == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            string error;
            if (!_repository.DeleteOthAllwnc(v_othAllwnc.RefOthAllwnc_Id, out error))
            {
                MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            RefreshTable();
        }
        //Перезачитать данные таблицы
        private void RefreshTable()
        {
            dgvOthAllwnc.StorePosition();
            dgvOthAllwnc.StoreSort();
            LoadDataToGridOthAllwnc();
            dgvOthAllwnc.RestSort<v_RefOthAllwnc>();
            dgvOthAllwnc.RestPosition();
        }
        //Инициализация грида
        private void InitGridOthAllwnc()
        {
            dgvOthAllwnc.BaseGrigStyle();
            dgvOthAllwnc.AddRefreshMenu(RefreshMenu);
            dgvOthAllwnc.AddSortGrid<RefOthAllwnc>("RefOthAllwnc_Id");
            dgvOthAllwnc.AddSearchGrid();
            dgvOthAllwnc.AddStatusStripRow(statusStripRow, false);
        }
        //Загрузка данных в грид
        private bool LoadDataToGridOthAllwnc()
        {
            string error;
            _refOthAllwncs = _repository.GetAllOthAllwnc(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження інших надбавок.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            _vRefOthAllwncs = GetViewAllowance(_refOthAllwncs);
            dgvOthAllwnc.DataSource = _vRefOthAllwncs;
            return true;
        }
        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvOthAllwnc.CurrentRow == null ? false : true;
            MenuItemCreate.Enabled = true;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled;
            ContextMenuEdit.Enabled = MenuItemEdit.Enabled;
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled;
        }

        public fmRefOthAllwnc(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Довідник інших надбавок");
        }

        private void fmRefOthAllwnc_Load(object sender, EventArgs e)
        {
            InitGridOthAllwnc();
            LoadDataToGridOthAllwnc();
        }

        private void fmRefOthAllwnc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvOthAllwnc_KeyDown(object sender, KeyEventArgs e)
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
    }
}
