using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumType;

namespace BLL
{
    public static class CheckTIN
    {
        public static bool CheckNumberTIN(string tin, out string error)
        {
            error = string.Empty;
            if (tin.Length != 10)
            {
                error = "Довжина ІПН повинна дорівнювати 10 символам";
                return false;
            }
            short[] koef = { 10, 5, 7, 9, 4, 6, 10, 5, 7 };
            //Контроль алфавита
            for (int i = 0; i < tin.Length; i++)
            {
                if (!char.IsDigit(tin[i]))
                {
                    error = "ІПН повинен складатися тільки з цифр";
                    return false;
                }
            }
            int sum = 0;
            for (int i = 0; i < tin.Length - 1; i++)
            {
                int digit;
                int.TryParse(tin[i].ToString(), out digit);
                sum += koef[i] * digit;
            }
            int checkSum = sum % 11 % 10;
            int tenDigit;
            int.TryParse(tin[9].ToString(), out tenDigit);
            if (checkSum != tenDigit)
            {
                error = "Не співпадає контрольна сума з контрольною цифрою";
                return false;
            }
            return true;
        }
        public static DateTime GetDateOfBirth(string tin, out string error)
        {
            error = string.Empty;
            DateTime dt = new DateTime(1899, 12, 31);
            string sDays = tin.Substring(0, 5);
            long days;
            if(!long.TryParse(sDays, out days))
            {
                error = "Не можливо перетворити string в int";
                return dt;
            }
            return dt.AddDays(days);
        }
        public static Sex GetSex(string tin, out string error)
        {
            error = string.Empty;
            int nineDigit;
            if(!int.TryParse(tin[8].ToString(), out nineDigit))
            {
                error = "Не можливо перетворити char в int";
                return Sex.Female;
            }
            if (nineDigit % 2 == 1)
                return Sex.Male;
            return Sex.Female;
        }

    }
}
