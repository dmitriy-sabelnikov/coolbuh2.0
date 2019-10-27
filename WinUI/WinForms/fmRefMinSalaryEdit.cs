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
using EnumType;

namespace WinUI.WinForms
{
    public partial class fmRefMinSalaryEdit : Form
    {
        private int _id = 0;
        private List<RefMinSalary> minSalaries = null;

        private bool CanSaveMinSalary()
        {
            if (tbPerBeg.Text == string.Empty && tbPerEnd.Text == string.Empty)
                return false;
            if (tbSm.Text == string.Empty)
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

            if (minSalaries != null)
            {
                foreach (RefMinSalary minSalary in minSalaries)
                {
                    if (_id == minSalary.RefMinSalary_Id)
                        continue;
                    DateTime datBeg = minSalary.RefMinSalary_PerBeg;
                    DateTime datEnd = minSalary.RefMinSalary_PerEnd == DateTime.MinValue ? DateTime.MaxValue : minSalary.RefMinSalary_PerEnd;
                    if (perEnd >= datBeg && perBeg <= datEnd)
                    {
                        MessageBox.Show("Період перетинається з існуючим ", "Помилка");
                        return false;
                    }
                }
            }
            return true;
        }

        public void SetData(RefMinSalary minSalary)
        {
            _id = minSalary.RefMinSalary_Id;
            if (minSalary.RefMinSalary_PerBeg != DateTime.MinValue)
                tbPerBeg.Text = minSalary.RefMinSalary_PerBeg.ToShortDateString();
            if (minSalary.RefMinSalary_PerEnd != DateTime.MinValue)
                tbPerEnd.Text = minSalary.RefMinSalary_PerEnd.ToShortDateString();
            tbSm.Text = minSalary.RefMinSalary_Sm.ToString();
        }
        public RefMinSalary GetData()
        {
            RefMinSalary minSalary = new RefMinSalary();
            minSalary.RefMinSalary_Id = _id;

            DateTime perBeg;
            DateTime.TryParse(tbPerBeg.Text, out perBeg);
            minSalary.RefMinSalary_PerBeg = perBeg;

            DateTime perEnd;
            DateTime.TryParse(tbPerEnd.Text, out perEnd);
            minSalary.RefMinSalary_PerEnd = perEnd;

            decimal sm = 0;
            decimal.TryParse(tbSm.Text, out sm);
            minSalary.RefMinSalary_Sm = sm;
            return minSalary;
        }

        public void AddControlPeriod(List<RefMinSalary> minSalaries)
        {
            this.minSalaries = minSalaries;
        }

        public fmRefMinSalaryEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;
            tbPerBeg.AddDateField('.');
            tbPerEnd.AddDateField('.');

            tbSm.AddFloatField(16, 2);
            tbSm.NecessaryField();
        }

        private void fmRefMinSalaryEdit_Load(object sender, EventArgs e)
        {
            tbPerBeg.IsModifyField(() => { btnOk.Enabled = true; });
            tbPerEnd.IsModifyField(() => { btnOk.Enabled = true; });
            tbSm.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveMinSalary()) return;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
