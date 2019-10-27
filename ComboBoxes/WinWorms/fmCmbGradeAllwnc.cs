using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WinFormExtensions;
using DAL;
using Entities;


namespace ComboBoxes.WinWorms
{
    public partial class fmCmbGradeAllwnc : Form
    {
        private List<RefGradeAllwnc> _allowances = null;

        public RefGradeAllwnc GetData()
        {
            if (dgvGradeAllwnc.CurrentRow == null)
                return null;

            RefGradeAllwnc allowance = dgvGradeAllwnc.CurrentRow.DataBoundItem as RefGradeAllwnc;

            return allowance;
        }
        private void InitGrid()
        {
            dgvGradeAllwnc.BaseGrigStyle();
            dgvGradeAllwnc.AddSortGrid<RefGradeAllwnc>("RefGradeAllwnc_Id");
            dgvGradeAllwnc.AddSearchGrid();
            dgvGradeAllwnc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGradeAllwnc.DataSource = _allowances;
        }

        public fmCmbGradeAllwnc(List<RefGradeAllwnc> allwncs)
        {
            InitializeComponent();
            this.BaseFormStyle("Довідник надбавок за класність");
            _allowances = allwncs;
        }

        private void fmCmbAllwnc_Load(object sender, EventArgs e)
        {
            InitGrid();
        }

        private void fmCmbAllwnc_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void dgvGradeAllwnc_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = dgvGradeAllwnc.CurrentRow == null ? DialogResult.No : DialogResult.OK;
                Close();
            }
        }
        //----------------------Пункты меню----------------------------//

        private void MenuItemChoose_Click(object sender, EventArgs e)
        {
            DialogResult = dgvGradeAllwnc.CurrentRow == null ? DialogResult.No : DialogResult.OK; ;
            Close();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = dgvGradeAllwnc.CurrentRow == null ? DialogResult.No : DialogResult.OK; ;
            Close();
        }

        private void dgvGradeAllwnc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DialogResult = dgvGradeAllwnc.CurrentRow == null ? DialogResult.No : DialogResult.OK;
                Close();
            }
        }
    }
}
