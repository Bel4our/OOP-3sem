using System;
using System.Collections;

namespace OOP10
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


        private Product()
        {
            Console.WriteLine("Конструктор без параметров");
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

    class Country
    {
        public string Name { get; set; }
        public int Square { get; set; }
        public Country(string name, int square)
        {
            Name = name;
            Square = square;
        }
    }



        class OOP { 

        static void Main()
        {
            int n = 5;
            string[] month = { "June", "May", "July", "March","April", "November", "December","September","October","Augest","January","February" };
            var nLengthMonths = from m in month
                               where m.Length == n
                               select m;
            foreach (var m in nLengthMonths) {
                Console.WriteLine(m);
            }

            Console.WriteLine();

            var sumAndWintMonthes = month.Where(m=>m == "June" || m == "July" || m == "Augest" || m == "December" || m == "February" || m == "January");
            foreach (var m in sumAndWintMonthes)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine();
            var soretdeMonths = month.OrderBy(m => m);
            foreach (var m in soretdeMonths)
            {
                Console.WriteLine(m);
            }

            Console.WriteLine();
            var monthesWithU = month.Where(m => m.Length >= 4 && m.Contains('u'));
            foreach (var m in monthesWithU)
            {
                Console.WriteLine(m);
            }




            List<Product> products = new List<Product>();
            Product product1 = new Product("продукт", 100, "Беларусь", 10, 10,12);
            Product product2 = new Product("продукт2", 101, "Россия", 20, 15,145);
            Product product3 = new Product("продукт3", 102, "США", 30, 176,457);
            Product product4 = new Product("продукт", 103, "Франция", 40, 13,124);
            Product product5 = new Product("продукт5", 104, "Китай", 50, 15,15672);
            Product product6 = new Product("продукт6", 105, "Великобритания", 60, 34,21);
            Product product7 = new Product("продукт", 106, "Германия", 70, 165,43);
            Product product8 = new Product("продукт8", 107, "Италия", 80, 37,67);
            Product product9 = new Product("продукт9", 108, "Испания", 90, 430,13);
            Product product10 = new Product("продукт", 109, "Мексика", 100, 54,22);

            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);
            products.Add(product6);
            products.Add(product7);
            products.Add(product8);
            products.Add(product9);
            products.Add(product10);

            var selectedProducts = from prod in products
                                   where prod.Name == "продукт"
                                   select prod;

            foreach (var prod in selectedProducts)
            {
                Console.WriteLine(prod.ToString());
            }

            int price = 45;

            var selectedProducts1 = from prod in products
                                    where prod.Price < price
                                    select prod;

            Console.WriteLine();

            foreach (var prod in selectedProducts1)
            {
                Console.WriteLine(prod.ToString());
            }

            int countOfSelectedProducts3 = (from prod in products
                                    where prod.Price >= 100
                                    select prod).Count();

            Console.WriteLine();

            Console.WriteLine(countOfSelectedProducts3);

            Console.WriteLine();

            var maxProduct = from prod in products
                             select prod;

            int max = maxProduct.Max(p=>p.ShelfLife);
            Console.WriteLine(max);

            Console.WriteLine();

            var sortedProducts = products.OrderBy(p => p.Manufacturer).ThenBy(p=>p.Amount);

            foreach (var prod in sortedProducts)
            {
                Console.WriteLine(prod.ToString());
            }


            var task4 = products.Where(p => p.Price >= 20).OrderBy(p=> p.Manufacturer).GroupBy(p=>p.Price).Skip(2).Count();

            Console.WriteLine();    
            Console.Write(task4);

            Country[] countries = {
                new Country("Беларусь", 196900000),
                new Country("Япония", 346346),
                new Country("Франция", 47568)
            };

            var joinedObj = from p in products
                         join c in countries
                         on p.Manufacturer equals c.Name
                         select new {Name = p.Name, Square = c.Square, CountryName = c.Name};


            Console.WriteLine();

            foreach (var obj in joinedObj)
            {
                Console.WriteLine(obj.Name + " " + obj.CountryName + " " + obj.Square);
            }

        }
    }

}