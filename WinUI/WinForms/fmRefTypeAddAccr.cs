using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using DAL;
using BLL;
using EnumType;
using WinFormExtensions;

namespace WinUI.WinForms
{
    public partial class fmRefTypeAddAccr : Form
    {
        private List<RefTypeAddAccr> _refTypeAddAccrs = null; //Кеширование
        private List<v_RefTypeAddAccr> _vRefTypeAddAccrs = null; //Кеширование

        private RefTypeAddAccrRepository _repository = new RefTypeAddAccrRepository(SetupProgram.Connection);

        private List<v_RefTypeAddAccr> GetViewTypeAddAccr(List<RefTypeAddAccr> typeAddAccrs)
        {
            List<v_RefTypeAddAccr> v_typeAddAccrs = new List<v_RefTypeAddAccr>();
            foreach (RefTypeAddAccr typeAddAccr in typeAddAccrs)
            {
                v_RefTypeAddAccr v_typeAddAccr = new v_RefTypeAddAccr();
                v_typeAddAccr.RefTypeAddAccr_Id = typeAddAccr.RefTypeAddAccr_Id;
                v_typeAddAccr.RefTypeAddAccr_Cd = typeAddAccr.RefTypeAddAccr_Cd;
                v_typeAddAccr.RefTypeAddAccr_Nm = typeAddAccr.RefTypeAddAccr_Nm;
                v_typeAddAccr.RefTypeAddAccr_Clc = 
                    (typeAddAccr.RefTypeAddAccr_Flg & (int)EnumTypeAddAccr_Flg.TypeAddAccr_Clc) > 0 ? 1 : 0;
                v_typeAddAccrs.Add(v_typeAddAccr);
            }
            return v_typeAddAccrs;
        }

        //Вставка строки
        private void InsertRecord()
        {
            fmRefTypeAddAccrEdit fmEdit = new fmRefTypeAddAccrEdit(EnumFormMode.Insert, "Створення типу додаткового нарахування");
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                RefTypeAddAccr pensAllwnc = fmEdit.GetData();
                int id = _repository.AddTypeAaddAccr(pensAllwnc, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
                dgvRefTypeAddAccr.SetPositionRow<v_RefTypeAddAccr>("RefTypeAddAccr_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvRefTypeAddAccr.CurrentRow == null) return;
            string error;
            v_RefTypeAddAccr v_typeAddAccr = dgvRefTypeAddAccr.CurrentRow.DataBoundItem as v_RefTypeAddAccr;
            if (v_typeAddAccr == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }

            fmRefTypeAddAccrEdit fmEdit = new fmRefTypeAddAccrEdit(EnumFormMode.Edit, "Зміна типу додаткового нарахування");
            fmEdit.SetData(_refTypeAddAccrs.FirstOrDefault(rec => rec.RefTypeAddAccr_Id == v_typeAddAccr.RefTypeAddAccr_Id));
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                RefTypeAddAccr typeAddAccr = fmEdit.GetData();
                if (!_repository.ModifyTypeAaddAccr(typeAddAccr, out error))
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
            if (dgvRefTypeAddAccr.CurrentRow == null) return;
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            v_RefTypeAddAccr v_typeAddAccr = dgvRefTypeAddAccr.CurrentRow.DataBoundItem as v_RefTypeAddAccr;
            if (v_typeAddAccr == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            string error;
            if (!_repository.DeleteTypeAddAccr(v_typeAddAccr.RefTypeAddAccr_Id, out error))
            {
                MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            RefreshTable();
        }

        //Перезачитать данные таблицы
        private void RefreshTable()
        {
            dgvRefTypeAddAccr.StorePosition();
            dgvRefTypeAddAccr.StoreSort();
            LoadDataToGridTypeAddAccr();
            dgvRefTypeAddAccr.RestSort<v_RefTypeAddAccr>();
            dgvRefTypeAddAccr.RestPosition();
        }
        //Инициализация грида
        private void InitGridTypeAddAccr()
        {
            dgvRefTypeAddAccr.BaseGrigStyle();
            dgvRefTypeAddAccr.AddRefreshMenu(RefreshMenu);
            dgvRefTypeAddAccr.AddSortGrid<v_RefTypeAddAccr>("RefTypeAddAccr_Id");
            dgvRefTypeAddAccr.AddSearchGrid();
            dgvRefTypeAddAccr.AddStatusStripRow(statusStripRow, false);
        }
        //Загрузка данных в грид
        private bool LoadDataToGridTypeAddAccr()
        {
            string error;
            _refTypeAddAccrs = _repository.GetAllTypeAddAccr(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження типів додаткових нарахувань.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            _vRefTypeAddAccrs = GetViewTypeAddAccr(_refTypeAddAccrs);
            dgvRefTypeAddAccr.DataSource = _vRefTypeAddAccrs;
            return true;
        }
        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvRefTypeAddAccr.CurrentRow == null ? false : true;
            MenuItemCreate.Enabled = true;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled;
            ContextMenuEdit.Enabled = MenuItemEdit.Enabled;
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled;
        }

        public fmRefTypeAddAccr(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Довідник типів додаткових нарахувань");
        }

        private void fmRefTypeAddAccr_Load(object sender, EventArgs e)
        {
            InitGridTypeAddAccr();
            LoadDataToGridTypeAddAccr();
        }

        private void fmRefTypeAddAccr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvRefTypeAddAccr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
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
