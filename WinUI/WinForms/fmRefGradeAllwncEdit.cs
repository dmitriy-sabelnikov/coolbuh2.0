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
using WinUI.Helper;
using ComboBoxes;
using BLL;
using EnumType;
using WinFormExtensions;
using DAL;

namespace WinUI.WinForms
{
    public partial class fmRefGradeAllwncEdit : Form
    {
        private cmbDepParam _cmbDepParams = new cmbDepParam();
        private CmbDep _cmbDep = new CmbDep();

        private RefDepRepository _repoDep = new RefDepRepository(SetupProgram.Connection);
        private List<RefDep> _deps = null;

        private int _id = 0;

        public void SetData(RefGradeAllwnc allowance)
        {
            if (allowance == null) return;
            _id = allowance.RefGradeAllwnc_Id;
            _cmbDep.ReadCombobox(allowance.RefGradeAllwnc_RefDep_Id);
            tbCd.Text = allowance.RefGradeAllwnc_Cd;
            tbNm.Text = allowance.RefGradeAllwnc_Nm;
            tbPct.Text = allowance.RefGradeAllwnc_Pct.ToString("0.00");
            tbGrade.Text = allowance.RefGradeAllwnc_Grade.ToString();
            cbUse.Checked = (allowance.RefGradeAllwnc_Flg & (int)EnumGradeAllwnc_Flg.ALLWNC_NOTUSE) > 0 ? false : true;
        }

        public RefGradeAllwnc GetData()
        {
            RefGradeAllwnc allwnc = new RefGradeAllwnc();
            allwnc.RefGradeAllwnc_Id = _id;
            allwnc.RefGradeAllwnc_Cd = tbCd.Text;
            allwnc.RefGradeAllwnc_Nm = tbNm.Text;
            decimal resDec = 0;
            if (decimal.TryParse(tbPct.Text, out resDec))
                allwnc.RefGradeAllwnc_Pct = resDec;
            int resInt = 0;
            if (int.TryParse(tbGrade.Text, out resInt))
                allwnc.RefGradeAllwnc_Grade = resInt;
            allwnc.RefGradeAllwnc_RefDep_Id = _cmbDepParams.RefDep_Id;
            if (cbUse.Checked)
            {
                allwnc.RefGradeAllwnc_Flg &= ~(int)EnumGradeAllwnc_Flg.ALLWNC_NOTUSE;
            }
            else
            {
                allwnc.RefGradeAllwnc_Flg |= (int)EnumGradeAllwnc_Flg.ALLWNC_NOTUSE;
            }
            return allwnc;
        }
        private bool CanSaveAllowance()
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
            if (tbPct.Text == string.Empty)
            {
                tbPct.Focus();
                return false;
            }
            return true;
        }

        public fmRefGradeAllwncEdit(EnumFormMode mode, string caption)
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

            tbCd.NecessaryField();
            tbNm.NecessaryField();
            tbPct.NecessaryField();

            tbGrade.AddNumericField();
            tbPct.AddFloatField(5, 2);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveAllowance()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void fmAllowanceEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void fmAllowanceEdit_Load(object sender, EventArgs e)
        {
            tbCd.IsModifyField(() => { btnOk.Enabled = true; });
            tbNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbPct.IsModifyField(() => { btnOk.Enabled = true; });
            tbGrade.IsModifyField(() => { btnOk.Enabled = true; });
            tbDepCd.IsModifyField(() => { btnOk.Enabled = true; });
            cbUse.IsModifyField(() => { btnOk.Enabled = true; });
        }
    }
}
