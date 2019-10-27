using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using EnumType;

namespace BLL
{
    public static class SalaryHelper
    {
        /// <summary>
        /// Получить наименование месяца по индексу
        /// </summary>
        /// <param name="index">Yомер месяца</param>
        /// <returns>Наименование месяца </returns>
        public static string GetMonthNameById(int index, EnumCaseWorld caseWorld)
        {
            string name = string.Empty;
            switch(index)
            {
                case 1:
                    if(caseWorld == EnumCaseWorld.Nominative)
                        name = "Січень";
                    else if (caseWorld == EnumCaseWorld.Genetive)
                        name = "Січня";
                    else if (caseWorld == EnumCaseWorld.Dative)
                        name = "Січню";
                    else if (caseWorld == EnumCaseWorld.Accusative)
                        name = "Січень";
                    else if (caseWorld == EnumCaseWorld.Instrumental)
                        name = "Січнем";
                    else if (caseWorld == EnumCaseWorld.Prepositional)
                        name = "Січню";
                    break;
                case 2:
                    if (caseWorld == EnumCaseWorld.Nominative)
                        name = "Лютий";
                    else if (caseWorld == EnumCaseWorld.Genetive)
                        name = "Лютого";
                    else if (caseWorld == EnumCaseWorld.Dative)
                        name = "Лютому";
                    else if (caseWorld == EnumCaseWorld.Accusative)
                        name = "Лютий";
                    else if (caseWorld == EnumCaseWorld.Instrumental)
                        name = "Лютим";
                    else if (caseWorld == EnumCaseWorld.Prepositional)
                        name = "Лютому";
                    break;
                case 3:
                    if (caseWorld == EnumCaseWorld.Nominative)
                        name = "Березень";
                    else if (caseWorld == EnumCaseWorld.Genetive)
                        name = "Березня";
                    else if (caseWorld == EnumCaseWorld.Dative)
                        name = "Березню";
                    else if (caseWorld == EnumCaseWorld.Accusative)
                        name = "Березень";
                    else if (caseWorld == EnumCaseWorld.Instrumental)
                        name = "Березнем";
                    else if (caseWorld == EnumCaseWorld.Prepositional)
                        name = "Березню";
                    break;
                case 4:
                    if (caseWorld == EnumCaseWorld.Nominative)
                        name = "Квітень";
                    else if (caseWorld == EnumCaseWorld.Genetive)
                        name = "Квітня";
                    else if (caseWorld == EnumCaseWorld.Dative)
                        name = "Квітню";
                    else if (caseWorld == EnumCaseWorld.Accusative)
                        name = "Квітень";
                    else if (caseWorld == EnumCaseWorld.Instrumental)
                        name = "Квітнем";
                    else if (caseWorld == EnumCaseWorld.Prepositional)
                        name = "Квітню";
                    break;
                case 5:
                    if (caseWorld == EnumCaseWorld.Nominative)
                        name = "Травень";
                    else if (caseWorld == EnumCaseWorld.Genetive)
                        name = "Травня";
                    else if (caseWorld == EnumCaseWorld.Dative)
                        name = "Травню";
                    else if (caseWorld == EnumCaseWorld.Accusative)
                        name = "Травень";
                    else if (caseWorld == EnumCaseWorld.Instrumental)
                        name = "Травнем";
                    else if (caseWorld == EnumCaseWorld.Prepositional)
                        name = "Травню";
                    break;
                case 6:
                    if (caseWorld == EnumCaseWorld.Nominative)
                        name = "Червень";
                    else if (caseWorld == EnumCaseWorld.Genetive)
                        name = "Червня";
                    else if (caseWorld == EnumCaseWorld.Dative)
                        name = "Червню";
                    else if (caseWorld == EnumCaseWorld.Accusative)
                        name = "Червень";
                    else if (caseWorld == EnumCaseWorld.Instrumental)
                        name = "Червнем";
                    else if (caseWorld == EnumCaseWorld.Prepositional)
                        name = "Червню";
                    break;
                case 7:
                    if (caseWorld == EnumCaseWorld.Nominative)
                        name = "Липень";
                    else if (caseWorld == EnumCaseWorld.Genetive)
                        name = "Липня";
                    else if (caseWorld == EnumCaseWorld.Dative)
                        name = "Липню";
                    else if (caseWorld == EnumCaseWorld.Accusative)
                        name = "Липень";
                    else if (caseWorld == EnumCaseWorld.Instrumental)
                        name = "Липнем";
                    else if (caseWorld == EnumCaseWorld.Prepositional)
                        name = "Липню";
                    break;
                case 8:
                    if (caseWorld == EnumCaseWorld.Nominative)
                        name = "Серпень";
                    else if (caseWorld == EnumCaseWorld.Genetive)
                        name = "Серпня";
                    else if (caseWorld == EnumCaseWorld.Dative)
                        name = "Серпню";
                    else if (caseWorld == EnumCaseWorld.Accusative)
                        name = "Серпень";
                    else if (caseWorld == EnumCaseWorld.Instrumental)
                        name = "Серпнем";
                    else if (caseWorld == EnumCaseWorld.Prepositional)
                        name = "Серпні";
                    break;
                case 9:
                    if (caseWorld == EnumCaseWorld.Nominative)
                        name = "Вересень";
                    else if (caseWorld == EnumCaseWorld.Genetive)
                        name = "Вересня";
                    else if (caseWorld == EnumCaseWorld.Dative)
                        name = "Вересню";
                    else if (caseWorld == EnumCaseWorld.Accusative)
                        name = "Вересень";
                    else if (caseWorld == EnumCaseWorld.Instrumental)
                        name = "Вереснем";
                    else if (caseWorld == EnumCaseWorld.Prepositional)
                        name = "Вересні";
                    break;
                case 10:
                    if (caseWorld == EnumCaseWorld.Nominative)
                        name = "Жовтень";
                    else if (caseWorld == EnumCaseWorld.Genetive)
                        name = "Жовтня";
                    else if (caseWorld == EnumCaseWorld.Dative)
                        name = "Жовтню";
                    else if (caseWorld == EnumCaseWorld.Accusative)
                        name = "Жовтень";
                    else if (caseWorld == EnumCaseWorld.Instrumental)
                        name = "Жовтнем";
                    else if (caseWorld == EnumCaseWorld.Prepositional)
                        name = "Жовтні";
                    break;
                case 11:
                    if (caseWorld == EnumCaseWorld.Nominative)
                        name = "Листопад";
                    else if (caseWorld == EnumCaseWorld.Genetive)
                        name = "Листопада";
                    else if (caseWorld == EnumCaseWorld.Dative)
                        name = "Листопаду";
                    else if (caseWorld == EnumCaseWorld.Accusative)
                        name = "Листопад";
                    else if (caseWorld == EnumCaseWorld.Instrumental)
                        name = "Листопадом";
                    else if (caseWorld == EnumCaseWorld.Prepositional)
                        name = "Листопаде";
                    break;
                case 12:
                    if (caseWorld == EnumCaseWorld.Nominative)
                        name = "Грудень";
                    else if (caseWorld == EnumCaseWorld.Genetive)
                        name = "Грудня";
                    else if (caseWorld == EnumCaseWorld.Dative)
                        name = "Грудню";
                    else if (caseWorld == EnumCaseWorld.Accusative)
                        name = "Грудень";
                    else if (caseWorld == EnumCaseWorld.Instrumental)
                        name = "Груднем";
                    else if (caseWorld == EnumCaseWorld.Prepositional)
                        name = "Грудні";
                    break;
            }
            return name;
        }

