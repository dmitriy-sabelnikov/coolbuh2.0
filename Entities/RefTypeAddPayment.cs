using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RefTypeAddPayment : IEquatable<RefTypeAddPayment>
    {
        public int RefTypeAddPayment_Id { get; set; }
        public string RefTypeAddPayment_Cd { get; set; }
        public string RefTypeAddPayment_Nm { get; set; }
        // Реализация интерфейса IEquatable<T>
        public bool Equals(RefTypeAddPayment other)
        {
            return
                this.RefTypeAddPayment_Id == other.RefTypeAddPayment_Id &&
                this.RefTypeAddPayment_Cd == other.RefTypeAddPayment_Cd &&
                this.RefTypeAddPayment_Nm == other.RefTypeAddPayment_Nm;
        }

        public override bool Equals(object obj)
        {
            // Сравнение с null всегда возвращает false
            if (obj == null)
                return false;
            // Если сравниваемые объекты имеют разный тип, равенство не верно
            if (obj.GetType() != this.GetType())
                return false;
            // Вызываем специфический метод сравнения
            return Equals((RefTypeAddPayment)obj);
        }
        public override int GetHashCode()
        {
            return String.Format("RefTypeAddPayment [{0}, {1}, {2}]", RefTypeAddPayment_Id, RefTypeAddPayment_Cd, RefTypeAddPayment_Nm).GetHashCode();
        }
    }
}
