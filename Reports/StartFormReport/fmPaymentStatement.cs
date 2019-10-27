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
    public partial class fmPaymentStatement : Form
    {
        private List<v_TypePayment> _checkedPayments = new List<v_TypePayment>();
        private List<RefTypeAddPayment> _checkedAddPayments = new List<RefTypeAddPayment>();

        public fmPaymentStatement()
        {
            InitializeComponent();
            this.BaseFormStyle("Параметри звіту");
            InitCmbCalendar();
            rbAllPayment.Checked = true;
            SetEnableBtnDep();
        }

        //Инициализация календарей
        private void InitCmbCalendar()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, false);
            cmbCalendar.DataSource = monthNames;
        }

        public DateTime GetDateParam()
        {
            return SalaryHelper.GetDateByIndex(cmbCalendar.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);
        }

        public EnumPaymentStatement GetFormParam()
        {
            if (rbAllPayment.Checked)
                return EnumPaymentStatement.AllPayment;
            return EnumPaymentStatement.ConcrPayment;
        }

        public List<int> GetIdCheckedTypePayment()
        {
            List<int> id = new List<int>();
            foreach (var payment in _checkedPayments)
            {
                id.Add(payment.Id);
            }
            return id;
        }

        public List<int> GetIdCheckedTypeAddPayment()
        {
            List<int> id = new List<int>();
            foreach (var addPayment in _checkedAddPayments)
            {
                id.Add(addPayment.RefTypeAddPayment_Id);
            }
            return id;
        }
        private void SetEnableBtnDep()
        {
            btnPayment.Enabled = rbConcrPayment.Checked ? true : false;
            btnAddPayment.Enabled = rbConcrPayment.Checked ? true : false;
        }

        private void rbAllPayment_CheckedChanged(object sender, EventArgs e)
        {
            SetEnableBtnDep();
        }

        private void rbConcrPayment_CheckedChanged(object sender, EventArgs e)
        {
            SetEnableBtnDep();
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

        private void btnPayment_Click(object sender, EventArgs e)
        {
            fmTypePayment typPayment = new fmTypePayment();
            typPayment.SetCheckedPayment(_checkedPayments);
            if (typPayment.ShowDialog() == DialogResult.OK)
            {
                _checkedPayments = typPayment.GetCheckedPayment();
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            fmTypeAddPayment typAddPayment = new fmTypeAddPayment();
            typAddPayment.SetCheckedAddPayment(_checkedAddPayments);
            if (typAddPayment.ShowDialog() == DialogResult.OK)
            {
                _checkedAddPayments = typAddPayment.GetCheckedAddPayment();
            }
        }
    }
}
