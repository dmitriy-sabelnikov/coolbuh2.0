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
using EnumType;
using WinFormExtensions;

namespace WinUI.WinForms
{
    public partial class fmPersCardChildEdit : Form
    {
        private int _id = 0;
        private List<Child> children = null;
        private bool CanSaveChild()
        {
            if (tbPerBeg.Text == string.Empty && tbPerEnd.Text == string.Empty)
                return false;
            if (tbCount.Text == string.Empty)
                return false;

            DateTime perBeg;
            DateTime.TryParse(tbPerBeg.Text, out perBeg);

            DateTime perEnd;
            DateTime.TryParse(tbPerEnd.Text, out perEnd);

            perEnd = perEnd == DateTime.MinValue ? perEnd = DateTime.MaxValue : perEnd;

            if (perBeg > perEnd)
            {
                MessageBox.Show("Дата початку більше за дату закінчення", "Помилка");
                return false;
            }

            if (children != null)
            {
                foreach (Child child in children)
                {
                    if (_id == child.Child_Id)
                        continue;
                    DateTime datBeg = child.Child_PerBeg;
                    DateTime datEnd = child.Child_PerEnd == DateTime.MinValue ? DateTime.MaxValue : child.Child_PerEnd;
                    if (perEnd >= datBeg && perBeg <= datEnd)
                    {
                        MessageBox.Show("Період перетинається з існуючим", "Помилка");
                        return false;
                    }
                }
            }
            return true;
        }

        public void SetData(Child child)
        {
            _id = child.Child_Id;
            if (child.Child_PerBeg != DateTime.MinValue)
                tbPerBeg.Text = child.Child_PerBeg.ToShortDateString();
            if (child.Child_PerEnd != DateTime.MinValue)
                tbPerEnd.Text = child.Child_PerEnd.ToShortDateString();
            tbCount.Text = child.Child_Count.ToString();
        }

        public Child GetData()
        {
            Child child = new Child();
            child.Child_Id = _id;

            DateTime perBeg;
            DateTime.TryParse(tbPerBeg.Text, out perBeg);
            child.Child_PerBeg = perBeg;

            DateTime perEnd;
            DateTime.TryParse(tbPerEnd.Text, out perEnd);
            child.Child_PerEnd = perEnd;


            int count = 0;
            int.TryParse(tbCount.Text, out count);
            child.Child_Count = count;
            return child;
        }

        public void AddControlPeriod(List<Child> children)
        {
            this.children = children;
        }

        public fmPersCardChildEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;
            tbPerBeg.AddDateField('.');
            tbPerEnd.AddDateField('.');

            tbCount.AddNumericField();
            tbCount.NecessaryField();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveChild()) return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void PersCardChildEdit_Load(object sender, EventArgs e)
        {
            tbPerBeg.IsModifyField(() => { btnOk.Enabled = true; });
            tbPerEnd.IsModifyField(() => { btnOk.Enabled = true; });
            tbCount.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void PersCardChildEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }
    }
}
