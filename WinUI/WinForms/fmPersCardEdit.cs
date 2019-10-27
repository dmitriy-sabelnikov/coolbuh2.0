using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinUI.Helper;
using Entities;
using BLL;
using DAL;
using WinFormExtensions;
using ComboBoxes;
using EnumType;

namespace WinUI.WinForms
{
    public partial class fmPersCardEdit : Form
    {
        private List<PersCard> persCards = null;                        //Кеширование
        private List<Child> childs             = new List<Child>();       //Кеширование
        private List<TaxRelief> taxReliefs     = new List<TaxRelief>();   //Кеширование
        private List<CardStatus> cardStatuses  = new List<CardStatus>();  //Кеширование
        private List<Disability> disabilities  = new List<Disability>();  //Кеширование
        private List<CardSpecExp> cardSpecExps = new List<CardSpecExp>(); //Кеширование
        private List<RefSpecExp> refSpecExps = null;
        private RefSpecExpRepository _repoSpecExp = new RefSpecExpRepository(SetupProgram.Connection);

        private PersCardRepository _repository = new PersCardRepository(SetupProgram.Connection);

        private ToolTip tooltip = new ToolTip();
        private int id = 0;
        
        //=============================================================================================================================
        //                                                      Дети
        //=============================================================================================================================
        //Вставка строки
        private void InsertChild()
        {
            fmPersCardChildEdit fmChildEdit = new fmPersCardChildEdit(EnumFormMode.Insert, "Створення інтервалу");
            fmChildEdit.AddControlPeriod(childs);
            if (fmChildEdit.ShowDialog() == DialogResult.OK)
            {
                Child getChild = fmChildEdit.GetData();
                if (childs.Count == 0)
                    getChild.Child_Id = 1;
                else
                    getChild.Child_Id = childs.Max(rec => rec.Child_Id) + 1;
                getChild.Child_PersCard_Id = id;
                childs.Add(getChild);
                RefreshTableChild();
            }
        }

