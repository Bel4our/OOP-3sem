using OOP7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP7
{


    public class Candy : Confectionery, IComparable<Candy>
    {
        private int sweetnesslevel = 0;
        public int SweetnessLevel
        {
            get { return sweetnesslevel; }
            set { sweetnesslevel = value; }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Уровень сладости: {SweetnessLevel}";
        }
        public int CompareTo(Candy other)
        {
            if (other == null) return 1;

            return this.SweetnessLevel.CompareTo(other.SweetnessLevel);
        }
    }
}
