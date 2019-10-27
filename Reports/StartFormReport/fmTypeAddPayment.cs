using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormExtensions;
using Entities;
using DAL;
using BLL;

namespace Reports.StartFormReport
{
    public partial class fmTypeAddPayment : Form
    {
        private RefTypeAddPaymentRepository _repoTypeAddPayment = new RefTypeAddPaymentRepository(SetupProgram.Connection);
        private List<RefTypeAddPayment> _refTypeAddPayment = new List<RefTypeAddPayment>(); //кэш
        private List<RefTypeAddPayment> _checkedAddPayments = null;

        public fmTypeAddPayment()
        {
            InitializeComponent();
            this.BaseFormStyle("Звіт. Типи додаткових виплат");
        }
        public List<RefTypeAddPayment> GetCheckedAddPayment()
        {
            return dgvTypeAddPayment.GetCheckedRecords<RefTypeAddPayment>();
        }
        public void SetCheckedAddPayment(List<RefTypeAddPayment> addPayments)
        {
            _checkedAddPayments = addPayments;
        }

        private void InitGridTypeAddPayment()
        {
            dgvTypeAddPayment.BaseGrigStyle();
            dgvTypeAddPayment.AddBirdColumn();
        }
        //Загрузка данных в грид "Типы дополнительных выплат"
        private bool LoadDataToGridTypeAddPayment()
        {
            string error;
            _refTypeAddPayment = _repoTypeAddPayment.GetAllTypeAddPayments(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження типів додаткових виплат.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            source.DataSource = _refTypeAddPayment;
            dgvTypeAddPayment.DataSource = source;
            return true;
        }

        private void fmTypeAddPayment_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }

        private void dgvTypeAddPayment_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
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
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fmTypeAddPayment_Load(object sender, EventArgs e)
        {
            InitGridTypeAddPayment();
            LoadDataToGridTypeAddPayment();
            dgvTypeAddPayment.SetCheckedRecords(_checkedAddPayments);
        }
    }
}