        /// <summary>
        /// Получить календарь в формате месяц-год
        /// </summary>
        /// <param name="yearStart">Год начала отчета</param>
        /// <param name="addRecordAllYear">Добавить строку год без месяца</param>
        /// <returns>Cписок месяц-год</returns>
        public static List<string> GetMonthNames(int yearStart, bool addRecordAllYear)
        {
            List<string> names = new List<string>();
            for (int year = yearStart; year <= DateTime.Today.Year; year++)
            {
                if(addRecordAllYear)
                {
                    names.Add("Рік " + year.ToString());
                }
                for (int month = 1; month <= 12; month++)
                {
                    if (year == DateTime.Today.Year && month > DateTime.Today.Month)
                        break;
                    names.Add(GetMonthNameById(month, EnumCaseWorld.Nominative) + " " + year.ToString());
                }
            }
            return names;
        }
        /// <summary>
        /// Получить год по индексу
        /// </summary>
        /// <param name="yearStart">Год начала отчета</param>
        /// <param name="index">Индекс</param>
        /// <param name="addAllYear">Добавить строку год без месяца</param>
        /// <returns>Год</returns>
        public static int GetYearByIndex(int yearStart, int index, bool addAllYear)
        {
            if(index < 0) return 0;
            int maxCntIndex = addAllYear == true ? 13 : 12;
            return yearStart + index / maxCntIndex;
        }
        /// <summary>
        /// Получить номер месяца по индексу
        /// Если addAllYear = true, то month = 0 это год (напр 2017 год) и month  в диапазоне (1, 12)
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <param name="addAllYear">Добавить строку год без месяца</param>
        /// <returns>Номер месяца</returns>
        public static int GetMonthByIndex(int index, bool addAllYear)
        {
            if (index < 0) return 0;
            int maxCntIndex = addAllYear == true ? 13 : 12;
            int month = index % maxCntIndex;
            if (addAllYear == false)
                month++;
            return month;
        }
        /// <summary>
        /// Получить индекс для комбика по дате
        /// </summary>
        /// <param name="yearStart">Год начала отсчета</param>
        /// <param name="date">Дата для которой определяется индекса</param>
        /// <param name="addAllYear">Добавить строку год без месяца</param>
        /// <returns>Индекс для комбика</returns>
        public static int GetIndexByDate(int yearStart, DateTime date, bool addAllYear)
        {
            if (date == DateTime.MinValue) return 0;
            if (yearStart > date.Year) return 0;
            int maxCntIndex = addAllYear == true ? 13 : 12;

            return (date.Year - yearStart) * maxCntIndex + date.Month - 1;
        }
        /// <summary>
        /// Получить дату из комбика по индексу
        /// </summary>
        /// <param name="index">Индекс комбика</param>
        /// <param name="yearStart">Год отсчета</param>
        /// <param name="addAllYear">Добавить строку год без месяца</param>
        /// <returns></returns>
        public static DateTime GetDateByIndex(int index, int yearStart, bool addAllYear)
        {
            if (index < 0) return DateTime.MinValue;
            int maxCntIndex = addAllYear == true ? 13 : 12;
            int year = yearStart + index / maxCntIndex;
            int month = index % maxCntIndex;
            if (addAllYear == false)
                month++;
            return DateTime.MinValue.AddYears(year - 1).AddMonths(month - 1);
        }

