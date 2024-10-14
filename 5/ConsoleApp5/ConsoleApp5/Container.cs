using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    public enum GiftType
    {
        Candy,
        Cookie,
        Caramel,
        ChocolateCandy
    }

    public struct GiftAttributes
    {
        public int ItemCount { get; set; }   
        public double TotalWeight { get; set; }  

        public GiftAttributes(int itemCount, double totalWeight)
        {
            ItemCount = itemCount;
            TotalWeight = totalWeight;
        }

        public override string ToString()
        {
            return $"Количество предметов: {ItemCount}, Общий вес: {TotalWeight} г.";
        }
    }


    public abstract class forGift
    {
        public abstract void Add(Confectionery obj);
        public abstract void Remove(Confectionery obj);
        public abstract void Out();
    }
    public class giftForChild : forGift
    {
        internal List<Confectionery> items = new List<Confectionery>();

        public GiftAttributes GiftDetails { get; set; }
        public GiftType Type { get; set; }

        public override void Add(Confectionery obj)
        {
            items.Add(obj);
            UpdateGiftDetails();  
        }


        public override void Remove(Confectionery obj)
        {
            items.Remove(obj);
            UpdateGiftDetails();  
        }

        public override void Out()
        {
            Console.WriteLine("Содержимое подарка:");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(GiftDetails.ToString());
        }

        private void UpdateGiftDetails()
        {
            int itemCount = items.Count;
            double totalWeight = 0;

            foreach (var item in items)
            {
                totalWeight += item.Weight;
            }

            GiftDetails = new GiftAttributes(itemCount, totalWeight);
        }
    }
}

