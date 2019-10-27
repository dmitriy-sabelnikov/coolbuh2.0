using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using EnumType;
using BLL;
using ComboBoxes;
using WinFormExtensions;
using DAL;

namespace WinUI.WinForms
{
    public partial class fmPaymentEdit : Form
    {
        private List<PersCard> _cards = null;                     // Кеш карточки работников

        private cmbCardParam _cmbCardParams = new cmbCardParam(); //параметры комбика карточек работников 

        private CmbCard cmbCard = new CmbCard();

        private PersCardRepository _repoPersCard = new PersCardRepository(SetupProgram.Connection);

        private int _id = 0;

        private bool CanSavePayment()
        {
            if (tbFIO.Text == string.Empty)
            {
                tbFIO.Focus();
                return false;
            }
            if (tbDate.Text == string.Empty)
            {
                tbDate.Focus();
                return false;
            }
            if (tbSm.Text == string.Empty)
            {
                tbSm.Focus();
                return false;
            }
            return true;
        }

        private decimal GetSmCashBox()
        {
            decimal resAmt = 0;
            decimal resPrice = 0;
            decimal.TryParse(tbAmt.Text, out resAmt);
            decimal.TryParse(tbPrice.Text, out resPrice);
            return PaymentHelper.GetSmPaymentCash(resPrice, resAmt);
        }
        private int GetIndexCmbType(int type)
        {
            switch (type)
            {
                case (int)EnumTypePayment.CashBox:
                    return 0;
                case (int)EnumTypePayment.Excerpt:
                    return 1;
                case (int)EnumTypePayment.List:
                    return 2;
                case (int)EnumTypePayment.InKindPay:
                    return 3;
            }
            return 0;
        }
        private int GetTypeByIndex(int index)
        {
            switch (index)
            {
                case 0:
                    return (int)EnumTypePayment.CashBox;
                case 1:
                    return (int)EnumTypePayment.Excerpt;
                case 2:
                    return (int)EnumTypePayment.List;
                case 3:
                    return (int)EnumTypePayment.InKindPay;
            }
            return (int)EnumTypePayment.CashBox;
        }

        public void SetData(Payment payment)
        {
            _id = payment.Payment_Id;
            cmbCard.ReadCombobox(payment.Payment_PersCard_Id);
            cmbType.SelectedIndex = GetIndexCmbType(payment.Payment_Type);

            if (payment.Payment_Date != DateTime.MinValue)
                tbDate.Text = payment.Payment_Date.ToShortDateString();

            tbAmt.Text = payment.Payment_Amt.ToString();
            tbPrice.Text = payment.Payment_Price.ToString("0.00");
            tbSm.Text = payment.Payment_Sm.ToString("0.00");
        }
        public Payment GetData()
        {
            Payment payment = new Payment();
            payment.Payment_Id = _id;
            payment.Payment_PersCard_Id = _cmbCardParams.PersCard_Id;
            payment.Payment_Type = GetTypeByIndex(cmbType.SelectedIndex);

            DateTime resDate;
            DateTime.TryParse(tbDate.Text, out resDate);
            payment.Payment_Date = resDate;

            decimal resDec = 0;
            if(decimal.TryParse(tbAmt.Text, out resDec))
            {
                payment.Payment_Amt = resDec;
            }
            if (decimal.TryParse(tbPrice.Text, out resDec))
            {
                payment.Payment_Price = resDec;
            }
            if (decimal.TryParse(tbSm.Text, out resDec))
            {
                payment.Payment_Sm = resDec;
            }
            return payment;
        }
        public fmPaymentEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;

            string error;
            _cards = _repoPersCard.GetAllCards(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження довідника особових карток.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            _cmbCardParams.persCards = _cards;
            _cmbCardParams.tbFio = tbFIO;
            _cmbCardParams.tbTIN = tbTIN;
            cmbCard.AddCombobox(btnCard, _cmbCardParams);

            tbAmt.AddFloatField(10, 2);
            tbSm.AddFloatField(10, 2);
            tbDate.AddDateField('.');

            tbFIO.NecessaryField(30);
            tbDate.NecessaryField();
            tbSm.NecessaryField();
        }

        private void fmPaymentEdit_Load(object sender, EventArgs e)
        {
            tbFIO.IsModifyField(() => { btnOk.Enabled = true; });
            cmbType.IsModifyField(() => { btnOk.Enabled = true; });
            tbDate.IsModifyField(() => { btnOk.Enabled = true; });
            tbAmt.IsModifyField(() => { btnOk.Enabled = true; });
            tbPrice.IsModifyField(() => { btnOk.Enabled = true; });
            tbSm.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void fmPaymentEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSavePayment()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void tbAmt_TextChanged(object sender, EventArgs e)
        {
            if(cmbType.SelectedIndex != 0) //касса
            {
                tbSm.Text = GetSmCashBox().ToString("0.00");
            }
            else
            {
                tbSm.Text = "0.00";
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbType.SelectedIndex == 0)//касса
            {
                tbPrice.Text = "0.00";
                tbPrice.Enabled = false;

                tbAmt.Text = "0.00";
                tbAmt.Enabled = false;

                tbSm.Enabled = true;
            }
            else
            {
                tbPrice.Enabled = true;
                tbAmt.Enabled = true;
                tbSm.Enabled = false;
            }
        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex != 0) //касса
            {
                tbSm.Text = GetSmCashBox().ToString("0.00");
            }
            else
            {
                tbSm.Text = "0.00";
            }
        }
    }
}