        ///<summary>
        ///Является ли пенсионером
        ///</summary>
        ///<returns>
        ///true - пенсионер
        /// </returns>
        ///<param name="calcDate">Дата на которую производится расчет</param>
        ///<param name="dop">Дата выхода на пенсию</param>
        public static bool IsPensWorker(DateTime calcDate, DateTime dop)
        {
            if (dop == DateTime.MinValue)
                return false;

            return dop <= calcDate ? true : false;
        }
        /// <summary>
        /// Получить сумму согласно КТУ
        /// </summary>
        /// <param name="ktu">КТУ</param>
        /// <param name="baseSm">Основная зарплата</param>
        /// <param name="allwncTotalSm">Общая сумма доплат</param>
        /// <param name="allwncTotalPct">Общая процент доплат</param>
        /// <param name="infoCalc">Результат расчета</param>
        /// <returns>Сумма КТУ</returns>
        public static double GetKTUSm(double ktu, double baseSm, double allwncTotalSm, double allwncTotalPct, ref StringBuilder infoCalc)
        {
            infoCalc.Clear();
            infoCalc.AppendLine("ПОЧАТКОВІ ДАНІ");
            infoCalc.AppendFormat("  Основна зарплата: {0} грн.\n", baseSm);
            infoCalc.AppendFormat("  Загальна сума доплат: {0} грн.\n", allwncTotalSm);
            infoCalc.AppendFormat("  Загальний відсоток доплат: {0}%\n", allwncTotalPct);
            infoCalc.AppendFormat("  КТУ: {0} \n", ktu);
            infoCalc.AppendLine("РОЗРАХУНОК");
            if (ktu == 1 || ktu == 0)
            {
                infoCalc.AppendLine("  Сума згідно з КТУ: 0.00 грн.\n");
                return 0;
            }
            if (ktu > 1)
            {
                double ktuSm = Math.Round((baseSm + allwncTotalSm) * (ktu - 1), 2);
                infoCalc.AppendFormat("  Сума згідно з КТУ: {0} грн.\n", ktuSm);
                infoCalc.AppendFormat("    - ({0} + {1}) * ({2} - 1)\n", baseSm, allwncTotalSm, ktu);
                return ktuSm;
            }
            if (ktu < 1)
            {
                double ktuPct = (1 - ktu) * 100.00;
                infoCalc.AppendFormat("  Відсоток КТУ: {0}\n", ktuPct);
                infoCalc.AppendFormat("    - (1 - {0}) * 100\n", ktu);
                if (ktuPct < allwncTotalPct)
                {
                    infoCalc.AppendFormat("  {0} < {1}\n", ktuPct, allwncTotalPct);
                    double ktuSm = Math.Round((-1 * (allwncTotalSm) * ktuPct / allwncTotalPct), 2);
                    infoCalc.AppendFormat("  Сума згідно з КТУ: {0} грн.\n", ktuSm);
                    infoCalc.AppendFormat("    - -1 * {0} * {1}/{2}\n", allwncTotalSm, ktuPct, allwncTotalPct);
                    return ktuSm;
                }
                else
                {
                    double ktuSm = -1 * allwncTotalSm;
                    infoCalc.AppendFormat("  {0} >= {1}\n", ktuPct, allwncTotalPct);
                    infoCalc.AppendFormat("  Сума згідно з КТУ: {0} грн.\n", ktuSm);
                    infoCalc.AppendFormat("    - -1 * {0}\n", ktuSm);
                    return ktuSm;
                }
            }
            return 0;
        }
        /// <summary>
        /// Полученние суммы процента от базовой суммы
        /// </summary>
        /// <param name="sm">Исходная сумма</param>
        /// <param name="pct">Процент</param>
        /// <returns>Сумма процента</returns>
        public static double GetSmByPct(double sm, double pct)
        {
            return Math.Round(pct * sm / 100.00, 2);
        }
        /// <summary>
        /// Полученние суммы доплати за стаж от базовой суммы
        /// </summary>
        /// <param name="baseSm">Основная зарплата</param>
        /// <param name="allwncSm">Сумма надбавок</param>
        /// <param name="pct">Процент</param>
        /// <param name="infoCalc">Результат расчета</param>
        /// <returns>Полученние суммы доплати за стаж</returns>
        public static double GetExpSmByPct(double baseSm, double allwncSm, double pct, ref StringBuilder infoCalc)
        {
            infoCalc.Clear();
            infoCalc.AppendLine("ПОЧАТКОВІ ДАНІ");
            infoCalc.AppendFormat("  Основна зарплата: {0} грн.\n", baseSm);
            infoCalc.AppendFormat("  Cума доплат: {0} грн.\n", allwncSm);
            infoCalc.AppendFormat("  Відсоток доплати за стаж: {0}%\n", pct);
            infoCalc.AppendLine("РОЗРАХУНОК");

            double resultSm = Math.Round((baseSm + allwncSm) * pct / 100.00, 2);
            infoCalc.AppendFormat("  Cума доплат за стаж: {0} грн.\n", resultSm);
            infoCalc.AppendFormat("    - ({0} + {1}) * {2}/100\n", baseSm, allwncSm, pct);
            return resultSm;
        }
        /// <summary>
        /// Получение итоговой суммы зарплаты
        /// </summary>
        /// <param name="ktu">КТУ</param>
        /// <param name="baseSm">Основная зарплата</param>
        /// <param name="allwncTotalSm">Общая сумма доплат</param>
        /// <param name="allwncTotalPct">Общая процент доплат</param>
        /// <param name="infoCalc">Результат расчета</param>
        /// <returns>Итоговая сумма</returns>
        public static double GetResultSmSalary(double ktu, double baseSm, double allwncTotalSm, double allwncTotalPct, ref StringBuilder infoCalc)
        {
            infoCalc.Clear();
            infoCalc.AppendLine("ПОЧАТКОВІ ДАНІ");
            infoCalc.AppendFormat("  Основна зарплата: {0} грн.\n", baseSm);
            infoCalc.AppendFormat("  Загальна сума доплат: {0} грн.\n", allwncTotalSm);
            infoCalc.AppendFormat("  Загальний відсоток доплат: {0} %\n", allwncTotalPct);
            infoCalc.AppendFormat("  КТУ: {0}\n", ktu);
            infoCalc.AppendLine("РОЗРАХУНОК");
            double resultSm = 0;
            if (ktu == 1 || ktu == 0)
            {
                resultSm = baseSm + allwncTotalSm;
                infoCalc.AppendFormat("  Всього: {0} грн.\n", resultSm);
                infoCalc.AppendFormat("    - {0} + {1}\n", baseSm, allwncTotalSm);
                return resultSm;
            }
            if (ktu > 1)
            {
                resultSm = Math.Round((baseSm + allwncTotalSm) * ktu, 2);
                infoCalc.AppendFormat("  Всього: {0} грн.\n", resultSm);
                infoCalc.AppendFormat("    - ({0} + {1}) * {2}\n", baseSm, allwncTotalSm, ktu);
                return resultSm;
            }
            if (ktu < 1)
            {
                double ktuPct = (1 - ktu) * 100.00;
                infoCalc.AppendFormat("  Відсоток КТУ: {0}%\n", ktuPct);
                infoCalc.AppendFormat("    - (1 - {0})* 100\n", ktu);
                if(ktuPct < allwncTotalPct)
                {
                    double ktuSm = Math.Round((allwncTotalSm * ktuPct / allwncTotalPct), 2);
                    resultSm = baseSm + allwncTotalSm - ktuSm;
                    infoCalc.AppendFormat("  {0} < {1}\n", ktuPct, allwncTotalPct);
                    infoCalc.AppendFormat("  Проміжна сума: {0} грн.\n", ktuSm);
                    infoCalc.AppendFormat("    - ({0} * {1})/{2}\n", allwncTotalSm, ktuPct, allwncTotalPct);
                    infoCalc.AppendFormat("  Всього: {0} грн.\n", resultSm);
                    infoCalc.AppendFormat("    - {0} + {1} - {2}\n", baseSm, allwncTotalSm, ktuSm);
                    return resultSm;
                }
                else
                {
                    resultSm = baseSm;
                    infoCalc.AppendFormat("  {0} >= {1}\n", ktuPct, allwncTotalPct);
                    infoCalc.AppendFormat("  Всього: {0} грн.\n", resultSm);
                    return resultSm;
                }
            }
            return 0;
        }

