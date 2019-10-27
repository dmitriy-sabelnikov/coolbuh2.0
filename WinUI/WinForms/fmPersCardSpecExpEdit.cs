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
using ComboBoxes;
using DAL;
using BLL;

namespace WinUI.WinForms
{
    public partial class fmPersCardSpecExpEdit : Form
    {
        private int _id = 0;
        private List<CardSpecExp> cardSpecExps = null;

        private TSimpleCmb<RefSpecExp> cmbSpecExp = new TSimpleCmb<RefSpecExp>("Довідник спецстажів");
        List<ViewField> vwFldSpecExp = new List<ViewField>();
        List<ResField> resFldSpecExp = new List<ResField>();
        private bool CanSaveCardSpecExp()
        {
            if (tbPerBeg.Text == string.Empty && tbPerEnd.Text == string.Empty)
                return false;
            if (tbSpecExpCd.Text == string.Empty)
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

            if (cardSpecExps != null)
            {
                foreach (CardSpecExp cardSpecExp in cardSpecExps)
                {
                    if (_id == cardSpecExp.CardSpecExp_Id)
                        continue;
                    DateTime datBeg = cardSpecExp.CardSpecExp_PerBeg;
                    DateTime datEnd = cardSpecExp.CardSpecExp_PerEnd == DateTime.MinValue ? DateTime.MaxValue : cardSpecExp.CardSpecExp_PerEnd;
                    if (perEnd >= datBeg && perBeg <= datEnd)
                    {
                        MessageBox.Show("Період перетинається з існуючим", "Помилка");
                        return false;
                    }
                }
            }
            return true;
        }
        public void SetData(CardSpecExp сardSpecExp)
        {
            _id = сardSpecExp.CardSpecExp_Id;
            if (сardSpecExp.CardSpecExp_PerBeg != DateTime.MinValue)
                tbPerBeg.Text = сardSpecExp.CardSpecExp_PerBeg.ToShortDateString();
            if (сardSpecExp.CardSpecExp_PerEnd != DateTime.MinValue)
                tbPerEnd.Text = сardSpecExp.CardSpecExp_PerEnd.ToShortDateString();
            cmbSpecExp.ReadCombobox("RefSpecExp_Id", сardSpecExp.CardSpecExp_RefSpecExp_Id.ToString());
        }


        public CardSpecExp GetData()
        {
            CardSpecExp cardSpecExp = new CardSpecExp();
            cardSpecExp.CardSpecExp_Id = _id;

            DateTime perBeg;
            DateTime.TryParse(tbPerBeg.Text, out perBeg);
            cardSpecExp.CardSpecExp_PerBeg = perBeg;

            DateTime perEnd;
            DateTime.TryParse(tbPerEnd.Text, out perEnd);
            cardSpecExp.CardSpecExp_PerEnd = perEnd;

            int resInt = 0;

            ResField fldId = resFldSpecExp.FirstOrDefault(rec => rec.Name == "RefSpecExp_Id");
            if (fldId != null)
            {
                if (int.TryParse(fldId.Val, out resInt))
                {
                    cardSpecExp.CardSpecExp_RefSpecExp_Id = resInt;
                }
            }
            return cardSpecExp;
        }

        public void AddControlPeriod(List<CardSpecExp> cardSpecExps)
        {
            this.cardSpecExps = cardSpecExps;
        }

        public fmPersCardSpecExpEdit(EnumFormMode mode, string caption, List<RefSpecExp> refSpecExps)
        {
            InitializeComponent();

            vwFldSpecExp.Add(new ViewField { Name = "RefSpecExp_Cd", Caption = "Код", Type = TypeFields.textBox });
            vwFldSpecExp.Add(new ViewField { Name = "RefSpecExp_ShortName", Caption = "Скорочене найменування", Type = TypeFields.textBox });
            vwFldSpecExp.Add(new ViewField { Name = "RefSpecExp_Name", Caption = "Найменування", Type = TypeFields.textBox });

            resFldSpecExp.Add(new ResField { Name = "RefSpecExp_Id" });
            resFldSpecExp.Add(new ResField { Name = "RefSpecExp_Cd", TxtBx = tbSpecExpCd, IsSearchByField = true });
            resFldSpecExp.Add(new ResField { Name = "RefSpecExp_Name", TxtBx = tbSpecExpNm });

            cmbSpecExp.AddCombobox(btnSpecExp, refSpecExps, vwFldSpecExp, resFldSpecExp, true, "RefSpecExp_Id");

            this.BaseFormStyle(caption);
            btnOk.Enabled = false;
            tbPerBeg.AddDateField('.');
            tbPerEnd.AddDateField('.');

            tbSpecExpCd.NecessaryField(175);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveCardSpecExp()) return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void fmPersCardSpecExpEdit_Load(object sender, EventArgs e)
        {
            tbPerBeg.IsModifyField(() => { btnOk.Enabled = true; });
            tbPerEnd.IsModifyField(() => { btnOk.Enabled = true; });
            tbSpecExpCd.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void fmPersCardSpecExpEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }
    }
}
