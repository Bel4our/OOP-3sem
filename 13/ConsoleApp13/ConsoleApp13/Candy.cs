using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp13
{
    [Serializable]
    public class Candy : Confectionery
    {
        [NonSerialized]

        private int sweetnesslevel = 20;

        [XmlIgnore]
        [JsonIgnore]
        public int SweetnessLevel
        {
            get { return sweetnesslevel; }
            set { sweetnesslevel = value; }
        }

        public Candy()
        {

        }
        public override string ToString()
        {
            return $"{base.ToString()}, Уровень сладости: {SweetnessLevel}";
        }

    }
}
