using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DFRec
    {
        public int DFRec_Id { get; set; }
        public int DFRec_DFCt_Id { get; set; }
        public int DFRec_Ord { get; set; } //Номер по порядку
        public string DFRec_USREOU { get; set; } //Код ЕГРПОУ
        public int DFRec_Type { get; set; } //Тип
        public string DFRec_FName { get; set; } //Имя
        public string DFRec_MName { get; set; } //Отчество
        public string DFRec_LName { get; set; } //Фамилия
        public string DFRec_TIN { get; set; } //ИНН
        public decimal DFRec_AccrIncSm { get; set; } //Сумма начисленного дохода
        public decimal DFRec_PaidIncSm { get; set; } //Сумма выплаченного дохода
        public decimal DFRec_TransfTaxSm { get; set; } //Сумма удержанного налога, перечисленного
        public decimal DFRec_AccrTaxSm { get; set; } //Сумма удержанного налога, начисленного
        public int DFRec_IncFlg { get; set; } //Признак дохода
        public DateTime DFRec_DOR { get; set; } //Дата поступления(date of receipt)
        public DateTime DFRec_DOD { get; set; } //Дата увольнения(date of dismissal)
        public int DFRec_SocBenefitFlg { get; set; } //Признак соц.льготы
        public int DFRec_Flg { get; set; } //Флаг
    }
}
