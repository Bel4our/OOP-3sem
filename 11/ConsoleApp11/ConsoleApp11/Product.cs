using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OOP11
{

    public partial class Product
    {
        public readonly int id;
        private string name;
        private int upc;
        private string manufacturer;
        private decimal price;
        private int shelfLife;
        private int amount;

        public static int counter = 0;

        private const string owner = "W.W.";


        public Product(string name, int upc, string manufacturer, decimal price, int shelfLife, int amount)
        {
            this.upc = upc;
            this.manufacturer = manufacturer;
            this.price = price;
            this.shelfLife = shelfLife;
            this.amount = amount;
            this.id = counter++;
            this.name = name;
        }

        public Product(int newUPC, string newManuf)
        {
            id = GetHashCode();
            name = "none";
            upc = newUPC;
            manufacturer = newManuf;
            price = 0;
            shelfLife = 0;
            amount = 0;

            counter++;
        }

        public Product(string name, string manuf = "hell")
        {
            id = GetHashCode();
            this.name = name;
            manufacturer = manuf;
            price = 0;
            shelfLife = 0;
            amount = 0;
            upc = 0;

            counter++;
        }


        public Product()
        {
            //Console.WriteLine("Конструктор без параметров");
            id = 1;
            amount = 1;
            manufacturer = "KYYGUIH";
            price = 1;
            shelfLife = 0;
            upc = 12345678;
            name = "name";

            counter++;
        }


        static Product()
        {
            Console.WriteLine($"Владелец - {owner}");
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int UPC
        {
            get { return upc; }
            set { upc = value; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public int ShelfLife
        {
            get { return shelfLife; }
            set { shelfLife = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public decimal TotalCost()
        {
            return price * amount;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Product)) return false;
            Product other = (Product)obj;

            return this.id == other.id && this.UPC == other.UPC && this.price == other.price && this.Manufacturer == other.manufacturer;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"Название: {name}, производитель: {manufacturer}, цена: {price}, количество: {amount}, срок хранения: {shelfLife}, общая стоимость: {TotalCost()}";
        }
    }

    public partial class Product
    {
        public static void ShowObjectCount()
        {
            Console.WriteLine($"Количество созданных объектов: {counter}");
        }

        public void UpdateAmount(ref int newAmount, out int oldAmount)
        {
            oldAmount = amount;
            amount = newAmount;
        }


        public static void DisplayProductsByName(Product[] products, string productName)
        {
            Console.WriteLine($"Products с названием '{productName}':");
            foreach (var product in products)
            {
                if (product != null && product.Name == productName)
                {
                    Console.WriteLine(product);
                }
            }
        }

        public static void DisplayProductsByNameAndPrice(Product[] products, string productName, decimal maxPrice)
        {
            Console.WriteLine($"Products с названием '{productName}' и ценой ниже <= {maxPrice}:");
            foreach (var product in products)
            {
                if (product != null && product.Name == productName && product.Price <= maxPrice)
                {
                    Console.WriteLine(product);
                }
            }
        }

        public void DisplayAnonymousType()
        {
            var anonymousProduct = new { Name = name, Manufacturer = manufacturer, Price = price };
            Console.WriteLine($"Анонимный тип Product: название = {anonymousProduct.Name}, производитель = {anonymousProduct.Manufacturer}, цена = {anonymousProduct.Price}");
        }

    }


}
