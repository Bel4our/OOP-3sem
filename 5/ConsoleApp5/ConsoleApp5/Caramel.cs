using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    internal class Caramel : Candy
    {
        public int hardLevel = 0;
        public int HardLevel
        {
            get { return hardLevel; }
            set { hardLevel = value; }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Твёрдая: {HardLevel}";
        }
    }

}