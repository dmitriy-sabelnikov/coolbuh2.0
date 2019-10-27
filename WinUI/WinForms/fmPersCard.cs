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
using WinUI.Helper;
using WinFormExtensions;
using EnumType;
using Reports;

namespace WinUI.WinForms
{
    public partial class fmPersCard : Form
    {
        private List<PersCard> persCards = null; //Кеширование
        private PersCardRepository _repository         = new PersCardRepository(SetupProgram.Connection);
        private ChildRepository _repoChild             = new ChildRepository(SetupProgram.Connection);
        private CardStatusRepository _repoCardStatus   = new CardStatusRepository(SetupProgram.Connection);
        private TaxReliefRepository _repoTaxRelief     = new TaxReliefRepository(SetupProgram.Connection);
        private DisabilityRepository _repoDisability   = new DisabilityRepository(SetupProgram.Connection);
        private CardSpecExpRepository _repoCardSpecExp = new CardSpecExpRepository(SetupProgram.Connection);

        private SqlSript sqlScipt = new SqlSript(SetupProgram.Connection);

        //Вставка строки
        private void InsertRecord()
        {
            fmPersCardEdit fmEdit = new fmPersCardEdit(EnumFormMode.Insert, "Створення картки");
            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                string error;
                PersCard card = fmEdit.GetData();
                int id = _repository.AddCard(card, out error);
                if (id == 0)
                {
                    MessageBox.Show("Помилка додавання рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }

                StringBuilder sql = new StringBuilder();

                List<Child> childs = fmEdit.GetChildren();
                foreach (Child child in childs)
                {
                    child.Child_PersCard_Id = id;
                    sql.AppendLine(_repoChild.CreateStrInsertChild(child));
                }

                List<CardStatus> getCardStatuses = fmEdit.GetCardStatus();
                foreach (CardStatus cardStatus in getCardStatuses)
                {
                    sql.AppendLine(_repoCardStatus.CreateStrInsertCardStatus(cardStatus));
                }

                List<TaxRelief> getTaxReliefs = fmEdit.GetTaxRelief();
                foreach (TaxRelief taxRelief in getTaxReliefs)
                {
                    sql.AppendLine(_repoTaxRelief.CreateStrInsertTaxRelief(taxRelief));
                }

                List<Disability> getDisabilities = fmEdit.GetDisability();
                foreach (Disability disability in getDisabilities)
                {
                    sql.AppendLine(_repoDisability.CreateStrInsertDisability(disability));
                }

                List<CardSpecExp> getCardSpecExps = fmEdit.GetCardSpecExp();
                foreach (CardSpecExp cardSpecExp in getCardSpecExps)
                {
                    sql.AppendLine(_repoCardSpecExp.CreateStrInsertCardSpecExp(cardSpecExp));
                }

                if (!sqlScipt.ExecuteSqlScript(sql.ToString(), out error))
                {
                    MessageBox.Show("Помилка оновлення.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }

                RefreshTable();
                dgvPersCard.SetPositionRow<PersCard>("PersCard_Id", id.ToString());
            }
        }
        //Обновление строки
        private void UpdateRecord()
        {
            if (dgvPersCard.CurrentRow == null) return;
            PersCard persCard = dgvPersCard.CurrentRow.DataBoundItem as PersCard;
            if (persCard == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            string error;
            List<Child> children = _repoChild.GetChildByParams(persCard.PersCard_Id, out error);
            if(error != string.Empty)
            {
                MessageBox.Show("Помилка отримання інтервалів дітей.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            List<TaxRelief> taxReliefs = _repoTaxRelief.GetTaxReliefByParams(persCard.PersCard_Id, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка отримання інтервалів пільг.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            List<CardStatus> cardStatuses = _repoCardStatus.GetCardStatusByParams(persCard.PersCard_Id, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка отримання інтервалів статуса.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            List<Disability> disabilities = _repoDisability.GetDisabilitiesByParams(persCard.PersCard_Id, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка отримання інтервалів інвалідності.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            List<CardSpecExp> cardSpecExps = _repoCardSpecExp.GetCardSpecExpByParams(persCard.PersCard_Id, out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка отримання інтервалів спецстажів.\nТехнічна інформація: " + error, "Помилка");
                return;
            }

            fmPersCardEdit fmEdit = new fmPersCardEdit(EnumFormMode.Edit, "Зміна картки");
            fmEdit.SetData(persCard);
            fmEdit.SetChildren(children);
            fmEdit.SetCardStatus(cardStatuses);
            fmEdit.SetTaxRelief(taxReliefs);
            fmEdit.SetDisability(disabilities);
            fmEdit.SetCardSpecExp(cardSpecExps);

            if (fmEdit.ShowDialog() == DialogResult.OK)
            {
                persCard = fmEdit.GetData();
                if (!_repository.ModifyCard(persCard, out error))
                {
                    MessageBox.Show("Помилка оновлення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }

                StringBuilder sql = new StringBuilder();
                sql.AppendLine(_repoChild.CreateStrDeleteChildByParam(persCard.PersCard_Id));
                List<Child> childs = fmEdit.GetChildren();
                foreach (Child child in childs)
                {
                    sql.AppendLine(_repoChild.CreateStrInsertChild(child));
                }

                sql.AppendLine(_repoCardStatus.CreateStrDeleteCardStatusByParam(persCard.PersCard_Id));
                List<CardStatus> getCardStatuses = fmEdit.GetCardStatus();
                foreach (CardStatus cardStatus in getCardStatuses)
                {
                    sql.AppendLine(_repoCardStatus.CreateStrInsertCardStatus(cardStatus));
                }

                sql.AppendLine(_repoTaxRelief.CreateStrDeleteTaxReliefByParam(persCard.PersCard_Id));
                List<TaxRelief> getTaxReliefs = fmEdit.GetTaxRelief();
                foreach (TaxRelief taxRelief in getTaxReliefs)
                {
                    sql.AppendLine(_repoTaxRelief.CreateStrInsertTaxRelief(taxRelief));
                }

                sql.AppendLine(_repoDisability.CreateStrDeleteDisabilityByParam(persCard.PersCard_Id));
                List<Disability> getDisabilities = fmEdit.GetDisability();
                foreach (Disability disability in getDisabilities)
                {
                    sql.AppendLine(_repoDisability.CreateStrInsertDisability(disability));
                }

                sql.AppendLine(_repoCardSpecExp.CreateStrDeleteCardSpecExpByParam(persCard.PersCard_Id));
                List<CardSpecExp> getCardSpecExps = fmEdit.GetCardSpecExp();
                foreach (CardSpecExp cardSpecExp in getCardSpecExps)
                {
                    sql.AppendLine(_repoCardSpecExp.CreateStrInsertCardSpecExp(cardSpecExp));
                }

                if (!sqlScipt.ExecuteSqlScript(sql.ToString(), out error))
                {
                    MessageBox.Show("Помилка оновлення.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
            }
        }
        //Физическое удаление строки
        private void DeleteRecord()
        {
            List<PersCard> checkedCard = dgvPersCard.GetCheckedRecords<PersCard>();
            if(checkedCard.Count > 0)
            {
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обрані рядки?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Coffee.Init("Видалення...");
                    foreach (PersCard card in checkedCard)
                    {
                        string error;
                        if (!_repository.DeleteCard(card.PersCard_Id, out error))
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
                if (dgvPersCard.CurrentRow == null) return;
                if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                PersCard persCard = dgvPersCard.CurrentRow.DataBoundItem as PersCard;
                if (persCard == null)
                {
                    MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                    return;
                }
                string error;
                if (!_repository.DeleteCard(persCard.PersCard_Id, out error))
                {
                    MessageBox.Show("Помилка видалення рядка.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                RefreshTable();
            }
        }
        //Перезачитать данные таблицы
        private void RefreshTable()
        {
            dgvPersCard.StorePosition();
            dgvPersCard.StoreSort();
            LoadDataToGridPersCard();
            dgvPersCard.RestSort<PersCard>();
            dgvPersCard.RestPosition();
        }
        //Инициализация грида "Зарплата"
        private void InitGridPersCard()
        {
            dgvPersCard.BaseGrigStyle();
            dgvPersCard.AddBirdColumn();
            dgvPersCard.AddRefreshMenu(RefreshMenu);
            dgvPersCard.AddSortGrid<PersCard>("PersCard_Id");
            dgvPersCard.AddSearchGrid();
            dgvPersCard.AddStatusStripRow(statusStripRow, true);
        }

        //Загрузка данных в грид "Зарплата"
        private bool LoadDataToGridPersCard()
        {
            string error;
            persCards = _repository.GetAllCards(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка завантаження карток обліку.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            dgvPersCard.DataSource = persCards;
            return true;
        }
        //Обновить меню
        private void RefreshMenu()
        {
            bool isEnableMenu = dgvPersCard.CurrentRow == null ? false : true;
            MenuItemCreate.Enabled = true;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;

            ContextMenuCreate.Enabled = MenuItemCreate.Enabled;
            ContextMenuEdit.Enabled = MenuItemEdit.Enabled;
            ContextMenuDelete.Enabled = MenuItemDelete.Enabled;
        }

        public fmPersCard(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Картки обліку");
        }

        private void fmPersCard_Load(object sender, EventArgs e)
        {
            InitGridPersCard();
            LoadDataToGridPersCard();
        }

        private void fmPersCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        private void dgvPersCard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        //--------------------События меню----------------------------
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

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        //----------------------------------------------------------
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
    }
}
