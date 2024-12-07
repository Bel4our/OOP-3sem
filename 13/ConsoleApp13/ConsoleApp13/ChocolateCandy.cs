using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ConsoleApp13
{
    [Serializable]
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
