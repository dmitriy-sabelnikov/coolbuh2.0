using EnumType;
using System;
using System.Windows.Forms;
using WinFormExtensions;

namespace WinUI.WinForms
{
    public partial class fmUnionReportExport : Form
    {
        public fmUnionReportExport()
        {
            InitializeComponent();
            this.BaseFormStyle("Експорт об'еднаної звітності");
            btnExport.AddOpenFileDialog(tbPathExport);
        }

        public string GetPathExport() => tbPathExport.Text;
        public void SetPathExport(string path) => tbPathExport.Text = path;

        public int GetFlagExport()
        {
            int flag = 0;

            if (cbTbl1.Checked) flag |= (int)EnumExportUnionReport.ExportTbl1;
            if (cbTbl2.Checked) flag |= (int)EnumExportUnionReport.ExportTbl2;
            if (cbTbl4.Checked) flag |= (int)EnumExportUnionReport.ExportTbl4;
            //if (cbTbl5.Checked) flag |= (int)EnumExportUnionReport.ExportTbl5;

            return flag;
        }
        public void SetFlagExport(int flag)
        {
            cbTbl1.Checked = (flag & (int)EnumExportUnionReport.ExportTbl1) > 0 ? true : false;
            cbTbl2.Checked = (flag & (int)EnumExportUnionReport.ExportTbl2) > 0 ? true : false;
            cbTbl4.Checked = (flag & (int)EnumExportUnionReport.ExportTbl4) > 0 ? true : false;
            //cbTbl5.Checked = (flag & (int)EnumExportUnionReport.ExportTbl5) > 0 ? true : false;
        }

        #region Private methods

        private bool CanPressOk()
        {
            if (tbPathExport.Text == string.Empty)
            {
                tbPathExport.Focus();
                return false;
            }
            if (!cbTbl1.Checked && !cbTbl2.Checked && !cbTbl4.Checked /*&& !cbTbl5.Checked*/)
            {
                cbTbl1.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region Events

        private void fmUnionReportExport_Load(object sender, EventArgs e)
        {
            tbPathExport.NecessaryField(25);
            cbTbl1.NecessaryField(5);
            cbTbl2.NecessaryField(5);
            cbTbl4.NecessaryField(5);
            //cbTbl5.NecessaryField(5);
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

        #endregion

    }
}
