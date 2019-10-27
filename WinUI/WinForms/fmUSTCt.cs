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
    public partial class fmUSTCt : Form
    {
        private USTCtRepository _repoUSTCt = new USTCtRepository(SetupProgram.Connection);
        private UST6Repository _repoUST6 = new UST6Repository(SetupProgram.Connection);
        private UST7Repository _repoUST7 = new UST7Repository(SetupProgram.Connection);

        private List<USTCt> _ustCts = new List<USTCt>(); //кэш

        private string _pathExport = string.Empty;
        private int _flgExport = 0;

        public fmUSTCt(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Єдиний соціальний внесок. Каталог");
        }
        //Вставка строки
        private void InsertRecord()
        {
            fmUSTCtEdit fmEdit = new fmUSTCtEdit(EnumFormMode.Insert, "Створення каталога ЄСВ");
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                USTCt getUSTCt = fmEdit.GetData();
                int id = _repoUSTCt.AddUSTCt(getUSTCt, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableUSTCt();
                dgvUSTCt.SetPositionRow<USTCt>("USTCt_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvUSTCt.CurrentRow == null) return;
            USTCt setUSTCt = dgvUSTCt.CurrentRow.DataBoundItem as USTCt;
            if (setUSTCt == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmUSTCtEdit fmEdit = new fmUSTCtEdit(EnumFormMode.Edit, "Зміна каталога ЄСВ");
            fmEdit.SetData(setUSTCt);
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                USTCt getUSTCt = fmEdit.GetData();
                string error;
                if (!_repoUSTCt.ModifyUSTCt(getUSTCt, out error))
                {
                    MessageBox.Show("Помилка оновлення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableUSTCt();
            }
        }
        //Физическое удаление строки
        private void DeleteRecord()
        {
            List<USTCt> checkedUSTCts = dgvUSTCt.GetCheckedRecords<USTCt>();
            if (checkedUSTCts.Count > 0)
            {
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обрані рядки?",
                    "Видалення", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Coffee.Init("Видалення...");

                    foreach (USTCt ustCt in checkedUSTCts)
                    {
                        string error;
                        if (!_repoUSTCt.DeleteUSTCt(ustCt.USTCt_Id, out error))
                        {
                            MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                            break;
                        }

                    }
                    Coffee.Term();
                    RefreshTableUSTCt();
                }
            }
            else
            {
                if (dgvUSTCt.CurrentRow == null) return;
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                USTCt ustCt = dgvUSTCt.CurrentRow.DataBoundItem as USTCt;
                if (ustCt == null)
                {
                    MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                    return;
                }
                string error;
                if (!_repoUSTCt.DeleteUSTCt(ustCt.USTCt_Id, out error))
                {
                    MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTableUSTCt();
            }
        }
        //Расчет строки
        private void CalcRecord()
        {
            List<USTCt> checkedUSTCts = dgvUSTCt.GetCheckedRecords<USTCt>();
            if (checkedUSTCts.Count > 0)
            {
                if (MessageBox.Show("Виконати розрахунок обраних рядки?",
                    "Розрахування", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Coffee.Init("Розрахування...");
                    foreach (USTCt ustCt in checkedUSTCts)
                    {
                        if(!CalcUST(ustCt))
                            break;
                    }
                    Coffee.Term();

                }
            }
            else
            {
                if (dgvUSTCt.CurrentRow == null) return;
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                USTCt ustCt = dgvUSTCt.CurrentRow.DataBoundItem as USTCt;
                if (ustCt == null)
                {
                    MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                    return;
                }
                if (!CalcUST(ustCt))
                    return;
            }
            RefreshTableUSTCt();
        }
        private bool CalcUST(USTCt ustCt)
        {
            if (ustCt == null)
                return false;
            string error;
            if (!_repoUST6.DeleteUST6ByParams(ustCt.USTCt_Id, out error))
            {
                MessageBox.Show("Помилка видалення таблиці 6.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if (!_repoUST7.DeleteUST7ByParams(ustCt.USTCt_Id, out error))
            {
                MessageBox.Show("Помилка видалення таблиці 7.\nТехнічна інформація: " + error, "Помилка");
                return false; 
            }
            if (!_repoUST6.CalcUST6(ustCt.USTCt_Id, out error))
            {
                MessageBox.Show("Помилка розрахунку таблиці 6.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            if (!_repoUST7.CalcUST7(ustCt.USTCt_Id, out error))
            {
                MessageBox.Show("Помилка розрахунку таблиці 7.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            ustCt.USTCt_DateClc = DateTime.Now;
            if (!_repoUSTCt.ModifyUSTCt(ustCt, out error))
            {
                MessageBox.Show("Помилка оновлення рядка каталога.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            return true;
        }
        //Вход в документ
        private void EnterToDoc()
        {
            if (dgvUSTCt.CurrentRow == null) return;
            USTCt ustCt = dgvUSTCt.CurrentRow.DataBoundItem as USTCt;
            if (ustCt == null)
            {
                MessageBox.Show("Не знайдений рядок", "Помилка");
                return;
            }
            bool isNeedClc = false;

            if((ustCt.USTCt_Flg & (int)EnumActionEnterUST.AskCalc)> 0)
            {
                if (MessageBox.Show("Виконати розрахунок ЄСВ?",
                    "Розрахування", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    isNeedClc = true;
                }
            }
            else if ((ustCt.USTCt_Flg & (int)EnumActionEnterUST.AlwaysCalc) > 0)
            {
              isNeedClc = true;
            }
            if(isNeedClc)
            {
                if (!CalcUST(ustCt))
                    return;
            }
            fmUST fmUST = new fmUST(this, ustCt);

            fmUST.ShowDialog();

            RefreshTableUSTCt();
        }
        //
        private void ExportToDbf()
        {
            List<USTCt> checkedUSTCts = dgvUSTCt.GetCheckedRecords<USTCt>();
            USTCt currentUSTCt = null; 
            if (checkedUSTCts.Count == 0)
            {
                currentUSTCt = dgvUSTCt.CurrentRow.DataBoundItem as USTCt;
                if(currentUSTCt == null)
                {
                    MessageBox.Show("Не обрані рядок/рядки для експорту", "Помилка");
                    return;
                }
            }

            fmUSTExport fmExport = new fmUSTExport();
            fmExport.SetPathExport(_pathExport);
            fmExport.SetFlgExport(_flgExport);
            if (fmExport.ShowDialog() == DialogResult.No)
            {
                _pathExport = fmExport.GetPathExport();
                _flgExport = fmExport.GetFlgExport();
                return;
            }
            _pathExport = fmExport.GetPathExport();
            _flgExport = fmExport.GetFlgExport();

            string error = string.Empty;
            List<USTCt> ustCts = new List<USTCt>();
            List<UST6> ust6s = new List<UST6>();
            List<UST7> ust7s = new List<UST7>();

            if(checkedUSTCts.Count > 0)
            {
                ustCts = checkedUSTCts;
            }
            else
            {
                ustCts.Add(currentUSTCt);
            }
            Coffee.Init("Завантаження даних...");
            foreach (USTCt ustCt in ustCts)
            {
                if((_flgExport & (int)EnumExportUST.ExportTbl6) > 0)
                {
                    Coffee.Refresh("Завантаження таблиці 6...");
                    ust6s.AddRange(_repoUST6.GetAllUST6ByParams(ustCt.USTCt_Id, out error));
                    if (error != string.Empty)
                    {
                        Coffee.Term();
                        MessageBox.Show("Помилка завантаження таблиці 6", "Помилка");
                        return;
                    }
                }
                if ((_flgExport & (int)EnumExportUST.ExportTbl7) > 0)
                {
                    Coffee.Refresh("Завантаження таблиці 7...");
                    ust7s.AddRange(_repoUST7.GetAllUST7ByParams(ustCt.USTCt_Id, out error));
                    if (error != string.Empty)
                    {
                        Coffee.Term();
                        MessageBox.Show("Помилка завантаження таблиці 7", "Помилка");
                        return;
                    }
                }
            }
            if ((_flgExport & (int)EnumExportUST.ExportTbl6) > 0)
            {
                Coffee.Refresh("Експорт таблиці 6");
                List<ExportUST6> exportUst6 = ExportUST.GetExportDataTbl6(ustCts, ust6s);

                if(!ExportUST.ExportUST6ToDbf(_pathExport, exportUst6, out error))
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка експорту таблиці 6", "Помилка");
                    return;
                }
            }
            if ((_flgExport & (int)EnumExportUST.ExportTbl7) > 0)
            {
                Coffee.Refresh("Експорт таблиці 7");
                List<ExportUST7> exportUst7 = ExportUST.GetExportDataTbl7(ustCts, ust7s);

                if (!ExportUST.ExportUST7ToDbf(_pathExport, exportUst7, out error))
                {
                    Coffee.Term();
                    MessageBox.Show("Помилка експорту таблиці 7", "Помилка");
                    return;
                }
            }

            Coffee.Term();
            MessageBox.Show("Експорт виконаний", "Увага");
        }
       
        //Перезачитать данные таблицы
        private void RefreshTableUSTCt()
        {
            dgvUSTCt.StorePosition();
            dgvUSTCt.StoreSort();
            LoadDataToGridUSTCt();
            dgvUSTCt.RestSort<USTCt>();
            dgvUSTCt.RestPosition();
        }
        //Инициализация грида ЕСВ
        private void InitGridUSTCt()
        {
            dgvUSTCt.BaseGrigStyle();
            dgvUSTCt.AddBirdColumn();
            dgvUSTCt.AddRefreshMenu(RefreshMenu);
            dgvUSTCt.AddSortGrid<USTCt>("USTCt_Id");
            dgvUSTCt.AddSearchGrid();
            dgvUSTCt.AddStatusStripRow(statusStripRow, true);
        }
        //Загрузка данных в грид ЕСВ
        private bool LoadDataToGridUSTCt()
        {
            string error;
            _ustCts = _repoUSTCt.GetAllUSTCts(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження ЄСВ.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            BindingSource source = new BindingSource();
            source.DataSource = _ustCts;
            dgvUSTCt.DataSource = source;
            return true;
        }
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvUSTCt.CurrentRow != null && dgvUSTCt.Focused ? true : false;
            MenuItemCreate.Enabled = true && dgvUSTCt.Focused;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;
            MenuItemClc.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled; 
            ContextMenuEdit.Enabled = MenuItemEdit.Enabled;     
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled; 
            ContextMenuClc.Enabled = MenuItemClc.Enabled;                   
        }

        private void fmUSTCt_Load(object sender, EventArgs e)
        {
            InitGridUSTCt();
            if (!LoadDataToGridUSTCt())
                return;
        }
        private void fmUSTCt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void dgvUSTCt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                EnterToDoc();
            }
        }

        private void dgvUSTCt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void MenuItemClc_Click(object sender, EventArgs e)
        {
            CalcRecord();
        }

        private void MenuItemRefresh_Click(object sender, EventArgs e)
        {
            RefreshTableUSTCt();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuItemExport_Click(object sender, EventArgs e)
        {
            ExportToDbf();
        }

        private void MenuItemChoose_Click(object sender, EventArgs e)
        {
            EnterToDoc();
        }
        //Коннтекстное меню
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
            RefreshTableUSTCt();
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
