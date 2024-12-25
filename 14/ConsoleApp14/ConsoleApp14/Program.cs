using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel.Design;

namespace OOP
{
    class Program
    {
        static Mutex consoleMutex = new Mutex();
        static ManualResetEvent pauseEvent = new ManualResetEvent(true);
        static object lockObject = new object();
        static bool evenTurn = false;

        static void Main()
        {
            DisplayRunningProcesses();
            WorkWithDomains();
            PrimeNumbersWithMutex();
            EvenOddNumbersWithMutex();
            TaskWithTimer();
        }
        static void DisplayRunningProcesses()
        {
            var processes = Process.GetProcesses();
            using (StreamWriter writer = new StreamWriter("task1.txt"))
            {
                foreach (var process in processes)
                {
                    try
                    {
                        writer.WriteLine($"ID: {process.Id}, Имя: {process.ProcessName}");
                        writer.WriteLine($"Приоритет: {process.BasePriority}");
                        writer.WriteLine($"Время начала: {process.StartTime}");
                        writer.WriteLine($"Время использования процесса: {process.TotalProcessorTime}");
                        writer.WriteLine($"Состояние: {process.Responding}");
                        writer.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        writer.WriteLine($"ID: {process.Id}, Имя: {process.ProcessName} - Ошибка: {ex.Message}");
                        writer.WriteLine();
                    }
                }
            }
        }
        static void WorkWithDomains()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            using (StreamWriter writer = new StreamWriter("task2.txt"))
            {
                writer.WriteLine($"Имя домена: {domain.FriendlyName}");
                writer.WriteLine($"Базовый директорий: {domain.BaseDirectory}");
                writer.WriteLine("Выгруженные сборки: ");
                foreach (var assembly in domain.GetAssemblies())
                {
                    writer.WriteLine($"- {assembly.FullName}");
                }

            }
        }
        static void PrimeNumbersWithMutex()
        {
            Console.Write("Введите число n: ");
            int n = int.Parse(Console.ReadLine());
            Thread thread = new Thread(() =>
            {
                using (StreamWriter writer = new StreamWriter("task3.txt"))
                {
                    for (int i = 2; i <= n; i++)
                    {
                        pauseEvent.WaitOne();
                        if (isPrime(i))
                        {
                            consoleMutex.WaitOne();
                            try
                            {
                                Console.WriteLine($"Значение: {i}");
                                writer.WriteLine(i);
                                Console.WriteLine($"Поток: {Thread.CurrentThread.Name}");
                                Console.WriteLine($"Идентификатор: {Thread.CurrentThread.ManagedThreadId}");
                                Console.WriteLine($"Приоритет: {Thread.CurrentThread.Priority}");
                                Console.WriteLine($"Состояние: {Thread.CurrentThread.ThreadState}");
                            }
                            finally
                            {
                                consoleMutex.ReleaseMutex();
                            }
                        }
                        Thread.Sleep(50);
                    }
                }
            });
            thread.Start();
            Thread.Sleep(1000);
            pauseEvent.Reset();
            Console.WriteLine("Поток приостановлен");
            Thread.Sleep(1000);
            pauseEvent.Set();
            Console.WriteLine("Поток возобновлен");
            thread.Join();
        }

        static bool isPrime(int n)
        {
            if (n < 2)
                return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        static void EvenOddNumbersWithMutex()
        {
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());

            Thread evenThread = new Thread(() => PrintEvenNumbers(n)) { Priority = ThreadPriority.Highest };
            Thread oddThread = new Thread(() => PrintOddNumbers(n)) { Priority = ThreadPriority.Lowest };

            evenThread.Start();
            evenThread.Join();

            oddThread.Start();
            oddThread.Join();

            evenThread = new Thread(() => PrintEvenNumbersWithSync(n));
            oddThread = new Thread(() => PrintOddNumbersWithSync(n));


            oddThread.Start();
            evenThread.Start();

            oddThread.Join();
            evenThread.Join();


        }

        static void PrintEvenNumbers(int n)
        {
            using (StreamWriter writer = new StreamWriter("task4-1.txt"))
            {
                for (int i = 2; i <= n; i += 2)
                {
                    lock (lockObject)
                    {
                        writer.WriteLine(i);
                        Console.WriteLine(i);
                    }
                    Thread.Sleep(50);
                }
            }
        }

        static void PrintOddNumbers(int n)
        {
            using (StreamWriter writer = new StreamWriter("task4-2.txt"))
            {
                for (int i = 1; i <= n; i += 2)
                {
                    lock (lockObject)
                    {
                        writer.WriteLine(i);
                        Console.WriteLine(i);
                    }
                    Thread.Sleep(100);
                }
            }
        }

        static void PrintEvenNumbersWithSync(int n)
        {
            for (int i = 2; i <= n; i += 2)
            {
                lock (lockObject)
                {
                    while (!evenTurn)
                    {
                        Monitor.Wait(lockObject);
                    }

                    Console.WriteLine($"Чередование (четное): {i}");
                    evenTurn = false;
                    Monitor.Pulse(lockObject);
                }
                Thread.Sleep(50);
            }
        }

        static void PrintOddNumbersWithSync(int n)
        {
            for (int i = 1; i <= n; i += 2)
            {
                lock (lockObject)
                {
                    while (evenTurn)
                    {
                        Monitor.Wait(lockObject);
                    }

                    Console.WriteLine($"Чередование (нечетное): {i}");
                    evenTurn = true;
                    Monitor.Pulse(lockObject);
                }
                Thread.Sleep(100);
            }
        }

        static void TaskWithTimer()
        {
            Timer timer = new Timer(PrintCurrentTime, null, 0, 1000);
            Console.WriteLine("Нажмите Enter для остановки таймера");
            Console.ReadLine();
            timer.Dispose();
        }


        static void PrintCurrentTime(object state)
        {
            consoleMutex.WaitOne();
            try
            {
                Console.WriteLine($"Текущее время: {DateTime.Now}");
            }
            finally
            {
                consoleMutex.ReleaseMutex();
            }
        }


    }
}
