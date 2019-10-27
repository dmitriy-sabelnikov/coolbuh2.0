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
    public partial class fmRefOthAllwncEdit : Form
    {
        private int _id = 0;

        public void SetData(RefOthAllwnc othAllwnc)
        {
            if (othAllwnc == null) return;

            _id = othAllwnc.RefOthAllwnc_Id;
            tbCd.Text = othAllwnc.RefOthAllwnc_Cd;
            tbNm.Text = othAllwnc.RefOthAllwnc_Nm;
            tbPct.Text = othAllwnc.RefOthAllwnc_Pct.ToString("0.00");
            cbUse.Checked = (othAllwnc.RefOthAllwnc_Flg & (int)EnumOthAllwnc_Flg.ALLWNC_NOTUSE) > 0 ? false : true;
        }

        public RefOthAllwnc GetData()
        {
            RefOthAllwnc othAllwnc = new RefOthAllwnc();
            othAllwnc.RefOthAllwnc_Id = _id;
            othAllwnc.RefOthAllwnc_Cd = tbCd.Text;
            othAllwnc.RefOthAllwnc_Nm = tbNm.Text;
            decimal resDec = 0;
            if (decimal.TryParse(tbPct.Text, out resDec))
                othAllwnc.RefOthAllwnc_Pct = resDec;
            if (cbUse.Checked)
            {
                othAllwnc.RefOthAllwnc_Flg &= ~(int)EnumOthAllwnc_Flg.ALLWNC_NOTUSE;
            }
            else
            {
                othAllwnc.RefOthAllwnc_Flg |= (int)EnumOthAllwnc_Flg.ALLWNC_NOTUSE;
            }
            return othAllwnc;
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

        public fmRefOthAllwncEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);

            btnOk.Enabled = false;

            tbCd.NecessaryField();
            tbNm.NecessaryField();
            tbPct.NecessaryField();

            tbPct.AddFloatField(5, 2);
        }

        private void fmRefOthAllwncEdit_Load(object sender, EventArgs e)
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

        private void fmRefOthAllwncEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
