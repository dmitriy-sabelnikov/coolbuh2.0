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
using EnumType;

namespace WinUI.WinForms
{
    public partial class fmRefSpecExpEdit : Form
    {
        private int id = 0;
        private bool CanSaveSpecExp()
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
        public void SetData(RefSpecExp specExp)
        {
            if (specExp == null) return;
            id = specExp.RefSpecExp_Id;
            tbCode.Text = specExp.RefSpecExp_Cd;
            tbC_Pid.Text = specExp.RefSpecExp_C_Pid;
            tbName.Text = specExp.RefSpecExp_Name;
        }

        public RefSpecExp GetData()
        {
            return new RefSpecExp()
            {
                RefSpecExp_Id = id,
                RefSpecExp_Cd = tbCode.Text,
                RefSpecExp_C_Pid = tbC_Pid.Text,
                RefSpecExp_Name = tbName.Text
            };
        }

        public fmRefSpecExpEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveSpecExp())
                return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmRefSpecExpEdit_Load(object sender, EventArgs e)
        {
            tbCode.NecessaryField();
            tbName.NecessaryField();

            tbCode.IsModifyField(() => { btnOk.Enabled = true; });
            tbC_Pid.IsModifyField(() => { btnOk.Enabled = true; });
            tbName.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void fmRefSpecExpEdit_KeyDown(object sender, KeyEventArgs e)
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
