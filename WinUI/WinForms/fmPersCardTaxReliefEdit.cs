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
    public partial class fmPersCardTaxReliefEdit : Form
    {
        private int _id = 0;
        private List<TaxRelief> taxReliefs = null;

        private bool CanSaveTaxRelief()
        {
            if (tbPerBeg.Text == string.Empty && tbPerEnd.Text == string.Empty)
                return false;
            if (tbKoef.Text == string.Empty)
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

            if (taxReliefs != null)
            {
                foreach (TaxRelief taxRelief in taxReliefs)
                {
                    if (_id == taxRelief.TaxRelief_Id)
                        continue;
                    DateTime datBeg = taxRelief.TaxRelief_PerBeg;
                    DateTime datEnd = taxRelief.TaxRelief_PerEnd == DateTime.MinValue ? DateTime.MaxValue : taxRelief.TaxRelief_PerEnd;
                    if (perEnd >= datBeg && perBeg <= datEnd)
                    {
                        MessageBox.Show("Період перетинається з існуючим", "Помилка");
                        return false;
                    }
                }
            }
            return true;
        }

        public void SetData(TaxRelief taxRelief)
        {
            _id = taxRelief.TaxRelief_Id;
            if (taxRelief.TaxRelief_PerBeg != DateTime.MinValue)
                tbPerBeg.Text = taxRelief.TaxRelief_PerBeg.ToShortDateString();
            if (taxRelief.TaxRelief_PerEnd != DateTime.MinValue)
                tbPerEnd.Text = taxRelief.TaxRelief_PerEnd.ToShortDateString();
            tbKoef.Text = taxRelief.TaxRelief_Koef.ToString();
        }

        public TaxRelief GetData()
        {
            TaxRelief taxRelief = new TaxRelief();
            taxRelief.TaxRelief_Id = _id;

            DateTime perBeg;
            DateTime.TryParse(tbPerBeg.Text, out perBeg);
            taxRelief.TaxRelief_PerBeg = perBeg;

            DateTime perEnd;
            DateTime.TryParse(tbPerEnd.Text, out perEnd);
            taxRelief.TaxRelief_PerEnd = perEnd;


            decimal koef = 0;
            decimal.TryParse(tbKoef.Text, out koef);
            taxRelief.TaxRelief_Koef = koef;
            return taxRelief;
        }
        public void AddControlPeriod(List<TaxRelief> taxReliefs)
        {
            this.taxReliefs = taxReliefs;
        }

        public fmPersCardTaxReliefEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;
            tbPerBeg.AddDateField('.');
            tbPerEnd.AddDateField('.');

            tbKoef.AddFloatField(10, 2);
            tbKoef.NecessaryField();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveTaxRelief()) return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmPersCardTaxReliefEdit_Load(object sender, EventArgs e)
        {
            tbPerBeg.IsModifyField(() => { btnOk.Enabled = true; });
            tbPerEnd.IsModifyField(() => { btnOk.Enabled = true; });
            tbKoef.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void fmPersCardTaxReliefEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }
    }
}
