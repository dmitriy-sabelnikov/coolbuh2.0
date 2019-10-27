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

namespace ComboBoxes.WinWorms
{
    public partial class fmCmbExpAllwnc : Form
    {
        private List<RefExpAllwnc> _allowances = null;

        public RefExpAllwnc GetData()
        {
            if (dgvExpAllwnc.CurrentRow == null)
                return null;

            RefExpAllwnc allowance = dgvExpAllwnc.CurrentRow.DataBoundItem as RefExpAllwnc;

            return allowance;
        }
        private void InitGrid()
        {
            dgvExpAllwnc.BaseGrigStyle();
            dgvExpAllwnc.AddSortGrid<RefExpAllwnc>("RefExpAllwnc_Id");
            dgvExpAllwnc.AddSearchGrid();
            dgvExpAllwnc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExpAllwnc.DataSource = _allowances;
        }

        public fmCmbExpAllwnc(List<RefExpAllwnc> allwncs)
        {
            InitializeComponent();
            this.BaseFormStyle("Довідник надбавок за стаж");
            _allowances = allwncs;
        }

        private void fmCmbExpAllwnc_Load(object sender, EventArgs e)
        {
            InitGrid();
        }

        private void fmCmbExpAllwnc_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
        private void MenuItemChoose_Click(object sender, EventArgs e)
        {
            DialogResult = dgvExpAllwnc.CurrentRow == null ? DialogResult.No : DialogResult.OK;
            Close();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvExpAllwnc_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = dgvExpAllwnc.CurrentRow == null ? DialogResult.No : DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = dgvExpAllwnc.CurrentRow == null ? DialogResult.No : DialogResult.OK;
            Close();
        }

        private void dgvExpAllwnc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DialogResult = dgvExpAllwnc.CurrentRow == null ? DialogResult.No : DialogResult.OK;
                Close();
            }
        }

    }
}
