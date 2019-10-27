using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumType;

namespace BLL
{
    public class CardStatusHelper
    {
        public static string GetStatusName(int cd)
        {
            switch (cd)
            {
                case (int)EnumCardStatus.Constant:
                    return "Постійний";
                case (int)EnumCardStatus.Temporary:
                    return "Тимчасовий";
                case (int)EnumCardStatus.Associative:
                    return "Асоціативний";
            }
            return "Не визначений";
        }
    }
}
