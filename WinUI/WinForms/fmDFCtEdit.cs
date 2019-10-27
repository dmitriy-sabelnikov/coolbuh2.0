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
using Entities;
using BLL;

namespace WinUI.WinForms
{
    public partial class fmDFCtEdit : Form
    {
        private int _id = 0;

        private bool CanSaveDFCt()
        {
            if (cmbYr.SelectedIndex == -1)
            {
                cmbYr.Focus();
                return false;
            }
            if (cmbQrt.SelectedIndex == -1)
            {
                cmbQrt.Focus();
                return false;
            }
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
        //Инициализация календаря лет
        private void InitCmbYr()
        {
            cmbYr.DataSource = SalaryHelper.GetYears(DateTime.Today.Year - SetupProgram.YearSalary, DateTime.Today.Year);
        }
        public void SetData(DFCt dfCt)
        {
            _id = dfCt.DFCt_Id;
            cmbQrt.SelectedIndex = SalaryHelper.GetQrtByDate(dfCt.DFCt_Date) - 1;
            cmbYr.SelectedIndex = DateTime.Today.Year - dfCt.DFCt_Date.Year + 1;
            tbNmr.Text = dfCt.DFCt_Nmr.ToString();
            tbNm.Text = dfCt.DFCt_Nm;
            if ((dfCt.DFCt_Flg & (int)EnumActionEnterDF.AskCalc) > 0)
            {
                rbAskClc.Checked = true;
            }
            else if ((dfCt.DFCt_Flg & (int)EnumActionEnterDF.AlwaysCalc) > 0)
            {
                rbClc.Checked = true;
            }
            else
            {
                rbNoClc.Checked = true;
            }
        }
        public DFCt GetData()
        {
            DFCt dfCt = new DFCt();
            dfCt.DFCt_Id = _id;
            dfCt.DFCt_Date = SalaryHelper.GetDateByQrt(
                cmbQrt.SelectedIndex + 1,
                DateTime.Today.Year - SetupProgram.YearSalary + cmbYr.SelectedIndex
                );
            int resInt = 0;
            if (int.TryParse(tbNmr.Text, out resInt))
            {
                dfCt.DFCt_Nmr = resInt;
            }
            dfCt.DFCt_Nm = tbNm.Text;
            dfCt.DFCt_Flg = 0;
            if (rbAskClc.Checked)
            {
                dfCt.DFCt_Flg |= (int)EnumActionEnterDF.AskCalc;
            }
            else if (rbClc.Checked)
            {
                dfCt.DFCt_Flg |= (int)EnumActionEnterDF.AlwaysCalc;
            }
            dfCt.DFCt_DateClc = DateTime.MinValue;
            return dfCt;
        }

        public fmDFCtEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;

            InitCmbYr();

            cmbYr.Enabled = mode == EnumFormMode.Insert ? true : false;
            cmbQrt.Enabled = mode == EnumFormMode.Insert ? true : false;
            cmbYr.SelectedIndex = cmbYr.Items.Count - 1;
            cmbQrt.SelectedIndex = 0;

            tbNmr.NecessaryField();
            tbNm.NecessaryField();

            tbNmr.AddNumericField();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveDFCt()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void fmDFCtEdit_Load(object sender, EventArgs e)
        {
            cmbYr.IsModifyField(() => { btnOk.Enabled = true; });
            cmbQrt.IsModifyField(() => { btnOk.Enabled = true; });
            tbNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbNmr.IsModifyField(() => { btnOk.Enabled = true; });
            rbClc.IsModifyField(() => { btnOk.Enabled = true; });
            rbNoClc.IsModifyField(() => { btnOk.Enabled = true; });
            rbAskClc.IsModifyField(() => { btnOk.Enabled = true; });
        }
    }
}
