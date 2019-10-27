using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class v_TypePayment : IEquatable<v_TypePayment>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Реализация интерфейса IEquatable<T>
        public bool Equals(v_TypePayment other)
        {
            return
                this.Id == other.Id &&
                this.Name == other.Name;
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
            return Equals((v_TypePayment)obj);
        }
        public override int GetHashCode()
        {
            return String.Format("v_TypePayment [{0}, {1}]", Id, Name).GetHashCode();
        }
    }
}
