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

       

    }



}
