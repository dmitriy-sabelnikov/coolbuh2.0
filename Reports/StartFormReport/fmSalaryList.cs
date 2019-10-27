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
    public partial class fmSalaryList : Form
    {
        private List<RefDep> _checkedDeps = new List<RefDep>(); 
        //Инициализация календарей
        private void InitCmbCalendar()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, false);
            cmbCalendar.DataSource = monthNames;
        }
        public fmSalaryList(bool EnableRbPersCard)
        {
            InitializeComponent();
            this.BaseFormStyle("Параметри звіту");
            InitCmbCalendar();
            rbFirm.Checked = true;
            rbPersCard.Enabled = EnableRbPersCard;
            SetEnableBtnDep();
        }

        public DateTime GetDateParam()
        {
            return SalaryHelper.GetDateByIndex(cmbCalendar.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);
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
            foreach(var dep in _checkedDeps)
            {
                id.Add(dep.RefDep_Id);
            }
            return id;
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

        private void fmSalaryList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }

        private void rbFirm_CheckedChanged(object sender, EventArgs e)
        {
            SetEnableBtnDep();
        }

        private void SetEnableBtnDep()
        {
            btnDep.Enabled = rbDep.Checked ? true : false;
        }

        private void rbDep_CheckedChanged(object sender, EventArgs e)
        {
            SetEnableBtnDep();
        }

        private void rbPersCard_CheckedChanged(object sender, EventArgs e)
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
    }
}
