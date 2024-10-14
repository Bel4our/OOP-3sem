using OOP4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    public class Candy : Confectionery
    {
        private int sweetnesslevel2 = 0;
        public int SweetnessLevel2
        { 
            get { return sweetnesslevel2; }
            set { sweetnesslevel2 = value; }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Уровень другой сладости: {SweetnessLevel2}";
        }
    }
}
