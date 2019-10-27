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
using BLL;
using DAL;
using Entities;
using EnumType;
using WinFormExtensions;

namespace WinUI.WinForms
{
    public partial class fmSetup : Form
    {
        private Dictionary<object, string> dictMod = new Dictionary<object, string>();
        private bool isNeedSave()
        {
            if (dictMod[txbSqlPath] != txbSqlPath.Text)
                return true;
            if (dictMod[txbDbfPath] != txbDbfPath.Text)
                return true;
            if (dictMod[cbConvertCp1252To866] != cbConvertCp1252To866.Checked.ToString())
                return true;
            if (dictMod[txbYear] != txbYear.Text)
                return true;
            if (dictMod[tbCmpNm] != tbCmpNm.Text)
                return true;
            if (dictMod[tbCmpUSREOU] != tbCmpUSREOU.Text)
                return true;
            return false;
        }
        private void LoadSetupParam()
        {
            txbSqlPath.Text = SetupProgram.PathToSQLFile;
            txbDbfPath.Text = SetupProgram.PathToDBFFile;
            cbConvertCp1252To866.Checked = SetupProgram.IsNeedConvertCp1252To866;
            txbYear.Text = SetupProgram.YearSalary.ToString();
            tbCmpNm.Text = SetupProgram.CmpNm;
            tbCmpUSREOU.Text = SetupProgram.CmpUSREOU;
        }
        //Сохранение настройки указанного типа
        private bool SaveSetup(SetupAppRepository repository, SetupApp AddModifySetup, out string error)
        {
            error = string.Empty;
            SetupApp setup = repository.GetSetupById(AddModifySetup.SetupApp_Type, out error);
            if (error != string.Empty)
            {
                return false;
            }
            if (setup != null)
            {
                setup.SetupApp_ValueDigit = AddModifySetup.SetupApp_ValueDigit;
                setup.SetupApp_ValueString = AddModifySetup.SetupApp_ValueString;
                if (!repository.ModifySetupApp(setup, out error))
                {
                    return false;
                }
            }
            else
            {
                setup = new SetupApp();
                setup.SetupApp_Type = AddModifySetup.SetupApp_Type;
                setup.SetupApp_ValueDigit = AddModifySetup.SetupApp_ValueDigit;
                setup.SetupApp_ValueString = AddModifySetup.SetupApp_ValueString;
                if (!repository.AddSetupApp(setup, out error))
                {
                    return false;
                }

            }
            return true;
        }
        private void SaveSetupsApp()
        {
            SetupProgram.PathToSQLFile = txbSqlPath.Text;
            SetupProgram.PathToDBFFile = txbDbfPath.Text;
            SetupProgram.IsNeedConvertCp1252To866 = cbConvertCp1252To866.Checked;
            SetupProgram.YearSalary = int.Parse(txbYear.Text);
            SetupProgram.CmpUSREOU= tbCmpUSREOU.Text;
            SetupProgram.CmpNm = tbCmpNm.Text;

            string error;
            SetupAppRepository repository = new SetupAppRepository(SetupProgram.Connection);
            //Сохранение настройки "Путь к dbf файлу"
            if (dictMod[txbSqlPath] != txbSqlPath.Text)
            {
                SetupApp dbfSetup = new SetupApp
                {
                    SetupApp_Type = (int)SetupAppType.PathToDBFFile,
                    SetupApp_ValueDigit = 0,
                    SetupApp_ValueString = SetupProgram.PathToDBFFile
                };
                if (!SaveSetup(repository, dbfSetup, out error))
                {
                    MessageBox.Show("Помилка збереження налаштування 'Шлях до dbf файлів'.\nТехнічна інформація: " + error, "Помилка");
                    return;

                }
            }
            //Сохранение настройки "Путь к sql файлу"
            if (dictMod[txbSqlPath] != txbSqlPath.Text)
            {
                SetupApp sqlSetup = new SetupApp
                {
                    SetupApp_Type = (int)SetupAppType.PathToSQLFile,
                    SetupApp_ValueDigit = 0,
                    SetupApp_ValueString = SetupProgram.PathToSQLFile
                };
                if (!SaveSetup(repository, sqlSetup, out error))
                {
                    MessageBox.Show("Помилка збереження налаштування 'Шлях до sql файлів'.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
            }
            //Сохранение настройки "Конвертация текста (cp1252 -> cp866)"
            if (dictMod[cbConvertCp1252To866] != cbConvertCp1252To866.Checked.ToString())
            {
                SetupApp ConvertCpSetup = new SetupApp
                {
                    SetupApp_Type = (int)SetupAppType.ConvertCp1252To866,
                    SetupApp_ValueDigit = SetupProgram.IsNeedConvertCp1252To866 ? 1 : 0,
                    SetupApp_ValueString = string.Empty
                };
                if (!SaveSetup(repository, ConvertCpSetup, out error))
                {
                    MessageBox.Show("Помилка збереження налаштування 'Конвертація тексту (cp1252 -> cp866)'.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
            }
            //Сохранение настройки "Кількість років відображення РЛ"
            if (dictMod[txbYear] != txbYear.Text)
            {
                SetupApp ConvertCpSetup = new SetupApp
                {
                    SetupApp_Type = (int)SetupAppType.YearSalary,
                    SetupApp_ValueDigit = SetupProgram.YearSalary,
                    SetupApp_ValueString = string.Empty
                };
                if (!SaveSetup(repository, ConvertCpSetup, out error))
                {
                    MessageBox.Show("Помилка збереження налаштування 'Кількість років відображення РЛ'.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
            }
            //Сохранение настройки "ЕГРПОУ предприятия"
            if (dictMod[tbCmpUSREOU] != tbCmpUSREOU.Text)
            {
                SetupApp cmpUSREOU = new SetupApp
                {
                    SetupApp_Type = (int)SetupAppType.CmpUSREOU,
                    SetupApp_ValueDigit = 0,
                    SetupApp_ValueString = SetupProgram.CmpUSREOU
                };
                if (!SaveSetup(repository, cmpUSREOU, out error))
                {
                    MessageBox.Show("Помилка збереження налаштування 'ЄДРПОУ підприємства'.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
            }
            //Сохранение настройки "Название предприятия"
            if (dictMod[tbCmpNm] != tbCmpNm.Text)
            {
                SetupApp cmpNm = new SetupApp
                {
                    SetupApp_Type = (int)SetupAppType.CmpNm,
                    SetupApp_ValueDigit = 0,
                    SetupApp_ValueString = SetupProgram.CmpNm
                };
                if (!SaveSetup(repository, cmpNm, out error))
                {
                    MessageBox.Show("Помилка збереження налаштування 'Назва підприємства'.\nТехнічна інформація: " + error, "Помилка");
                    return;
                }
            }
        }   

        public fmSetup(Form owner)
        {
            InitializeComponent();
            this.SingleFormMode(owner);
            this.BaseFormStyle("Налаштування");
        }

        private void fmSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(isNeedSave())
            {
                if (MessageBox.Show("Зберігти внесені зміни?", "Збереження", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveSetupsApp();
            }
        }
        private void fmSetup_Load(object sender, EventArgs e)
        {
            txbYear.AddNumericField();

            //tabControlSetup.SetLeftTabs(20, 120);

            btnChooseDbf.AddOpenFileDialog(txbDbfPath);
            btnChooseSql.AddOpenFileDialog(txbSqlPath);

            LoadSetupParam();

            dictMod.Add(txbDbfPath, txbDbfPath.Text);
            dictMod.Add(txbSqlPath, txbSqlPath.Text);
            dictMod.Add(cbConvertCp1252To866, cbConvertCp1252To866.Checked.ToString());
            dictMod.Add(txbYear, txbYear.Text);
            dictMod.Add(tbCmpUSREOU, tbCmpUSREOU.Text);
            dictMod.Add(tbCmpNm, tbCmpNm.Text);
        }

        private void fmSetup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void tabControlSetup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
