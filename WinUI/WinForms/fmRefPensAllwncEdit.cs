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
    public partial class fmRefPensAllwncEdit : Form
    {
        private int _id = 0;

        public void SetData(RefPensAllwnc pensAllwnc)
        {
            if (pensAllwnc == null) return;

            _id = pensAllwnc.RefPensAllwnc_Id;
            tbCd.Text = pensAllwnc.RefPensAllwnc_Cd;
            tbNm.Text = pensAllwnc.RefPensAllwnc_Nm;
            tbPct.Text = pensAllwnc.RefPensAllwnc_Pct.ToString("0.00");
            cbUse.Checked = (pensAllwnc.RefPensAllwnc_Flg & (int)EnumPensAllwnc_Flg.ALLWNC_NOTUSE) > 0 ? false : true;
        }

        public RefPensAllwnc GetData()
        {
            RefPensAllwnc pensAllwnc = new RefPensAllwnc();
            pensAllwnc.RefPensAllwnc_Id = _id;
            pensAllwnc.RefPensAllwnc_Cd = tbCd.Text;
            pensAllwnc.RefPensAllwnc_Nm = tbNm.Text;
            decimal resDec = 0;
            if (decimal.TryParse(tbPct.Text, out resDec))
                pensAllwnc.RefPensAllwnc_Pct = resDec;
            if (cbUse.Checked)
            {
                pensAllwnc.RefPensAllwnc_Flg &= ~(int)EnumPensAllwnc_Flg.ALLWNC_NOTUSE;
            }
            else
            {
                pensAllwnc.RefPensAllwnc_Flg |= (int)EnumPensAllwnc_Flg.ALLWNC_NOTUSE;
            }
            return pensAllwnc;
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

        public fmRefPensAllwncEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);

            btnOk.Enabled = false;

            tbCd.NecessaryField();
            tbNm.NecessaryField();
            tbPct.NecessaryField();

            tbPct.AddFloatField(5, 2);
        }

        private void fmRefPensAllwncEdit_Load(object sender, EventArgs e)
        {
            tbCd.IsModifyField(() => { btnOk.Enabled = true; });
            tbNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbPct.IsModifyField(() => { btnOk.Enabled = true; });
            cbUse.IsModifyField(() => { btnOk.Enabled = true; });
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

        private void fmRefPensAllwncEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
