using OOP4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    abstract public class Confectionery: BaseClone, ICloneable
    {
        private string name = "not founded";
        private string description = "not founded";
        private double weight = 0;
       
        public string Name 
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
       
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public override string ToString()
        {
            return $"Тип объекта: {this.GetType()}, Название: {Name}, Описание: {Description}, Вес: {Weight}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Confectionery other)
            {
                return this.Name == other.Name && this.Weight == other.Weight && this.Description == other.Description;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Weight.GetHashCode() ^ Description.GetHashCode();
        }


        public override bool DoClone(object Obj)
        {
            Confectionery  conf = (Confectionery)Obj;
            Name = conf.Name;
            Description = conf.Description;
            Weight = conf. Weight;
            Console.WriteLine("Клонирование успешно");
            return true;
        }

        bool ICloneable.DoClone(object Obj)
        {
            Confectionery conf = (Confectionery)Obj;
            Console.WriteLine($"А это просто интерфейс");
            return true;
        }
    }
}
