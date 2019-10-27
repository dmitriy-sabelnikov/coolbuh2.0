using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using WinFormExtensions;

namespace Reports.StartFormReport
{
    public partial class fmSalStatement : Form
    {
        private void InitCmbCalendar()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, false);
            cmbCalendar.DataSource = monthNames;
        }
        public DateTime GetDateParam()
        {
            return SalaryHelper.GetDateByIndex(cmbCalendar.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);
        }
        public bool GetShowNullRec()
        {
            return cbShowNullRec.Checked ? true : false;
        }

        public fmSalStatement()
        {
            InitializeComponent();
            this.BaseFormStyle("Параметри звіту");
            InitCmbCalendar();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmSalStatement_KeyDown(object sender, KeyEventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
