using BLL;
using DAL;
using Entities;
using EnumType;
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
    public partial class fmUnionReportCt : Form
    {
        private readonly UnionReportCtRepository _repoUnionReportCt = new UnionReportCtRepository(SetupProgram.Connection);
        private readonly UnionReportT1Repository _repoUnionReportT1 = new UnionReportT1Repository(SetupProgram.Connection);
        private readonly UnionReportT2Repository _repoUnionReportT2 = new UnionReportT2Repository(SetupProgram.Connection);
        private readonly UnionReportT4Repository _repoUnionReportT4 = new UnionReportT4Repository(SetupProgram.Connection);
        private readonly UnionReportT5Repository _repoUnionReportT5 = new UnionReportT5Repository(SetupProgram.Connection);

        private string _pathExport = string.Empty;
        private int _flagExport = 0;

        public fmUnionReportCt(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Об'єднана звітність. Каталог");
        }

        #region Private methods

        //Вставка строки
        private void InsertRecord()
        {
            var fmEdit = new fmUnionReportCtEdit(EnumFormMode.Insert, "Створення каталога об'єднаної звітності");
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                var unionReportCt = fmEdit.GetData();
                int id = _repoUnionReportCt.AddUnionReportCt(unionReportCt, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
                dgvUnionReportCt.SetPositionRow<UnionReportCt>("UnionReportCt_Id", id.ToString());
            }
        }

        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvUnionReportCt.CurrentRow == null) return;
            var unionReportCt = dgvUnionReportCt.CurrentRow.DataBoundItem as UnionReportCt;
            if (unionReportCt == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }

            var fmEdit = new fmUnionReportCtEdit(EnumFormMode.Edit, "Зміна каталога об'єднаної звітності");
            fmEdit.SetData(unionReportCt);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                unionReportCt = fmEdit.GetData();
                string error;
                if (!_repoUnionReportCt.ModifyUnionReportCt(unionReportCt, out error))
                {
                    MessageBox.Show("Помилка оновлення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
            }
        }

        //Физическое удаление строки
        private void DeleteRecord()
        {
            var UnionReportCts = dgvUnionReportCt.GetCheckedRecords<UnionReportCt>();
            if (UnionReportCts.Count > 0)
            {
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обрані рядки?",
                    "Видалення", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Coffee.Init("Видалення...");
                    foreach (var unionReportCt in UnionReportCts)
                    {
                        string error;
                        if (!_repoUnionReportCt.DeleteUnionReportCt(unionReportCt.UnionReportCt_Id, out error))
                        {
                            MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                            break;
                        }
                    }
                    Coffee.Term();
                    RefreshTable();
                }
            }
            else
            {
                if (dgvUnionReportCt.CurrentRow == null) return;
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", 
                    "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                var unionReportCt = dgvUnionReportCt.CurrentRow.DataBoundItem as UnionReportCt;
                if (unionReportCt == null)
                {
                    MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                    return;
                }
                string error;
                if (!_repoUnionReportCt.DeleteUnionReportCt(unionReportCt.UnionReportCt_Id, out error))
                {
                    MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
            }
        }

        //Вход в документ
        private void EnterToDoc()
        {
            if (dgvUnionReportCt.CurrentRow == null) return;
            var unionReportCt = dgvUnionReportCt.CurrentRow.DataBoundItem as UnionReportCt;
            if (unionReportCt == null)
            {
                MessageBox.Show("Не знайдений рядок", "Помилка");
                return;
            }

            bool isNeedClc = false;
            if ((unionReportCt.UnionReportCt_Flg & (int)EnumActionEnterUnionReport.AskCalc) > 0)
            {
                if (MessageBox.Show("Виконати розрахунок об'єднаної звітності",
                    "Розрахування", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    isNeedClc = true;
                }
            }
            else if ((unionReportCt.UnionReportCt_Flg & (int)EnumActionEnterUnionReport.AlwaysCalc) > 0)
            {
                isNeedClc = true;
            }

            if (isNeedClc)
            {
                if (!CalcUnionReport(unionReportCt))
                    return;
            }

            var fmUnionReport = new fmUnionReport(this, unionReportCt);
            fmUnionReport.ShowDialog();
            RefreshTable();
        }
        //Расчет строки
        private void CalcRecord()
        {
            var unionReportCts = dgvUnionReportCt.GetCheckedRecords<UnionReportCt>();
            if (unionReportCts.Count > 0)
            {
                if (MessageBox.Show("Виконати розрахунок обраних рядки?",
                    "Розрахування", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Coffee.Init("Розрахування...");
                    foreach (var unionReportCt in unionReportCts)
                    {
                        if (!CalcUnionReport(unionReportCt))
                            break;
                    }
                    Coffee.Term();
                }
            }
            else
            {
                if (dgvUnionReportCt.CurrentRow == null) return;
                if (MessageBox.Show("Виконати розрахунок обранного рядка?", "Розрахування", 
                    MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                var unionReportCt = dgvUnionReportCt.CurrentRow.DataBoundItem as UnionReportCt;
                if (unionReportCt == null)
                {
                    MessageBox.Show("Не знайдений рядок для розрахування", "Помилка");
                    return;
                }
                if (!CalcUnionReport(unionReportCt))
                    return;
            }
            RefreshTable();
        }

        //Расчет отчетности
        private bool CalcUnionReport(UnionReportCt unionReportCt)
        {
            if (unionReportCt == null)
                return false;

            string error;
            if (!_repoUnionReportT1.DeleteUnionReportT1ByParams(unionReportCt.UnionReportCt_Id, out error))
            {
                MessageBox.Show("Помилка видалення таблиці 1.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if (!_repoUnionReportT2.DeleteUnionReportT2ByParams(unionReportCt.UnionReportCt_Id, out error))
            {
                MessageBox.Show("Помилка видалення таблиці 2.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if (!_repoUnionReportT4.DeleteUnionReportT4ByParams(unionReportCt.UnionReportCt_Id, out error))
            {
                MessageBox.Show("Помилка видалення таблиці 4.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if (!_repoUnionReportT5.DeleteUnionReportT5ByParams(unionReportCt.UnionReportCt_Id, out error))
            {
                MessageBox.Show("Помилка видалення таблиці 5.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if (!_repoUnionReportT1.CalcUnionReportT1(unionReportCt.UnionReportCt_Id, out error))
            {
                MessageBox.Show("Помилка розрахунку таблиці 1.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if (!_repoUnionReportT2.CalcUnionReportT2(unionReportCt.UnionReportCt_Id, out error))
            {
                MessageBox.Show("Помилка розрахунку таблиці 2.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if (!_repoUnionReportT4.CalcUnionReportT4(unionReportCt.UnionReportCt_Id, out error))
            {
                MessageBox.Show("Помилка розрахунку таблиці 4.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if (!_repoUnionReportT5.CalcUnionReportT5(unionReportCt.UnionReportCt_Id, out error))
            {
                MessageBox.Show("Помилка розрахунку таблиці 5.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            unionReportCt.UnionReportCt_DateClc = DateTime.Now;
            if (!_repoUnionReportCt.ModifyUnionReportCt(unionReportCt, out error))
            {
                MessageBox.Show("Помилка оновлення рядка каталога.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }

            return true;
        }
        private void ExportToDbf()
        {
            var unionReportCt = dgvUnionReportCt.CurrentRow.DataBoundItem as UnionReportCt;
            if (unionReportCt == null)
            {
                MessageBox.Show("Не обрані рядок/рядки для експорту", "Помилка");
                return;
            }

            var fmExport = new fmUnionReportExport();
            fmExport.SetPathExport(_pathExport);
            fmExport.SetFlagExport(_flagExport);

            var resultDialog = fmExport.ShowDialog();
            _pathExport = fmExport.GetPathExport();
            _flagExport = fmExport.GetFlagExport();

            if (resultDialog == DialogResult.No)
                return;

            string error = string.Empty;
            var unionReportT1 = new List<UnionReportT1>();
            var unionReportT2 = new List<UnionReportT2>();
            var unionReportT4 = new List<UnionReportT4>();
            var unionReportT5 = new List<UnionReportT5>();

            Coffee.Init("Завантаження даних...");
            if ((_flagExport & (int)EnumExportUnionReport.ExportTbl1) > 0)
            {
                Coffee.Refresh("Завантаження таблиці 1...");
                var result = _repoUnionReportT1.GetAllUnionReportT1ByParams(unionReportCt.UnionReportCt_Id, out error);
                if (error != string.Empty)
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка завантаження таблиці 1", "Помилка");
                    return;
                }
                unionReportT1.AddRange(result);
            }
            if ((_flagExport & (int)EnumExportUnionReport.ExportTbl2) > 0)
            {
                Coffee.Refresh("Завантаження таблиці 2...");
                var result = _repoUnionReportT2.GetAllUnionReportT2ByParams(unionReportCt.UnionReportCt_Id, out error);
                if (error != string.Empty)
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка завантаження таблиці 2", "Помилка");
                    return;
                }
                unionReportT2.AddRange(result);
            }
            if ((_flagExport & (int)EnumExportUnionReport.ExportTbl4) > 0)
            {
                Coffee.Refresh("Завантаження таблиці 4...");
                var result = _repoUnionReportT4.GetAllUnionReportT4ByParams(unionReportCt.UnionReportCt_Id, out error);
                if (error != string.Empty)
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка завантаження таблиці 4", "Помилка");
                    return;
                }
                unionReportT4.AddRange(result);
            }
            //if ((_flagExport & (int)EnumExportUnionReport.ExportTbl5) > 0)
            //{
            //    Coffee.Refresh("Завантаження таблиці 5...");
            //    var result = _repoUnionReportT5.GetAllUnionReportT5ByParams(unionReportCt.UnionReportCt_Id, out error);
            //    if (error != string.Empty)
            //    {
            //        Coffee.Term();
            //        MessageBox.Show("Помилка завантаження таблиці 5", "Помилка");
            //        return;
            //    }
            //    unionReportT5.AddRange(result);
            //}

            if ((_flagExport & (int)EnumExportUnionReport.ExportTbl1) > 0)
            {
                Coffee.Refresh("Експорт таблиці 1");
                var exportFile1 = ExportUnionReport.GetExportUnionReportT1(unionReportT1.Where(rec => rec.UnionReportT1_ExportFile == 1).ToList());
                var exportFile2 = ExportUnionReport.GetExportUnionReportT1(unionReportT1.Where(rec => rec.UnionReportT1_ExportFile == 2).ToList());
                var exportFile3 = ExportUnionReport.GetExportUnionReportT1(unionReportT1.Where(rec => rec.UnionReportT1_ExportFile == 3).ToList());

                if (exportFile1.Count() > 0 && !ExportUnionReport.ExportUnionReportT1ToDbf(_pathExport, exportFile1, "UnionReportT1_1", out error))
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка експорту таблиці 1. Місяць 1", "Помилка");
                    return;
                }

                if (exportFile2.Count() > 0 && !ExportUnionReport.ExportUnionReportT1ToDbf(_pathExport, exportFile2, "UnionReportT1_2", out error))
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка експорту таблиці 1. Місяць 2", "Помилка");
                    return;
                }

                if (exportFile3.Count() > 0 && !ExportUnionReport.ExportUnionReportT1ToDbf(_pathExport, exportFile3, "UnionReportT1_3", out error))
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка експорту таблиці 1. Місяць 3", "Помилка");
                    return;
                }
            }

            if ((_flagExport & (int)EnumExportUnionReport.ExportTbl2) > 0)
            {
                Coffee.Refresh("Експорт таблиці 2");
                var exportFile = ExportUnionReport.GetExportUnionReportT2(unionReportCt, unionReportT2);

                if (exportFile.Count() > 0 && !ExportUnionReport.ExportUnionReportT2ToDbf(_pathExport, exportFile, "UnionReportT2", out error))
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка експорту таблиці 2", "Помилка");
                    return;
                }
            }

            if ((_flagExport & (int)EnumExportUnionReport.ExportTbl4) > 0)
            {
                Coffee.Refresh("Експорт таблиці 4");
                var exportFile1 = ExportUnionReport.GetExportUnionReportT4(unionReportT4.Where(rec => rec.UnionReportT4_ExportFile == 1).ToList());
                var exportFile2 = ExportUnionReport.GetExportUnionReportT4(unionReportT4.Where(rec => rec.UnionReportT4_ExportFile == 2).ToList());
                var exportFile3 = ExportUnionReport.GetExportUnionReportT4(unionReportT4.Where(rec => rec.UnionReportT4_ExportFile == 3).ToList());

                if (exportFile1.Count() > 0 && !ExportUnionReport.ExportUnionReportT4ToDbf(_pathExport, exportFile1, "UnionReportT4_1", out error))
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка експорту таблиці 4. Місяць 1", "Помилка");
                    return;
                }

                if (exportFile2.Count() > 0 && !ExportUnionReport.ExportUnionReportT4ToDbf(_pathExport, exportFile2, "UnionReportT4_2", out error))
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка експорту таблиці 4. Місяць 2", "Помилка");
                    return;
                }

                if (exportFile3.Count() > 0 && !ExportUnionReport.ExportUnionReportT4ToDbf(_pathExport, exportFile3, "UnionReportT4_3", out error))
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка експорту таблиці 4. Місяць 3", "Помилка");
                    return;
                }
            }

            Coffee.Term();
            MessageBox.Show("Експорт виконаний", "Увага");
        }

        //Перезачитать данные таблицы
        private void RefreshTable()
        {
            dgvUnionReportCt.StorePosition();
            dgvUnionReportCt.StoreSort();
            LoadDataToGrid();
            dgvUnionReportCt.RestSort<UnionReportCt>();
            dgvUnionReportCt.RestPosition();
        }

        //Инициализация грида 
        private void InitGrid()
        {
            dgvUnionReportCt.BaseGrigStyle();
            dgvUnionReportCt.AddBirdColumn();
            dgvUnionReportCt.AddRefreshMenu(RefreshMenu);
            dgvUnionReportCt.AddSortGrid<UnionReportCt>("UnionReportCt_Id");
            dgvUnionReportCt.AddSearchGrid();
            dgvUnionReportCt.AddStatusStripRow(statusStripRow, true);
        }

        //Загрузка данных в грид
        private bool LoadDataToGrid()
        {
            string error;
            var unionReportCts = _repoUnionReportCt.GetAllUnionReportCts(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження об'єднаної звітності.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            source.DataSource = unionReportCts;
            dgvUnionReportCt.DataSource = source;

            return true;
        }

        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvUnionReportCt.CurrentRow != null && dgvUnionReportCt.Focused ? true : false;
            MenuItemCreate.Enabled = true && dgvUnionReportCt.Focused;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;
            MenuItemChoose.Enabled = isEnableMenu;
            MenuItemClc.Enabled = isEnableMenu;
            MenuItemExport.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled;
            ContextMenuEdit.Enabled = MenuItemEdit.Enabled;
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled;
            ContextMenuChoose.Enabled = MenuItemChoose.Enabled;
            ContextMenuClc.Enabled = MenuItemClc.Enabled;
            ContextMenuExport.Enabled = MenuItemExport.Enabled;
        }
        #endregion

        #region Events

        private void fmUnionReportCt_Load(object sender, EventArgs e)
        {
            InitGrid();
            if (!LoadDataToGrid())
                return;
        }

        private void fmUnionReportCt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvUnionReportCt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                EnterToDoc();
            }
        }

        private void dgvUnionReportCt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EnterToDoc();
        }

        private void MenuItemCreate_Click(object sender, EventArgs e)
        {
            InsertRecord();
        }

        private void MenuItemEdit_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void MenuItemRefresh_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void MenuItemChoose_Click(object sender, EventArgs e)
        {
            EnterToDoc();
        }

        private void MenuItemClc_Click(object sender, EventArgs e)
        {
            CalcRecord();
        }

        private void MenuItemExport_Click(object sender, EventArgs e)
        {
            ExportToDbf();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
