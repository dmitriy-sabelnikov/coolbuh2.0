using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinUI.Helper;
using Entities;
using WinFormExtensions;
using ComboBoxes;
using DAL;
using BLL;
using EnumType;

namespace WinUI.WinForms
{
    public partial class fmRefExpAllwncEdit : Form
    {
        private int id = 0;
        private cmbDepParam _cmbDepParams = new cmbDepParam();
        private CmbDep _cmbDep = new CmbDep();

        private RefDepRepository _repoDep = new RefDepRepository(SetupProgram.Connection);
        private List<RefDep> _deps = null;

        private bool CanSaveExpAllwnc()
        {
            if (tbCd.Text == string.Empty)
            {
                tbCd.Focus();
                return false;
            }
            if (tbNm.Text == string.Empty)
            {
                tbNm.Focus();
                return false;
            }
            if (tbYear.Text == string.Empty)
            {
                tbYear.Focus();
                return false;
            }
            if (tbMech.Text == string.Empty)
            {
                tbMech.Focus();
                return false;
            }
            if (tbOth.Text == string.Empty)
            {
                tbOth.Focus();
                return false;
            }
            return true;
        }
        public void SetData(RefExpAllwnc expAllwnc)
        {
            if (expAllwnc == null) return;
            id = expAllwnc.RefExpAllwnc_Id;
            tbCd.Text = expAllwnc.RefExpAllwnc_Cd;
            tbNm.Text = expAllwnc.RefExpAllwnc_Nm;
            tbYear.Text = expAllwnc.RefExpAllwnc_Year.ToString();
            tbMech.Text = expAllwnc.RefExpAllwnc_Mech.ToString();
            tbOth.Text = expAllwnc.RefExpAllwnc_Oth.ToString();
            _cmbDep.ReadCombobox(expAllwnc.RefExpAllwncMech_RefDep_Id);
            cbUse.Checked = (expAllwnc.RefExpAllwnc_Flg & (int)EnumGradeAllwnc_Flg.ALLWNC_NOTUSE) > 0 ? false : true;
        }

        public RefExpAllwnc GetData()
        {
            RefExpAllwnc expAllwnc = new RefExpAllwnc();
            decimal decRes = 0;
            int intRes = 0;

            expAllwnc.RefExpAllwnc_Id = id;
            expAllwnc.RefExpAllwnc_Cd = tbCd.Text;
            expAllwnc.RefExpAllwnc_Nm = tbNm.Text;
            if (decimal.TryParse(tbMech.Text, out decRes))
                expAllwnc.RefExpAllwnc_Mech = decRes;
            if(decimal.TryParse(tbOth.Text, out decRes))
                expAllwnc.RefExpAllwnc_Oth = decRes;
            if(int.TryParse(tbYear.Text, out intRes))
                expAllwnc.RefExpAllwnc_Year = intRes;

            expAllwnc.RefExpAllwncMech_RefDep_Id = _cmbDepParams.RefDep_Id;
            if (cbUse.Checked)
            {
                expAllwnc.RefExpAllwnc_Flg &= ~(int)EnumExpAllwnc_Flg.ALLWNC_NOTUSE;
            }
            else
            {
                expAllwnc.RefExpAllwnc_Flg |= (int)EnumExpAllwnc_Flg.ALLWNC_NOTUSE;
            }

            return expAllwnc;
        }

        public fmRefExpAllwncEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;

            string error;
            _deps = _repoDep.GetAllDeps(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження довідника підрозділів.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            _cmbDepParams.refDeps = _deps;
            _cmbDepParams.tbCd = tbDepCd;
            _cmbDepParams.tbNm = tbDepNm;
            _cmbDep.AddCombobox(btnDep, _cmbDepParams);

            tbYear.AddNumericField();
            tbMech.AddFloatField(3, 2);
            tbOth.AddFloatField(3, 2);

            tbCd.NecessaryField();
            tbNm.NecessaryField();
            tbYear.NecessaryField();
            tbMech.NecessaryField();
            tbOth.NecessaryField();
        }

        private void fmRefExpAllwncEdit_Load(object sender, EventArgs e)
        {
            tbCd.IsModifyField(() => { btnOk.Enabled = true; });
            tbNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbYear.IsModifyField(() => { btnOk.Enabled = true; });
            tbMech.IsModifyField(() => { btnOk.Enabled = true; });
            tbOth.IsModifyField(() => { btnOk.Enabled = true; });
            tbDepCd.IsModifyField(() => { btnOk.Enabled = true; });
            tbDepNm.IsModifyField(() => { btnOk.Enabled = true; });
            cbUse.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveExpAllwnc())
                return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmRefExpAllwncEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
