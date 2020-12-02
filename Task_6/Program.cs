using System;
using System.Text;

namespace Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            int m;
            int n;
            m = MyProgram.MyData("m number of rows in the array");
            n = MyProgram.MyData("n number of columns in the array");

            int[,] mas = new int[m, n];

            MyProgram.mas_random(ref mas);//Заполняє масив рандомними числами
            MyProgram.mas_print(mas);//Виводить масив

            int key;
            key = MyProgram.MyData("key", "numb");

            MyProgram.key_find(mas, key);//Знаходження елементу за ключем
            MyProgram.func(mas);//Сама функція

        }
    }
    class MyProgram
    {
        public static int MyData(string s, string mode = "arr")
        {
            int x = 0;
            Console.Write($"\nInput {s}: ");
            string str = Console.ReadLine();
            switch (mode)
            {
                case "arr":
                    while (!int.TryParse(str, out x) | x <= 0)
                    {
                        Console.WriteLine("Invalid values");
                        str = Console.ReadLine();
                    }
                    break;

                case "numb":
                    while (!int.TryParse(str, out x))
                    {
                        Console.WriteLine("Invalid values");
                        str = Console.ReadLine();
                    }
                    break;
            }
            return x;
        }

        public static void mas_random(ref int[,] arr)
        {
            Random rnd = new Random();
            int m = arr.GetUpperBound(0) + 1;
            int n = arr.GetUpperBound(1) + 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = rnd.Next(1, 41);
                }
            }
        }

        public static void mas_print(int[,] arr)
        {
            int m = arr.GetUpperBound(0) + 1;
            int n = arr.GetUpperBound(1) + 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{arr[i, j]} \t");
                }

                Console.WriteLine();

            }
        }

        public static void key_find(int[,] arr, int key)
        {
            int m = arr.GetUpperBound(0) + 1;
            int n = arr.GetUpperBound(1) + 1;
            bool flag = true;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (arr[i, j] == key)
                    {
                        Console.WriteLine($"array[{i},{j}] = {arr[i, j]}");
                        flag = false;
                    }
                }
            }

            if (flag)
            {
                Console.WriteLine($"Massive has no element { key}");
            }
            Console.WriteLine();
        }
        public static void func(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(1); ++i)
            {
                int tempmax = int.MinValue;
                int tempmin = int.MaxValue;
                for (int j = 0; j < arr.GetLength(0); ++j)
                {
                    if (arr[j, i] > tempmax)
                    {
                        tempmax = arr[j, i];
                    }
                    if (arr[j, i] < tempmin)
                    {
                        tempmin = arr[j, i];
                    }
                }
                Console.WriteLine($"{i + 1}. {tempmin} + {tempmax} = {tempmin + tempmax}");
            }

        }
    }
}