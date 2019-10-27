using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

namespace WinFormExtensions
{
    public static class DataGridViewExtension
    {
        private static int countCallStorePosition { get; set; }
        private static int countCallStoreSort { get; set; }
        private static int posY { get; set; }
        private static int posX { get; set; }

        private static int sortIndex { get; set; }
        private static SortOrder sortOrder { get; set; }

        private static KeyPressEventHandler hDgvFindData;
        //Сохранить позицию курсора
        public static void StorePosition(this DataGridView dgv)
        {
            countCallStorePosition++;
            posY = dgv.CurrentCell != null ? dgv.CurrentCell.ColumnIndex : 0;
            posX = dgv.CurrentRow != null ? dgv.CurrentRow.Index : 0;
        }
        //Восстановить позицию курсора
        public static void RestPosition(this DataGridView dgv)
        {
            if(--countCallStorePosition > 0)
            {
                MessageBox.Show("Порушений баланс викликів методів StorePosition/RestPosition");
                return;
            }
            if (dgv.RowCount == 0)
                return;
            int restoreX = 0;
            int restoreY = 0;

            if (dgv.RowCount < posX)
                restoreX = dgv.RowCount - 1;

            if (posX < 0)
                restoreX = 0;
            else if (dgv.RowCount <= posX)
                restoreX = dgv.RowCount - 1;
            else
                restoreX = posX;

            if (posY < 0)
                restoreY = 0;
            else if (dgv.ColumnCount < posY)
                restoreY = dgv.ColumnCount - 1;
            else
                restoreY = posY;
            //Проверка на видимость колонки
            if (dgv.Columns[restoreY].Visible == false)
            {
                //поиск первого видимого столбца
                for (int col = 0; col < dgv.ColumnCount; col++)
                {
                    if (dgv.Columns[col].Visible)
                    {
                        restoreY = col;
                        break;
                    }
                }
            }

            dgv.CurrentCell = dgv.Rows[restoreX].Cells[restoreY];
        }
        //Сохранить сортировку
        public static void StoreSort(this DataGridView dgv)
        {
            countCallStoreSort++;
            sortIndex = 0;
            sortOrder = SortOrder.None;
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                SortOrder order = dgv.Columns[i].HeaderCell.SortGlyphDirection;
                if (order != SortOrder.None)
                {
                    sortIndex = i;
                    sortOrder = order;
                    break;
                }
            }
        }
        //Сохранить сортировку
        public static void RestSort<T>(this DataGridView dgv)
        {
            if (--countCallStoreSort > 0)
            {
                MessageBox.Show("Порушений баланс викликів методів StorePosition/RestPosition");
                return;
            }
            if (sortOrder != SortOrder.None)
            {
                List<T> listData = GetListFromDataSource<T>(dgv);
                if (listData == null)
                    return;

                string strColumnName = dgv.Columns[sortIndex].Name;
                PropertyInfo property = typeof(T).GetProperty(strColumnName); 
                if (property == null)
                    return;

                listData = SortList(listData, property, sortOrder);
                SetListToDataSource(dgv, listData);
                dgv.Columns[sortIndex].HeaderCell.SortGlyphDirection = sortOrder;
            }
        }