        /// <summary>
        /// Получение номера квартала по дате
        /// </summary>
        /// <param name="date">Дата</param>
        /// <returns>Квартал</returns>
        public static int GetQrtByDate(DateTime date)
        {
            int month = date.Month;
            if (month >= 1 && month < 4)
                return 1;
            if (month >=4  && month < 7)
                return 2;
            if (month >= 7 && month < 10)
                return 3;
            return 4;
        }
        /// <summary>
        /// Получение даты начала квартала по номеру
        /// </summary>
        /// <param name="qrt">Квартал</param>
        /// <param name="year">Год</param>
        /// <returns>Дата начала квартала</returns>
        public static DateTime GetDateByQrt(int qrt, int year)
        {
            if (year == 0)
                return DateTime.MinValue;
            if (qrt == 1)
                return new DateTime(year, 1, 1);
            if (qrt == 2)
                return new DateTime(year, 4, 1);
            if (qrt == 3)
                return new DateTime(year, 7, 1);
            if (qrt == 4)
                return new DateTime(year, 10, 1);
            return DateTime.MinValue;
        }
        /// <summary>
        /// Получить года в интервале
        /// </summary>
        /// <param name="yearStart">Год начала отсчета</param>
        /// <param name="yearStop">Год конец отсчета</param>
        /// <returns>Cписок годов</returns>
        public static List<int> GetYears(int yearStart, int yearStop)
        {
            List<int> years = new List<int>();
            for (int year = yearStart; year <= yearStop; year++)
            {
                years.Add(year);
            }
            return years;
        }
        public static string GetLastNameWithInit(string lastName, string middleName, string firstName)
        {
            int substrInit = 3;
            if (lastName == string.Empty)
                return string.Empty;
            string result = lastName;
            if (firstName == string.Empty)
                return result;
            result += " " + firstName.Substring(0, substrInit);
            if (middleName != string.Empty)
            {
                result += ". " + middleName.Substring(0, substrInit);
            }
            return result;
        }
    }
}
