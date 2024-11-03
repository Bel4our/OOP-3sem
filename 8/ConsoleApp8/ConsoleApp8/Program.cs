using System;
using System.Diagnostics;
using System.Collections;


namespace OOP8
{
    public delegate void UpgradeEvent();
    public delegate void TurnOnEvent(int voltage);

    public class Boss
    {
        public event UpgradeEvent? Upgrade;
        public event TurnOnEvent? TurnOn;

        public void PerformUpgrade()
        {
            Console.WriteLine("Boss: Включение...");
            Upgrade?.Invoke();
        }

        public void PerformTurnOn(int voltage)
        {
            Console.WriteLine($"Boss: Включение на {voltage}V...");
            TurnOn?.Invoke(voltage);
        }
    }

    public abstract class Equipment
    {
        public string Name { get; set; }
        public bool IsWork { get; set; } = true;
        public int UpgradeLevel { get; set; } = 0;

        public Equipment(string name)
        {
            Name = name;
        }

        public abstract void OnUpgrade();
        public abstract void OnTurnOn(int voltage);
    }


    public class Microwave : Equipment
    {
        public Microwave(string name) : base(name) { }

        public override void OnUpgrade() => Console.WriteLine(IsWork ? $"Улучшение {Name} до уровня {++UpgradeLevel}": $"Оборудование {Name} сломано!");

        public override void OnTurnOn(int voltage)
        {
            if (IsWork)
            {
                if (voltage < 120)
                {
                    Console.WriteLine($"Недостаточное напряжение для включения {Name}");
                }
                else if (voltage > 300)
                {
                    Console.WriteLine($"Перенапряжение, {Name} сломано");
                    IsWork = false;
                }
                else
                {
                    Console.WriteLine($"{Name} включено при напряжении {voltage}");
                }
            }
            else
            {
                Console.WriteLine($"Оборудование {Name} сломано!");
            }
        }
    }

    public class Fridge : Equipment
    {
        public Fridge(string name) : base(name) { }

        public override void OnUpgrade()
        {
            if (IsWork)
            {
                UpgradeLevel++;
                Console.WriteLine($"Улучшение {Name} до уровня {UpgradeLevel}");
            }
            else
            {
                Console.WriteLine($"Оборудование {Name} сломано!");
            }
        }

        public override void OnTurnOn(int voltage)
        {
            if (IsWork)
            {
                if (voltage < 150)
                {
                    Console.WriteLine($"Недостаточное напряжение для включения {Name}");
                }
                else if (voltage > 400)
                {
                    Console.WriteLine($"Перенапряжение, {Name} сломано");
                    IsWork = false;
                }
                else
                {
                    Console.WriteLine($"{Name} включено при напряжении {voltage}");
                }
            }
            else
            {
                Console.WriteLine($"Оборудование {Name} сломано!");
            }
        }

    }


    

    public class Computer : Equipment
    {
        public Computer(string name) : base(name) { }

        public override void OnUpgrade()
        {
            if (IsWork)
            {
                UpgradeLevel++;
                Console.WriteLine($"Улучшение {Name} до уровня {UpgradeLevel}");
            }
            else
            {
                Console.WriteLine($"Оборудование {Name} сломано!");
            }
        }

        public override void OnTurnOn(int voltage)
        {
            if (IsWork)
            {
                if (voltage < 160)
                {
                    Console.WriteLine($"Недостаточное напряжение для включения {Name}");
                }
                else if (voltage > 280)
                {
                    Console.WriteLine($"Перенапряжение, {Name} сломано");
                    IsWork = false;
                }
                else
                {
                    Console.WriteLine($"{Name} включено при напряжении {voltage}");
                }
            }
            else
            {
                Console.WriteLine($"Оборудование {Name} сломано!");
            }
        }
    }

    class StringCorrector
    {
        private Action<string> CorrectStr1;
        private Action<string, char> Correctstr2;

        public StringCorrector()
        {
           
            CorrectStr1 += DelSpace;
            CorrectStr1 += UpperCase;
            CorrectStr1 += DelPunct;
            Correctstr2 = AddSymb;
        }

        public void DelPunct(string str)
        {
            str = str.Replace("!", "")
                     .Replace(".", "")
                     .Replace(",", "")
                     .Replace(":", "")
                     .Replace(";", "")
                     .Replace("?", "");
            Console.WriteLine("Удаление знаков препинания: " + str);
        }

        public void AddSymb(string str, char symb)
        {
            str += symb;
            Console.WriteLine($"Строка с добавленным символом '{symb}': " + str);
        }

        public void UpperCase(string str)
        {
            str = str.ToUpper();
            Console.WriteLine("Строка в верхнем регистре: " + str);
        }

        public void DelSpace(string str)
        {
            str = str.Replace(" ", "");
            Console.WriteLine("Строка без пробелов: " + str);
        }

        public void UseAll(string input, char additionalSymbol)
        {
            Console.WriteLine("Исходная строка: " + input);

            Correctstr2?.Invoke(input, additionalSymbol);

            CorrectStr1?.Invoke(input);


        }
    }
    class lab8
    {
        static public void Main()
        {
            Boss boss = new Boss();
            Microwave microwave = new Microwave("Micro1");
            Fridge fridge = new Fridge("Fridge1");
            Computer computer = new Computer("Comp1");

            boss.Upgrade += microwave.OnUpgrade;
            boss.Upgrade += fridge.OnUpgrade;
            boss.Upgrade += computer.OnUpgrade;

            boss.TurnOn += microwave.OnTurnOn;
            boss.TurnOn += fridge.OnTurnOn;
            boss.TurnOn += computer.OnTurnOn;

            boss.PerformUpgrade();
            boss.PerformTurnOn(480);
            boss.PerformTurnOn(260);


            

            StringCorrector corrector = new StringCorrector();

            string input = "Hell Yeah!";
            char s = '!';

            corrector.UseAll(input, s);

        }
    }
}