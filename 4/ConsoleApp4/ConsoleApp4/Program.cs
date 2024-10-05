using System;


namespace OOP4
{
    public interface ICloneable
    {
        bool DoClone(object Obj);
    }

    public abstract class BaseClone
    { 
       public abstract bool DoClone(object Obj);
    }



    class Lab4
    {
        static void Main()
        {
            Cookie cookie = new Cookie
            {
                Name = "Овсяное печенье",
                Weight = 50,
                Description = "Хрустящее овсяное печенье",
                IsCrunchy = true
            };

          

            Caramel caramel = new Caramel
            {
                Name = "Карамель",
                Weight = 30,
                Description = "Твердая карамель",
                SweetnessLevel = 90,
                HardLevel = 7
            };


          


           if (caramel is Caramel)
            {
                Console.WriteLine("Это карамель");
            }
            else
            {
                Console.WriteLine("Это не карамель");
            }

           if(caramel is Confectionery)
            {
                Console.WriteLine("Это кондитерское изделие");
            }
            else
                Console.WriteLine("Это не кондитерское изделие");








            Caramel caramel2 = new Caramel();

            Console.WriteLine(caramel2.DoClone(caramel));

            Cookie cookie2 = new Cookie();
            ICloneable clone = cookie2;

            Console.WriteLine(clone.DoClone(cookie));





            Candy candy1 = new Candy() 
            {
                Name = "Конфета",
                Weight = 100,
                Description = "Новый образец конфеты",
                SweetnessLevel = 60,
            };


            ChocolateCandy chock = candy1 as ChocolateCandy;


            if(chock != null)
            {
                Console.WriteLine("успешно преобразование");
            }
            else
            {
                Console.WriteLine("Не успешно");
            }


            ChocolateCandy chocolateCandy = new ChocolateCandy
            {
                Name = "Шоколадная конфета",
                Weight = 120,
                Description = "Конфета с высоким содержанием какао",
                SweetnessLevel = 80,
                CocoaPercentage = 70
            };

            Candy cand2 = chocolateCandy as Candy;

            if (cand2 != null)
            {
                Console.WriteLine("успешно преобразование");
            }
            else
            {
                Console.WriteLine("Не успешно");
            }




            CandyBox candyBox = new CandyBox
            {
                Name = "Коробка конфет",
                Weight = 500,
                Description = "Ассорти конфет",
                ConfInBox = new Confectionery[] { chocolateCandy, cookie }
            };


            Console.WriteLine(chocolateCandy.ToString());

            BaseClone[] baseCloneArray = { chocolateCandy, cookie, candyBox, caramel };

            Printer printer = new Printer();

            foreach (var item in baseCloneArray)
            {
                printer.IAmPrinting(item);
            }
        }



    }
   

}