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
using WinFormExtensions;


namespace WinUI.WinForms
{
    public partial class fmPersCardStatusEdit : Form
    {
        private int _id = 0;
        private List<CardStatus> cardStatuses = null;
        private bool CanSavePersCard()
        {
            if (tbPerBeg.Text == string.Empty && tbPerEnd.Text == string.Empty)
                return false;
            if (cbType.SelectedIndex == -1)
                return false;

            DateTime perBeg;
            DateTime.TryParse(tbPerBeg.Text, out perBeg);

            DateTime perEnd;
            DateTime.TryParse(tbPerEnd.Text, out perEnd);

            perEnd = perEnd == DateTime.MinValue ? perEnd = DateTime.MaxValue : perEnd;

            if (perBeg > perEnd)
            {
                MessageBox.Show("Дата початку більше за дату закінчення", "Помилка");
                return false;
            }

            if (cardStatuses != null)
            {
                foreach (CardStatus status in cardStatuses)
                {
                    if (_id == status.CardStatus_Id)
                        continue;
                    DateTime datBeg = status.CardStatus_PerBeg;
                    DateTime datEnd = status.CardStatus_PerEnd == DateTime.MinValue ? DateTime.MaxValue : status.CardStatus_PerEnd;
                    if (perEnd >= datBeg && perBeg <= datEnd)
                    {
                        MessageBox.Show("Період перетинається з існуючим", "Помилка");
                        return false;
                    }
                }
            }
            return true;
        }

        private int GetIndexCmType(int TypeCd)
        {
            switch(TypeCd)
            {
                case (int)EnumCardStatus.Constant:
                    return 0;
                case (int)EnumCardStatus.Temporary:
                    return 1;
                case (int)EnumCardStatus.Associative:
                    return 2;
            }
            return 0;
        }

        private int GetCdTypeByIndex(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    return (int)EnumCardStatus.Constant;
                case 1:
                    return (int)EnumCardStatus.Temporary;
                case 2:
                    return (int)EnumCardStatus.Associative;
            }
            return (int)EnumCardStatus.Constant;
        }

        public void SetData(CardStatus status)
        {
            _id = status.CardStatus_Id;
            if (status.CardStatus_PerBeg != DateTime.MinValue)
                tbPerBeg.Text = status.CardStatus_PerBeg.ToShortDateString();
            if (status.CardStatus_PerEnd != DateTime.MinValue)
                tbPerEnd.Text = status.CardStatus_PerEnd.ToShortDateString();
            cbType.SelectedIndex = GetIndexCmType(status.CardStatus_Type);
        }
        public CardStatus GetData()
        {
            CardStatus status = new CardStatus();
            status.CardStatus_Id = _id;

            DateTime perBeg;
            DateTime.TryParse(tbPerBeg.Text, out perBeg);
            status.CardStatus_PerBeg = perBeg;

            DateTime perEnd;
            DateTime.TryParse(tbPerEnd.Text, out perEnd);
            status.CardStatus_PerEnd = perEnd;

            status.CardStatus_Type = GetCdTypeByIndex(cbType.SelectedIndex);

            return status;
        }

        public void AddControlPeriod(List<CardStatus> statuses)
        {
            this.cardStatuses = statuses;
        }


        public fmPersCardStatusEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;
            tbPerBeg.AddDateField('.');
            tbPerEnd.AddDateField('.');
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSavePersCard()) return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmPersCardCardEdit_Load(object sender, EventArgs e)
        {
            tbPerBeg.IsModifyField(() => { btnOk.Enabled = true; });
            tbPerEnd.IsModifyField(() => { btnOk.Enabled = true; });
            cbType.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void fmPersCardCardEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }
    }
}
