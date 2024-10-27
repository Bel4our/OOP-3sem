using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace OOP7
{

    public interface IAction<T> 
    {   
        void AddItem(T item);  
        void DeleteItem(T item);
        void CheckList(Predicate<T> predicate);  
    }

    public class List<T>:IAction<T> where T: IComparable<T>
    {
        T[] list;
        public int count = 0;

        public List()
        {
            list = new T[1];
        }

        public List(int size)
        {
            this.list = new T[size];
        }

        public void AddItem(T item)
        {
            if (count == list.Length)
            {
                DoublingList();
            }
            list[count] = item;
            count++;
        }

        public void DeleteItem(T item)
        {
                bool found = false;

                for (int i = 0; i < count; i++)
                {
                    if (list[i].CompareTo(item) == 0)
                    {
                        for (int j = i; j < count - 1; j++)
                        {
                            list[j] = list[j + 1];
                        }
                        count--; 
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Элемент не найден.");
                }
        }
       

        public void CheckList(Predicate<T> predicate)
        {
            bool found = false;
            for (int i = 0; i < count; i++)
            {
                if (predicate(list[i]))
                {
                    Console.WriteLine($"Элемент {list[i]} удовлетворяет условию.");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Нет элементов, удовлетворяющих условию.");
            }
        }

        private void DoublingList()
        {
            T[] buf = new T[list.Length + 1];
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
            list1.AddItem(item);
            for (int i = 0; i < list.count; i++)
            {
                list1.AddItem(list[i]);
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
                list1.AddItem(list[i]);
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
                newList.AddItem(list1[i]);
            }

            for (int i = 0; i < list2.count; i++)
            {
                newList.AddItem(list2[i]);
            }

            return newList;
        }

        public void PrintAll()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{list[i]}");
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

        public void PushToFile()
        {
            using StreamWriter sw = new("List.json");
            var str = JsonSerializer.Serialize(list);
            sw.WriteLine(str);

        }

        public void ReadFromFile()
        {
            using StreamReader sr = new("List.json");
            var str = sr.ReadToEnd();
            list = JsonSerializer.Deserialize<T[]>(str);
        }
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
            try {

                List<int> intList = new List<int>();
                intList.AddItem(10);
                intList.AddItem(20);
                intList.AddItem(30);
                Console.WriteLine("Список целых чисел:");
                intList.PrintAll();
                intList.DeleteItem(20);
                intList.PrintAll();

                Console.WriteLine("Элементы больше 15:");
                intList.CheckList( x=> x > 15);

                List<float> floatList = new List<float>();
                floatList.AddItem(10.5f);
                floatList.AddItem(20.8f);
                floatList.AddItem(30.3f);
                Console.WriteLine("Список вещественных чисел:");
                floatList.PrintAll();

                List<string> stringList = new List<string>();
                stringList.AddItem("Hello");
                stringList.AddItem("World");
                Console.WriteLine("Список строк:");
                stringList.PrintAll();


                List<Candy> candies = new List<Candy>();
                Candy candy1 = new Candy { Name = "Леденец", Description = "кислый", SweetnessLevel = 8 };
                Candy candy2 = new Candy { Name = "Леденец", Description = "сладкий", SweetnessLevel = 5 };
                candies.AddItem(candy1);
                candies.AddItem(candy2);
                candies.DeleteItem(candy2);
                candies.PrintAll();
                candies.CheckList(c => c.SweetnessLevel > 1);

                stringList.PushToFile();
                stringList.ReadFromFile();
                stringList.PrintAll();

            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }
    }
}