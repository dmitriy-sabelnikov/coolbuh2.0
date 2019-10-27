using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entities;
using DAL;
using ComboBoxes.WinWorms;
using System.Windows.Forms;
using System.ComponentModel;

namespace ComboBoxes
{
    public class cmbGradeAllwncParam
    {
        public void ClearParams()
        {
            if(tbCd != null) tbCd.Text = string.Empty;
            if(tbNm != null) tbNm.Text = string.Empty;
            if(tbPct != null) tbPct.Text = string.Empty;
            RefGradeAllwnc_Id = 0;
        }
        public int RefGradeAllwnc_Id { get; set; }
        public List<RefGradeAllwnc> gradeAllwncs { get; set; }
        public TextBox tbCd { get; set; }
        public TextBox tbNm { get; set; }
        public TextBox tbPct { get; set; }
    }

    public class CmbGradeAllwnc
    {
        private cmbGradeAllwncParam _cmbParams = null;
        private void btn_Click(object sender, EventArgs e)
        {
            fmCmbGradeAllwnc fmCmbAllwnc = new fmCmbGradeAllwnc(_cmbParams.gradeAllwncs);
            if (fmCmbAllwnc.ShowDialog() == DialogResult.OK)
            { 
                RefGradeAllwnc allwnc = fmCmbAllwnc.GetData();
                _cmbParams.RefGradeAllwnc_Id = allwnc.RefGradeAllwnc_Id;
                if (_cmbParams.tbCd != null) _cmbParams.tbCd.Text = allwnc.RefGradeAllwnc_Cd;
                if (_cmbParams.tbPct != null) _cmbParams.tbPct.Text = allwnc.RefGradeAllwnc_Pct.ToString("0.00");
                if (_cmbParams.tbNm != null) _cmbParams.tbNm.Text = allwnc.RefGradeAllwnc_Nm;
            }
        }
        private void tbCd_Validating(object sender, CancelEventArgs e)
        {
            if (_cmbParams.tbCd.Text == string.Empty)
            {
                _cmbParams.ClearParams();
                return;
            }
            RefGradeAllwnc allwnc = _cmbParams.gradeAllwncs.FirstOrDefault(rec => rec.RefGradeAllwnc_Cd == _cmbParams.tbCd.Text);
            if (allwnc != null)
            {
                _cmbParams.RefGradeAllwnc_Id = allwnc.RefGradeAllwnc_Id;

                if (_cmbParams.tbCd != null)
                    _cmbParams.tbCd.Text = allwnc.RefGradeAllwnc_Cd;

                if (_cmbParams.tbNm != null)
                    _cmbParams.tbNm.Text = allwnc.RefGradeAllwnc_Nm;

                if (_cmbParams.tbPct != null)
                    _cmbParams.tbPct.Text = allwnc.RefGradeAllwnc_Pct.ToString("0.00");

            }
            else
            {
                _cmbParams.ClearParams();
                btn_Click(sender, e);
            }
        }

        private void tbCd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tbCd_Validating(sender, new CancelEventArgs());
            }
        }

        public void AddCombobox(Button btn, cmbGradeAllwncParam cmbParams)
        {
            if (cmbParams == null) return;
            if (cmbParams.gradeAllwncs == null) return;

            _cmbParams = cmbParams;

            if (_cmbParams.tbCd != null)
            {
                _cmbParams.tbCd.Validating += new CancelEventHandler(tbCd_Validating);
                _cmbParams.tbCd.KeyDown += new KeyEventHandler(tbCd_KeyDown);
            }
            if (btn != null)
            {
                btn.Click += new EventHandler(btn_Click);
            }
        }
        public void ReadCombobox(int id)
        {
            if (_cmbParams == null) return;
            if (_cmbParams.gradeAllwncs == null) return;

            RefGradeAllwnc allwnc = _cmbParams.gradeAllwncs.FirstOrDefault(rec => rec.RefGradeAllwnc_Id == id);
            if (allwnc == null)
            {
                _cmbParams.ClearParams();
                return;
            }
            _cmbParams.RefGradeAllwnc_Id = allwnc.RefGradeAllwnc_Id;

            if (_cmbParams.tbCd != null)
                _cmbParams.tbCd.Text = allwnc.RefGradeAllwnc_Cd;

            if (_cmbParams.tbNm != null)
                _cmbParams.tbNm.Text = allwnc.RefGradeAllwnc_Nm;

            if (_cmbParams.tbPct != null)
                _cmbParams.tbPct.Text = allwnc.RefGradeAllwnc_Pct.ToString("0.00");
        }
    }
}
