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
    public partial class fmAddPaymentEdit : Form
    {
        private List<PersCard> _cards = null;                             // Кеш карточки работников
        private List<RefTypeAddPayment> _typeAddPayments = null;          // Кеш типов выплат

        private cmbCardParam _cmbCardParams = new cmbCardParam(); //параметры комбика карточек работников 
        private CmbCard cmbCard = new CmbCard();
        private TSimpleCmb<RefTypeAddPayment> cmbTypeAddPayment = new TSimpleCmb<RefTypeAddPayment>("Довідник додаткових виплат");

        private PersCardRepository _repoPersCard = new PersCardRepository(SetupProgram.Connection);
        private RefTypeAddPaymentRepository _repoTypeAddPayment = new RefTypeAddPaymentRepository(SetupProgram.Connection);

        List<ViewField> vwFldTypeAddPayment= new List<ViewField>();
        List<ResField> resFldTypeAddPayment = new List<ResField>();

        private int _id = 0;

        private bool CanSaveAddPayment()
        {
            if (tbFIO.Text == string.Empty)
            {
                tbFIO.Focus();
                return false;
            }
            if (tbTypeCd.Text == string.Empty)
            {
                tbTypeCd.Focus();
                return false;
            }
            if (tbSm.Text == string.Empty)
            {
                tbSm.Focus();
                return false;
            }
            return true;
        }

        //Инициализация календарей
        private void InitCmbCalendar()
        {
            List<string> monthNames = SalaryHelper.GetMonthNames(DateTime.Today.Year - SetupProgram.YearSalary, false);
            cmbCalendar.DataSource = monthNames;
        }

        public void SetData(AddPayment addPayment)
        {
            _id = addPayment.AddPayment_Id;
            cmbCalendar.SelectedIndex = SalaryHelper.GetIndexByDate(
                DateTime.Today.Year - SetupProgram.YearSalary, addPayment.AddPayment_Date, false);

            cmbCard.ReadCombobox(addPayment.AddPayment_PersCard_Id);
            cmbTypeAddPayment.ReadCombobox("RefTypeAddPayment_Id", addPayment.AddPayment_TypeAddPayment_Id.ToString());
            tbSm.Text = addPayment.AddPayment_Sm.ToString("0.00");
        }
        public AddPayment GetData()
        {
            AddPayment addPayment = new AddPayment();
            addPayment.AddPayment_Id = _id;
            addPayment.AddPayment_PersCard_Id = _cmbCardParams.PersCard_Id;
            addPayment.AddPayment_Date = SalaryHelper.GetDateByIndex(cmbCalendar.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);

            int resInt = 0;
            decimal resDec = 0;

            ResField fldId = resFldTypeAddPayment.FirstOrDefault(rec => rec.Name == "RefTypeAddPayment_Id");
            if (fldId != null)
            {
                if (int.TryParse(fldId.Val, out resInt))
                {
                    addPayment.AddPayment_TypeAddPayment_Id = resInt;
                }
            }
            //Сумма
            if (decimal.TryParse(tbSm.Text, out resDec))
                addPayment.AddPayment_Sm = resDec;

            return addPayment;
        }
        public fmAddPaymentEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;

            string error;
            _cards = _repoPersCard.GetAllCards(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка отримання довідника особових карток.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            _cmbCardParams.persCards = _cards;
            _cmbCardParams.tbFio = tbFIO;
            _cmbCardParams.tbTIN = tbTIN;
            cmbCard.AddCombobox(btnCard, _cmbCardParams);

            _typeAddPayments = _repoTypeAddPayment.GetAllTypeAddPayments(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка отримання довідника типів додаткових виплат.\nТехнічна інформація: " + error, "Помилка");
                return;
            }

            vwFldTypeAddPayment.Add(new ViewField { Name = "RefTypeAddPayment_Cd", Caption = "Код", Type = TypeFields.textBox });
            vwFldTypeAddPayment.Add(new ViewField { Name = "RefTypeAddPayment_Nm", Caption = "Найменування", Type = TypeFields.textBox });

            resFldTypeAddPayment.Add(new ResField { Name = "RefTypeAddPayment_Id" });
            resFldTypeAddPayment.Add(new ResField { Name = "RefTypeAddPayment_Cd", TxtBx = tbTypeCd, IsSearchByField = true });
            resFldTypeAddPayment.Add(new ResField { Name = "RefTypeAddPayment_Nm", TxtBx = tbTypeNm });

            cmbTypeAddPayment.AddCombobox(btnType, _typeAddPayments, vwFldTypeAddPayment, resFldTypeAddPayment, true, "RefTypeAddPayment_Id");

            InitCmbCalendar();


            tbFIO.NecessaryField(30);
            tbTypeNm.NecessaryField(30);
            tbSm.AddFloatField(10, 2);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveAddPayment()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmAddPaymentEdit_Load(object sender, EventArgs e)
        {
            cmbCalendar.IsModifyField(() => { btnOk.Enabled = true; });
            tbTypeCd.IsModifyField(() => { btnOk.Enabled = true; });
            tbTypeNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbFIO.IsModifyField(() => { btnOk.Enabled = true; });
            tbSm.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void fmAddPaymentEdit_KeyDown(object sender, KeyEventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
