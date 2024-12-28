using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        TPLPrimeSearch();
        CancelTokenDemo();
        TasksWithResults();
        ContinuationTasks();
        ParallelLoops();
        ParallelInvoke();
        BlockingCollectionDemo();
        AsyncAwaitDemo().Wait();
    }
    static void TPLPrimeSearch()
    {
        Console.WriteLine("----- Поиск простых чисел -----");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Task<List<int>> primeTask = Task.Run(() => FindPrimaryNumbers(1, 100));
        Console.WriteLine($"ID задачи: {primeTask.Id}");
        Console.WriteLine($"Статус задачи до завершения: {primeTask.Status}");
        primeTask.Wait();
        stopwatch.Stop();
        Console.WriteLine($"Статус задачи после выполнения: {primeTask.Status}");
        Console.WriteLine($"Количество найденных простых чисел в заданном диапазоне: {primeTask.Result.Count}");
        Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
    }
    static List<int> FindPrimaryNumbers(int start, int end)
    {
        bool[] isPrime = new bool[end + 1];
        for (int i = 2; i <= end; i++)
        {
            isPrime[i] = true;
        }
        for (int j = 2; j * j <= end; j++)
        {
            if (isPrime[j])
            {
                for (int k = j * j; k <= end; k += j)
                {
                    isPrime[k] = false;
                }
            }
        }
        List<int> primes = new List<int>();
        for (int i = start; i <= end; i++)
        {
            if (isPrime[i])
            {
                primes.Add(i);
            }
        }
        return primes;
    }
    static void CancelTokenDemo()
    {
        Console.WriteLine("----- Отмена задачи с помощью CancellationToken -----");
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;
        Task<List<int>> primeTask = Task.Run(() => FindPrimeNumbersWithCancellation(1, 100, token), token);

        cts.Cancel();
        try
        {
            primeTask.Wait();
            Console.WriteLine($"Количество найденных простых чисел в заданном диапазоне: {primeTask.Result.Count}");
        }
        catch (AggregateException ex)
        {
            foreach (var inner in ex.InnerExceptions)
            {
                if (inner is TaskCanceledException)
                {
                    Console.WriteLine("Задача была прервана досрочно");
                }
                else
                {
                    Console.WriteLine("Произошла ошибка: " + inner.Message);
                }
            }
        }
        finally
        {
            cts.Dispose();
        }
    }
    static List<int> FindPrimeNumbersWithCancellation(int start, int end, CancellationToken token)
    {
        bool[] isPrime = new bool[end + 1];
        for (int i = 2; i <= end; i++)
        {
            isPrime[i] = true;
        }
        for (int j = 2; j * j <= end; j++)
        {
            if (isPrime[j])
            {
                for (int k = j * j; k <= end; k += j)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Задача отменена!");
                        token.ThrowIfCancellationRequested();
                    }
                    isPrime[k] = false;
                }
            }
        }
        List<int> result = new List<int>();
        for (int i = start; i <= end; i++)
        {
            if (isPrime[i])
            {
                result.Add(i);
            }
        }
        return result;
    }
    static void TasksWithResults()
    {
        Console.WriteLine("----- Задача с возвратом результата -----");
        Task<int> task1 = Task.Run(() => CalculateFirst(10));
        Task<int> task2 = Task.Run(() => CalculateSecond(20));
        Task<int> task3 = Task.Run(() => CalculateThird(30));
        Task<int> finalTask = Task.WhenAll(task1, task2, task3).ContinueWith(t => t.Result.Sum());

        
        Console.WriteLine($"Итоговый результат: {finalTask.Result}");
    }

    static int CalculateFirst(int x) => x * 2;
    static int CalculateSecond(int x) => x * 3;
    static int CalculateThird(int x) => x * 4;


    static void ContinuationTasks()
    {
        Console.WriteLine("----- Задача продолжения -----");
        Task<int> firstTask = Task.Run(() => 52);
        Task continuationTask = firstTask.ContinueWith(t => Console.WriteLine($"Результат предыдущей задачи: {t.Result}"));

        Task<int> secondTask = Task.Run(() => 100);
        int result = secondTask.GetAwaiter().GetResult();
        Console.WriteLine($"Результат задачи (GetAwaiter): {result}");
    }
    static void ParallelLoops()
    {
        Console.WriteLine("----- Параллельные циклы -----");
        Stopwatch sequentialWatch = Stopwatch.StartNew();
        for(int i = 0; i < 50000000; i++)
        {
            Math.Sin(i);
        }
        sequentialWatch.Stop();
        Stopwatch parallelWatch = Stopwatch.StartNew();
        Parallel.For(0, 50000000, i =>
        {
            Math.Sin(i);
        });
        parallelWatch.Stop();
        Console.WriteLine($"Последовательный цикл: {sequentialWatch.ElapsedMilliseconds} мс");
        Console.WriteLine($"Параллельный цикл: {parallelWatch.ElapsedMilliseconds} мс");
    }
    static void ParallelInvoke()
    {
        Console.WriteLine("----- ParallelInvoke -----");
        Parallel.Invoke(
            () => Console.WriteLine("Операция 1"),
            () => Console.WriteLine("Операция 2"),
            () => Console.WriteLine("Операция 3")
        );
    }
    static void BlockingCollectionDemo()
    {
        BlockingCollection<string> warehouse = new BlockingCollection<string>();

        List<Task> suppliers = new List<Task>
        {
            Task.Run(() => Supplier("Товар A", 2000, warehouse)),
            Task.Run(() => Supplier("Товар B", 1500, warehouse)),
            Task.Run(() => Supplier("Товар C", 1000, warehouse)),
            Task.Run(() => Supplier("Товар D", 3000, warehouse)),
            Task.Run(() => Supplier("Товар E", 2500, warehouse))
        };

        List<Task> customers = new List<Task>();
        for (int i = 1; i <= 10; i++)
        {
            int customerId = i;
            customers.Add(Task.Run(() => Customer(customerId, warehouse)));
        }

        Task.WaitAll(suppliers.ToArray());

        warehouse.CompleteAdding();

        Task.WaitAll(customers.ToArray());

        Console.WriteLine("Все покупатели завершили покупки.");
    }

    static void Supplier(string productName, int delay, BlockingCollection<string> warehouse)
    {
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(delay);
            warehouse.Add(productName);
            Console.WriteLine($"Поставщик добавил: {productName}");
        }
    }

    static void Customer(int customerId, BlockingCollection<string> warehouse)
    {
        while (!warehouse.IsCompleted)
        {
            string product;
            if (warehouse.TryTake(out product, TimeSpan.FromMilliseconds(500)))
            {
                Console.WriteLine($"Покупатель {customerId} купил: {product}");
            }
            else
            {
                Console.WriteLine($"Покупатель {customerId} не нашел товар и ушел");
            }
        }
    }
    static async Task AsyncAwaitDemo()
    {
        Console.WriteLine("----- Async/Await -----");
        int result = await PerformAsyncOperation();
        Console.WriteLine($"Результат асинхронной операции: {result}");
    }
    static async Task<int> PerformAsyncOperation()
    {
        await Task.Delay(1000);
        return 52;
    }
}
