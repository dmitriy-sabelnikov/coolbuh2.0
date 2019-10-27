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


namespace WinUI.WinForms
{
    public partial class fmRefTypeAddPayment : Form
    {
        private RefTypeAddPaymentRepository _repository = new RefTypeAddPaymentRepository(SetupProgram.Connection);
        private List<RefTypeAddPayment> typeAddPayments = null; //Кеширование
        //Вставка строки
        private void InsertRecord()
        {
            fmRefTypeAddPaymentEdit fmEdit = new fmRefTypeAddPaymentEdit("Створення типу додаткових виплат");
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                RefTypeAddPayment typeAddPayment = fmEdit.GetData();
                int id = _repository.AddTypeAddPayment(typeAddPayment, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
                dgvRefTypeAddPayment.SetPositionRow<RefTypeAddPayment>("RefTypeAddPayment_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvRefTypeAddPayment.CurrentRow == null) return;
            string error;
            RefTypeAddPayment typeAddPayment= dgvRefTypeAddPayment.CurrentRow.DataBoundItem as RefTypeAddPayment;
            if (typeAddPayment == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmRefTypeAddPaymentEdit fmEdit = new fmRefTypeAddPaymentEdit("Зміна типу додаткових виплат");
            fmEdit.SetData(typeAddPayment);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                typeAddPayment = fmEdit.GetData();
                if (!_repository.ModifyTypeAddPayment(typeAddPayment, out error))
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
            if (dgvRefTypeAddPayment.CurrentRow == null) return;
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            RefTypeAddPayment typeAddPayment = dgvRefTypeAddPayment.CurrentRow.DataBoundItem as RefTypeAddPayment;
            if (typeAddPayment == null)
            {
                MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                return;
            }
            string error;
            if (!_repository.DeleteTypeAddPayment(typeAddPayment.RefTypeAddPayment_Id, out error))
            {
                MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            RefreshTable();
        }
        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvRefTypeAddPayment.CurrentRow == null ? false : true;
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
            dgvRefTypeAddPayment.StorePosition();
            dgvRefTypeAddPayment.StoreSort();
            LoadDataToGridTypeAddPayment();
            dgvRefTypeAddPayment.RestSort<RefTypeAddPayment>();
            dgvRefTypeAddPayment.RestPosition();
        }
        //Инициализация грида
        private void InitGridTypeAddPayment()
        {
            dgvRefTypeAddPayment.BaseGrigStyle();
            dgvRefTypeAddPayment.AddRefreshMenu(RefreshMenu);
            dgvRefTypeAddPayment.AddSortGrid<RefTypeAddPayment>("RefTypeAddPayment_Id");
            dgvRefTypeAddPayment.AddSearchGrid();
            dgvRefTypeAddPayment.AddStatusStripRow(statusStripRow, false);
        }
        //Загрузка данных в грид
        private bool LoadDataToGridTypeAddPayment()
        {
            string error;
            typeAddPayments = _repository.GetAllTypeAddPayments(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження типів додатковиз виплат.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            dgvRefTypeAddPayment.DataSource = typeAddPayments;
            return true;
        }

        public fmRefTypeAddPayment(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Довідник типів додаткових виплат");
            InitGridTypeAddPayment();
            LoadDataToGridTypeAddPayment();
        }

        private void fmRefTypeAddPayment_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void dgvRefTypeAddPayment_KeyDown(object sender, KeyEventArgs e)
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
