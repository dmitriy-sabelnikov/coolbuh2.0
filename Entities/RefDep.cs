using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entities
{
    //Справочник подразделений
    public class RefDep : IEquatable<RefDep>
    {
        public int RefDep_Id { get; set; }     
        public string RefDep_Cd { get; set; }   //Код
        public string RefDep_Nm { get; set; } //Наименование

        // Реализация интерфейса IEquatable<T>
        public bool Equals(RefDep other)
        {
            return 
                this.RefDep_Id == other.RefDep_Id &&
                this.RefDep_Cd == other.RefDep_Cd &&
                this.RefDep_Nm == other.RefDep_Nm;
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
            return Equals((RefDep)obj);
        }
        public override int GetHashCode()
        {
            return String.Format("RefDep [{0}, {1}, {2}]", RefDep_Id, RefDep_Cd, RefDep_Nm).GetHashCode();
        }
    }
}
