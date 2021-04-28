using System;

namespace Entities
{
    public class UnionReportT2
    {
        public int UnionReportT2_Id { get; set; }
        // Ссылка на каталог
        public int UnionReportT2_CtId { get; set; }
        // Код ЕГРПОУ
        public string  UnionReportT2_USREOU { get; set; }
        // Тип
        public int UnionReportT2_Type { get; set; }
        // ИНН
        public string UnionReportT2_TIN { get; set; }
        // Фамилия
        public string UnionReportT2_LName { get; set; }
        // Имя
        public string UnionReportT2_FName { get; set; }
        // Отчество
        public string UnionReportT2_MName { get; set; }
        // Сумма начисленного дохода
        public decimal UnionReportT2_AccrIncSm { get; set; }
        // Сумма выплаченного дохода
        public decimal UnionReportT2_PaidIncSm { get; set; }
        // Сумма удержанного налога, начисленного
        public decimal UnionReportT2_AccrTaxSm { get; set; }
        // Сумма удержанного налога, перечисленного
        public decimal UnionReportT2_TransfTaxSm { get; set; }
        // Признак дохода
        public int UnionReportT2_IncFlg { get; set; }
        // Дата поступления(date of receipt)
        public DateTime UnionReportT2_DOR { get; set; }
        // Дата увольнения(date of dismissal)
        public DateTime UnionReportT2_DOD { get; set; }
        // Признак соц.льготы
        public int UnionReportT2_SocBenefitFlg { get; set; }
        //Сумма военного сбора, начисленного
        public decimal  UnionReportT2_AccrWarTaxSm { get; set; }
        // Сумма военного сбора, перечисленного
        public decimal UnionReportT2_TransWarTaxSm { get; set; }             
    }
}
