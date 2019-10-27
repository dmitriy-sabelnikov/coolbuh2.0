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

namespace WinUI.WinForms
{
    public partial class fmPassword : Form
    {
        private string _password { get; set; }

        public fmPassword()
        {
            InitializeComponent();
            this.BaseFormStyle("Пароль");
            btnOk.Enabled = false;
        }

        public string GetPassword()
        {
            return _password;
        }

        private void fmPassword_Load(object sender, EventArgs e)
        {
            tbPassword.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _password = tbPassword.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
