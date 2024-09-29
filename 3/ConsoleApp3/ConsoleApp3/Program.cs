using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3
{
    public class List<T>
    {
        T[] list;
        public int count = 0;




        public List()
        {
            list = new T[5];
        }

        public List(int size)
        {
            this.list = new T[size];
        }

        public void Add(T item)
        {
            if (count == list.Length)
            {
                DoublingList();
            }
            list[count] = item;
            count++;
        }


        private void DoublingList()
        {
            T[] buf = new T[list.Length * 2];
            for (int i = 0; i < list.Length; i++)
            {
                buf[i] = list[i];
            }
            list = buf;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= list.Length)
                {
                    throw new IndexOutOfRangeException("Неверный индекс");
                }
                return list[index];
            }
            set
            {
                if (index < 0 || index >= list.Length)
                {
                    throw new IndexOutOfRangeException("Неверный индекс");
                }
                list[index] = value;
            }

        }




        public static List<T> operator +(T item, List<T> list)
        {
            var list1 = new List<T>();
            list1.Add(item);
            for (int i = 0; i < list.count; i++)
            {
                list1.Add(list[i]);
            }
            return list1;
        }


        public static List<T> operator --(List<T> list)
        {

            if (list.count == 0)
            {
                Console.WriteLine("Список пуст!");
                return list;
            }

            var list1 = new List<T>();
            for (int i = 1; i < list.count; i++)
            {
                list1.Add(list[i]);
            }
            return list1;
        }

        public static bool operator !=(List<T> list1, List<T> list2)
        {
            if (list1.count != list2.count)
                return true;

            for (int i = 0; i < list1.count; i++)
            {
                if (!list1[i].Equals(list2[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator ==(List<T> list1, List<T> list2)
        {
            if (list1.count == list2.count)
                return true;

            for (int i = 0; i < list1.count; i++)
            {
                if (list1[i].Equals(list2[i]))
                {
                    return true;
                }
            }
            return false;
        }


        public static List<T> operator *(List<T> list1, List<T> list2)
        {
            var newList = new List<T>();

            for (int i = 0; i < list1.count; i++)
            {
                newList.Add(list1[i]);
            }

            for (int i = 0; i < list2.count; i++)
            {
                newList.Add(list2[i]);
            }

            return newList;
        }

        public void PrintAll()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine();
        }


        public static Production? production;

        public class Production
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public Production(int id, string name)
            {
                Id = id;
                Name = name;
            }
        }

        public class Developer
        {
            public string Fio { get; set; }
            public int Id { get; set; }
            public string Department { get; set; }

            public Developer(string fio, int id, string department)
            {
                Fio = fio;
                Id = id;
                Department = department;
            }
        }
        public Developer developer;
    }


    public static class StatisticOperation
    {
        public static int Sum(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.count; i++)
            {
                sum += list[i];
            }
            return sum;
        }

        public static int DifferenceMaxMin(List<int> list)
        {
            if (list.count == 0)
            {
                throw new InvalidOperationException("Список пуст.");
            }

            int max = list[0];
            int min = list[0];

            for (int i = 1; i < list.count; i++)
            {
                if (list[i] > max) max = list[i];
                if (list[i] < min) min = list[i];
            }

            return max - min;
        }

        public static int Count(List<int> list)
        {
            return list.count;
        }

        public static int CountWordsWithCapital(this List<string> list)
        {
            int count = 0;

            for (int i = 0; i < list.count; i++)
            {
                string sentence = list[i];
                bool isWord = false; 

                for (int j = 0; j < sentence.Length; j++)
                {
                    char c = sentence[j];

                    if (char.IsWhiteSpace(c))
                    {
                        isWord = false; 
                    }
                    else
                    {
                        if (!isWord) 
                        {
                            if (char.IsUpper(c))
                            {
                                count++; 
                            }
                            isWord = true; 
                        }
                    }
                }
            }

            return count;
        }



        public static bool HasDuplicates(this List<int> list)
        {
            if (list.count < 2) return false;

            int[] sortedArray = new int[list.count];
            for (int i = 0; i < list.count; i++)
            {
                sortedArray[i] = list[i];
            }

            Array.Sort(sortedArray);

            for (int i = 1; i < sortedArray.Length; i++)
            {
                if (sortedArray[i] == sortedArray[i - 1])
                {
                    return true;
                }
            }
            return false; 
        }
    }
    class OOP
    {
        static void Main()
        {
            List<int> list = new List<int>();
            Console.WriteLine("Введите элемент:");
            list.Add(Convert.ToInt32(Console.ReadLine()));
            list.Add(Convert.ToInt32(Console.ReadLine()));
            list.Add(Convert.ToInt32(Console.ReadLine()));
            list.Add(Convert.ToInt32(Console.ReadLine()));
            list.Add(Convert.ToInt32(Console.ReadLine()));
            list.Add(Convert.ToInt32(Console.ReadLine()));
            list.Add(Convert.ToInt32(Console.ReadLine()));
            list.Add(Convert.ToInt32(Console.ReadLine()));
            list.PrintAll();

            list = 0 + list;  
            list.PrintAll();

            list = --list;  
            list.PrintAll();

            List<int> list2 = new List<int>();
            list2.Add(5);
            List<int> combinedList = list * list2;  
            combinedList.PrintAll();

            Console.WriteLine(list != list2);

            List<int>.production = new List<int>.Production(1, "S. G.");

            int sum = StatisticOperation.Sum(list);
            Console.WriteLine($"Сумма элементов: {sum}");

            int difference = StatisticOperation.DifferenceMaxMin(list);
            Console.WriteLine($"Разница между максимальным и минимальным: {difference}");

            int count = StatisticOperation.Count(list);
            Console.WriteLine($"Количество элементов: {count}");


            bool hasDuplicates = list.HasDuplicates();
            Console.WriteLine($"Есть ли повторяющиеся элементы: {hasDuplicates}");


            List<string> stringList = new List<string>();
            stringList.Add("Nehdf dG JJ");
            stringList.Add("gfh Gs jfgf Let");
            stringList.Add("Los Polos Hermanos jjg jnjs");
            int capitalWordsCount = stringList.CountWordsWithCapital();
            Console.WriteLine($"Количество слов с заглавной буквы: {capitalWordsCount}");
        }
    }
}