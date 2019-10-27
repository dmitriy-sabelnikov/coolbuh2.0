using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnumType;
using Entities;
using WinFormExtensions;

namespace WinUI.WinForms
{
    public partial class fmRefLivWageEdit : Form
    {
        private int _id = 0;
        private List<RefLivWage> livWages = null;

        private bool CanSaveLivWage()
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

            if (livWages != null)
            {
                foreach (RefLivWage livWage in livWages)
                {
                    if (_id == livWage.RefLivWage_Id)
                        continue;
                    DateTime datBeg = livWage.RefLivWage_PerBeg;
                    DateTime datEnd = livWage.RefLivWage_PerEnd == DateTime.MinValue ? DateTime.MaxValue : livWage.RefLivWage_PerEnd;
                    if (perEnd >= datBeg && perBeg <= datEnd)
                    {
                        MessageBox.Show("Період перетинається з існуючим ", "Помилка");
                        return false;
                    }
                }
            }
            return true;
        }

        public void SetData(RefLivWage refLivWage)
        {
            _id = refLivWage.RefLivWage_Id;
            if (refLivWage.RefLivWage_PerBeg != DateTime.MinValue)
                tbPerBeg.Text = refLivWage.RefLivWage_PerBeg.ToShortDateString();
            if (refLivWage.RefLivWage_PerEnd != DateTime.MinValue)
                tbPerEnd.Text = refLivWage.RefLivWage_PerEnd.ToShortDateString();
            tbSm.Text = refLivWage.RefLivWage_Sm.ToString();
        }
        public RefLivWage GetData()
        {
            RefLivWage livWage = new RefLivWage();
            livWage.RefLivWage_Id = _id;

            DateTime perBeg;
            DateTime.TryParse(tbPerBeg.Text, out perBeg);
            livWage.RefLivWage_PerBeg = perBeg;

            DateTime perEnd;
            DateTime.TryParse(tbPerEnd.Text, out perEnd);
            livWage.RefLivWage_PerEnd = perEnd;

            decimal sm = 0;
            decimal.TryParse(tbSm.Text, out sm);
            livWage.RefLivWage_Sm = sm;
            return livWage;
        }

        public void AddControlPeriod(List<RefLivWage> livWages)
        {
            this.livWages = livWages;
        }

        public fmRefLivWageEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;
            tbPerBeg.AddDateField('.');
            tbPerEnd.AddDateField('.');

            tbSm.AddFloatField(16,2);
            tbSm.NecessaryField();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveLivWage()) return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmRefLivWageEdit_Load(object sender, EventArgs e)
        {
            tbPerBeg.IsModifyField(() => { btnOk.Enabled = true; });
            tbPerEnd.IsModifyField(() => { btnOk.Enabled = true; });
            tbSm.IsModifyField(() => { btnOk.Enabled = true; });
        }
    }
}
