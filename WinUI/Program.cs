using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Configuration;
using System.IO;
using BLL;
using Entities;
using System.Reflection;
using WinUI.Helper;

namespace WinUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBServer sqlServer = new DBServer();
            string error;
            string connStringCoolbuh = ConfigurationManager.ConnectionStrings["CoolbuhContext"].ConnectionString;
            //Подключение к сетевому ресурсу
            if (connStringCoolbuh.IndexOf("LocalDB") == -1)
            {
                //Подключаемся к мастер схеме, для проверки и создания базы сoolbuh 
                string connStringMaster = ConfigurationManager.ConnectionStrings["MasterContext"].ConnectionString;

                if (!sqlServer.ConnectToSqlDB(connStringMaster, out error))
                {
                    MessageBox.Show("Помилка підключення до СУБД 'Master'. \nТехнічна інформація: " + error, "Помилка");
                    return;
                }
                if (!InitSqlDB.CreateDBIfNotExists(sqlServer.GetConnectionSqlDb(), out error))
                {
                    MessageBox.Show("Помилка створення СУБД 'coolbuh'. \nТехнічна інформація: " + error, "Помилка");
                    sqlServer.DisconnectFromSqlDB(out error);
                    return;
                }
                sqlServer.DisconnectFromSqlDB(out error);
            }
            //Подключение к БД coolbuh
            if (!sqlServer.ConnectToSqlDB(connStringCoolbuh, out error))
            {
                MessageBox.Show("Помилка підключення до СУБД. \nТехнічна інформація: " + error, "Помилка");
                return;
            }
            //Проверка первичного запуска программы
            bool isFirstStart = InitSqlDB.IsExistsTableSetup(sqlServer.GetConnectionSqlDb(), out error);
            if(error != string.Empty)
            {
                MessageBox.Show("Помилка визначення первинного запуску програми.\nТехнічна інформація: " + error, "Помилка");
                return;
            }
            if(isFirstStart)
            {
                Service.UpdateServerObject(sqlServer.GetConnectionSqlDb());
            }
            //Инициализация настроек
            SetupAppRepository setupAppRepository = new SetupAppRepository(sqlServer.GetConnectionSqlDb());
            List<SetupApp> setups = setupAppRepository.GetAllSetups(out error);
            if (error != string.Empty)
            {
                MessageBox.Show("Помилка зачитування налаштувань програми. \nТехнічна інформація: " + error, "Помилка");
                return;
            }
            SetupProgram.InitSetups(setups);
            SetupProgram.Connection = sqlServer.GetConnectionSqlDb();
            //Запуск главной формы
            Application.Run(new fmMainForm());

            sqlServer.DisconnectFromSqlDB(out error);
        }
    }
}
