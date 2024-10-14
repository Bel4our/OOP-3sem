using OOP4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    class ChocolateCandy : Candy
    {
        private int cocoaPercentage = 0;
        public int CocoaPercentage
        {
            get { return cocoaPercentage; }
            set { cocoaPercentage = value; }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Процент какао: {CocoaPercentage}%";
        }
    }
}
