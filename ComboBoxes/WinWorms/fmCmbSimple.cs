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

namespace ComboBoxes.WinWorms
{
    public partial class fmCmbSimple : Form
    {
 
        private void InitGrid(List<ViewField> fields)
        {
            dgvSimpleCmb.BaseGrigStyle();
            dgvSimpleCmb.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSimpleCmb.AddSearchGrid();
            foreach (ViewField field in fields)
            {
                if (field.Type == TypeFields.textBox)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.Name = field.Name;
                    column.DataPropertyName = field.Name;
                    column.HeaderText = field.Caption;
                    dgvSimpleCmb.Columns.Add(column);
                }
                else if (field.Type == TypeFields.checkBox)
                {
                    DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
                    column.Name = field.Name;
                    column.DataPropertyName = field.Name;
                    column.HeaderText = field.Caption;
                    column.FalseValue = 0;
                    column.TrueValue = 1;
                    dgvSimpleCmb.Columns.Add(column);
                }
            }
        }
        public void SetSourceDgv<T>(List<T> sourceGrig)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = sourceGrig;
            dgvSimpleCmb.DataSource = bindingSource1;
        }

        public void AddSortGrid<T>(string defFieldSort)
        {
            dgvSimpleCmb.AddSortGrid<T>(defFieldSort);
        }

        public T GetData<T>() 
        {
            if (dgvSimpleCmb.CurrentRow == null) return default(T);

            T currentObject = (T)dgvSimpleCmb.CurrentRow.DataBoundItem;
            return currentObject;
        }
        public fmCmbSimple(string caption, List<ViewField> vwFields)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            InitGrid(vwFields);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = dgvSimpleCmb.CurrentRow == null ? DialogResult.No : DialogResult.OK; ;
            Close();
        }
        private void fmCmbSimple_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void dgvSimpleCmb_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = dgvSimpleCmb.CurrentRow == null ? DialogResult.No : DialogResult.OK;
                Close();
            }
        }

        private void MenuItemChoose_Click(object sender, EventArgs e)
        {
            DialogResult = dgvSimpleCmb.CurrentRow == null ? DialogResult.No : DialogResult.OK;
            Close();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dgvSimpleCmb_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DialogResult = dgvSimpleCmb.CurrentRow == null ? DialogResult.No : DialogResult.OK;
                Close();
            }
        }
    }
}
