using System;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using System.Text.Json;



namespace OOP11
{
    class Lab11
    {
        static void Main()
        {

            Product product1 = new Product("продукт", 100, "Беларусь", 1000, 10, 12);

            Console.WriteLine("Имя сборки: " + Reflector.NameofAssembly(product1));
            Console.WriteLine("Есть ли публичные методы: " + Reflector.HasPublicConstructors(product1));
            Console.WriteLine("Публичные методы: ");
            IEnumerable<string> methods  = Reflector.GetPublicMethods(product1);
            foreach (var method in methods)
            {
                Console.WriteLine(method);
            }
            Console.WriteLine();
            Console.WriteLine("Поля и свойства");
            IEnumerable<string> propAndFields = Reflector.GetPropertiesAndFields(product1);
            foreach(var prop in propAndFields)
            {
                Console.WriteLine(prop);
            }
            Console.WriteLine();
            IEnumerable<string> interfaces = Reflector.GetRInterfaces(product1);
            foreach(var prop in interfaces)
            {
                Console.WriteLine(prop);
            }
            Console.WriteLine();
            Console.WriteLine("Методы содержащие параметр:");
            string className = typeof(Product).FullName;
            IEnumerable<string> methods2 = Reflector.GetMethodsWithParameterType(className, "Object");
            foreach (var prop in methods2)
            {
                Console.WriteLine(prop);
            }

            
            Reflector.WriteClassInfoToFile(className, "File.json");

            string str = (string)Reflector.Invoke(className, "ToString", @"C:\лабы\Мущук\ООП\OOP-3sem\11\ConsoleApp11\ConsoleApp11\bin\Debug\net6.0\File.txt");

            Console.WriteLine();
            Console.WriteLine(str);
            Console.WriteLine();

            Product createdProduct = Reflector.Create<Product>();
            Console.WriteLine(createdProduct.ToString());





            Furniture sofa = new Furniture("диван", "кожаный","красный");

            Console.WriteLine("Имя сборки: " + Reflector.NameofAssembly(sofa));
            Console.WriteLine("Есть ли публичные методы: " + Reflector.HasPublicConstructors(sofa));
            Console.WriteLine("Публичные методы: ");
            IEnumerable<string> methods3 = Reflector.GetPublicMethods(sofa);
            foreach (var method in methods3)
            {
                Console.WriteLine(method);
            }
            Console.WriteLine();
            Console.WriteLine("Поля и свойства");
            IEnumerable<string> propAndFields2 = Reflector.GetPropertiesAndFields(sofa);
            foreach (var prop in propAndFields2)
            {
                Console.WriteLine(prop);
            }
            Console.WriteLine();
            IEnumerable<string> interfaces2 = Reflector.GetRInterfaces(sofa);
            foreach (var prop in interfaces2)
            {
                Console.WriteLine(prop);
            }
            Console.WriteLine();
            Console.WriteLine("Методы содержащие параметр:");
            string className2 = typeof(Furniture).FullName;
            IEnumerable<string> methods4 = Reflector.GetMethodsWithParameterType(className2, "Object");
            foreach (var prop in methods4)
            {
                Console.WriteLine(prop);
            }

            Reflector.WriteClassInfoToFile(className2, "File.json");

            string str2 = (string)Reflector.Invoke(className2, "ToString", @"C:\лабы\Мущук\ООП\OOP-3sem\11\ConsoleApp11\ConsoleApp11\bin\Debug\net6.0\File.txt");

            Console.WriteLine();
            Console.WriteLine(str2);
            Console.WriteLine();

            Furniture createdProduct2 = Reflector.Create<Furniture>();
            Console.WriteLine(createdProduct2.ToString());






            List<int> list = new List<int> { 1, 2, 3, 4, 5 };

            Console.WriteLine("Имя сборки: " + Reflector.NameofAssembly(list));
            Console.WriteLine("Есть ли публичные методы: " + Reflector.HasPublicConstructors(list));
            Console.WriteLine("Публичные методы: ");
            IEnumerable<string> methodsList = Reflector.GetPublicMethods(list);
            foreach (var method in methodsList)
            {
                Console.WriteLine(method);
            }
            Console.WriteLine();
            Console.WriteLine("Поля и свойства");
            IEnumerable<string> propAndFieldsList = Reflector.GetPropertiesAndFields(list);
            foreach (var prop in propAndFieldsList)
            {
                Console.WriteLine(prop);
            }
            Console.WriteLine();
            IEnumerable<string> interfacesList = Reflector.GetRInterfaces(list);
            foreach (var prop in interfacesList)
            {
                Console.WriteLine(prop);
            }
            Console.WriteLine();
            Console.WriteLine("Методы содержащие параметр:");
            string className3 = typeof(List<int>).FullName;
            IEnumerable<string> methodsListWithParameter = Reflector.GetMethodsWithParameterType(className3, "Object");
            foreach (var prop in methodsListWithParameter)
            {
                Console.WriteLine(prop);
            }

            //Reflector.WriteClassInfoToFile(className3, "File.json");

            string str3 = (string)Reflector.Invoke(className3, "ToString", @"C:\лабы\Мущук\ООП\OOP-3sem\11\ConsoleApp11\ConsoleApp11\bin\Debug\net6.0\File.txt");

            Console.WriteLine();
            Console.WriteLine(str3);
            Console.WriteLine();

            List<int> createdList = Reflector.Create<List<int>>();
            Console.WriteLine(createdList);


            string className4 = typeof(Furniture).FullName;
            Reflector.Invoke(className4, "ShowText", @"C:\лабы\Мущук\ООП\OOP-3sem\11\ConsoleApp11\ConsoleApp11\bin\Debug\net6.0\File.txt");
    }
    }

}