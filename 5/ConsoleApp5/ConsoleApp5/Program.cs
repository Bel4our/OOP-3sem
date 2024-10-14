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
            Candy candy1 = new Candy
            {
                Name = "Конфета",
                Weight = 100,
                Description = "Леденец",
                SweetnessLevel = 60
            };

            Caramel caramel = new Caramel
            {
                Name = "Карамель",
                Weight = 50,
                Description = "Твердая",
                SweetnessLevel = 80,
                HardLevel = 5
            };

            Cookie cookie = new Cookie
            {
                Name = "Овсяное печенье",
                Weight = 75,
                Description = "Хрустящее",
                SweetnessLevel = 10,
                IsCrunchy = true
            };

            giftForChild childGift = new giftForChild
            {
                Type = GiftType.Candy
            };

         
            childGift.Add(candy1);
            childGift.Add(caramel);
            childGift.Add(cookie);

            GiftController giftController = new GiftController(childGift);

            childGift.Out();

            giftController.SortBySweetness();

            giftController.FindCandyBySweetnessRange(70, 100);

            double totalWeight = giftController.CalculateTotalWeight();
            Console.WriteLine($"Общий вес подарка: {totalWeight}");
        }
    }
}