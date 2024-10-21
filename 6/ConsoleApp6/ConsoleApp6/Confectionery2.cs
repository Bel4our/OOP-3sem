using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP4
{
    abstract public partial class Confectionery
    {
        public override bool DoClone(object Obj)
        {
            Confectionery conf = (Confectionery)Obj;
            Name = conf.Name;
            Description = conf.Description;
            Weight = conf.Weight;
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
