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
using DAL;
using Entities;
using BLL;
using WinFormExtensions;

namespace WinUI.WinForms
{
    public partial class fmRefDepEdit : Form
    {
        private RefDepRepository _repository = new RefDepRepository(SetupProgram.Connection);
        private int id = 0;
        private bool CanSaveDep()
        {
            if(tbCode.Text == string.Empty)
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
        public void SetData(RefDep refDep)
        {
            if (refDep == null) return;
            id = refDep.RefDep_Id;
            tbCode.Text = refDep.RefDep_Cd;
            tbName.Text = refDep.RefDep_Nm;
        }

        public RefDep GetData()
        {
            return new RefDep()
            {
                RefDep_Id = id ,
                RefDep_Cd = tbCode.Text,
                RefDep_Nm = tbName.Text
            };
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveDep()) return;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void fmRefDepEdit_Load(object sender, EventArgs e)
        {
            tbCode.IsModifyField(() => { btnOk.Enabled = true;});
            tbName.IsModifyField(() => { btnOk.Enabled = true; });
        }

        public fmRefDepEdit(string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;

            tbCode.AddNumericField();

            tbCode.NecessaryField();
            tbName.NecessaryField();
        }

        private void fmRefDepEdit_KeyDown(object sender, KeyEventArgs e)
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
