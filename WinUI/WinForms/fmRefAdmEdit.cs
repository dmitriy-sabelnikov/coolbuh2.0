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
using WinFormExtensions;
using EnumType;

namespace WinUI.WinForms
{
    public partial class fmRefAdmEdit : Form
    {
        private int id = 0;
        private ToolTip tooltip = new ToolTip();
        private bool CanSaveAdm()
        {
            if (tbFIO.Text == string.Empty)
            {
                tbFIO.Focus();
                return false;
            }
            if (cmbTypDol.SelectedIndex == -1)
            {
                cmbTypDol.Focus();
                return false;
            }
            return true;
        }
        public void SetData(RefAdm adm)
        {
            if (adm == null) return;
            id           = adm.RefAdm_Id;
            tbFIO.Text   = adm.RefAdm_FIO;
            tbTIN.Text   = adm.RefAdm_TIN;
            string namePos = PositionHelper.GetNamePosByCd(adm.RefAdm_TypDol);
            cmbTypDol.SelectedIndex = cmbTypDol.Items.IndexOf(namePos);
            tbTel.Text   = adm.RefAdm_Tel.ToString();
        }
        private void InitCmbPosition()
        {
            cmbTypDol.DataSource = PositionHelper.GetListNamePosition();
        }
        public RefAdm GetData()
        {
            RefAdm adm = new RefAdm();
            adm.RefAdm_Id = id;
            adm.RefAdm_FIO = tbFIO.Text;
            adm.RefAdm_TIN = tbTIN.Text;
            adm.RefAdm_TypDol = PositionHelper.GetCdPosByName(cmbTypDol.SelectedValue.ToString());
            int outres = 0;
            if (int.TryParse(tbTel.Text, out outres))
            {
                adm.RefAdm_Tel = outres;
            }
            return adm;
        }
        public fmRefAdmEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;
            tbFIO.NecessaryField();
            tbTIN.AddNumericField();
            tbTel.AddNumericField();
            InitCmbPosition();

        }

        private void tbTIN_Validating(object sender, CancelEventArgs e)
        {
            string error;
            tooltip.Hide(tbTIN);
            if (tbTIN.Text == string.Empty)
                return;

            if (!CheckTIN.CheckNumberTIN(tbTIN.Text, out error))
            {
                tbTIN.SetToolTipe(error);
                tbTIN.Focus();
                return;
            }
        }

        private void fmRefAdmEdit_Load(object sender, EventArgs e)
        {
            tbFIO.IsModifyField(() => { btnOk.Enabled = true; });
            tbTIN.IsModifyField(() => { btnOk.Enabled = true; });
            tbTel.IsModifyField(() => { btnOk.Enabled = true; });
            cmbTypDol.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveAdm())
                return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void fmRefAdmEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
