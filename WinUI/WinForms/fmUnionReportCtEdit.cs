using BLL;
using Entities;
using EnumType;
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

namespace WinUI.WinForms
{
    public partial class fmUnionReportCtEdit : Form
    {
        private int _id = 0;

        public fmUnionReportCtEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;

            InitCmbYear();

            cmbYr.Enabled = mode == EnumFormMode.Insert ? true : false;
            cmbQrt.Enabled = mode == EnumFormMode.Insert ? true : false;
            cmbYr.SelectedIndex = cmbYr.Items.Count - 1;
            cmbQrt.SelectedIndex = 0;

            tbNmr.NecessaryField();
            tbNm.NecessaryField();

            tbNmr.AddNumericField();
        }

        #region Private methods

        // Инициализация календаря 
        private void InitCmbYear()
        {
            cmbYr.DataSource = SalaryHelper.GetYears(DateTime.Today.Year - SetupProgram.YearSalary, DateTime.Today.Year);
        }

        // Получить индекс комбика кварталов
        private int GetComboboxQrtIndex(int quarter)
            => quarter - 1;

        // Получить индекс комбика лет
        private int GetQrtFromComboboxIndex(int index)
            => index + 1;

        // Получить квартал по индексу комбика 
        private int GetComboboxYearIndex(int year)
            => DateTime.Today.Year - year + 1;

        // Получить год по индексу комбика 
        private int GetYearFromComboboxIndex(int index)
            => DateTime.Today.Year - SetupProgram.YearSalary + index;

        // Возможность сохранить 
        private bool CanSave()
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

        #endregion

        #region Public methods

        public void SetData(UnionReportCt unionReportCt)
        {
            _id = unionReportCt.UnionReportCt_Id;
            cmbQrt.SelectedIndex = GetComboboxQrtIndex(unionReportCt.UnionReportCt_Qrt);
            cmbYr.SelectedIndex = GetComboboxYearIndex(unionReportCt.UnionReportCt_Year);
            tbNmr.Text = unionReportCt.UnionReportCt_Nmr.ToString();
            tbNm.Text = unionReportCt.UnionReportCt_Nm;
            if ((unionReportCt.UnionReportCt_Flg & (int)EnumActionEnterUnionReport.AskCalc) > 0)
            {
                rbAskClc.Checked = true;
            }
            else if ((unionReportCt.UnionReportCt_Flg & (int)EnumActionEnterUnionReport.AlwaysCalc) > 0)
            {
                rbClc.Checked = true;
            }
            else
            {
                rbNoClc.Checked = true;
            }
        }
        public UnionReportCt GetData()
        {
            var unionReportCt = new UnionReportCt();
            unionReportCt.UnionReportCt_Id = _id;
            unionReportCt.UnionReportCt_Qrt = GetQrtFromComboboxIndex(cmbQrt.SelectedIndex);
            unionReportCt.UnionReportCt_Year = GetYearFromComboboxIndex(cmbYr.SelectedIndex);

            int resInt = 0;
            if (int.TryParse(tbNmr.Text, out resInt))
            {
                unionReportCt.UnionReportCt_Nmr = resInt;
            }
            unionReportCt.UnionReportCt_Nm = tbNm.Text;
            unionReportCt.UnionReportCt_Flg = 0;

            if (rbAskClc.Checked)
            {
                unionReportCt.UnionReportCt_Flg |= (int)EnumActionEnterUnionReport.AskCalc;
            }
            else if (rbClc.Checked)
            {
                unionReportCt.UnionReportCt_Flg |= (int)EnumActionEnterUnionReport.AlwaysCalc;
            }
            unionReportCt.UnionReportCt_DateClc = DateTime.MinValue;

            return unionReportCt;
        }

        #endregion

        #region Events

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSave()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void fmUnionReportCtEdit_Load(object sender, EventArgs e)
        {
            cmbYr.IsModifyField(() => { btnOk.Enabled = true; });
            cmbQrt.IsModifyField(() => { btnOk.Enabled = true; });
            tbNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbNmr.IsModifyField(() => { btnOk.Enabled = true; });
            rbClc.IsModifyField(() => { btnOk.Enabled = true; });
            rbNoClc.IsModifyField(() => { btnOk.Enabled = true; });
            rbAskClc.IsModifyField(() => { btnOk.Enabled = true; });
        }

        #endregion
    }
}
