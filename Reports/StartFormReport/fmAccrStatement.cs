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
using EnumType;
using Entities;
using WinFormExtensions;


namespace Reports.StartFormReport
{
    public partial class fmAccrStatement : Form
    {
        private List<RefDep> _checkedDeps = new List<RefDep>();
        public fmAccrStatement()
        {
            InitializeComponent();
            this.BaseFormStyle("Параметри звіту");
            InitCmbCalendarBeg();
            InitCmbCalendarEnd();
            rbFirm.Checked = true;
            SetEnableBtnDep();
        }

        public DateTime GetDateBegParam()
        {
            return SalaryHelper.GetDateByIndex(cmbCalendarBeg.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);
        }
        public DateTime GetDateEndParam()
        {
            return SalaryHelper.GetDateByIndex(cmbCalendarEnd.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);
        }

        public EnumSalaryList GetFormParam()
        {
            if (rbFirm.Checked)
                return EnumSalaryList.ByFirma;
            else if (rbDep.Checked)
                return EnumSalaryList.ByDep;
            return EnumSalaryList.ByPersCard;
        }

        public List<int> GetIdCheckedDep()
        {
            List<int> id = new List<int>();
            foreach (var dep in _checkedDeps)
            {
                id.Add(dep.RefDep_Id);
            }
            return id;
        }
        private bool CanBeOkParam()
        {
            DateTime datBeg = SalaryHelper.GetDateByIndex(cmbCalendarBeg.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);
            DateTime datEnd = SalaryHelper.GetDateByIndex(cmbCalendarEnd.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);

            if (datBeg > datEnd)
            {
                MessageBox.Show("Дата початку більше дати закінчення інтервалу", "Увага");
                cmbCalendarEnd.Focus();
                return false;
            }
            return true;
        }
        //Инициализация календарей
        private void InitCmbCalendarBeg()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, false);
            cmbCalendarBeg.DataSource = monthNames;
        }
        private void InitCmbCalendarEnd()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, false);
            cmbCalendarEnd.DataSource = monthNames;
        }
        private void SetEnableBtnDep()
        {
            btnDep.Enabled = rbDep.Checked ? true : false;
        }

        private void rbFirm_CheckedChanged(object sender, EventArgs e)
        {
            SetEnableBtnDep();
        }

        private void rbDep_CheckedChanged(object sender, EventArgs e)
        {
            SetEnableBtnDep();
        }

        private void btnDep_Click(object sender, EventArgs e)
        {
            fmDepartment dep = new fmDepartment();
            dep.SetCheckedDep(_checkedDeps);
            if (dep.ShowDialog() == DialogResult.OK)
            {
                _checkedDeps = dep.GetCheckedDep();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanBeOkParam())
                return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmAccrStatement_KeyDown(object sender, KeyEventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void cmbCalendarBeg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCalendarEnd.SelectedIndex < cmbCalendarBeg.SelectedIndex)
            {
                cmbCalendarEnd.SelectedIndex = cmbCalendarBeg.SelectedIndex;
            }
        }

        private void cmbCalendarEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCalendarEnd.SelectedIndex < cmbCalendarBeg.SelectedIndex)
            {
                cmbCalendarBeg.SelectedIndex = cmbCalendarBeg.SelectedIndex;
            }
        }
    }
}
