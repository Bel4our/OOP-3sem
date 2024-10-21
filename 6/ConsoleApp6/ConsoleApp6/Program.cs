using System;
using System.Diagnostics;

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
            try
            {

                try
                {

                    Candy candy1 = new Candy
                    {
                        Name = "Конфета",
                        Weight = 100,
                        Description = "Леденец",
                        SweetnessLevel = 60
                    };

                    if (candy1.Weight <= 0)
                    {
                        throw new InvalidWeightException("Вес не может быть отрицательным или равным нулю!");
                    }
                }
                catch (InvalidWeightException ex)
                {
                    Console.WriteLine($"Локальная обработка: {ex.Message}");
                    Console.WriteLine(ex.Source);
                    Console.WriteLine(ex.TargetSite);
                    throw;
                }

                Caramel caram1 = new Caramel
                {
                    Name = "Карамель",
                    Weight = 120,
                    Description = "Мягкая",
                    hardLevel = 2
                };
          
                if(caram1.hardLevel <= 0)
                {
                    throw new InvalidCaramelHardLevel("Твёрдость карамели не может быть ниже нуля!");
                }

                ChocolateCandy chocCand = new ChocolateCandy
                {
                    Name = "Шоколадная конфета",
                    Weight = 20,
                    Description = "С начинкой",
                    SweetnessLevel = 20,
                    CocoaPercentage = 1
                };

                if (chocCand.CocoaPercentage < 0 || chocCand.CocoaPercentage > 100)
                {
                    throw new InvalidCocoaPercentageException("Процент какао не может быть отрицательным или равным нулю!");
                }

               // chocCand = null;
                if (chocCand == null)
                {
                    throw new ArgumentNullException(nameof(chocCand), "Объект ChocolateCandy не может быть null!");
                }
                CandyBox candbox = new CandyBox
                {
                    ConfInBox = new Confectionery[] { chocCand }
                };


                Debug.Assert(caram1.Weight > 0, "Вес карамели должен быть положительным!");

                Console.WriteLine($"Конфета {caram1.Name}, вес: {caram1.Weight}");

            }
            catch (InvalidCocoaPercentageException ex)
            {
                Console.WriteLine($"Ошибка процента какао: {ex.Message}");
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.TargetSite);
            }
            catch (InvalidWeightException ex)
            {
                Console.WriteLine($"Глобальная обработка: {ex.Message}");
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.TargetSite);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ArgumentNullException: {ex.Message}");
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.TargetSite);
            }
            catch (InvalidCaramelHardLevel ex)
            {
                Console.WriteLine($"Ошибка уровня твёрдости: {ex.Message}");
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.TargetSite);
            }
            catch
            {
                Console.WriteLine("Возникла непредвиденная ошибка");
            }
            finally
            {
                Console.WriteLine("Завершение обработки исключений.");
            }
        }
    }
}