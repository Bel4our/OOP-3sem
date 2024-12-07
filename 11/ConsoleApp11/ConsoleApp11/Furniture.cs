using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP11
{
    internal class Furniture
    {
        string Name { get; set; }
        string Material { get; set; }

        string Color { get; set; }


        public Furniture(string Name, string Material, string Color)
        {
            this.Name = Name;
            this.Material = Material;
            this.Color = Color;
        }
        public Furniture()
        {
            this.Name = "заготовка";
            this.Material = "доски";
            this.Color = "не окрашена";
        }


        public override string ToString()
        {
            return $"Название: {Name}, материал: {Material}, цвет: {Color}";
        }

        public void ShowText(string text)
        {
            Console.WriteLine(text);
        }
       

    }
}
