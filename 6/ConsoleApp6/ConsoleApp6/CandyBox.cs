using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    class CandyBox : Confectionery
    {
        private Confectionery[] confInBox;
        public Confectionery[] ConfInBox 
        {
            get { return confInBox; }
            set { confInBox = value; }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Количество предметов в коробке: {ConfInBox.Length}";
        }
    }
}
