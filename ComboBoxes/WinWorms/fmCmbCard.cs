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
    public partial class fmCmbCard : Form
    {
        private List<PersCard> _persCards = null;
        public PersCard GetData()
        {
            if (dgvCmbCard.CurrentRow == null) return null;
            return dgvCmbCard.CurrentRow.DataBoundItem as PersCard;
        }
        private void InitGrid()
        {
            dgvCmbCard.BaseGrigStyle();
            dgvCmbCard.AddSortGrid<PersCard>("PersCard_Id");
            dgvCmbCard.AddSearchGrid();
            dgvCmbCard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCmbCard.DataSource = _persCards;
        }

        public fmCmbCard(List<PersCard> cards)
        {
            InitializeComponent();
            this.BaseFormStyle("Довідник карток");
            _persCards = cards.OrderBy(rec => rec.PersCard_LName).ToList();
        }

        private void fmCmbCard_Load(object sender, EventArgs e)
        {
            InitGrid();
        }

        private void fmCmbCard_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void MenuItemChoose_Click(object sender, EventArgs e)
        {
            DialogResult = dgvCmbCard.CurrentRow == null ? DialogResult.No : DialogResult.OK;
            Close();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvCmbCard_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = dgvCmbCard.CurrentRow == null ? DialogResult.No : DialogResult.OK;
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
            DialogResult = dgvCmbCard.CurrentRow == null ? DialogResult.No : DialogResult.OK;
            Close();
        }

        private void dgvCmbCard_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DialogResult = dgvCmbCard.CurrentRow == null ? DialogResult.No : DialogResult.OK;
                Close();
            }
        }
    }
}
