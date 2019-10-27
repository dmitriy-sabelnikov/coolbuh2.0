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
    public partial class fmRefTypeAddAccrEdit : Form
    {
        private int id = 0;

        private bool CanSaveTypeAddAccr()
        {
            if (tbCode.Text == string.Empty)
            {
                tbCode.Focus();
                return false;
            }
            if (tbName.Text == string.Empty)
            {
                tbName.Focus();
                return false;
            }
            return true;
        }
        public void SetData(RefTypeAddAccr typeAddAccr)
        {
            if (typeAddAccr == null) return;
            id = typeAddAccr.RefTypeAddAccr_Id;
            tbCode.Text = typeAddAccr.RefTypeAddAccr_Cd;
            tbName.Text = typeAddAccr.RefTypeAddAccr_Nm;
            cbClc.Checked = 
                (typeAddAccr.RefTypeAddAccr_Flg & (int)EnumTypeAddAccr_Flg.TypeAddAccr_Clc) > 0 ? true : false;
        }

        public RefTypeAddAccr GetData()
        {
            RefTypeAddAccr typeAddAccr = new RefTypeAddAccr();
            typeAddAccr.RefTypeAddAccr_Id = id;
            typeAddAccr.RefTypeAddAccr_Cd = tbCode.Text;
            typeAddAccr.RefTypeAddAccr_Nm = tbName.Text;
            if (cbClc.Checked)
                typeAddAccr.RefTypeAddAccr_Flg |= (int)EnumTypeAddAccr_Flg.TypeAddAccr_Clc;
            else
                typeAddAccr.RefTypeAddAccr_Flg &= ~(int)EnumTypeAddAccr_Flg.TypeAddAccr_Clc;
            return typeAddAccr;
        }
        public fmRefTypeAddAccrEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;

            tbCode.NecessaryField();
            tbName.NecessaryField();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveTypeAddAccr())
                return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void fmRefTypeAddAccrEdit_Load(object sender, EventArgs e)
        {
            tbCode.IsModifyField(() => { btnOk.Enabled = true; });
            tbName.IsModifyField(() => { btnOk.Enabled = true; });
            cbClc.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void fmRefTypeAddAccrEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }
    }
}
