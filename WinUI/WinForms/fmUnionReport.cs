using BLL;
using DAL;
using Entities;
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

namespace WinUI.WinForms
{
    public partial class fmUnionReport : Form
    {
        private readonly UnionReportCt _unionReportCt;
        private UnionReportT1Repository _repoUnionReportT1 = new UnionReportT1Repository(SetupProgram.Connection);
        private UnionReportT2Repository _repoUnionReportT2 = new UnionReportT2Repository(SetupProgram.Connection);
        private UnionReportT4Repository _repoUnionReportT4 = new UnionReportT4Repository(SetupProgram.Connection);
        //private UnionReportT5Repository _repoUnionReportT5 = new UnionReportT5Repository(SetupProgram.Connection);

        public fmUnionReport(Form owner, UnionReportCt unionReportCt)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Об'єднана звітність. Таблиці");
            _unionReportCt = unionReportCt;
        }

        #region Private methods
        
        //Инициализация грида таблицы 1 
        private void InitGridUnionReportT1()
        {
            dgvUnionReportT1.BaseGrigStyle();
            dgvUnionReportT1.AddSortGrid<UnionReportT1>("UnionReportT1_Id");
            dgvUnionReportT1.AddSearchGrid();
            dgvUnionReportT1.AddStatusStripRow(statusStripRowUnionReportT1, true);
        }

        //Инициализация грида таблицы 2 
        private void InitGridUnionReportT2()
        {
            dgvUnionReportT2.BaseGrigStyle();
            dgvUnionReportT2.AddSortGrid<UnionReportT2>("UnionReportT2_Id");
            dgvUnionReportT2.AddSearchGrid();
            dgvUnionReportT2.AddStatusStripRow(statusStripRowUnionReportT2, true);
        }

        //Инициализация грида таблицы 4 
        private void InitGridUnionReportT4()
        {
            dgvUnionReportT4.BaseGrigStyle();
            dgvUnionReportT4.AddSortGrid<UnionReportT4>("UnionReportT4_Id");
            dgvUnionReportT4.AddSearchGrid();
            dgvUnionReportT4.AddStatusStripRow(statusStripRowUnionReportT4, true);
        }

        ////Инициализация грида таблицы 5 
        //private void InitGridUnionReportT5()
        //{
        //    dgvUnionReportT5.BaseGrigStyle();
        //    dgvUnionReportT5.AddSortGrid<UnionReportT2>("UnionReportT5_Id");
        //    dgvUnionReportT5.AddSearchGrid();
        //    dgvUnionReportT5.AddStatusStripRow(statusStripRowUnionReportT5, true);
        //}

        //Загрузка данных в грид таблицы 1 
        private bool LoadDataToGridUnionReportT1()
        {
            string error;
            var unionReportT1s = _repoUnionReportT1.GetAllUnionReportT1ByParams(_unionReportCt.UnionReportCt_Id, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження таблиці 1.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            source.DataSource = unionReportT1s;
            dgvUnionReportT1.DataSource = source;

            return true;
        }

        //Загрузка данных в грид таблицы 2 
        private bool LoadDataToGridUnionReportT2()
        {
            string error;
            var unionReportT2s = _repoUnionReportT2.GetAllUnionReportT2ByParams(_unionReportCt.UnionReportCt_Id, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження таблиці 2.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            source.DataSource = unionReportT2s;
            dgvUnionReportT2.DataSource = source;

            return true;
        }

        //Загрузка данных в грид таблицы 4 
        private bool LoadDataToGridUnionReportT4()
        {
            string error;
            var unionReportT4s = _repoUnionReportT4.GetAllUnionReportT4ByParams(_unionReportCt.UnionReportCt_Id, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження таблиці 4.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            source.DataSource = unionReportT4s;
            dgvUnionReportT4.DataSource = source;

            return true;
        }

        ////Загрузка данных в грид таблицы 5 
        //private bool LoadDataToGridUnionReportT5()
        //{
        //    string error;
        //    var unionReportT5s = _repoUnionReportT5.GetAllUnionReportT5ByParams(_unionReportCt.UnionReportCt_Id, out error);
        //    if (error != string.Empty)
        //    {
        //        MessageBox.Show("Помилка завантаження таблиці 5.\nТехнічна інформація: " + error, "Помилка");
        //        return false;
        //    }
        //    BindingSource source = new BindingSource();
        //    source.DataSource = unionReportT5s;
        //    dgvUnionReportT5.DataSource = source;
        //
        //    return true;
        //}

        #endregion

        #region Events

        private void fmUnionReport_Load(object sender, EventArgs e)
        {
            InitGridUnionReportT1();
            InitGridUnionReportT2();
            InitGridUnionReportT4();
            //InitGridUnionReportT5();
            if (!LoadDataToGridUnionReportT1()) return;
            if (!LoadDataToGridUnionReportT2()) return;
            if (!LoadDataToGridUnionReportT4()) return;
            //if (!LoadDataToGridUnionReportT5()) return;
        }

        private void fmUnionReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvUnionReportT1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvUnionReportT2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvUnionReportT4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvUnionReportT5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        #endregion

    }
}
