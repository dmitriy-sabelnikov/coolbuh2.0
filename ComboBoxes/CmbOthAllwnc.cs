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
    public class cmbOthAllwncParam
    {
        public void ClearParams()
        {
            if(tbCd != null) tbCd.Text = string.Empty;
            if(tbNm != null) tbNm.Text = string.Empty;
            if(tbPct != null) tbPct.Text = string.Empty;
            RefOthAllwnc_Id = 0;
        }
        public int RefOthAllwnc_Id { get; set; }
        public List<RefOthAllwnc> othAllwncs { get; set; }
        public TextBox tbCd { get; set; }
        public TextBox tbNm { get; set; }
        public TextBox tbPct { get; set; }
    }
    public class CmbOthAllwnc
    {
        private cmbOthAllwncParam _cmbParams = null;
        private void btn_Click(object sender, EventArgs e)
        {
            fmCmbOthAllwnc fmCmbAllwnc = new fmCmbOthAllwnc(_cmbParams.othAllwncs);
            if (fmCmbAllwnc.ShowDialog() == DialogResult.OK)
            {
                RefOthAllwnc allwnc = fmCmbAllwnc.GetData();
                _cmbParams.RefOthAllwnc_Id = allwnc.RefOthAllwnc_Id;
                if (_cmbParams.tbCd != null) _cmbParams.tbCd.Text = allwnc.RefOthAllwnc_Cd;
                if (_cmbParams.tbPct != null) _cmbParams.tbPct.Text = allwnc.RefOthAllwnc_Pct.ToString("0.00");
                if (_cmbParams.tbNm != null) _cmbParams.tbNm.Text = allwnc.RefOthAllwnc_Nm;
            }
        }
        private void tbCd_Validating(object sender, CancelEventArgs e)
        {
            if (_cmbParams.tbCd.Text == string.Empty)
            {
                _cmbParams.ClearParams();
                return;
            }
            RefOthAllwnc allwnc = _cmbParams.othAllwncs.FirstOrDefault(rec => rec.RefOthAllwnc_Cd == _cmbParams.tbCd.Text);
            if (allwnc != null)
            {
                _cmbParams.RefOthAllwnc_Id = allwnc.RefOthAllwnc_Id;

                if (_cmbParams.tbCd != null)
                    _cmbParams.tbCd.Text = allwnc.RefOthAllwnc_Cd;

                if (_cmbParams.tbNm != null)
                    _cmbParams.tbNm.Text = allwnc.RefOthAllwnc_Nm;

                if (_cmbParams.tbPct != null)
                    _cmbParams.tbPct.Text = allwnc.RefOthAllwnc_Pct.ToString("0.00");

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

        public void AddCombobox(Button btn, cmbOthAllwncParam cmbParams)
        {
            if (cmbParams == null) return;
            if (cmbParams.othAllwncs == null) return;

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
            if (_cmbParams.othAllwncs == null) return;

            RefOthAllwnc allwnc = _cmbParams.othAllwncs.FirstOrDefault(rec => rec.RefOthAllwnc_Id == id);
            if (allwnc == null)
            {
                _cmbParams.ClearParams();
                return;
            }
            _cmbParams.RefOthAllwnc_Id = allwnc.RefOthAllwnc_Id;

            if (_cmbParams.tbCd != null)
                _cmbParams.tbCd.Text = allwnc.RefOthAllwnc_Cd;

            if (_cmbParams.tbNm != null)
                _cmbParams.tbNm.Text = allwnc.RefOthAllwnc_Nm;

            if (_cmbParams.tbPct != null)
                _cmbParams.tbPct.Text = allwnc.RefOthAllwnc_Pct.ToString("0.00");
        }
    }
}
