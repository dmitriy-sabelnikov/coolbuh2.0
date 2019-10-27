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
using BLL;

namespace Reports.StartFormReport
{
    public partial class fmTypePayment : Form
    {
        private List<v_TypePayment> _checkedPayments = null;
        public fmTypePayment()
        {
            InitializeComponent();
            this.BaseFormStyle("Звіт. Типи виплат");
        }
        public List<v_TypePayment> GetCheckedPayment()
        {
            return dgvTypePayment.GetCheckedRecords<v_TypePayment>();
        }
        public void SetCheckedPayment(List<v_TypePayment> payments)
        {
            _checkedPayments = payments;
        }

        private void InitGridTypePayment()
        {
            dgvTypePayment.BaseGrigStyle();
            dgvTypePayment.AddBirdColumn();
        }
        //Загрузка данных в таблицу
        private void LoadDataToGridTypePayment()
        {
            List<v_TypePayment> vTypePayment = TypePaymentHelper.GetTypePayment();
            dgvTypePayment.DataSource = vTypePayment;
        }

        private void fmTypePayment_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }

        private void dgvTypePayment_KeyDown(object sender, KeyEventArgs e)
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

        private void fmTypePayment_Load(object sender, EventArgs e)
        {
            InitGridTypePayment();
            LoadDataToGridTypePayment();
            dgvTypePayment.SetCheckedRecords(_checkedPayments);
        }
    }
}
