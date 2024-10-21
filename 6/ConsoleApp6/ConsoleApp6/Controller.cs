using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    public class GiftController
    {
        protected giftForChild giftC;
        public GiftController(giftForChild gift)
        {
            giftC = gift;
        }

        public void SortBySweetness()
        {
            giftC.items.Sort((x, y) => x.SweetnessLevel.CompareTo(y.SweetnessLevel));
            Console.WriteLine("Сортировка по уровню сладости выполнена:");
            giftC.Out();
        }

        public void FindCandyBySweetnessRange(int minSweetness, int maxSweetness)
        {
            Console.WriteLine($"Поиск конфет с уровнем сладости от {minSweetness} до {maxSweetness}:");

            foreach (var item in giftC.items)
            {
                if (item.SweetnessLevel >= minSweetness && item.SweetnessLevel <= maxSweetness)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        public double CalculateTotalWeight()
        {
            double totalWeight = 0;
            foreach (var item in giftC.items)
            {
                totalWeight += item.Weight;
            }
            return totalWeight;
        }
    }

}
