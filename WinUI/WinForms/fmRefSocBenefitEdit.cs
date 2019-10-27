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
    public partial class fmRefSocBenefitEdit : Form
    {
        private int _id = 0;
        private List<RefSocBenefit> socBenefits = null;
        private bool CanSaveSocBenefit()
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

            if (socBenefits != null)
            {
                foreach (RefSocBenefit socBenefit in socBenefits)
                {
                    if (_id == socBenefit.RefSocBenefit_Id)
                        continue;
                    DateTime datBeg = socBenefit.RefSocBenefit_PerBeg;
                    DateTime datEnd = socBenefit.RefSocBenefit_PerEnd == DateTime.MinValue ? DateTime.MaxValue : socBenefit.RefSocBenefit_PerEnd;
                    if (perEnd >= datBeg && perBeg <= datEnd)
                    {
                        MessageBox.Show("Період перетинається з існуючим ", "Помилка");
                        return false;
                    }
                }
            }
            return true;
        }
        public void SetData(RefSocBenefit socBenefit)
        {
            _id = socBenefit.RefSocBenefit_Id;
            if (socBenefit.RefSocBenefit_PerBeg != DateTime.MinValue)
                tbPerBeg.Text = socBenefit.RefSocBenefit_PerBeg.ToShortDateString();
            if (socBenefit.RefSocBenefit_PerEnd != DateTime.MinValue)
                tbPerEnd.Text = socBenefit.RefSocBenefit_PerEnd.ToShortDateString();
            tbSm.Text = socBenefit.RefSocBenefit_Sm.ToString();
            tbLimSm.Text = socBenefit.RefSocBenefit_LimSm.ToString();
        }
        public RefSocBenefit GetData()
        {
            RefSocBenefit socBenefit = new RefSocBenefit();
            socBenefit.RefSocBenefit_Id = _id;

            DateTime perBeg;
            DateTime.TryParse(tbPerBeg.Text, out perBeg);
            socBenefit.RefSocBenefit_PerBeg = perBeg;

            DateTime perEnd;
            DateTime.TryParse(tbPerEnd.Text, out perEnd);
            socBenefit.RefSocBenefit_PerEnd = perEnd;

            decimal sm = 0;
            decimal.TryParse(tbSm.Text, out sm);
            socBenefit.RefSocBenefit_Sm = sm;

            decimal.TryParse(tbLimSm.Text, out sm);
            socBenefit.RefSocBenefit_LimSm = sm;
            return socBenefit;
        }

        public void AddControlPeriod(List<RefSocBenefit> socBenefits)
        {
            this.socBenefits = socBenefits;
        }

        public fmRefSocBenefitEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;
            tbPerBeg.AddDateField('.');
            tbPerEnd.AddDateField('.');

            tbSm.AddFloatField(16, 2);
            tbSm.NecessaryField();

            tbLimSm.AddFloatField(16, 2);
            tbLimSm.NecessaryField();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveSocBenefit()) return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmRefSocBenefitEdit_Load(object sender, EventArgs e)
        {
            tbPerBeg.IsModifyField(() => { btnOk.Enabled = true; });
            tbPerEnd.IsModifyField(() => { btnOk.Enabled = true; });
            tbSm.IsModifyField(() => { btnOk.Enabled = true; });
            tbLimSm.IsModifyField(() => { btnOk.Enabled = true; });
        }
    }
}
