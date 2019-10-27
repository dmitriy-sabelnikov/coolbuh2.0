using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Interfaces;
using System.IO;
using WinFormExtensions;

namespace Reports
{
    public partial class fmReportViewer : Form
    {
        private IReport _report = null;
        private string _savePath = string.Empty;
        private string _nameExport = "report";

        private string ChoosePathToFile(string path)
        {
            fmChoosePath fmPath = new fmChoosePath();
            if(path != string.Empty)
            {
                fmPath.SetPathExport(path);
            }
            if (fmPath.ShowDialog() == DialogResult.OK)
            {
                return fmPath.GetPathExport();
            }
            return string.Empty;
        }
        private bool ExportReport(string path, string name, string type, out string error)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            byte[] bytes;
            error = string.Empty;
            try
            {
                bytes = reportViewer.LocalReport.Render(
                    type, null, out mimeType, out encoding, out filenameExtension,
                    out streamids, out warnings);
            }
            catch(Exception exc)
            {
                error = exc.Message;
                return false;
                     
            }

            if (warnings.Length != 0)
            {
                foreach (Warning warn in warnings)
                {
                    error += warn.Message;
                    error += Environment.NewLine;
                }
                return false;
            }
            try
            {
                using (FileStream fs = new FileStream(path + "\\" + name + "." + filenameExtension, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception exc)
            {
                error = exc.Message;
                return false;

            }
            return true;
        }
        private string GetPathToReport()
        {
            //Получим директорию к папке отчетами
            string folder = "\\REP";
            StringBuilder currentDir = new StringBuilder(Directory.GetCurrentDirectory());
            int startIndex = currentDir.ToString().IndexOf("\\WinUI");
            if (startIndex >= 0)
            {
                currentDir.Remove(startIndex, currentDir.Length - startIndex);
            }
            currentDir.Append(folder);
            //Проверка существования директории
            string dirToRep = currentDir.ToString();
            if (!Directory.Exists(dirToRep))
            {
                MessageBox.Show("Не вдалося знайти папку зі звітами.\nТехнічна інформація: діректорії " + dirToRep + "не існує", "Помилка");
                return string.Empty;
            }
            return dirToRep;
        }

        public DialogResult StartReport()
        {
            if(!_report.StartReport())
            {
                return DialogResult.Cancel;
            }
            reportViewer.ProcessingMode = ProcessingMode.Local;
            LocalReport localReport = reportViewer.LocalReport;
            string reportDirectory = GetPathToReport();
            if (reportDirectory == string.Empty)
                return DialogResult.No;

            localReport.ReportPath = reportDirectory + "\\" + _report.NameReport;
            if(_report.DataSources != null)
            {
                foreach (ReportDataSource source in _report.DataSources)
                {
                    localReport.DataSources.Add(source);
                }
            }
            if (_report.Parameters != null)
            {
                localReport.SetParameters(_report.Parameters);
            }
            if(_report.SubreportProc != null)
            {
                localReport.SubreportProcessing += new SubreportProcessingEventHandler(_report.SubreportProc);
            }

            return this.ShowDialog();
        }        

        public fmReportViewer(Form owner, IReport report)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //this.SingleFormMode(owner);
            _report = report;
        }

        private void fmReportViewer_Load(object sender, EventArgs e)
        {
            reportViewer.RefreshReport();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void reportViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void fmReportViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void MenuItemExportToPdf_Click(object sender, EventArgs e)
        {
            _savePath = ChoosePathToFile(_savePath);
            if (_savePath == string.Empty)
                return;
            string type = "PDF";
            string error;
            if (ExportReport(_savePath, _nameExport, type, out error))
            {
                MessageBox.Show("Експорт виконаний", "Увага");
            }
            else
            {
                MessageBox.Show("Помилка експорту.\nТехнічна інформація " + error, "Увага");
            }
        }

        private void MenuItemExportToWord_Click(object sender, EventArgs e)
        {
            _savePath = ChoosePathToFile(_savePath);
            if (_savePath == string.Empty)
                return;
            string type = "WORD";
            string error;
            if (ExportReport(_savePath, _nameExport, type, out error))
            {
                MessageBox.Show("Експорт виконаний", "Увага");
            }
            else
            {
                MessageBox.Show("Помилка експорту.\nТехнічна інформація " + error, "Увага");
            }
        }

        private void MenuItemExportToExcel_Click(object sender, EventArgs e)
        {
            _savePath = ChoosePathToFile(_savePath);
            if (_savePath == string.Empty)
                return;
            string type = "EXCEL";
            string error;
            if (ExportReport(_savePath, _nameExport, type, out error))
            {
                MessageBox.Show("Експорт виконаний", "Увага");
            }
            else
            {
                MessageBox.Show("Помилка експорту.\nТехнічна інформація " + error, "Увага");
            }
        }
    }
}
