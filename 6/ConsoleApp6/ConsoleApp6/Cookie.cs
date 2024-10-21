using OOP4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    sealed class Cookie : Confectionery
    {
        private bool isCrunchy = false;
        public bool IsCrunchy
        {
            get { return isCrunchy; }
            set { isCrunchy = value; }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Хрустящее: {IsCrunchy}";
        }
    }
}
