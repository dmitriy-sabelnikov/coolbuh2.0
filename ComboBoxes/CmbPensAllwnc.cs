using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using ComboBoxes.WinWorms;
using System.Windows.Forms;
using System.ComponentModel;

namespace ComboBoxes
{
    public class cmbPensAllwncParam
    {
        public void ClearParams()
        {
            if(tbCd != null) tbCd.Text = string.Empty;
            if(tbNm != null) tbNm.Text = string.Empty;
            if(tbPct != null) tbPct.Text = string.Empty;
            RefPensAllwnc_Id = 0;
        }
        public int RefPensAllwnc_Id { get; set; }
        public List<RefPensAllwnc> pensAllwncs { get; set; }
        public TextBox tbCd { get; set; }
        public TextBox tbNm { get; set; }
        public TextBox tbPct { get; set; }
    }
    public class CmbPensAllwnc
    {
        private cmbPensAllwncParam _cmbParams = null;
        private void btn_Click(object sender, EventArgs e)
        {
            fmCmbPensAllwnc fmCmbAllwnc = new fmCmbPensAllwnc(_cmbParams.pensAllwncs);
            if (fmCmbAllwnc.ShowDialog() == DialogResult.OK)
            {
                RefPensAllwnc allwnc = fmCmbAllwnc.GetData();
                _cmbParams.RefPensAllwnc_Id = allwnc.RefPensAllwnc_Id;
                if (_cmbParams.tbCd != null) _cmbParams.tbCd.Text = allwnc.RefPensAllwnc_Cd;
                if (_cmbParams.tbPct != null) _cmbParams.tbPct.Text = allwnc.RefPensAllwnc_Pct.ToString("0.00");
                if (_cmbParams.tbNm != null) _cmbParams.tbNm.Text = allwnc.RefPensAllwnc_Nm;
            }
        }
        private void tbCd_Validating(object sender, CancelEventArgs e)
        {
            if (_cmbParams.tbCd.Text == string.Empty)
            {
                _cmbParams.ClearParams();
                return;
            }
            RefPensAllwnc allwnc = _cmbParams.pensAllwncs.FirstOrDefault(rec => rec.RefPensAllwnc_Cd == _cmbParams.tbCd.Text);
            if (allwnc != null)
            {
                _cmbParams.RefPensAllwnc_Id = allwnc.RefPensAllwnc_Id;

                if (_cmbParams.tbCd != null)
                    _cmbParams.tbCd.Text = allwnc.RefPensAllwnc_Cd;

                if (_cmbParams.tbNm != null)
                    _cmbParams.tbNm.Text = allwnc.RefPensAllwnc_Nm;

                if (_cmbParams.tbPct != null)
                    _cmbParams.tbPct.Text = allwnc.RefPensAllwnc_Pct.ToString("0.00");

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

        public void AddCombobox(Button btn, cmbPensAllwncParam cmbParams)
        {
            if (cmbParams == null) return;
            if (cmbParams.pensAllwncs == null) return;

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
            if(_cmbParams.pensAllwncs == null) return;

            RefPensAllwnc allwnc = _cmbParams.pensAllwncs.FirstOrDefault(rec => rec.RefPensAllwnc_Id == id);
            if (allwnc == null)
            {
                _cmbParams.ClearParams();
                return;
            }
            _cmbParams.RefPensAllwnc_Id = allwnc.RefPensAllwnc_Id;

            if (_cmbParams.tbCd != null)
                _cmbParams.tbCd.Text = allwnc.RefPensAllwnc_Cd;

            if (_cmbParams.tbNm != null)
                _cmbParams.tbNm.Text = allwnc.RefPensAllwnc_Nm;

            if (_cmbParams.tbPct != null)
                _cmbParams.tbPct.Text = allwnc.RefPensAllwnc_Pct.ToString("0.00");
        }
    }
}
