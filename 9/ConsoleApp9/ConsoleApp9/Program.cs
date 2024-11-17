using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;


namespace OOP9
{

    internal class Furniture
    {
        string Name {  get; set; }
        string Material {  get; set; }
        
        string Color { get; set; }

        public Furniture(string Name, string Material, string Color) 
        {
            this.Name = Name;
            this.Material = Material; 
            this.Color = Color;
        }

        public override string ToString()
        {
            return $"Название: {Name}, материал: {Material}, цвет: {Color}";
        }

    }



    class forFurniture<T> : IList<T>
    {
        private ArrayList furnitureList;

        public forFurniture()
        {
            furnitureList = new ArrayList();
        }

        public T this[int index]
        {
            get => (T)furnitureList[index];
            set => furnitureList[index] = value;
        }

        public int Count => furnitureList.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            furnitureList.Add(item);
        }

        public void Clear()
        {
            furnitureList.Clear();
        }

        public bool Contains(T item)
        {
            return furnitureList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < furnitureList.Count; i++)
            {
                array[arrayIndex + i] = (T)furnitureList[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T furniture in furnitureList)
            {
                yield return furniture;
            }
        }

        public int IndexOf(T item)
        {
            return furnitureList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            furnitureList.Insert(index, item);
        }

        public bool Remove(T item)
        {
            if (furnitureList.Contains(item))
            {
                furnitureList.Remove(item);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            furnitureList.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }

        public void DisplayCollection()
        {
            Console.WriteLine("Коллекция мебели:");
            foreach (T furniture in furnitureList)
            {
                Console.WriteLine(furniture);
            }
        }
    }

    

    class Lab9
    {
        static void Main(string[] args)
        {
            Furniture sofa = new Furniture("Диван", "кожа", "коричневый");
            Furniture chair = new Furniture("Стул", "дерево", "белый");
            Furniture locker = new Furniture("Шкаф", "дерево", "чёрный");
            forFurniture<Furniture> furnitures = new forFurniture<Furniture>();
            furnitures.Add(sofa);
            furnitures.Add(chair);
            furnitures.Add(locker);
            furnitures.DisplayCollection();
            Console.WriteLine(furnitures.IndexOf(chair));
            furnitures.Insert(0, locker);
            furnitures.Remove(chair);
            furnitures.DisplayCollection();
            furnitures.Clear();
            furnitures.DisplayCollection();


            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("Hello");
            arrayList.Add('f');
            arrayList.Add(34.6);
            arrayList.Add(34.6f);

            arrayList.RemoveRange(2, 2);
            arrayList.Insert(0, 19);

            Queue queue = new Queue();

            foreach (var value in arrayList)
            {
                queue.Enqueue(value);
            }


            foreach(var value in queue)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine(queue.Contains(12));
            Console.WriteLine(queue.Contains(1));


            
            ObservableCollection<Furniture> obsev = new ObservableCollection<Furniture>();
            obsev.CollectionChanged += Furn_CollectionChanged;
            obsev.Insert(0, sofa);
            obsev.Insert(1, chair);
            obsev.Insert(2, locker);
            obsev.RemoveAt(0);
           

        }

        private static void Furn_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems?[0] is Furniture newFurn)
                    {
                        Console.WriteLine($"Добавлен новый объект: {newFurn.ToString()}");
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems?[0] is Furniture oldFurn)
                    {
                        Console.WriteLine($"Удалён объект: {oldFurn.ToString()}");
                    }
                    break;
            }
        }
    }
}