using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComboBoxes.WinWorms;
using System.Windows.Forms;
using System.ComponentModel;
using Entities;

namespace ComboBoxes
{
    public class cmbExpAllwncParam
    {
        public void ClearParams()
        {
            if(tbCd != null) tbCd.Text = string.Empty;
            if(tbNm != null) tbNm.Text = string.Empty;
            if(tbPct != null) tbPct.Text = string.Empty;
            RefExpAllwnc_Id = 0;
        }
        public int RefExpAllwnc_Id { get; set; }
        public int RefDep_MechId { get; set; }
        public List<RefExpAllwnc> expAllwncs { get; set; }
        public TextBox tbCd { get; set; }
        public TextBox tbNm { get; set; }
        public TextBox tbPct { get; set; }
    }
    public class CmbExpAllwnc
    {
        private cmbExpAllwncParam _cmbParams = null;
        private void btn_Click(object sender, EventArgs e)
        {
            fmCmbExpAllwnc fmCmbAllwnc = new fmCmbExpAllwnc(_cmbParams.expAllwncs);
            if (fmCmbAllwnc.ShowDialog() == DialogResult.OK)
            {
                RefExpAllwnc allwnc = fmCmbAllwnc.GetData();
                if (allwnc == null) return;
                _cmbParams.RefExpAllwnc_Id = allwnc.RefExpAllwnc_Id;
                if (_cmbParams.tbCd != null) _cmbParams.tbCd.Text = allwnc.RefExpAllwnc_Cd;
                if (_cmbParams.tbPct != null)
                {
                    if (allwnc.RefExpAllwncMech_RefDep_Id == _cmbParams.RefDep_MechId)
                        _cmbParams.tbPct.Text = allwnc.RefExpAllwnc_Mech.ToString("0.00");
                    else
                        _cmbParams.tbPct.Text = allwnc.RefExpAllwnc_Oth.ToString("0.00");
                }
                if (_cmbParams.tbNm != null) _cmbParams.tbNm.Text = allwnc.RefExpAllwnc_Nm;
            }
        }

        private void tbCd_Validating(object sender, CancelEventArgs e)
        {
            if (_cmbParams.tbCd.Text == string.Empty)
            {
                _cmbParams.ClearParams();
                return;
            }
            RefExpAllwnc allwnc = _cmbParams.expAllwncs.FirstOrDefault(rec => rec.RefExpAllwnc_Cd == _cmbParams.tbCd.Text);
            if (allwnc != null)
            {
                _cmbParams.RefExpAllwnc_Id = allwnc.RefExpAllwnc_Id;

                if (_cmbParams.tbCd != null)
                    _cmbParams.tbCd.Text = allwnc.RefExpAllwnc_Cd;

                if (_cmbParams.tbNm != null)
                    _cmbParams.tbNm.Text = allwnc.RefExpAllwnc_Nm;

                if (_cmbParams.tbPct != null)
                {
                    if (allwnc.RefExpAllwncMech_RefDep_Id == _cmbParams.RefDep_MechId)
                        _cmbParams.tbPct.Text = allwnc.RefExpAllwnc_Mech.ToString("0.00");
                    else
                        _cmbParams.tbPct.Text = allwnc.RefExpAllwnc_Oth.ToString("0.00");
                }
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

        public void AddCombobox(Button btn, cmbExpAllwncParam cmbParams)
        {
            if (cmbParams == null) return;
            if (cmbParams.expAllwncs == null) return;

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
            if (_cmbParams.expAllwncs == null) return;

            RefExpAllwnc allwnc = _cmbParams.expAllwncs.FirstOrDefault(rec => rec.RefExpAllwnc_Id == id);
            if (allwnc == null)
            {
                _cmbParams.ClearParams();
                return;
            }
            _cmbParams.RefExpAllwnc_Id = allwnc.RefExpAllwnc_Id;

            if (_cmbParams.tbCd != null)
                _cmbParams.tbCd.Text = allwnc.RefExpAllwnc_Cd;

            if (_cmbParams.tbNm != null)
                _cmbParams.tbNm.Text = allwnc.RefExpAllwnc_Nm;

            if (_cmbParams.tbPct != null)
            {
                if (allwnc.RefExpAllwncMech_RefDep_Id == _cmbParams.RefDep_MechId)
                    _cmbParams.tbPct.Text = allwnc.RefExpAllwnc_Mech.ToString("0.00");
                else
                    _cmbParams.tbPct.Text = allwnc.RefExpAllwnc_Oth.ToString("0.00");
            }
        }
    }
}
