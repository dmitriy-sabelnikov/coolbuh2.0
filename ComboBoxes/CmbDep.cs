using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using ComboBoxes.WinWorms;
using System.Data.SqlClient;
using Entities;
using DAL;

namespace ComboBoxes
{
    public class cmbDepParam
    {
        public void ClearParams()
        {
            RefDep_Id = 0;
            if (tbCd != null) tbCd.Text = string.Empty;
            if (tbNm != null) tbNm.Text = string.Empty;
        }
        public int RefDep_Id { get; set; }
        public List<RefDep> refDeps { get; set; }
        public TextBox tbCd { get; set; }
        public TextBox tbNm { get; set; }
    }
    public class CmbDep
    {
        private cmbDepParam _cmbParams = null;
        private void btn_Click(object sender, EventArgs e)
        {
            fmCmbDep cmbDep = new fmCmbDep(_cmbParams.refDeps);
            if (cmbDep.ShowDialog() == DialogResult.OK)
            {
                RefDep dep = cmbDep.GetData();
                _cmbParams.RefDep_Id = dep.RefDep_Id;
                if(_cmbParams.tbCd != null)
                    _cmbParams.tbCd.Text = dep.RefDep_Cd;
                if (_cmbParams.tbNm != null)
                    _cmbParams.tbNm.Text = dep.RefDep_Nm;
            }
        }

        private void tbCd_Validating(object sender, CancelEventArgs e)
        {
            if(_cmbParams.tbCd.Text == string.Empty)
            {
                _cmbParams.ClearParams();
                return;
            }
            RefDep dep = _cmbParams.refDeps.FirstOrDefault(deps => deps.RefDep_Cd == _cmbParams.tbCd.Text);
            if (dep != null)
            {
                _cmbParams.RefDep_Id = dep.RefDep_Id;
                _cmbParams.tbCd.Text = dep.RefDep_Cd;
                if (_cmbParams.tbNm != null)
                    _cmbParams.tbNm.Text = dep.RefDep_Nm;
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

        public void AddCombobox(Button btnDep, cmbDepParam cmbParams)
        {
            if (cmbParams == null) return;
            if (cmbParams.refDeps == null) return;

            _cmbParams = cmbParams;

            if (_cmbParams.tbCd != null)
            {
                _cmbParams.tbCd.Validating += new CancelEventHandler(tbCd_Validating);
                _cmbParams.tbCd.KeyDown += new KeyEventHandler(tbCd_KeyDown);
            }

            if (btnDep != null)
            {
                btnDep.Click += new EventHandler(btn_Click);
            }
        }
        public void ReadCombobox(int id)
        {
            if (_cmbParams == null) return;
            if (_cmbParams.refDeps == null) return;


            RefDep dep = _cmbParams.refDeps.FirstOrDefault(deps => deps.RefDep_Id == id);
            if (dep == null)
            {
                _cmbParams.ClearParams();
                return;
            }
            _cmbParams.RefDep_Id = dep.RefDep_Id;

            if (_cmbParams.tbCd !=null)
                _cmbParams.tbCd.Text = dep.RefDep_Cd;

            if (_cmbParams.tbNm != null)
                _cmbParams.tbNm.Text = dep.RefDep_Nm;
        }
    }
}