        //Получить индекс колонки по наименованию
        public static int GetIndexIdGrid(this DataGridView dgv, string id_name)
        {
            int index_id = -1;
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                if (dgv.Columns[i].Name == id_name)
                {
                    index_id = i;
                    return index_id;
                }
            }
            return index_id;
        }
        //Добавить сортировку по таблице
        public static void AddSortGrid(this DataGridView dgv, Action<DataGridViewCellMouseEventArgs> sort)
        {
            dgv.ColumnHeaderMouseClick += (object sender, DataGridViewCellMouseEventArgs e) =>
            {
                sort(e);
            };
        }
        public static SortOrder getSortOrder(this DataGridView dgv, int columnIndex)
        {
            bool isTextBoxClmn = dgv.Columns[columnIndex] is DataGridViewTextBoxColumn;

            if (dgv.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending || isTextBoxClmn == false)
            {
                dgv.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.None;
                return SortOrder.None;
            }
            else if (dgv.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.None)
            {
                dgv.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                return SortOrder.Ascending;
            }
            else if (dgv.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending)
            {
                dgv.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                return SortOrder.Descending;
            }
            return SortOrder.None;
        }

        private static List<T> GetListFromDataSource<T>(DataGridView dgv)
        {
            BindingSource bindingSource = dgv.DataSource as BindingSource;
            if (bindingSource == null)
            {
                return dgv.DataSource as List<T>;
            }
            return bindingSource.List as List<T>;
        }
        private static void SetListToDataSource<T>(DataGridView dgv, List<T> source)
        {
            BindingSource bindingSource = dgv.DataSource as BindingSource;
            if (bindingSource == null)
            {
                dgv.DataSource = source;
                return;
            }
            bindingSource.DataSource = source;
            dgv.DataSource = bindingSource;
        }

        private static List<T> SortList<T>(List<T> source, PropertyInfo property, SortOrder order)
        {
            if (order == SortOrder.Ascending || order == SortOrder.None)
            {
                return source.OrderBy(x => property.GetValue(x, null)).ToList();
            }
            return source.OrderByDescending(x => property.GetValue(x, null)).ToList();
        }
        //Универсальная сортировка
        public static void AddSortGrid<T>(this DataGridView dgv, string fieldSortDef)
        {
            dgv.ColumnHeaderMouseClick += (object sender, DataGridViewCellMouseEventArgs e) =>
            {
                List<T> listData = GetListFromDataSource<T>(dgv);
                if (listData == null) return;
 
                string strColumnName = dgv.Columns[e.ColumnIndex].Name;
                SortOrder strSortOrder = dgv.getSortOrder(e.ColumnIndex);

                PropertyInfo property = strSortOrder == SortOrder.None ? typeof(T).GetProperty(fieldSortDef) : property = typeof(T).GetProperty(strColumnName);
                if (property == null) return;
                
                listData = SortList(listData, property, strSortOrder);
                SetListToDataSource(dgv, listData);     
                dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
            };
        }

        //Добавить итоги по таблице (количество строк) 
        public static void AddStatusStripRow(this DataGridView dgv, StatusStrip statusStrip, bool showInfoSelRow)
        {
            statusStrip.Font = new Font(statusStrip.Font, FontStyle.Bold);

            ToolStripLabel infoCountRowLabel = new ToolStripLabel();
            statusStrip.Items.Add(infoCountRowLabel);
            ToolStripLabel infoSelCountRowLabel = new ToolStripLabel();
            statusStrip.Items.Add(infoSelCountRowLabel);
            infoCountRowLabel.Text = "Рядків: 0";
            if(showInfoSelRow)
                infoSelCountRowLabel.Text = "Відмічено: 0";

            dgv.DataSourceChanged += (object sender, EventArgs e) =>
            {
                infoCountRowLabel.Text = "Рядків: " + dgv.RowCount.ToString();
                if (showInfoSelRow)
                    infoSelCountRowLabel.Text = "Відмічено: 0";
            };
            if (showInfoSelRow)
            {
                dgv.MouseUp += (object sender, MouseEventArgs e) =>
                {
                    if (dgv.CurrentCell == null) return;
                    int index_bird = dgv.GetIndexIdGrid("Bird");
                    if (dgv.CurrentCell.ColumnIndex == index_bird)
                    {
                        int selRow = 0;
                        for (int i = 0; i < dgv.RowCount; i++)
                        {
                            if (dgv.Rows[i].Cells[index_bird].Value != null)
                            {
                                selRow++;
                            }
                        }
                        infoSelCountRowLabel.Text = "Відмічено: " + selRow.ToString();
                    }
                };
                dgv.KeyUp += (object sender, KeyEventArgs e) =>
                {
                    if (e.KeyCode == Keys.Space)
                    {
                        int index_bird = dgv.GetIndexIdGrid("Bird");
                        if (index_bird >= 0)
                        {
                            int selRow = 0;
                            for (int i = 0; i < dgv.RowCount; i++)
                            {
                                if (dgv.Rows[i].Cells[index_bird].Value != null)
                                {
                                    selRow++;
                                }
                            }
                            infoSelCountRowLabel.Text = "Відмічено: " + selRow.ToString();
                        }
                    }
                };
            }
        }
       
        //Обновление меню
        public static void AddRefreshMenu(this DataGridView dgv, Action refreshMenu)
        {
            //dgv.Paint += (object sender, PaintEventArgs e) =>
            //{
            //    refreshMenu();
            //};
            dgv.Click += (object sender, EventArgs e) =>
            {
                refreshMenu();
            };
        }
        //Добавление колонки "Птичка" в таблицу
        public static void AddBirdColumn(this DataGridView dgv, bool frozen = false)
        {
            DataGridViewCheckBoxColumn birdColumn = new DataGridViewCheckBoxColumn();
            birdColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            birdColumn.Name = "Bird";
            birdColumn.HeaderText = string.Empty;
            birdColumn.DisplayIndex = 0;
            birdColumn.ReadOnly = false;
            birdColumn.Frozen = frozen;
            birdColumn.FalseValue = false;
            birdColumn.TrueValue = true;
            dgv.Columns.Add(birdColumn);
            dgv.KeyDown += (object sender, KeyEventArgs e) =>
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (dgv.RowCount == 0) return;

                    int index_bird = dgv.GetIndexIdGrid("Bird");
                    if (index_bird >= 0)
                        dgv.CurrentRow.Cells[index_bird].Value = dgv.CurrentRow.Cells[index_bird].Value == null ? (object)true : null;
                }
            };
            dgv.Click += (object sender, EventArgs e) =>
            {
                if (dgv.CurrentCell == null) return;
                int index_bird = dgv.GetIndexIdGrid("Bird");
                if (dgv.CurrentCell.ColumnIndex == index_bird)
                {
                    dgv.CurrentRow.Cells[index_bird].Value = dgv.CurrentRow.Cells[index_bird].Value == null ? (object)true : null;
                }
            };
        }

        //Стандартная настройка стиля таблицы 
        public static void BaseGrigStyle(this DataGridView dgv, DataGridViewAutoSizeColumnsMode mode = DataGridViewAutoSizeColumnsMode.Fill)
        {
            dgv.MultiSelect = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AutoGenerateColumns = false;
            dgv.AutoSizeColumnsMode = mode;
            dgv.BackgroundColor = Color.White;
            dgv.ReadOnly = true;
            //dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.DefaultCellStyle.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dgv.DefaultCellStyle.SelectionForeColor = Color.DarkBlue;
            dgv.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
            dgv.ScrollBars = ScrollBars.Both;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgv.DoubleBuffered(true);

            //Отключаем возможность перехода по enter на другую строку в гриде
            dgv.KeyDown += (object sender, KeyEventArgs e) =>
            {
                e.SuppressKeyPress = e.KeyCode == Keys.Enter ? true : false;
            };
        }
        //Получить "отмеченные птичкой" строки
        public static List<T> GetCheckedRecords<T>(this DataGridView dgv)
            where T : class 
        {
            List<T> checkedBird = new List<T>();
            int index_bird = dgv.GetIndexIdGrid("Bird");
            if (index_bird == -1)
                return checkedBird;
            dgv.StorePosition();
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv.Rows[i].Cells[index_bird].Value != null)
                    checkedBird.Add(dgv.Rows[i].DataBoundItem as T);
            }
            dgv.RestPosition();
            return checkedBird;
        }
        //Установить "птички"
        //Должен быть переопределн метод Equals
        public static void SetCheckedRecords<T>(this DataGridView dgv, List<T> checkedBird)
            where T : class
        {
            if (checkedBird == null)
                return;
            if (checkedBird.Count == 0)
                return;
            int index_bird = dgv.GetIndexIdGrid("Bird");
            if (index_bird == -1)
                return ;

            dgv.StorePosition();
            foreach (T record in checkedBird)
            {
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    if(record.Equals(dgv.Rows[i].DataBoundItem))
                    {
                        dgv.Rows[i].Cells[index_bird].Value = (object)true;
                    }
                }
            }
            dgv.RestPosition();
        }
        //Двойная буферизация(для ускорения загрузки)
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
        //Проверка модификации таблицы
        public static void IsModifyField(this DataGridView dgv, Action isModify)
        {
            dgv.DataSourceChanged += (object sender, EventArgs e) =>
            {
                isModify();
            };
        }
        //Установить позицию курсора на заданную строку
        public static void SetPositionRow<T>(this DataGridView dgv, string columnFind, string valueFind)
        {
            List<T> listData = GetListFromDataSource<T>(dgv);
            if (listData == null)
                return;

            PropertyInfo property = typeof(T).GetProperty(columnFind);
            if (property == null)
                return;

            int posX = listData.FindIndex(x => property.GetValue(x, null).ToString() == valueFind);
            int posY = dgv.CurrentCell != null ? dgv.CurrentCell.ColumnIndex : 0;
            if (posX == -1)
                return;
            dgv.CurrentCell = dgv.Rows[posX].Cells[posY];
        }
        //Добавить универсальный поиск по гриду
        public static void AddSearchGrid(this DataGridView dgv)
        {
            hDgvFindData =  (object sender, KeyPressEventArgs e) => 
            {
                CreateSearchPanel(dgv, e.KeyChar);
            };
            dgv.KeyPress += hDgvFindData;
        }
        private static void FindTextInGridColumn(DataGridView dgv, TextBox textbox,  char keyChar)
        {
            string searchString = textbox.Text + keyChar;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv.Rows[i].Cells[dgv.CurrentCell.ColumnIndex].Value.ToString().StartsWith(searchString, StringComparison.OrdinalIgnoreCase))
                {
                    dgv.CurrentCell = dgv[dgv.CurrentCell.ColumnIndex, i];
                    return;
                }
            }
        }
        private static void CreateSearchPanel(DataGridView dgv, char keyChar)
        {
            if (dgv.CurrentCell == null)
                return;
            byte MARGIN = 0;

            if (char.IsDigit(keyChar) || char.IsLetter(keyChar))
            {
                dgv.KeyPress -= hDgvFindData;

                Panel pnlFind = new Panel();
                pnlFind.Name = "pnlSearch";
                pnlFind.Left = dgv.Left;
                pnlFind.Width = dgv.Width;
                pnlFind.Height = 50;
                pnlFind.Dock = DockStyle.Bottom;

                Button btnDestroy = new Button();
                btnDestroy.Name = "btnDestroy";
                btnDestroy.Text = "x";
                btnDestroy.Font = new Font(btnDestroy.Font, FontStyle.Bold);
                btnDestroy.Height = 20;
                btnDestroy.Width = 20;
                btnDestroy.Top = MARGIN;
                btnDestroy.Left = pnlFind.Width - btnDestroy.Width - MARGIN;
                btnDestroy.Click += (object sender, EventArgs e) => 
                {
                    if (dgv.Parent.Controls.Contains(pnlFind))
                    {
                        dgv.Parent.Controls.Remove(pnlFind);
                        dgv.KeyPress += hDgvFindData;
                        dgv.Focus();
                    }
                };
                pnlFind.Controls.Add(btnDestroy);

                Label lblFindCaption = new Label();
                lblFindCaption.Name = "lblFindCaption";
                lblFindCaption.Font = new Font(lblFindCaption.Font, FontStyle.Bold);
                lblFindCaption.Text = "Пошук по полю: " + dgv.Columns[dgv.CurrentCell.ColumnIndex].HeaderText;
                lblFindCaption.Top = MARGIN;
                lblFindCaption.Left = MARGIN;
                lblFindCaption.Width = pnlFind.Width - btnDestroy.Width - MARGIN;
                pnlFind.Controls.Add(lblFindCaption);

                TextBox textBox = new TextBox();
                textBox.Name = "tbSearch";
                textBox.Left = MARGIN;
                textBox.Top = MARGIN + lblFindCaption.Height;
                textBox.Width = pnlFind.Width - MARGIN;
                textBox.Text = keyChar.ToString();
                textBox.SelectionStart = textBox.Text.Length;
                //Первичный поиск при первом нажатии клавиши
                FindTextInGridColumn(dgv, textBox, keyChar);
                textBox.KeyPress += (object sender, KeyPressEventArgs e) =>
                {
                  FindTextInGridColumn(dgv, textBox, e.KeyChar);
                };
                textBox.LostFocus += (object sender, EventArgs e) => 
                {
                    if(dgv.Parent.Controls.Contains(pnlFind))
                    {
                        dgv.Parent.Controls.Remove(pnlFind);
                        dgv.KeyPress += hDgvFindData;
                        dgv.Focus();
                    }
                };
                pnlFind.Controls.Add(textBox);
                dgv.Parent.Controls.Add(pnlFind);
                textBox.Focus();
            }
        }
    }
}