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
using DAL;
using BLL;
using Entities;

namespace Reports.StartFormReport
{
    public partial class fmDepartment : Form
    {
        private RefDepRepository _repoDep = new RefDepRepository(SetupProgram.Connection);
        List<RefDep> _deps = null;
        private void InitGridRefDep()
        {
            dgvRefDep.BaseGrigStyle();
            dgvRefDep.AddBirdColumn();
        }
        //Загрузка данных в таблицу
        private bool LoadDataToGridRefDep()
        {
            string error;
            List<RefDep> refDeps = _repoDep.GetAllDeps(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження підрозділів.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            dgvRefDep.DataSource = refDeps;
            return true;
        }
        public fmDepartment()
        {
            InitializeComponent();
            this.BaseFormStyle("Звіт. Довідник підрозділів");
        }

        private void dgvRefDep_KeyDown(object sender, KeyEventArgs e)
        {
            //Нажатие кнопки Escape
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.No;
                Close();
            }
        }

        private void fmDepartment_KeyDown(object sender, KeyEventArgs e)
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
        public List<RefDep> GetCheckedDep()
        {
            return dgvRefDep.GetCheckedRecords<RefDep>();
        }
        public void SetCheckedDep(List<RefDep> deps)
        {
            _deps = deps;
        }

        private void fmDepartment_Load(object sender, EventArgs e)
        {
            InitGridRefDep();
            LoadDataToGridRefDep();
            dgvRefDep.SetCheckedRecords(_deps);
        }
    }
}
