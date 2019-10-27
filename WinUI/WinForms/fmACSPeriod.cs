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

namespace WinUI.WinForms
{
    public partial class fmACSPeriod : Form
    {
        private bool CanSavePeriod()
        {
            if(cmbCalendarBeg.SelectedIndex > cmbCalendarEnd.SelectedIndex)
            {
                MessageBox.Show("Дата початку більше кінця періоду", "Увага");
                return false;
            }
            return true;
        }
        //Инициализация календарей
        private void InitCmbCalendarBeg()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, false);
            cmbCalendarBeg.DataSource = monthNames;
            cmbCalendarBeg.SelectedIndex = cmbCalendarBeg.Items.Count - 1;
        }
        private void InitCmbCalendarEnd()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, false);
            cmbCalendarEnd.DataSource = monthNames;
            cmbCalendarEnd.SelectedIndex = cmbCalendarEnd.Items.Count - 1;
        }

        public DateTime GetPeriodBeg()
        {
            return SalaryHelper.GetDateByIndex(cmbCalendarBeg.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);
        }
        public DateTime GetPeriodEnd()
        {
            return SalaryHelper.GetDateByIndex(cmbCalendarEnd.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);

        }

        public fmACSPeriod(string caption)
        {
            InitializeComponent();
            this.BaseFormStyle("Період розрахунку");
            Text = caption;
        }

        private void fmACSPeriod_Load(object sender, EventArgs e)
        {
            InitCmbCalendarBeg();
            InitCmbCalendarEnd();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSavePeriod()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
