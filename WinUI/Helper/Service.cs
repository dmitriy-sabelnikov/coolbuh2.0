using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace WinUI.Helper
{
    public static class Service
    {
        public static bool RunSqlSript(string pathToSqlFile, SqlConnection conn)
        {
            if (pathToSqlFile == string.Empty)
            {
                MessageBox.Show("Не вказаний путь до файлів ");
                return false;
            }
            //Выполнение скриптов заливки в установленные таблицы
            Coffee.Init("Виконання sql скриптів...");
            List<string> sqlFiles;
            string error;
            if (!GetFilesFromPath.GetNamesSqlFile(pathToSqlFile, out sqlFiles, out error))
            {
                MessageBox.Show("Помилка отримання sql файлів.\nТехнічна інформація: " + error, "Помилка");
                Coffee.Term();
                return false;
            }
            if (sqlFiles.Count == 0)
            {
                Coffee.Term();
                return false;
            }
            SqlSript sqlSript = new SqlSript(conn);
            foreach (string file in sqlFiles)
            {
                Coffee.Refresh("Виконання sql скриптів..." + file + ".sql");
                if (!sqlSript.RunScript(SetupProgram.PathToSQLFile + "\\" + file + ".sql", out error))
                {
                    MessageBox.Show("Помилка виконання sql скрипта " + file + ".\nТехнічна інформація: " + error, "Помилка");
                }
            }
            Coffee.Term();
            return true;
        }
        public static bool ImportDB(string pathToDbfFile, SqlConnection conn)
        {
            if (pathToDbfFile == string.Empty)
            {
                MessageBox.Show("Не вказаний путь до файлів ");
                return false;
            }
            Coffee.Init("Імпорт бази даних ...");
            // Получение Dbf файлов
            string error;
            List<string> dbfFiles;
            if (!GetFilesFromPath.GetNamesDbfFile(pathToDbfFile, out dbfFiles, out error))
            {
                MessageBox.Show("Помилка отримання dbf файлів.\nТехнічна інформація: " + error, "Помилка");
                Coffee.Term();
                return false;
            }
            if(dbfFiles.Count == 0)
            {
                Coffee.Term();
                return true;
            }
            //Подключение к OleDB серверу
            DBServer oleDbServer = new DBServer();
            StringBuilder connectionString = new StringBuilder(
            @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + SetupProgram.PathToDBFFile + ";Extended Properties=dBase III");
            if (!oleDbServer.ConnectToOleDB(connectionString.ToString(), out error))
            {
                MessageBox.Show("Помилка підключення до OleDB.\nТехнічна інформація: " + error, "Помилка");
                Coffee.Term();
                return false;
            }
            //Импорт
            string prefix = "imp_"; //Добавим префикс для различия импортированных таблиц от стандартных  
            ConvertDbfToSql convertDB = new ConvertDbfToSql(conn, oleDbServer.GetConnectionOleDb(), SetupProgram.IsNeedConvertCp1252To866, prefix);
            foreach (string file in dbfFiles)
            {
                Coffee.Refresh("Імпорт бази даних ..." + file + ".dbf");
                if (!convertDB.ConvertDBFToSQL(file, out error))
                {
                    MessageBox.Show("Помилка конвертації dbf файла " + file + ".\nТехнічна інформація: " + error, "Помилка");
                }
            }
            oleDbServer.DisconnectFromOleDB(out error);
            Coffee.Term();
            return true;
        }
        public static bool UpdateServerObject(SqlConnection conn)
        {
            //Получим директорию к папке с обновлениями
            string pathToSql = "\\SQL"; 
            StringBuilder currentDir = new StringBuilder(Directory.GetCurrentDirectory());
            int startIndex = currentDir.ToString().IndexOf("\\WinUI");
            if(startIndex >= 0)
            {
                currentDir.Remove(startIndex, currentDir.Length - startIndex);
            }
            currentDir.Append(pathToSql);
            //Проверка существования директории
            string currentDirToUpdate = currentDir.ToString();
            if (!Directory.Exists(currentDirToUpdate))
            {
                MessageBox.Show("Не вдалося знайти папку з оновленнями.\nТехнічна інформація: діректорії " + currentDirToUpdate + "не існує", "Помилка");
                return false;
            }
            //Получение всех sql скриптов по указанному пути currentDirToUpdate
            List<string> sqlFiles;
            string error;
            if (!GetFilesFromPath.GetNamesSqlFile(currentDirToUpdate, out sqlFiles, out error))
            {
                MessageBox.Show("Помилка отримання sql файлів.\nТехнічна інформація: " + error, "Помилка");
                return false;
            }
            //В папке обновлений пусто
            if (sqlFiles.Count == 0)
            {
                return false;
            }
            Coffee.Init("Виконання sql скриптів...");
            bool bRet = true;
            SqlSript sqlSript = new SqlSript(conn);
            foreach (string file in sqlFiles)
            {
                Coffee.Refresh("Виконання sql скриптів..." + file + ".sql");
                if (!sqlSript.RunScript(currentDirToUpdate + "\\" + file + ".sql", out error))
                {
                    MessageBox.Show("Помилка виконання sql скрипта " + file + ".\nТехнічна інформація: " + error, "Помилка");
                    bRet = false;
                }
            }
            Coffee.Term();
            return bRet;
        }
    }
}
