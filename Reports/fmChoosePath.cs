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

namespace Reports
{
    public partial class fmChoosePath : Form
    {
        private bool CanPressOk()
        {
            if (tbPathExport.Text == string.Empty)
            {
                tbPathExport.Focus();
                return false;
            }
            return true;
        }

        public string GetPathExport()
        {
            return tbPathExport.Text;
        }
        public void SetPathExport(string path)
        {
            tbPathExport.Text = path;
        }

        public fmChoosePath()
        {
            InitializeComponent();
            btnExport.AddOpenFileDialog(tbPathExport);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanPressOk())
                return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmChoosePath_Load(object sender, EventArgs e)
        {
            tbPathExport.NecessaryField(25);
        }
    }
}
