using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnumType;
using Entities;
using BLL;
using WinFormExtensions;

namespace WinUI.WinForms
{
    public partial class fmUSTCtEdit : Form
    {
        private int _id = 0;

        private bool CanSaveUstCt()
        {
            if (tbNmr.Text == string.Empty)
            {
                tbNmr.Focus();
                return false;
            }
            if (tbNm.Text == string.Empty)
            {
                tbNm.Focus();
                return false;
            }
            return true;
        }
        //Инициализация календарей
        private void InitCmbCalendar()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, false);
            cmbCalendar.DataSource = monthNames;
        }
        public fmUSTCtEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;

            InitCmbCalendar();

            cmbCalendar.Enabled = mode == EnumFormMode.Insert ? true : false;
            cmbCalendar.SelectedIndex = cmbCalendar.Items.Count - 1;

            tbNmr.NecessaryField();
            tbNm.NecessaryField();

            tbNmr.AddNumericField();
        }
        public void SetData(USTCt ustCt)
        {
            _id = ustCt.USTCt_Id;
            cmbCalendar.SelectedIndex = SalaryHelper.GetIndexByDate(
                DateTime.Today.Year - SetupProgram.YearSalary, ustCt.USTCt_Date, false);
            tbNmr.Text = ustCt.USTCt_Nmr.ToString();
            tbNm.Text = ustCt.USTCt_Nm;
            if ((ustCt.USTCt_Flg & (int)EnumActionEnterUST.AskCalc) > 0)
            {
                rbAskClc.Checked = true;
            }
            else if ((ustCt.USTCt_Flg & (int)EnumActionEnterUST.AlwaysCalc) > 0)
            {
                rbClc.Checked = true;
            }
            else
            {
                rbNoClc.Checked = true;
            }
        }
        public USTCt GetData()
        {
            USTCt ustCt = new USTCt();
            ustCt.USTCt_Id = _id;
            ustCt.USTCt_Date = SalaryHelper.GetDateByIndex(cmbCalendar.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);
            int resInt = 0;
            if(int.TryParse(tbNmr.Text, out resInt))
            {
                ustCt.USTCt_Nmr = resInt;
            }
            ustCt.USTCt_Nm = tbNm.Text;
            ustCt.USTCt_Flg = 0;
            if (rbAskClc.Checked)
            {
                ustCt.USTCt_Flg |= (int)EnumActionEnterUST.AskCalc;
            }
            else if (rbClc.Checked)
            {
                ustCt.USTCt_Flg |= (int)EnumActionEnterUST.AlwaysCalc;
            }
            return ustCt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveUstCt()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmUSTCtEdit_Load(object sender, EventArgs e)
        {
            cmbCalendar.IsModifyField(() => { btnOk.Enabled = true; });
            tbNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbNmr.IsModifyField(() => { btnOk.Enabled = true; });
            rbClc.IsModifyField(() => { btnOk.Enabled = true; });
            rbNoClc.IsModifyField(() => { btnOk.Enabled = true; });
            rbAskClc.IsModifyField(() => { btnOk.Enabled = true; });
        }
    }
}
