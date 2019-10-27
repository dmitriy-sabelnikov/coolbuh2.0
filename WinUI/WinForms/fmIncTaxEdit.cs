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
using ComboBoxes;
using DAL;
using BLL;
using WinFormExtensions;


namespace WinUI.WinForms
{
    public partial class fmIncTaxEdit : Form
    {
        private List<PersCard> _cards = null;                     // Кеш карточки работников
        private cmbCardParam _cmbCardParams = new cmbCardParam(); //параметры комбика карточек работников 
        private CmbCard cmbCard = new CmbCard();

        private PersCardRepository _repoPersCard = new PersCardRepository(SetupProgram.Connection);

        private int _id = 0;

        private bool CanSaveIncTax()
        {
            if (tbFIO.Text == string.Empty)
            {
                tbFIO.Focus();
                return false;
            }
            if (tbSm.Text == string.Empty)
            {
                tbSm.Focus();
                return false;
            }
            return true;
        }

        public void SetData(IncTax incTax)
        {
            _id = incTax.IncTax_Id;
            cmbCalendar.SelectedIndex = SalaryHelper.GetIndexByDate(
                DateTime.Today.Year - SetupProgram.YearSalary, incTax.IncTax_Date, false);
            
            cmbCard.ReadCombobox(incTax.IncTax_PersCard_Id);
            tbSm.Text = incTax.IncTax_Sm.ToString("0.00");
        }
        public IncTax GetData()
        {
            IncTax incTax = new IncTax();
            incTax.IncTax_Id = _id;
            incTax.IncTax_PersCard_Id = _cmbCardParams.PersCard_Id;
            incTax.IncTax_Date = SalaryHelper.GetDateByIndex(cmbCalendar.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);
            decimal resDec = 0;
            //Сумма
            if (decimal.TryParse(tbSm.Text, out resDec))
                incTax.IncTax_Sm = resDec;
            
            return incTax;
        }
        //Инициализация календарей
        private void InitCmbCalendar()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, false);
            cmbCalendar.DataSource = monthNames;
        }
        public fmIncTaxEdit(EnumFormMode mode, string caption)
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

            InitCmbCalendar();

            tbFIO.NecessaryField(30);
            tbSm.NecessaryField();

            tbSm.AddFloatField(10, 2);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveIncTax()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmIncTaxEdit_Load(object sender, EventArgs e)
        {
            cmbCalendar.IsModifyField(() => { btnOk.Enabled = true; });
            tbFIO.IsModifyField(() => { btnOk.Enabled = true; });
            tbSm.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void fmIncTaxEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }
    }
}