        //Обновление строки
        private void UpdateChild()
        {
            if (dgvChild.CurrentRow == null) return;
            Child child = dgvChild.CurrentRow.DataBoundItem as Child;
            if (child == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmPersCardChildEdit fmChildEdit = new fmPersCardChildEdit(EnumFormMode.Edit, "Зміна інтервалу");
            fmChildEdit.AddControlPeriod(childs);
            fmChildEdit.SetData(child);
            if (fmChildEdit.ShowDialog() == DialogResult.OK)
            {
                child = fmChildEdit.GetData();
                Child findChild = childs.FirstOrDefault(rec => rec.Child_Id == child.Child_Id);
                if(findChild == null)
                {
                    MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                    return;
                }
                findChild.Child_PerBeg = child.Child_PerBeg;
                findChild.Child_PerEnd= child.Child_PerEnd;
                findChild.Child_Count = child.Child_Count;
                RefreshTableChild();
            }
        }
        //Физическое удаление строки
        private void DeleteChild()
        {
            if (dgvChild.CurrentRow == null) return;
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            Child child = dgvChild.CurrentRow.DataBoundItem as Child;
            if (child == null)
            {
                MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                return;
            }
            childs.Remove(child);
            RefreshTableChild();
        }
        //Инициализация грида "Дети"
        private void InitGridChild()
        {
            dgvChild.BaseGrigStyle();
            dgvChild.ContextMenuStrip = contextMenuStrip;
            dgvChild.AddRefreshMenu(RefreshMenuChild);
        }

        //Перезачитать данные таблицы
        private void RefreshTableChild()
        {
            BindingSource source = new BindingSource();
            source.DataSource = childs;
            dgvChild.DataSource = source;
            dgvChild.Refresh();
        }

        //Обновить меню
        private void RefreshMenuChild()
        {
            bool isEnableMenu = dgvChild.CurrentRow == null ? false : true;
            MenuItemCreate.Enabled = true;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;
        }
        
        //=============================================================================================================================
        //                                                      Льготы
        //=============================================================================================================================
        //Вставка строки
        private void InsertTaxRelief()
        {
            fmPersCardTaxReliefEdit fmTaxReliefEdit = new fmPersCardTaxReliefEdit(EnumFormMode.Insert, "Створення інтервалу");
            fmTaxReliefEdit.AddControlPeriod(taxReliefs);
            if (fmTaxReliefEdit.ShowDialog() == DialogResult.OK)
            {
                TaxRelief getTaxRelief = fmTaxReliefEdit.GetData();
                if (taxReliefs.Count == 0)
                    getTaxRelief.TaxRelief_Id = 1;
                else
                    getTaxRelief.TaxRelief_Id = childs.Max(rec => rec.Child_Id) + 1;
                getTaxRelief.TaxRelief_PersCard_Id = id;
                taxReliefs.Add(getTaxRelief);
                RefreshTableTaxRelief();
            }
        }

        //Обновление строки
        private void UpdateTaxRelief()
        {
            if (dgvTaxRelief.CurrentRow == null) return;
            TaxRelief taxRelief = dgvTaxRelief.CurrentRow.DataBoundItem as TaxRelief;
            if (taxRelief == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmPersCardTaxReliefEdit fmTaxReliefEdit = new fmPersCardTaxReliefEdit(EnumFormMode.Edit, "Зміна інтервалу");
            fmTaxReliefEdit.AddControlPeriod(taxReliefs);
            fmTaxReliefEdit.SetData(taxRelief);
            if (fmTaxReliefEdit.ShowDialog() == DialogResult.OK)
            {
                taxRelief = fmTaxReliefEdit.GetData();
                TaxRelief findTaxRelief = taxReliefs.FirstOrDefault(rec => rec.TaxRelief_Id == taxRelief.TaxRelief_Id);
                if (findTaxRelief == null)
                {
                    MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                    return;
                }
                findTaxRelief.TaxRelief_PerBeg = taxRelief.TaxRelief_PerBeg;
                findTaxRelief.TaxRelief_PerEnd = taxRelief.TaxRelief_PerEnd;
                findTaxRelief.TaxRelief_Koef = taxRelief.TaxRelief_Koef;
                RefreshTableTaxRelief();
            }
        }
        //Физическое удаление строки
        private void DeleteTaxRelief()
        {
            if (dgvTaxRelief.CurrentRow == null) return;
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            TaxRelief taxRelief = dgvTaxRelief.CurrentRow.DataBoundItem as TaxRelief;
            if (taxRelief == null)
            {
                MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                return;
            }
            taxReliefs.Remove(taxRelief);
            RefreshTableTaxRelief();
        }
        //Инициализация грида "Льготы"
        private void InitGridTaxRelief()
        {
            dgvTaxRelief.BaseGrigStyle();
            dgvTaxRelief.ContextMenuStrip = contextMenuStrip;
            dgvTaxRelief.AddRefreshMenu(RefreshMenuTaxRelief);
        }

        //Перезачитать данные таблицы
        private void RefreshTableTaxRelief()
        {
            BindingSource source = new BindingSource();
            source.DataSource = taxReliefs;
            dgvTaxRelief.DataSource = source;
            //dgvTaxRelief.Refresh();
        }

        //Обновить меню
        private void RefreshMenuTaxRelief()
        {
            bool isEnableMenu = dgvTaxRelief.CurrentRow == null ? false : true;
            MenuItemCreate.Enabled = true;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;
        }
        
        //=============================================================================================================================
        //                                                      Статус
        //=============================================================================================================================
        //Вставка строки
        private void InsertCardStatus()
        {
            fmPersCardStatusEdit fmStatusEdit = new fmPersCardStatusEdit(EnumFormMode.Insert, "Створення інтервалу");
            fmStatusEdit.AddControlPeriod(cardStatuses);
            if (fmStatusEdit.ShowDialog() == DialogResult.OK)
            {
                CardStatus getCardStatus = fmStatusEdit.GetData();
                if (cardStatuses.Count == 0)
                    getCardStatus.CardStatus_Id = 1;
                else
                    getCardStatus.CardStatus_Id = cardStatuses.Max(rec => rec.CardStatus_Id) + 1;
                getCardStatus.CardStatus_PersCard_Id = id;
                cardStatuses.Add(getCardStatus);
                RefreshTableCardStatus();
            }
        }

        //Обновление строки
        private void UpdateCardStatus()
        {
            if (dgvCardStatus.CurrentRow == null) return;
            CardStatus cardStatus = dgvCardStatus.CurrentRow.DataBoundItem as v_CardStatus;
            if (cardStatus == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmPersCardStatusEdit fmCardStatusEdit = new fmPersCardStatusEdit(EnumFormMode.Edit, "Зміна інтервалу");
            fmCardStatusEdit.AddControlPeriod(cardStatuses);
            fmCardStatusEdit.SetData(cardStatus);
            if (fmCardStatusEdit.ShowDialog() == DialogResult.OK)
            {
                cardStatus = fmCardStatusEdit.GetData();
                CardStatus findCardStatus = cardStatuses.FirstOrDefault(rec => rec.CardStatus_Id == cardStatus.CardStatus_Id);
                if (findCardStatus == null)
                {
                    MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                    return;
                }
                findCardStatus.CardStatus_PerBeg = cardStatus.CardStatus_PerBeg;
                findCardStatus.CardStatus_PerEnd = cardStatus.CardStatus_PerEnd;
                findCardStatus.CardStatus_Type = cardStatus.CardStatus_Type;
                RefreshTableCardStatus();
            }
        }
        //Физическое удаление строки
        private void DeleteCardStatus()
        {
            if (dgvCardStatus.CurrentRow == null) return;
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            CardStatus cardStatus = dgvCardStatus.CurrentRow.DataBoundItem as v_CardStatus;
            if (cardStatus == null)
            {
                MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                return;
            }
            cardStatuses.Remove(cardStatus);
            RefreshTableCardStatus();
        }
        //Инициализация грида "Статус"
        private void InitGridCardStatus()
        {
            dgvCardStatus.BaseGrigStyle();
            dgvCardStatus.ContextMenuStrip = contextMenuStrip;
            dgvCardStatus.AddRefreshMenu(RefreshMenuCardStatus);
        }
        //Перезачитать данные таблицы
        private void RefreshTableCardStatus()
        {
            BindingSource source = new BindingSource();
            source.DataSource = GetViewCardStatus(cardStatuses);
            dgvCardStatus.DataSource = source;
            dgvCardStatus.Refresh();
        }

        private List<v_CardStatus> GetViewCardStatus(List<CardStatus> statuses)
        {
            List<v_CardStatus> res = (from status in statuses
                                      select new v_CardStatus
                                      {
                                        CardStatus_Id = status.CardStatus_Id,
                                        CardStatus_PerBeg = status.CardStatus_PerBeg,
                                        CardStatus_PerEnd = status.CardStatus_PerEnd,
                                        CardStatus_Type = status.CardStatus_Type,
                                        CardStatus_TypeNm = CardStatusHelper.GetStatusName(status.CardStatus_Type)
                                      }).ToList();
            return res;
        }
        //Обновить меню
        private void RefreshMenuCardStatus()
        {
            bool isEnableMenu = dgvCardStatus.CurrentRow == null ? false : true;
            MenuItemCreate.Enabled = true;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;
        }
        //=============================================================================================================================
        //                                                      Инвалидность
        //=============================================================================================================================
        //Вставка строки
        private void InsertDisability()
        {
            fmPersCardDisabilityEdit fmDisabilityEdit = new fmPersCardDisabilityEdit(EnumFormMode.Insert, "Створення інтервалу");
            fmDisabilityEdit.AddControlPeriod(disabilities);
            if (fmDisabilityEdit.ShowDialog() == DialogResult.OK)
            {
                Disability getDisability = fmDisabilityEdit.GetData();
                if (disabilities.Count == 0)
                    getDisability.Disability_Id = 1;
                else
                    getDisability.Disability_Id = disabilities.Max(rec => rec.Disability_Id) + 1;
                getDisability.Disability_PersCard_Id = id;
                disabilities.Add(getDisability);
                RefreshTableDisability();
            }
        }

        //Обновление строки
        private void UpdateDisability()
        {
            if (dgvDisability.CurrentRow == null) return;
            Disability disability = dgvDisability.CurrentRow.DataBoundItem as Disability;
            if (disability == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmPersCardDisabilityEdit fmCardDisabilityEdit = new fmPersCardDisabilityEdit(EnumFormMode.Edit, "Зміна інтервалу");
            fmCardDisabilityEdit.AddControlPeriod(disabilities);
            fmCardDisabilityEdit.SetData(disability);
            if (fmCardDisabilityEdit.ShowDialog() == DialogResult.OK)
            {
                disability = fmCardDisabilityEdit.GetData();
                Disability findDisability = disabilities.FirstOrDefault(rec => rec.Disability_Id == disability.Disability_Id);
                if (findDisability == null)
                {
                    MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                    return;
                }
                findDisability.Disability_PerBeg = disability.Disability_PerBeg;
                findDisability.Disability_PerEnd = disability.Disability_PerEnd;
                findDisability.Disability_Attr = disability.Disability_Attr;
                RefreshTableDisability();
            }
        }
        //Физическое удаление строки
        private void DeleteDisability()
        {
            if (dgvDisability.CurrentRow == null) return;
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            Disability disability = dgvDisability.CurrentRow.DataBoundItem as Disability;
            if (disability == null)
            {
                MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                return;
            }
            disabilities.Remove(disability);
            RefreshTableDisability();
        }
        //Инициализация грида "Статус"
        private void InitGridDisability()
        {
            dgvDisability.BaseGrigStyle();
            dgvDisability.ContextMenuStrip = contextMenuStrip;
            dgvDisability.AddRefreshMenu(RefreshMenuDisability);
        }
        //Перезачитать данные таблицы
        private void RefreshTableDisability()
        {
            BindingSource source = new BindingSource();
            source.DataSource = disabilities;
            dgvDisability.DataSource = source;
            dgvDisability.Refresh();
        }

        //Обновить меню
        private void RefreshMenuDisability()
        {
            bool isEnableMenu = dgvDisability.CurrentRow == null ? false : true;
            MenuItemCreate.Enabled = true;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;
        }
        //=============================================================================================================================
        //                                                      Спецстажи
        //=============================================================================================================================
        //Вставка строки
        private void InsertCardSpecExp()
        {
            fmPersCardSpecExpEdit fmСardSpecExpEdit = new fmPersCardSpecExpEdit(EnumFormMode.Insert, "Створення інтервалу", refSpecExps);
            fmСardSpecExpEdit.AddControlPeriod(cardSpecExps);
            if (fmСardSpecExpEdit.ShowDialog() == DialogResult.OK)
            {
                CardSpecExp getСardSpecExp = fmСardSpecExpEdit.GetData();
                if (cardSpecExps.Count == 0)
                    getСardSpecExp.CardSpecExp_Id = 1;
                else
                    getСardSpecExp.CardSpecExp_Id = cardSpecExps.Max(rec => rec.CardSpecExp_Id) + 1;
                getСardSpecExp.CardSpecExp_PersCard_Id = id;
                cardSpecExps.Add(getСardSpecExp);
                RefreshTableCardSpecExp();
            }
        }
        //Обновление строки
        private void UpdateCardSpecExp()
        {
            if (dgvCardSpecExp.CurrentRow == null) return;
            CardSpecExp cardSpecExp = dgvCardSpecExp.CurrentRow.DataBoundItem as v_CardSpecExp;
            if (cardSpecExp == null)
            {
                MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                return;
            }
            fmPersCardSpecExpEdit fmСardSpecExpEdit = new fmPersCardSpecExpEdit(EnumFormMode.Edit, "Зміна інтервалу", refSpecExps);
            fmСardSpecExpEdit.AddControlPeriod(cardSpecExps);
            fmСardSpecExpEdit.SetData(cardSpecExp);
            if (fmСardSpecExpEdit.ShowDialog() == DialogResult.OK)
            {
                cardSpecExp = fmСardSpecExpEdit.GetData();
                CardSpecExp findСardSpecExp = cardSpecExps.FirstOrDefault(rec => rec.CardSpecExp_Id == cardSpecExp.CardSpecExp_Id);
                if (findСardSpecExp == null)
                {
                    MessageBox.Show("Не знайдений рядок для оновлення", "Помилка");
                    return;
                }
                findСardSpecExp.CardSpecExp_PerBeg = cardSpecExp.CardSpecExp_PerBeg;
                findСardSpecExp.CardSpecExp_PerEnd = cardSpecExp.CardSpecExp_PerEnd;
                findСardSpecExp.CardSpecExp_RefSpecExp_Id = cardSpecExp.CardSpecExp_RefSpecExp_Id;
                RefreshTableCardSpecExp();
            }
        }
        //Физическое удаление строки
        private void DeleteCardSpecExp()
        {
            if (dgvCardSpecExp.CurrentRow == null) return;
            if (MessageBox.Show("Ви впевнені, що бажаєте видалити обраний рядок?", "Видалення", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            CardSpecExp cardSpecExp = dgvCardSpecExp.CurrentRow.DataBoundItem as v_CardSpecExp;
            if (cardSpecExp == null)
            {
                MessageBox.Show("Не знайдений рядок для видалення", "Помилка");
                return;
            }
            cardSpecExps.Remove(cardSpecExp);
            RefreshTableCardSpecExp();
        }
        //Инициализация грида "Статус"
        private void InitGridCardSpecExp()
        {
            dgvCardSpecExp.BaseGrigStyle();
            dgvCardSpecExp.ContextMenuStrip = contextMenuStrip;
            dgvCardSpecExp.AddRefreshMenu(RefreshMenuCardSpecExp);
        }
        //Перезачитать данные таблицы
        private void RefreshTableCardSpecExp()
        {
            BindingSource source = new BindingSource();
            source.DataSource = GetViewCardSpecExp(cardSpecExps);
            dgvCardSpecExp.DataSource = source;
            dgvCardSpecExp.Refresh();
        }
        private List<v_CardSpecExp> GetViewCardSpecExp(List<CardSpecExp> cardSpecExps)
        {
            List<v_CardSpecExp> res = (from cardSpecExp in cardSpecExps
                                       join specExp in refSpecExps on cardSpecExp.CardSpecExp_RefSpecExp_Id equals specExp.RefSpecExp_Id
                                       select new v_CardSpecExp
                                       {
                                           CardSpecExp_Id = cardSpecExp.CardSpecExp_Id,
                                           CardSpecExp_PerBeg = cardSpecExp.CardSpecExp_PerBeg,
                                           CardSpecExp_PerEnd = cardSpecExp.CardSpecExp_PerEnd,
                                           CardSpecExp_RefSpecExp_Id = cardSpecExp.CardSpecExp_RefSpecExp_Id,
                                           CardSpecExp_RefSpecExp_Nm = specExp.RefSpecExp_Name
                                      }).ToList();
            return res;
        }
        //Обновить меню
        private void RefreshMenuCardSpecExp()
        {
            bool isEnableMenu = dgvCardSpecExp.CurrentRow == null ? false : true;
            MenuItemCreate.Enabled = true;
            MenuItemEdit.Enabled = isEnableMenu;
            MenuItemDelete.Enabled = isEnableMenu;
        }
        //=============================================================================================================================
        //                                                      
        //=============================================================================================================================
        public fmPersCardEdit(EnumFormMode mode, string caption)
        {
            InitializeComponent();
            this.BaseFormStyle(caption);
            btnOk.Enabled = false;

            string error;
            refSpecExps = _repoSpecExp.GetAllSpecExps(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка отримання довідника спецстажів.\nТехнічна інформація: " + error, "Помилка");
                return;
            }

            InitGridChild();
            InitGridTaxRelief();
            InitGridCardStatus();
            InitGridDisability();
            InitGridCardSpecExp();

            tbLName.NecessaryField();
            tbFName.NecessaryField();
            tbDOB.NecessaryField();
            tbDOR.NecessaryField();
            tbTIN.NecessaryField();
            
            tbTIN.AddNumericField();
            tbExp.AddNumericField();
            tbGrade.AddNumericField();
            
            tbDOB.AddDateField('.');
            tbDOR.AddDateField('.');
            tbDOD.AddDateField('.');
            tbDOP.AddDateField('.');
        }

        private bool CanSaveCard()
        {
            if(tbLName.Text == string.Empty)
            {
                tabPersCard.SelectedIndex = 0;
                tbLName.Focus();
                return false;
            }
            
            if (tbFName.Text == string.Empty)
            {
                tabPersCard.SelectedIndex = 0;
                tbFName.Focus();
                return false;
            }
            
            if (tbDOB.Text == string.Empty)
            {
                tabPersCard.SelectedIndex = 0;
                tbDOB.Focus();
                return false;
            }
            
            if (tbDOR.Text == string.Empty)
            {
                tabPersCard.SelectedIndex = 0;
                tbDOR.Focus();
                return false;
            }
            
            if (tbTIN.Text == string.Empty)
            {
                tabPersCard.SelectedIndex = 0;
                tbDOR.Focus();
                return false;
            }

            return true;
        }
        private void fmPersCardEdit_Load(object sender, EventArgs e)
        {
            
            RefreshTableChild();
            RefreshTableTaxRelief();
            RefreshTableCardStatus();
            RefreshTableDisability();
            RefreshTableCardSpecExp();
            
            tbFName.IsModifyField(() => { btnOk.Enabled = true;});
            tbMName.IsModifyField(() => { btnOk.Enabled = true;});
            tbLName.IsModifyField(() => { btnOk.Enabled = true; });
            tbTIN.IsModifyField(() => { btnOk.Enabled = true;});
            tbExp.IsModifyField(() => { btnOk.Enabled = true; });
            tbGrade.IsModifyField(() => { btnOk.Enabled = true; });
            tbDOB.IsModifyField(() => { btnOk.Enabled = true;});
            tbDOR.IsModifyField(() => { btnOk.Enabled = true;});
            tbDOD.IsModifyField(() => { btnOk.Enabled = true; });
            tbDOP.IsModifyField(() => { btnOk.Enabled = true; });
            dgvChild.IsModifyField(() => { btnOk.Enabled = true; });
            dgvTaxRelief.IsModifyField(() => { btnOk.Enabled = true; });
            dgvCardStatus.IsModifyField(() => { btnOk.Enabled = true; });
            dgvDisability.IsModifyField(() => { btnOk.Enabled = true; });
            dgvCardSpecExp.IsModifyField(() => { btnOk.Enabled = true; });
            rbMale.IsModifyField(() => { btnOk.Enabled = true; });
            rbFemale.IsModifyField(() => { btnOk.Enabled = true; });
        }

        public void SetData(PersCard card)
        {
            if (card == null) return;
            id = card.PersCard_Id;
            tbFName.Text = card.PersCard_FName;
            tbMName.Text = card.PersCard_MName;
            tbLName.Text = card.PersCard_LName;
            tbTIN.Text = card.PersCard_TIN;
            if (card.PersCard_Exp != 0)
                tbExp.Text = card.PersCard_Exp.ToString();
            if (card.PersCard_Grade != 0)
                tbGrade.Text = card.PersCard_Grade.ToString();
            if (card.PersCard_DOB != DateTime.MinValue)
                tbDOB.Text = card.PersCard_DOB.ToShortDateString();
            if (card.PersCard_DOR != DateTime.MinValue)
                tbDOR.Text = card.PersCard_DOR.ToShortDateString();
            if (card.PersCard_DOD != DateTime.MinValue)
                tbDOD.Text = card.PersCard_DOD.ToShortDateString();
            if (card.PersCard_DOP != DateTime.MinValue)
                tbDOP.Text = card.PersCard_DOP.ToShortDateString();
            if (card.PersCard_Sex == (int)Sex.Female)
                rbFemale.Checked = true;
            else
                rbMale.Checked = true;
        }

        public PersCard GetData()
        {
            PersCard card = new PersCard();
            card.PersCard_Id = id;
            card.PersCard_FName = tbFName.Text;
            card.PersCard_MName = tbMName.Text;
            card.PersCard_LName = tbLName.Text;
            card.PersCard_TIN = tbTIN.Text;
            int exp = 0;
            int.TryParse(tbExp.Text, out exp);
            card.PersCard_Exp = exp;

            int grade = 0;
            int.TryParse(tbGrade.Text, out grade);
            card.PersCard_Grade = grade;

            DateTime dob;
            DateTime.TryParse(tbDOB.Text, out dob);
            card.PersCard_DOB = dob;

            DateTime dor;
            DateTime.TryParse(tbDOR.Text, out dor);
            card.PersCard_DOR = dor;

            DateTime dod;
            DateTime.TryParse(tbDOD.Text, out dod);
            card.PersCard_DOD = dod;

            DateTime dop;
            DateTime.TryParse(tbDOP.Text, out dop);
            card.PersCard_DOP = dop;
            if (rbFemale.Checked)
                card.PersCard_Sex = (int)Sex.Female;
            else
                card.PersCard_Sex = (int)Sex.Male;
            return card;
        }
        
        public void SetChildren(List<Child> children)
        {
            childs = children;
        }
        public List<Child> GetChildren()
        {
            return childs;
        }
        public void SetTaxRelief(List<TaxRelief> taxReliefs)
        {
            this.taxReliefs = taxReliefs;
        }
        public List<TaxRelief> GetTaxRelief()
        {
            return taxReliefs;
        }
        public void SetCardStatus(List<CardStatus> cardStatuses)
        {
            this.cardStatuses = cardStatuses;
        }
        public List<CardStatus> GetCardStatus()
        {
            return cardStatuses;
        }
        public void SetDisability(List<Disability> disabilities)
        {
            this.disabilities = disabilities;
        }
        public List<Disability> GetDisability()
        {
            return disabilities;
        }
        public void SetCardSpecExp(List<CardSpecExp> cardSpecExps)
        {
            this.cardSpecExps = cardSpecExps;
        }
        public List<CardSpecExp> GetCardSpecExp()
        {
            return cardSpecExps;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CanSaveCard())
                return;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void tbTIN_Validating(object sender, CancelEventArgs e)
        {
            string error;
            tooltip.Hide(tbTIN);
            if (tbTIN.Text == string.Empty)
                return;
            
            if (!CheckTIN.CheckNumberTIN(tbTIN.Text, out error))
            {
                tbTIN.SetToolTipe(error);
                tbTIN.Focus();
                return;
            }
            
            if (persCards == null) //Кеширование
                persCards = _repository.GetAllCards(out error);
            
            int duplTin = persCards.Where(card => card.PersCard_TIN == tbTIN.Text && card.PersCard_Id != id).Count();
            
            if(duplTin > 0)
            {
                tbTIN.SetToolTipe("Картка з таким ІПН вже існує");
                tbTIN.Focus();
                return;
            }
            
            DateTime dtDOB = CheckTIN.GetDateOfBirth(tbTIN.Text, out error);
            if (error == string.Empty)
            {
                tbDOB.Text = dtDOB.ToShortDateString();
                tbDOB.Refresh();
            }
            Sex sex = CheckTIN.GetSex(tbTIN.Text, out error);
            if (error == string.Empty)
            {
                if (sex == Sex.Female)
                    rbFemale.Checked = true;
                else
                    rbMale.Checked = true;
            }
        }

        private void fmPersCardEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void MenuItemCreate_Click(object sender, EventArgs e)
        {
            if (dgvChild.Focus())
                InsertChild();
            else if (dgvTaxRelief.Focus())
                InsertTaxRelief();
            else if (dgvCardStatus.Focus())
                InsertCardStatus();
            else if (dgvDisability.Focus())
                InsertDisability();
            else if (dgvCardSpecExp.Focus())
                InsertCardSpecExp();
        }

        private void MenuItemEdit_Click(object sender, EventArgs e)
        {
            if (dgvChild.Focus())
                UpdateChild();
            else if (dgvTaxRelief.Focus())
                UpdateTaxRelief();
            else if (dgvCardStatus.Focus())
                UpdateCardStatus();
            else if (dgvDisability.Focus())
                UpdateDisability();
            else if (dgvCardSpecExp.Focus())
                UpdateCardSpecExp();
        }

        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            if (dgvChild.Focus())
                DeleteChild();
            else if (dgvTaxRelief.Focus())
                DeleteTaxRelief();
            else if (dgvCardStatus.Focus())
                DeleteCardStatus();
            else if (dgvDisability.Focus())
                DeleteDisability();
            else if (dgvCardSpecExp.Focus())
                DeleteCardSpecExp();
        }
    }
}
