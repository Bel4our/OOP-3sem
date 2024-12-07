using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;




namespace ConsoleApp13
{
    public interface ISerializer
    {
        void Serialize<T>(T obj, string filePath);
        T Deserialize<T>(string filePath);
    }

    public class BinarySerializer : ISerializer
    {
        public void Serialize<T>(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, obj);
            }
        }

        public T Deserialize<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (T)bf.Deserialize(fs);
            }
        }
    }


    public class SoapSerializer : ISerializer
    {
        public void Serialize<T>(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                SoapFormatter soap = new SoapFormatter();
                soap.Serialize(fs, obj);
            }
        }

        public T Deserialize<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                SoapFormatter soap = new SoapFormatter();
                return (T)soap.Deserialize(fs);
            }
        }
    }

    public class JsonSerializer : ISerializer
    {
        public void Serialize<T>(T obj, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {

                var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
                System.Text.Json.JsonSerializer.Serialize(fs, obj, options);
            }
        }

        public T Deserialize<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                return System.Text.Json.JsonSerializer.Deserialize<T>(fs);
            }
        }
    }

    public class XmlSerializer : ISerializer
    {
        public void Serialize<T>(T obj, string filePath)
        {

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                xs.Serialize(fs, obj);
            }
        }

        public T Deserialize<T>(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                return (T)xs.Deserialize(fs);
            }
        }
    }



    public class Program
    {
        static void Main()
        {
            Candy candy = new Candy();

            string binaryFilePath = "BinaryFile.txt";
            string soapFilePath = "SoapFile.xml";
            string xmlFilePath = "XMLFile.xml";
            string jsonFilePath = "JSONFile.json";

            ISerializer binarySerializer = new BinarySerializer();
            ISerializer soapSerializer = new SoapSerializer();
            ISerializer jsonSerializer = new JsonSerializer();
            ISerializer xmlSerializer = new XmlSerializer();

            binarySerializer.Serialize(candy, binaryFilePath);
            soapSerializer.Serialize(candy, soapFilePath);
            xmlSerializer.Serialize(candy, xmlFilePath);
            jsonSerializer.Serialize(candy, jsonFilePath);

            Candy candB = binarySerializer.Deserialize<Candy>(binaryFilePath);
            Candy candS = soapSerializer.Deserialize<Candy>(soapFilePath);
            Candy candX = xmlSerializer.Deserialize<Candy>(xmlFilePath);
            Candy candJ = jsonSerializer.Deserialize<Candy>(jsonFilePath);

            Console.WriteLine(candB.ToString());
            Console.WriteLine(candS.ToString());
            Console.WriteLine(candX.ToString());
            Console.WriteLine(candJ.ToString());
            Console.WriteLine();

            Candy candy1 = new Candy { SweetnessLevel = 10 };
            Candy candy2 = new Candy { SweetnessLevel = 15 };
            Candy candy3 = new Candy { SweetnessLevel = 20 };
            Candy candy4 = new Candy { SweetnessLevel = 25 };

            Candy[] candies = new Candy[] { candy1, candy2, candy3, candy4 };

            string binaryFilePath2 = "BinaryFile2.txt";
            string soapFilePath2 = "SoapFile2.xml";
            string xmlFilePath2 = "XMLFile2.xml";
            string jsonFilePath2 = "JSONFile2.json";

            binarySerializer.Serialize(candies, binaryFilePath2);
            soapSerializer.Serialize(candies, soapFilePath2);
            xmlSerializer.Serialize(candies, xmlFilePath2);
            jsonSerializer.Serialize(candies, jsonFilePath2);

            Candy[] candiesB = binarySerializer.Deserialize<Candy[]>(binaryFilePath2);
            Candy[] candiesS = soapSerializer.Deserialize<Candy[]>(soapFilePath2);
            Candy[] candiesX = xmlSerializer.Deserialize<Candy[]>(xmlFilePath2);
            Candy[] candiesJ = jsonSerializer.Deserialize<Candy[]>(jsonFilePath2);


            Console.WriteLine("Binary:");
            foreach (var element in candiesB)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("SOAP:");
            foreach (var element in candiesS)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("XML:");
            foreach (var element in candiesX)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();

            Console.WriteLine("JSON:");
            foreach (var element in candiesJ)
            {
                Console.WriteLine(element.ToString());
            }
            Console.WriteLine();


            string xmlFilePath3 = "XMLFile3.xml";

            var xDoc = new XmlDocument();
            xDoc.Load(xmlFilePath3);

            XPathNavigator navigator = xDoc.CreateNavigator();

            XPathNodeIterator iterator = navigator.Select("//Candy[SweetnessLevel > 15]");

            while (iterator.MoveNext())
            {
                var sweetnessLevel = iterator.Current.SelectSingleNode("SweetnessLevel").Value;
                Console.WriteLine($"SweetnessLevel: {sweetnessLevel}");
            }
            Console.WriteLine();

            XPathNavigator firstCandy = navigator.SelectSingleNode("//Candy[1]");
            if (firstCandy != null)
            {
                Console.WriteLine(firstCandy.OuterXml);
            }



            XElement candiesXml = new XElement("Candies",
           new XElement("Candy",
               new XAttribute("Id", 1),
               new XElement("Name", "Chocolate"),
               new XElement("SweetnessLevel", 10),
               new XElement("IsSweet", true)
                              ),
           new XElement("Candy",
               new XAttribute("Id", 2),
               new XElement("Name", "Lollipop"),
               new XElement("SweetnessLevel", 15),
               new XElement("IsSweet", true)
                       ),
           new XElement("Candy",
               new XAttribute("Id", 3),
               new XElement("Name", "Sour Candy"),
               new XElement("SweetnessLevel", 15),
               new XElement("IsSweet", false)
           )
                       );


            Console.WriteLine();
            Console.WriteLine();


            candiesXml.Save("Candies.xml");

            var sweetCandies = candiesXml.Elements("Candy")
                                         .Where(c => (bool)c.Element("IsSweet") == true);
            foreach (var cand in sweetCandies)
            {
                Console.WriteLine(cand.Element("Name").Value);
            }

            Console.WriteLine();
            var highSweetness = candiesXml.Elements("Candy")
                                          .Where(c => (int)c.Element("SweetnessLevel") > 10);

            foreach (var cand in highSweetness)
            {
                Console.WriteLine(cand.Element("Name").Value);
            }

        }
    }

}