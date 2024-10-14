using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    class Printer
    {
        public void IAmPrinting(BaseClone someobj)
        {
            Console.WriteLine(someobj.GetType());
            Console.WriteLine(someobj.ToString());
        }
    }
}