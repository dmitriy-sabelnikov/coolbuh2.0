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


namespace WinUI.WinForms
{
    public partial class fmUST : Form
    {
        private USTCt _ustCt = null;
        private UST6Repository _repoUST6 = new UST6Repository(SetupProgram.Connection);
        private UST7Repository _repoUST7 = new UST7Repository(SetupProgram.Connection);
        private List<UST6> _UST6s = new List<UST6>();
        private List<UST7> _UST7s = new List<UST7>();

        //Инициализация грида таблицы 6 ЕСВ
        private void InitGridUST6()
        {
            dgvUST6.BaseGrigStyle();
            dgvUST6.AddSortGrid<UST6>("UST6_Id");
            dgvUST6.AddSearchGrid();
            dgvUST6.AddStatusStripRow(statusStripRowUST6, true);
        }
        //Загрузка данных в грид таблицы 6 ЕСВ
        private bool LoadDataToGridUST6()
        {
            string error;
            _UST6s = _repoUST6.GetAllUST6ByParams(_ustCt.USTCt_Id, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження таблиці 6 ЕСВ.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            source.DataSource = _UST6s;
            dgvUST6.DataSource = source;
            return true;
        }
        //Инициализация грида таблицы 7 ЕСВ
        private void InitGridUST7()
        {
            dgvUST7.BaseGrigStyle();
            dgvUST7.AddSortGrid<UST7>("UST7_Id");
            dgvUST7.AddSearchGrid();
            dgvUST7.AddStatusStripRow(statusStripRowUST7, true);
        }
        //Загрузка данных в грид таблицы 6 ЕСВ
        private bool LoadDataToGridUST7()
        {
            string error;
            _UST7s = _repoUST7.GetAllUST7ByParams(_ustCt.USTCt_Id, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження таблиці 7 ЕСВ.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            source.DataSource = _UST7s;
            dgvUST7.DataSource = source;
            return true;
        }
        public fmUST(Form owner, USTCt ustCt)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Единий соціальний внесок. Таблиці");
            _ustCt = ustCt;
        }

        private void fmUST_Load(object sender, EventArgs e)
        {
            InitGridUST6();
            InitGridUST7();
            if (!LoadDataToGridUST6())
                return;
            if (!LoadDataToGridUST7())
                return;
        }

        private void dgvUST7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvUST6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void fmUST_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
