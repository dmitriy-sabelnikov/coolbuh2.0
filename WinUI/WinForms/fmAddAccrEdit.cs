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

namespace WinUI
{
    public partial class fmAddAccrEdit : Form
    {
        private List<PersCard> _cards = null;                     // Кеш карточки работников
        private List<RefDep> _deps = null;                        // Кеш подразделений
        private List<RefTypeAddAccr> _typeAddAccrs = null;        // Кеш типов начислений

        private cmbDepParam _cmbDepParams = new cmbDepParam();    //параметры комбика подразделений                      
        private cmbCardParam _cmbCardParams = new cmbCardParam(); //параметры комбика карточек работников 

        private CmbCard cmbCard = new CmbCard();
        private CmbDep cmbDep = new CmbDep();
        private TSimpleCmb<RefTypeAddAccr> cmbTypeAddAccr = new TSimpleCmb<RefTypeAddAccr>("Довідник додаткових нарахуваннь");

        private PersCardRepository _repoPersCard = new PersCardRepository(SetupProgram.Connection);
        private RefDepRepository _repoDep = new RefDepRepository(SetupProgram.Connection);
        private RefTypeAddAccrRepository _repoTypeAddAccr = new RefTypeAddAccrRepository(SetupProgram.Connection);

        List<ViewField> vwFldTypeAddAccr = new List<ViewField>();
        List<ResField> resFldTypeAddAccr = new List<ResField>();

        private int _id = 0;

        private bool CanSaveAddAccr ()
        {
            if (tbFIO.Text == string.Empty)
            {
                tbFIO.Focus();
                return false;
            }
            if (tbDepCd.Text == string.Empty)
            {
                tbDepCd.Focus();
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

        public void SetData(AddAccr addAccr)
        {
            _id = addAccr.AddAccr_Id;
            cmbCalendar.SelectedIndex = SalaryHelper.GetIndexByDate(
                DateTime.Today.Year - SetupProgram.YearSalary, addAccr.AddAccr_Date, false);

            cmbCard.ReadCombobox(addAccr.AddAccr_PersCard_Id);
            cmbDep.ReadCombobox(addAccr.AddAccr_RefDep_Id);
            cmbTypeAddAccr.ReadCombobox("RefTypeAddAccr_Id", addAccr.AddAccr_RefTypeAddAccr_Id.ToString());
            tbSm.Text = addAccr.AddAccr_Sm.ToString("0.00");
        }
        public AddAccr GetData()
        {
            AddAccr addAccr = new AddAccr();
            addAccr.AddAccr_Id = _id;
            addAccr.AddAccr_PersCard_Id = _cmbCardParams.PersCard_Id;
            addAccr.AddAccr_RefDep_Id = _cmbDepParams.RefDep_Id;
            addAccr.AddAccr_Date = SalaryHelper.GetDateByIndex(cmbCalendar.SelectedIndex, DateTime.Today.Year - SetupProgram.YearSalary, false);

            int resInt = 0;
            decimal resDec = 0;

            ResField fldId = resFldTypeAddAccr.FirstOrDefault(rec => rec.Name == "RefTypeAddAccr_Id");
            if(fldId != null)
            {
                if(int.TryParse(fldId.Val, out resInt))
                {
                    addAccr.AddAccr_RefTypeAddAccr_Id = resInt;
                }
            }
            //Сумма
            if (decimal.TryParse(tbSm.Text, out resDec))
                addAccr.AddAccr_Sm = resDec;

            return addAccr;
        }
        public fmAddAccrEdit(EnumFormMode mode, string caption)
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

            _deps = _repoDep.GetAllDeps(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка отримання довідника підрозділів.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            _cmbDepParams.refDeps = _deps;
            _cmbDepParams.tbCd = tbDepCd;
            _cmbDepParams.tbNm = tbDepNm;
            cmbDep.AddCombobox(btnDep, _cmbDepParams);

            _typeAddAccrs = _repoTypeAddAccr.GetAllTypeAddAccr(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка отримання довідника типів додаткових нарахуваннь.\nТехнічна інформація: " + error, "Помилка");
                return;
            }

            vwFldTypeAddAccr.Add(new ViewField { Name = "RefTypeAddAccr_Cd", Caption = "Код", Type = TypeFields.textBox });
            vwFldTypeAddAccr.Add(new ViewField { Name = "RefTypeAddAccr_Nm", Caption = "Найменування", Type = TypeFields.textBox });

            resFldTypeAddAccr.Add(new ResField { Name = "RefTypeAddAccr_Id" });
            resFldTypeAddAccr.Add(new ResField { Name = "RefTypeAddAccr_Cd", TxtBx = tbTypeCd, IsSearchByField = true });
            resFldTypeAddAccr.Add(new ResField { Name = "RefTypeAddAccr_Nm", TxtBx = tbTypeNm });

            cmbTypeAddAccr.AddCombobox(btnType, _typeAddAccrs, vwFldTypeAddAccr, resFldTypeAddAccr, true, "RefTypeAddAccr_Id");

            InitCmbCalendar();

            tbDepCd.NecessaryField();
            tbDepNm.NecessaryField(30);
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
            if (!CanSaveAddAccr()) return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmAddAccrEdit_Load(object sender, EventArgs e)
        {
            cmbCalendar.IsModifyField(() => { btnOk.Enabled = true; });
            tbDepCd.IsModifyField(() => { btnOk.Enabled = true; });
            tbDepNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbTypeCd.IsModifyField(() => { btnOk.Enabled = true; });
            tbTypeNm.IsModifyField(() => { btnOk.Enabled = true; });
            tbFIO.IsModifyField(() => { btnOk.Enabled = true; });
            tbSm.IsModifyField(() => { btnOk.Enabled = true; });
        }

        private void fmAddAccrEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }
    }
}
