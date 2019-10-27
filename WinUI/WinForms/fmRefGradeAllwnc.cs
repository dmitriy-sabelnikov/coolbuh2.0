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
using WinUI.Helper;
using WinFormExtensions;
using EnumType;
using System.IO;

namespace WinUI.WinForms
{
    public partial class fmRefGradeAllwnc : Form
    {
        private List<RefGradeAllwnc> _refGradeAllwncs = null; //Кеширование
        private List<RefDep> _refDeps = null; //Кеширование
        private List<v_RefGradeAllwnc> _vRefGradeAllwncs = null; //Кеширование.View

        private RefGradeAllwncRepository _repository = new RefGradeAllwncRepository(SetupProgram.Connection);
        private RefDepRepository _refDepRepo = new RefDepRepository(SetupProgram.Connection);

        private List<v_RefGradeAllwnc> GetViewAllowance(List<RefGradeAllwnc> Allowance, List<RefDep> refDeps)
        {
            List<v_RefGradeAllwnc> v_allwncs = new List<v_RefGradeAllwnc>();
            foreach(RefGradeAllwnc allwnc in Allowance)
            {
                RefDep refDep = refDeps.FirstOrDefault(s => s.RefDep_Id == allwnc.RefGradeAllwnc_RefDep_Id);
                v_RefGradeAllwnc v_allwnc = new v_RefGradeAllwnc();
                v_allwnc.RefGradeAllwnc_Id = allwnc.RefGradeAllwnc_Id;
                v_allwnc.RefGradeAllwnc_Cd = allwnc.RefGradeAllwnc_Cd;
                v_allwnc.RefGradeAllwnc_Nm = allwnc.RefGradeAllwnc_Nm;
                v_allwnc.RefGradeAllwnc_Pct = allwnc.RefGradeAllwnc_Pct;
                v_allwnc.RefGradeAllwnc_Grade = allwnc.RefGradeAllwnc_Grade;
                if(refDep != null)
                {
                    v_allwnc.RefGradeAllwnc_RefDep_Id = allwnc.RefGradeAllwnc_RefDep_Id;
                    v_allwnc.RefGradeAllwnc_RefDep_Nm = refDep.RefDep_Nm;
                }
                v_allwnc.RefGradeAllwnc_Use = (allwnc.RefGradeAllwnc_Flg & (int)EnumGradeAllwnc_Flg.ALLWNC_NOTUSE) > 0 ? 0 : 1; 
                v_allwncs.Add(v_allwnc);
            }
            return v_allwncs;
        }

        //Вставка строки
        private void InsertRecord()
        {
            fmRefGradeAllwncEdit fmEdit = new fmRefGradeAllwncEdit(EnumFormMode.Insert, "Створення надбавки за класність");
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                RefGradeAllwnc gradeAllwncs = fmEdit.GetData();
                int id = _repository.AddGradeAllwnc(gradeAllwncs, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
                dgvGradeAllwnc.SetPositionRow<v_RefGradeAllwnc>("RefGradeAllwnc_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvGradeAllwnc.CurrentRow == null) return;
            v_RefGradeAllwnc v_allowance = dgvGradeAllwnc.CurrentRow.DataBoundItem as v_RefGradeAllwnc;
            if (v_allowance == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmRefGradeAllwncEdit fmEdit = new fmRefGradeAllwncEdit(EnumFormMode.Edit, "Зміна надбавки за класність");
            fmEdit.SetData(_refGradeAllwncs.FirstOrDefault(rec => rec.RefGradeAllwnc_Id == v_allowance.RefGradeAllwnc_Id));
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                RefGradeAllwnc allowance = fmEdit.GetData();
                string error;
                if (!_repository.ModifyGradeAllwnc(allowance, out error))
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
            if (dgvGradeAllwnc.CurrentRow == null) return;

            if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            v_RefGradeAllwnc allowance = dgvGradeAllwnc.CurrentRow.DataBoundItem as v_RefGradeAllwnc;
            if (allowance == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }

            string error;
            if (!_repository.DeleteGradeAllwnc(allowance.RefGradeAllwnc_Id, out error))
            {
                MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            RefreshTable();
        }
        //Перезачитать данные таблицы
        private void RefreshTable()
        {
            dgvGradeAllwnc.StorePosition();
            dgvGradeAllwnc.StoreSort();
            LoadDataToGridGradeAllwnc();
            dgvGradeAllwnc.RestSort<v_RefGradeAllwnc>();
            dgvGradeAllwnc.RestPosition();
        }

        //Инициализация грида
        private void InitGridGradeAllwnc()
        {
            dgvGradeAllwnc.BaseGrigStyle();
            dgvGradeAllwnc.AddRefreshMenu(RefreshMenu);
            dgvGradeAllwnc.AddSortGrid<RefGradeAllwnc>("RefGradeAllwnc_Id");
            dgvGradeAllwnc.AddSearchGrid();
            dgvGradeAllwnc.AddStatusStripRow(statusStripRow, false);
        }
        //Загрузка данных в грид
        private bool LoadDataToGridGradeAllwnc()
        {
            string error;
            _refGradeAllwncs = _repository.GetAllGradeAllwnc(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження доплат.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            _refDeps = _refDepRepo.GetAllDeps(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження підрозділів.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            _vRefGradeAllwncs = GetViewAllowance(_refGradeAllwncs, _refDeps);
            dgvGradeAllwnc.DataSource = _vRefGradeAllwncs;
            return true;
        }
        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvGradeAllwnc.CurrentRow == null ? false : true;
            MenuItemCreate.Enabled = true;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled;
            ContextMenuEdit.Enabled = MenuItemEdit.Enabled;
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled;
        }

        public fmRefGradeAllwnc(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Довідник надбавок за класність");
        }

        private void fmAllowance_Load(object sender, EventArgs e)
        {
            InitGridGradeAllwnc();
            LoadDataToGridGradeAllwnc();
        }

        private void fmAllowance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvAllowance_KeyDown(object sender, KeyEventArgs e)
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
        //----------------------------------------------------------
    }
}
