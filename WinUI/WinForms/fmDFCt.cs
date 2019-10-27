using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Entities;
using BLL;
using WinFormExtensions;
using EnumType;


namespace WinUI.WinForms
{
    public partial class fmDFCt : Form
    {
        private DFCtRepository _repoDFCt = new DFCtRepository(SetupProgram.Connection);
        private DFRecRepository _repoDFRec = new DFRecRepository(SetupProgram.Connection);
        private RefAdmRepository _repoRefAdm = new RefAdmRepository(SetupProgram.Connection);

        private List<DFCt> _dfCts = null; //кэш
        private List<RefAdm> _refAdms = null; //кэш

        private string _pathExport = string.Empty;

        public fmDFCt(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Форма 1ДФ. Каталог");
        }
        //Вставка строки
        private void InsertRecord()
        {
            fmDFCtEdit fmEdit = new fmDFCtEdit(EnumFormMode.Insert, "Створення каталога 1 ДФ");
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                DFCt getDFCt = fmEdit.GetData();
                int id = _repoDFCt.AddDFCt(getDFCt, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
                dgvDFCt.SetPositionRow<DFCt>("DFCt_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvDFCt.CurrentRow == null) return;
            DFCt setDFCt = dgvDFCt.CurrentRow.DataBoundItem as DFCt;
            if (setDFCt == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmDFCtEdit fmEdit = new fmDFCtEdit(EnumFormMode.Edit, "Зміна каталога 1 ДФ");
            fmEdit.SetData(setDFCt);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                DFCt getDFCt = fmEdit.GetData();
                string error;
                if (!_repoDFCt.ModifyDFCt(getDFCt, out error))
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
            List<DFCt> checkedDFCts = dgvDFCt.GetCheckedRecords<DFCt>();
            if (checkedDFCts.Count > 0)
            {
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обрані рядки?",
                    "Видалення", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Coffee.Init("Видалення...");
                    foreach (DFCt dfCt in checkedDFCts)
                    {
                        string error;
                        if (!_repoDFCt.DeleteDFCt(dfCt.DFCt_Id, out error))
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
                if (dgvDFCt.CurrentRow == null) return;
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                DFCt dfCt = dgvDFCt.CurrentRow.DataBoundItem as DFCt;
                if (dfCt == null)
                {
                    MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                    return;
                }
                string error;
                if (!_repoDFCt.DeleteDFCt(dfCt.DFCt_Id, out error))
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
            if (dgvDFCt.CurrentRow == null) return;
            DFCt dfCt = dgvDFCt.CurrentRow.DataBoundItem as DFCt;
            if (dfCt == null)
            {
                MessageBox.Show("Не знайдений рядок", "Помилка");
                return;
            }
            bool isNeedClc = false;

            if ((dfCt.DFCt_Flg & (int)EnumActionEnterDF.AskCalc) > 0)
            {
                if (MessageBox.Show("Виконати розрахунок 1ДФ?",
                    "Розрахування", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    isNeedClc = true;
                }
            }
            else if ((dfCt.DFCt_Flg & (int)EnumActionEnterDF.AlwaysCalc) > 0)
            {
                isNeedClc = true;
            }
            if (isNeedClc)
            {
                if (!CalcDF(dfCt))
                    return;
            }
            fmDFRec dfRec = new fmDFRec(this, dfCt);

            dfRec.ShowDialog();
            
            RefreshTable();
        }
        //Расчет строки
        private void CalcRecord()
        {
            List<DFCt> checkedDFCts = dgvDFCt.GetCheckedRecords<DFCt>();
            if (checkedDFCts.Count > 0)
            {
                if (MessageBox.Show("Виконати розрахунок обраних рядки?",
                    "Розрахування", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Coffee.Init("Розрахування...");
                    foreach (DFCt dfCt in checkedDFCts)
                    {
                        if (!CalcDF(dfCt))
                            break;
                    }
                    Coffee.Term();
                }
            }
            else
            {
                if (dgvDFCt.CurrentRow == null) return;
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                DFCt dfCt = dgvDFCt.CurrentRow.DataBoundItem as DFCt;
                if (dfCt == null)
                {
                    MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                    return;
                }
                if (!CalcDF(dfCt))
                    return;
            }
            RefreshTable();
        }
        private bool CalcDF(DFCt dfCt)
        {
            if (dfCt == null)
                return false;

            string error;
            if (!_repoDFRec.DeleteDFRecByParams(dfCt.DFCt_Id, out error))
            {
                MessageBox.Show("Помилка видалення 1ДФ.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if (!_repoDFRec.CalcDFRec(dfCt.DFCt_Id, out error))
            {
                MessageBox.Show("Помилка розрахунку 1ДФ.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            dfCt.DFCt_DateClc = DateTime.Now;
            if (!_repoDFCt.ModifyDFCt(dfCt, out error))
            {
                MessageBox.Show("Помилка оновлення рядка каталога.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            return true;
        }
        private void ExportToDbf()
        {
            List<DFCt> checkedDFCts = dgvDFCt.GetCheckedRecords<DFCt>();
            DFCt currentDFCt = null;
            if (checkedDFCts.Count == 0)
            {
                currentDFCt = dgvDFCt.CurrentRow.DataBoundItem as DFCt;
                if (currentDFCt == null)
                {
                    MessageBox.Show("Не обрані рядок/рядки для експорту", "Помилка");
                    return;
                }
            }

            fmDFExport fmExport = new fmDFExport();
            fmExport.SetPathExport(_pathExport);
            if (fmExport.ShowDialog() == DialogResult.No)
            {
                _pathExport = fmExport.GetPathExport();
                return;
            }
            _pathExport = fmExport.GetPathExport();

            string error = string.Empty;
            List<DFCt> dfCts = new List<DFCt>();
            List<DFRec> dfRecs = new List<DFRec>();

            if (checkedDFCts.Count > 0)
            {
                dfCts = checkedDFCts;
            }
            else
            {
                dfCts.Add(currentDFCt);
            }
            
            Coffee.Init("Завантаження даних...");
            if(_refAdms == null)
            {
                _refAdms = _repoRefAdm.GetAllAdms(out error);
                if (error != string.Empty)
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка завантаження администрации", "Помилка");
                    return;
                }
            }

            foreach (DFCt dfCt in dfCts)
            {
                Coffee.Refresh("Завантаження 1 ДФ...");

                dfRecs = _repoDFRec.GetAllDFRecByParams(dfCt.DFCt_Id, out error);
                if (error != string.Empty)
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка завантаження 1ДФ", "Помилка");
                    return;
                }
                Coffee.Refresh("Експорт 1 ДФ...");
                int qrt = SalaryHelper.GetQrtByDate(dfCt.DFCt_Date);
                List<ExportDFRec> exportDfRec = ExportDF.GetExportDataDF(dfCt.DFCt_Date, dfRecs, _refAdms);
                
                if (!ExportDF.ExportDFToDbf(_pathExport, qrt, exportDfRec, out error))
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка експорту 1 ДФ", "Помилка");
                    return;
                }
            }
            Coffee.Term();
            MessageBox.Show("Експорт виконаний", "Увага");
        }
       
        //Перезачитать данные таблицы
        private void RefreshTable()
        {
            dgvDFCt.StorePosition();
            dgvDFCt.StoreSort();
            LoadDataToGridDFCt();
            dgvDFCt.RestSort<DFCt>();
            dgvDFCt.RestPosition();
        }
        //Инициализация грида 1ДФ
        private void InitGridDFCt()
        {
            dgvDFCt.BaseGrigStyle();
            dgvDFCt.AddBirdColumn();
            dgvDFCt.AddRefreshMenu(RefreshMenu);
            dgvDFCt.AddSortGrid<DFCt>("DFCt_Id");
            dgvDFCt.AddSearchGrid();
            dgvDFCt.AddStatusStripRow(statusStripRow, true);
        }
        //Загрузка данных в грид 1ДФ
        private bool LoadDataToGridDFCt()
        {
            string error;
            _dfCts = _repoDFCt.GetAllDFCts(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження 1ДФ.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            source.DataSource = GetViewDfCt(_dfCts);
            dgvDFCt.DataSource = source;
            return true;
        }
        private List<v_DFCt> GetViewDfCt(List<DFCt> dfCts)
        {

            List<v_DFCt> res = (from dfct in dfCts
                                   select new v_DFCt
                                   {
                                       DFCt_Id = dfct.DFCt_Id,
                                       DFCt_Date = dfct.DFCt_Date,
                                       DFCt_Nmr = dfct.DFCt_Nmr,
                                       DFCt_Nm = dfct.DFCt_Nm,
                                       DFCt_DateClc = dfct.DFCt_DateClc,
                                       DFCt_Flg = dfct.DFCt_Flg,
                                       DFCt_Qrt = SalaryHelper.GetQrtByDate(dfct.DFCt_Date),
                                       DFCt_Yr = dfct.DFCt_Date.Year
                                   }).ToList();
            return res;
        } 
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvDFCt.CurrentRow != null && dgvDFCt.Focused ? true : false;
            MenuItemCreate.Enabled = true && dgvDFCt.Focused;
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

        private void fmDFCt_Load(object sender, EventArgs e)
        {
            InitGridDFCt();
            if (!LoadDataToGridDFCt())
                return;
        }
        private void fmDFCt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvDFCt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                EnterToDoc();
            }
        }

        private void dgvDFCt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EnterToDoc();
        }
        //=====================================МЕНЮ============================

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
        //Контекстное меню
        private void ContextMenuCreate_Click(object sender, EventArgs e)
        {
            InsertRecord();
        }

        private void ContextMenuEdit_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }

        private void ContextMenuDelete_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        private void ContextMenuRefresh_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void ContextMenuChoose_Click(object sender, EventArgs e)
        {
            EnterToDoc();
        }

        private void ContextMenuClc_Click(object sender, EventArgs e)
        {
            CalcRecord();
        }

        private void ContextMenuExport_Click(object sender, EventArgs e)
        {
            ExportToDbf();
        }
    }   
}
