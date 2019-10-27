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
using DAL;
using BLL;
using WinFormExtensions;

namespace WinUI.WinForms
{
    public partial class fmDFRec : Form
    {
        private DFCt _dfCt = null;
        private DFRecRepository _repoDFRec = new DFRecRepository(SetupProgram.Connection);
        private List<DFRec> _DFRecs = new List<DFRec>();

        //Инициализация грида 1 ДФ
        private void InitGridDFRec()
        {
            dgvDFRec.BaseGrigStyle();
            dgvDFRec.AddSortGrid<DFRec>("DFRec_Id");
            dgvDFRec.AddSearchGrid();
            dgvDFRec.AddStatusStripRow(statusStripRowDFRec, true);
        }
        //Загрузка данных в грид 1 ДФ
        private bool LoadDataToGridDFRec()
        {
            string error;
            _DFRecs = _repoDFRec.GetAllDFRecByParams(_dfCt.DFCt_Id, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження 1 ДФ.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            source.DataSource = _DFRecs;
            dgvDFRec.DataSource = source;
            return true;
        }
        public fmDFRec(Form owner, DFCt dfCt)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("1ДФ");
            _dfCt = dfCt;
        }

        private void fmDFRec_Load(object sender, EventArgs e)
        {
            InitGridDFRec();
            if (!LoadDataToGridDFRec())
                return;
        }

        private void dgvDFRec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void fmDFRec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
