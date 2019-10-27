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
using WinFormExtensions;

namespace ComboBoxes.WinWorms
{
    public partial class fmCmbOthAllwnc : Form
    {
        private List<RefOthAllwnc> _allowances = null;

        public RefOthAllwnc GetData()
        {
            if (dgvOthAllwnc.CurrentRow == null)
                return null;

            RefOthAllwnc allowance = dgvOthAllwnc.CurrentRow.DataBoundItem as RefOthAllwnc;

            return allowance;
        }
        private void InitGrid()
        {
            dgvOthAllwnc.BaseGrigStyle();
            dgvOthAllwnc.AddSortGrid<RefOthAllwnc>("RefOthAllwnc_Id");
            dgvOthAllwnc.AddSearchGrid();
            dgvOthAllwnc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOthAllwnc.DataSource = _allowances;
        }

        public fmCmbOthAllwnc(List<RefOthAllwnc> allwncs)
        {
            InitializeComponent();
            this.BaseFormStyle("Довідник інші надбавки");
            _allowances = allwncs;
        }

        private void fmCmbOthAllwnc_Load(object sender, EventArgs e)
        {
            InitGrid();
        }

        private void fmCmbOthAllwnc_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void dgvOthAllwnc_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = dgvOthAllwnc.CurrentRow == null ? DialogResult.No : DialogResult.OK;
                Close();
            }
        }

        private void MenuItemChoose_Click(object sender, EventArgs e)
        {
            DialogResult = dgvOthAllwnc.CurrentRow == null ? DialogResult.No : DialogResult.OK;
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
            DialogResult = dgvOthAllwnc.CurrentRow == null ? DialogResult.No : DialogResult.OK;
            Close();
        }

        private void dgvOthAllwnc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DialogResult = dgvOthAllwnc.CurrentRow == null ? DialogResult.No : DialogResult.OK;
                Close();
            }
        }
    }
}
