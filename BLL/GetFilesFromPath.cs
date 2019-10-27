using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BLL
{
    //Получить файлы по указанному пути
    public static class GetFilesFromPath 
    {
        //Получить все именя DBF файлов по указанному пути
        public static bool GetNamesDbfFile(string path, out List<string> files, out string errors)
        {
            return GetFiles(path, "*.dbf", out files, out errors);
        }

        //Получить все имена SQL файлов по указанному пути
        public static bool GetNamesSqlFile(string path, out List<string> files, out string errors)
        {
            return GetFiles(path, "*.sql", out files, out errors);
        }

        //Удалить расширение из наименования файла
        private static string GetFileWithoutExt(string fileName)
        {
            char ch = '.';
            fileName.LastIndexOf(ch);
            return fileName.Substring(0, fileName.LastIndexOf(ch));
        }

        private static bool GetFiles(string path, string ext, out List<string> files, out string errors)
        {
            files = new List<string>();
            errors = string.Empty;

            if (path == String.Empty)
            {
                errors = "Не вказаний путь";
                return false;
            }
            if (!Directory.Exists(path))
            {
                errors = "Не існує директорії";
                return false;
            }

            try
            {
                string[] dirs = Directory.GetFiles(path, ext);
                foreach (string dir in dirs)
                {
                    files.Add(GetFileWithoutExt(Path.GetFileName(dir)));
                }
                return true;
            }
            catch (Exception error)
            {
                errors = error.Message;
            }
            return false;
        }
    }
}
