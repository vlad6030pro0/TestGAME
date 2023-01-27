using System;
using System.Threading;
using System.IO;

namespace MyConsoleGame
{
    class Program
    {
        static int x = Console.CursorLeft; //Расстояние относительно левой стороны
        static int y = Console.CursorTop; //Расстояние относительно верха
        static string texture = "☻"; //Наша текстурка
        static int time = 0;
        static bool pressedsp = false; //булевая переменная для рисования
        static int[] xcord = new int[100]; // массивы для коллизии
        static int[] ycord = new int[27];
        static int countx = 0; //cчетчики для коллизии
        static int county = 0;
        static int numx = 0; // индексы массивов для записи в массив
        static int numy = 0;
        static int[,] arr = new int[100, 27];

        static void Main(string[] args)
        {

            //рисуем стены
            Console.WriteLine("|────────────────────────────────────────────────────────────────────────────────────────────────────|");
            Console.SetCursorPosition(99, 0);
            Console.WriteLine("\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n|\n");
            for (int i = 0; i < 28; i++)
            {
                Console.SetCursorPosition(101, i);
                Console.Write("|");
            }
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("|────────────────────────────────────────────────────────────────────────────────────────────────────|");
            //рисуем человечека
            Console.SetCursorPosition(100, 27);
            Console.WriteLine("Р");
            Console.SetCursorPosition(10, 10);
            Console.Write(texture);
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (x == 100 && y == 27)
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    Console.WriteLine("Вы победили!");
                }
                Move(key);
            }
        }

        //управление
        public static void Move(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.W && y > 1)
            {
                if (arr[x, y + 1] != 1)
                {
                    if (!(y == 27 && x == 100))
                    {
                        Console.SetCursorPosition(x, y);
                        if (pressedsp)
                        {
                            Console.WriteLine("#");
                            xcord[x]=1;
                            ycord[y] = 1;
                        }
                        else
                        {
                            Console.WriteLine(" ");
                            xcord[x] = 0;
                            ycord[y] = 0; 
                        }
                        Console.SetCursorPosition(x, y - 1);
                        y = Console.CursorTop;
                        Console.Write(texture);
                    }
                }
            }

            if (key.Key == ConsoleKey.S && y < 27)
            {
                if (!(y == 27 && x == 100))
                {
                    Console.SetCursorPosition(x, y);
                    if (pressedsp)
                    {
                        Console.WriteLine("#");
                        xcord[numx] = x;
                        ycord[numy] = y;
                        numx++;
                        numy++;
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }
                    Console.SetCursorPosition(x, y + 1);
                    y = Console.CursorTop;
                    Console.Write(texture);
                }
            }

            if (key.Key == ConsoleKey.A && x > 1)
            {
                for (int i = 0; i < xcord.Length; i++)
                {
                    if (Console.CursorLeft - 1 != xcord[i])
                    {
                        countx++;
                    }
                }
                for (int i = 0; i < ycord.Length; i++)
                {
                    if (Console.CursorTop != ycord[i])
                    {
                        county++;
                    }
                }

                if (countx == xcord.Length && county == ycord.Length)
                {
                    if (!(y == 27 && x == 100))
                    {
                        Console.SetCursorPosition(x, y);
                        if (pressedsp)
                        {
                            Console.WriteLine("#");
                            xcord[numx] = x;
                            ycord[numy] = y;
                            numx++;
                            numy++;
                        }
                        else
                        {
                            Console.WriteLine(" ");
                        }
                        Console.SetCursorPosition(x - 1, y);
                        x = Console.CursorLeft;
                        Console.Write(texture);
                    }
                }
                countx = 0;
                county = 0;
            }

            if (key.Key == ConsoleKey.D && x < 100)
            {
                for (int i = 0; i < xcord.Length; i++)
                {
                    if (Console.CursorLeft + 1 != xcord[i])
                    {
                        countx++;
                    }
                }
                for (int i = 0; i < xcord.Length; i++)
                {
                    if (Console.CursorLeft + 1 != xcord[i])
                    {
                        county++;
                    }
                }

                if (countx == xcord.Length && county == ycord.Length)
                {
                    if (!(y == 27 && x == 100))
                    {
                        Console.SetCursorPosition(x, y);
                        if (pressedsp)
                        {
                            Console.WriteLine("#");
                            xcord[numx] = x;
                            ycord[numy] = y;
                            numx++;
                            numy++;
                        }
                        else
                        {
                            Console.WriteLine(" ");
                        }
                        Console.SetCursorPosition(x + 1, y);
                        x = Console.CursorLeft;
                        Console.Write(texture);
                    }
                }
                countx = 0;
                county = 0;
            }

            if (key.Key == ConsoleKey.Spacebar)
            {
                pressedsp = !pressedsp;
            }
        }
    }
}
