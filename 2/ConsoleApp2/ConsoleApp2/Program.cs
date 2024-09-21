using System;

namespace Second
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

        public Product(string name, string manuf = "hell" )
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

            return this.id == other.id && this.UPC == other.UPC && this.price == other.price && this.Manufacturer==other.manufacturer;
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

    class SecondLab
    {
        static void Main()
        {
            Product product1 = new Product(12345, "LPH");
            product1.Price = 150;
            product1.Amount = 10;
           
            Product product2 = new Product("Яблоко");
            product2.Price = 200;
            product2.Amount = 5;
            product2.Manufacturer = "ФKLf";

            Product product3 = new Product("Автомобиль");
            product3.Price = 50;
            product3.Amount = 20;
            product3.Manufacturer = "Aston Martin";

            int a = Product.counter;

            

            Product product4 = new Product("Автомобиль");

            Product[] products = new Product[] { product1, product2, product3, product4 };

            Product.DisplayProductsByName(products, "Яблоко");
            Product.DisplayProductsByNameAndPrice(products, "Автомобиль", 100);

            int newAmount = 15;
            product1.UpdateAmount(ref newAmount, out int oldAmount);
            Console.WriteLine($"старое количесвто: {oldAmount}, новое количество: {product1.Amount}");

            product1.DisplayAnonymousType();

            Product.ShowObjectCount();

            Console.WriteLine(product1.GetType());
            Console.WriteLine(product1.ToString());

            Console.WriteLine($"Продкуты равны?: {product1.Equals(product2)}");
        }
    }
}