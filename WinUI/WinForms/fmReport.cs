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
using EnumType;
using Reports;
using Interfaces;

namespace WinUI
{
    public partial class fmReport : Form
    {
        private List<Report> _reports = null; //кэш
        private ReportRepository _repoReport = new ReportRepository(SetupProgram.Connection);
        private List<int> id_card = null;
        //Инициализация грида дополнительные начисления
        private void InitGridReport()
        {
            dgvReport.BaseGrigStyle();
            dgvReport.AddSortGrid<Report>("Report_Id");
            dgvReport.AddSearchGrid();
            dgvReport.AddStatusStripRow(statusStripRow, true);
        }
        //Загрузка данных в грид "Отчеты"
        private bool LoadDataToGridReport()
        {
            string error;
            _reports = _repoReport.GetAllReports(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження звітів.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            source.DataSource = _reports.OrderBy(rec => rec.Report_Name);
            dgvReport.DataSource = source;
            return true;
        }
        private void PrintReport()
        {
            if (dgvReport.CurrentRow == null) return;
            Report report = dgvReport.CurrentRow.DataBoundItem as Report;
            if (report == null)
            {
                MessageBox.Show("Не знайдений звіт для друку", "Помилка");
                return;
            }

            ReportManager manager = new ReportManager(report.Report_File);
            manager.SetCheckedCard(id_card);

            IReport rep = manager.GetInstanceReport();
            if (rep == null)
            {
                MessageBox.Show("Не написаний код для друку звіта. Див. файл ReportManager.cs", "Помилка");
                return;
            }     
            fmReportViewer rpr = new fmReportViewer(this, rep);
            rpr.StartReport();
            this.Refresh();
        }

        public fmReport(Form owner, List<int> id = null, bool isModal = false)
        {
            id_card = id;
            InitializeComponent();
            this.BaseFormStyle("Звіти");
            if (!isModal)
                this.SingleFormMode(owner);
        }

        private void fmReport_Load(object sender, EventArgs e)
        {
            InitGridReport();
            if (!LoadDataToGridReport())
                return;
        }

        private void fmReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                PrintReport();
            else
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvReport_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PrintReport();
        }
        //Контекстное меню
        private void ContextMenuPrint_Click(object sender, EventArgs e)
        {
            PrintReport();
        }
    }
}
