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
    public partial class fmPersCardDisabilityEdit : Form
    {
        private int _id = 0;
        private List<Disability> disabilities = null;
        private bool CanSaveDisability()
        {
            if (tbPerBeg.Text == string.Empty && tbPerEnd.Text == string.Empty)
                return false;
            if (tbAttr.Text == string.Empty)
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

            if (disabilities != null)
            {
                foreach (Disability disability in disabilities)
                {
                    if (_id == disability.Disability_Id)
                        continue;
                    DateTime datBeg = disability.Disability_PerBeg;
                    DateTime datEnd = disability.Disability_PerEnd == DateTime.MinValue ? DateTime.MaxValue : disability.Disability_PerEnd;
                    if (perEnd >= datBeg && perBeg <= datEnd)
                    {
                        MessageBox.Show("Період перетинається з існуючим", "Помилка");
                        return false;
                    }
                }
            }
            return true;
        }

        public void SetData(Disability disability)
        {
            _id = disability.Disability_Id;
            if (disability.Disability_PerBeg != DateTime.MinValue)
                tbPerBeg.Text = disability.Disability_PerBeg.ToShortDateString();
            if (disability.Disability_PerEnd!= DateTime.MinValue)
                tbPerEnd.Text = disability.Disability_PerEnd.ToShortDateString();
            tbAttr.Text = disability.Disability_Attr.ToString();
        }

        public Disability GetData()
        {
            Disability disability = new Disability();
            disability.Disability_Id = _id;

            DateTime perBeg;
            DateTime.TryParse(tbPerBeg.Text, out perBeg);
            disability.Disability_PerBeg = perBeg;

            DateTime perEnd;
            DateTime.TryParse(tbPerEnd.Text, out perEnd);
            disability.Disability_PerEnd = perEnd;

            int attr = 0;
            int.TryParse(tbAttr.Text, out attr);
            disability.Disability_Attr = attr;
            return disability;
        }

        public void AddControlPeriod(List<Disability> disabilities)
        {
            this.disabilities = disabilities;
        }
        public fmPersCardDisabilityEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;
            tbPerBeg.AddDateField('.');
            tbPerEnd.AddDateField('.');

            tbAttr.AddNumericField();
            tbAttr.NecessaryField();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveDisability()) return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmPersCardDisabilityEdit_Load(object sender, EventArgs e)
        {
            tbPerBeg.IsModifyField(() => { btnOk.Enabled = true; });
            tbPerEnd.IsModifyField(() => { btnOk.Enabled = true; });
            tbAttr.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void fmPersCardDisabilityEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }
    }
}
