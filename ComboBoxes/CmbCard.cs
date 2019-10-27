using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComboBoxes.WinWorms;
using System.Data.SqlClient;
using Entities;
using DAL;
using System.Windows.Forms;
using System.ComponentModel;

namespace ComboBoxes
{
    public class cmbCardParam
    {
        public void ClearParams()
        {
            PersCard_Id = 0;
            if(tbFio != null)
                tbFio.Text = string.Empty;
            if (tbTIN != null)
                tbTIN.Text = string.Empty;
            if (tbExp != null)
                tbExp.Text = string.Empty;
            if (tbGrade != null)
                tbGrade.Text = string.Empty;
    }

    public int PersCard_Id { get; set; }
        public List<PersCard> persCards { get; set; }
        public TextBox tbFio { get; set; }
        public TextBox tbTIN { get; set; }
        public TextBox tbExp { get; set; }
        public TextBox tbGrade { get; set; }
    }
    public class CmbCard
    {
        private cmbCardParam _cmbParams = null;

        private string GetShortFIO(string FName, string MName, string LName)
        {
            return LName + " " + FName.Substring(0, 1) + ". " + MName.Substring(0, 1) + ".";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            fmCmbCard cmbCard = new fmCmbCard(_cmbParams.persCards);
            if (cmbCard.ShowDialog() == DialogResult.OK)
            {
                PersCard card = cmbCard.GetData();
                _cmbParams.PersCard_Id = card.PersCard_Id;
                if (_cmbParams.tbFio != null)
                    _cmbParams.tbFio.Text = GetShortFIO(card.PersCard_FName, card.PersCard_MName, card.PersCard_LName);
                if (_cmbParams.tbExp != null)
                    _cmbParams.tbExp.Text = card.PersCard_Exp.ToString();
                if (_cmbParams.tbTIN != null)
                    _cmbParams.tbTIN.Text = card.PersCard_TIN;
                if (_cmbParams.tbGrade != null)
                    _cmbParams.tbGrade.Text = card.PersCard_Grade.ToString();
            }
        }

        public void AddCombobox(Button btn, cmbCardParam cmbParams)
        {
            if (cmbParams == null) return;
            if (cmbParams.persCards == null) return;
            _cmbParams = cmbParams;

            if (btn != null)
            {
                btn.Click += new EventHandler(btn_Click);
            }
        }
        public void ReadCombobox(int id)
        {
            if (_cmbParams == null) return;
            if (_cmbParams.persCards == null) return;

            PersCard card = _cmbParams.persCards.FirstOrDefault(rec => rec.PersCard_Id == id);
            if (card == null)
            {
                _cmbParams.ClearParams();
                return;
            }
            _cmbParams.PersCard_Id = card.PersCard_Id;

            if (_cmbParams.tbFio != null)
                _cmbParams.tbFio.Text = GetShortFIO(card.PersCard_FName, card.PersCard_MName, card.PersCard_LName); ;
            if (_cmbParams.tbExp != null)
                _cmbParams.tbExp.Text = card.PersCard_Exp.ToString();
            if (_cmbParams.tbTIN != null)
                _cmbParams.tbTIN.Text = card.PersCard_TIN;
            if (_cmbParams.tbGrade != null)
                _cmbParams.tbGrade.Text = card.PersCard_Grade.ToString();
        }
    }
}
