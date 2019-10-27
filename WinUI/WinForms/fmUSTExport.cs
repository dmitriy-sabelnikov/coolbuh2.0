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
using EnumType;

namespace WinUI.WinForms
{
    public partial class fmUSTExport : Form
    {
        private bool CanPressOk()
        {
            if (tbPathExport.Text == string.Empty)
            {
                tbPathExport.Focus();
                return false;
            }
            if (cbTbl6.Checked == false && cbTbl7.Checked == false)
            {
                cbTbl6.Focus();
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

        public int GetFlgExport()
        {
            int flg = 0;
            if (cbTbl6.Checked)
                flg |= (int)EnumExportUST.ExportTbl6;
            if (cbTbl7.Checked)
                flg |= (int)EnumExportUST.ExportTbl7;
            return flg;
        }
        public void SetFlgExport(int flg)
        {
            cbTbl6.Checked = (flg & (int)EnumExportUST.ExportTbl6) > 0 ? true : false;
            cbTbl7.Checked = (flg & (int)EnumExportUST.ExportTbl7) > 0 ? true : false;
        }

        public fmUSTExport()
        {
            InitializeComponent();
            this.BaseFormStyle("Експорт ЕСВ");
            btnExport.AddOpenFileDialog(tbPathExport);
        }

        private void fmUSTExport_Load(object sender, EventArgs e)
        {
            tbPathExport.NecessaryField(25);
            cbTbl6.NecessaryField(5);
            cbTbl7.NecessaryField(5);
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
    }
}
