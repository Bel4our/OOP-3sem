using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class First
    {
        static void Main()
        {

            // типы

            bool b1 = true;
            byte b2 = 1;
            sbyte b3 = 2;
            char c1 = 'c';
            decimal d1 = 3;
            double d2 = 4;
            float f1 = 5;
            int i1 = 6;
            uint i2 = 7;
            nint n1 = 8;
            nuint n2 = 9;
            long l1 = 10;
            ulong l2 = 11;
            short s1 = 12;
            ushort s2 = 13;


            Console.WriteLine("Ввод данных");
            b1 = Convert.ToBoolean(Console.ReadLine());
            b2 = Convert.ToByte(Console.ReadLine());
            b3 = Convert.ToSByte(Console.ReadLine());
            //c1 = Convert.ToChar(Console.ReadLine());
            //d1 = Convert.ToDecimal(Console.ReadLine());
            //d2 = Convert.ToDouble(Console.ReadLine());
            //f1 = (float)Convert.ToDouble(Console.ReadLine());
            //i1 = Convert.ToInt32(Console.ReadLine());
            //i2 = Convert.ToUInt32(Console.ReadLine());
            //n1 = Convert.ToInt32(Console.ReadLine());
            //n2 = Convert.ToUInt32(Console.ReadLine());
            //l1 = Convert.ToInt32(Console.ReadLine());
            //l2 = Convert.ToUInt32(Console.ReadLine());
            //s1 = Convert.ToInt16(Console.ReadLine());
            //s2 = Convert.ToUInt16(Console.ReadLine());
            Console.WriteLine($"{b1}, {b2}, {b3}, {c1}, {d1}, {d2}, {f1}, {i1}, {i2}, {n1}, {n2}, {l1}, {l2}, {s1}, {s2}");


            double db1 = 34.5;
            float fl2 = (float)db1;
            long in1 = (long)db1;
            int in2 = (int)in1;
            short in3 = (short)in2;
            byte in4 = (byte)in3;
            char in5 = (char)in4;

            
            in3 = in4;
            in2 = in3;
            in1 = in2;
            fl2 = in1;
            db1 = fl2;



            bool a1 = true;
            Object o1 = a1;
            bool a2 = (bool)o1;

            int a3 = 5;
            Object o2 = a3;
            int a4 = (int)o2;

            char a5 = 'g';
            Object o3 = a5;
            char a6 = (char)o3;






            var first = 5;
            var second = "hello";

            Console.WriteLine(first.GetType() + " " + second.GetType());



            int? x = null;
            Nullable<int> x2 = 7;
            Console.WriteLine(x ?? x2);


            //var issu = 5;
            //issu = "char";




            // строки

            String fStr = "Hello";
            String sStr = "hello";
            if(fStr == sStr)
            {
                Console.WriteLine("equal");
            }
            else
            {
                Console.WriteLine("not equal");
            }



            String str1 = "Text";
            String str2 = "More text";
            String str3 = "MORE MORE TEXT";



            String str4 = str1+ str2;
            Console.WriteLine(str4);
            String str5 = string.Copy(str1);
            Console.WriteLine(str5);

            Console.WriteLine(str3.Substring(5, 4));
            string[] sub = str3.Split(new char[] { ' ' });
            Console.WriteLine(sub[0]);


            Console.WriteLine(str3.Insert(4, str1));

            Console.WriteLine(str3.Remove(4, 5));


            Console.WriteLine($"{str2} - str2");

            Console.WriteLine();
            String empStr = "";
            String nullStr = null;
            Console.WriteLine(string.IsNullOrEmpty(empStr));
            Console.WriteLine(string.IsNullOrEmpty(nullStr));



            StringBuilder sb = new StringBuilder("ELLght YEAAAAH!");
            sb.Append("!!");
            sb.Insert(0, "H");
            sb.Remove(4, 3);
            Console.WriteLine(sb);



            // массивы


            int[,] arr = new int[,] { { 4, 5 }, { 6, 7 } };

            for(int i = 0; i< arr.GetLength(0); i++)
            {
                for(int j = 0; j< arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }



            string[] z = new string[] { "Help ", "me ", "please" };
            Console.WriteLine(z.Length + " - длина");
            for(int i = 0; i< z.Length; i++)
            {
                Console.WriteLine(z[i]);
            }

            Console.WriteLine("Введите номер элемента массива:");
            int numb = Convert.ToInt32(Console.ReadLine());
            bool fl = true;
            while (fl)
            {
                if (numb < 0 || numb > z.Length-1)
                {
                    Console.WriteLine("Not founded");
                    numb = Convert.ToInt32(Console.ReadLine());
                    continue;
                }
                fl = false;
            }
            Console.WriteLine("Введите новое значение массива:");
            string val = Console.ReadLine();

            z[numb] = val;
            
            for (int i = 0; i < z.Length; i++)
            {
                Console.WriteLine(z[i]);
            }


            double[][] b = { new double[2], new double[3], new double[4] };

            for (int i = 0;i < b.Length; i++)
            {
                Console.WriteLine("Строка: " + (i+1));
                for (int j = 0; j < b[i].Length; j++)
                {
                    b[i][j] =  Convert.ToDouble(Console.ReadLine());
                }

            }

            Console.WriteLine("Массив: ");
            for (int i = 0; i < b.Length; i++)
            {
                for (int j = 0; j < b[i].Length; j++)
                {
                    Console.Write(b[i][j] + " ");
                }
                Console.WriteLine();
            }


            var arr2 = new int[] { 1, 2 };
            var arrStr = new []{ "hell", "yeah" };

            for(int i = 0; i<arr2.Length; i++) {
                Console.Write(arr2[i]+ " ");
            }

            Console.WriteLine();

            for (int i = 0; i < arrStr.Length; i++)
            {
                Console.Write(arrStr[i] + " ");
            }

            Console.WriteLine();


            var tup = (2, "hello", 'h', "again", 1ul);

            Console.WriteLine("Кортеж: " + tup);
            Console.WriteLine(tup.Item2);
            Console.WriteLine(tup.Item1);
            Console.WriteLine(tup.Item5);

            var (at, bt, ct, dt, et) = tup;

            Console.WriteLine(at);
            Console.WriteLine(bt);
            Console.WriteLine(ct);
            Console.WriteLine(dt);
            Console.WriteLine(et);

            var (_, _, _, _, ft) = tup;

            Console.WriteLine(ft);

            Console.WriteLine();

            var tup1 = (1, "am", '4', "new", 2ul);
            Console.WriteLine(tup == tup1);


            (int, int, int, char) locFun(int[] arrVar, string strVar)
            {
                int maxArrEl = arrVar.Max();
                int minArrEl = arrVar.Min();
                int sum = arrVar.Sum();
                char fLet = strVar[0];
                return (maxArrEl, minArrEl, sum, fLet);
            }

            int[] arV = new int[] { 2, 4, 6, 5, 7, 3, 5, 8, 3 };
            var tup2 = locFun(arV, str2);
            Console.WriteLine(tup2);


            void CheckedFunc()
            {
                checked
                {
                    int Max = int.MaxValue;
                    Console.WriteLine(Max);
                }
            }
            void UncheckedFunc()
            {
                unchecked
                {
                    int Max = int.MaxValue;
                    Console.WriteLine(Max);
                }
            }

            CheckedFunc();
            UncheckedFunc();









        }  
    }
}





