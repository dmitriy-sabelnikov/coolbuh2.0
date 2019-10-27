using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormExtensions;
using Entities;
using EnumType;
using DAL;
using BLL;


namespace WinUI.WinForms
{
    public partial class fmRefTypeAddPaymentEdit : Form
    {
        private RefTypeAddPaymentRepository _repository = new RefTypeAddPaymentRepository(SetupProgram.Connection);
        private int id = 0;
        private bool CanSaveTypeAddPayment()
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

        public void SetData(RefTypeAddPayment typeAddPayment)
        {
            if (typeAddPayment == null) return;
            id = typeAddPayment.RefTypeAddPayment_Id;
            tbCode.Text = typeAddPayment.RefTypeAddPayment_Cd;
            tbName.Text = typeAddPayment.RefTypeAddPayment_Nm;

        }
        public RefTypeAddPayment GetData()
        {
            return new RefTypeAddPayment()
            {
                RefTypeAddPayment_Id = id,
                RefTypeAddPayment_Cd = tbCode.Text,
                RefTypeAddPayment_Nm = tbName.Text
            };
        }

        public fmRefTypeAddPaymentEdit(string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;

            tbCode.AddNumericField();

            tbCode.NecessaryField();
            tbName.NecessaryField();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveTypeAddPayment()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void fmRefTypeAddPaymentEdit_Load(object sender, EventArgs e)
        {
            tbCode.IsModifyField(() => { btnOk.Enabled = true; });
            tbName.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void fmRefTypeAddPaymentEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
