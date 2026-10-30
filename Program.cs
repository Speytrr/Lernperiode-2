using System;
using System.Diagnostics;
using System.Threading;
public class Program
{
    static int x = 1;
    static int y = 1;
    static int time = 0;
    static int width = 60;
    static int height = 15;

    static string[] Maze =
    {
            "############################################################",
            "#                                                          #",
            "#                                                          #",
            "#                                                          #",
            "#                                                          #",
            "#                                                          #",
            "#                                                          #",
            "#                                                          #",
            "#                                                          #",
            "#                                                          #",
            "#                                                          #",
            "#                                                          #",
            "#                                                          #",
            "#                                                          #",
            "############################################################"
        };

    public static void Main()
    {
        Console.SetWindowSize(60, 17);
        Menu();
    }

    public static void Menu()
    {
        Console.SetCursorPosition(15, 0);
        Console.WriteLine("=============================");
        Console.SetCursorPosition(15, 1);
        Console.WriteLine("========= LABYRINTH =========");
        Console.SetCursorPosition(15, 2);
        Console.WriteLine("=============================");

        Console.SetCursorPosition(15, 4);
        Console.WriteLine("1. Easy");
        Console.SetCursorPosition(15, 5);
        Console.WriteLine("2. Hard");
        Console.SetCursorPosition(15, 6);
        Console.WriteLine("3. Exit");

        Console.SetCursorPosition(0, 7);


        string input = Console.ReadLine();

        if (input == "1")
        {
            Console.Clear();
            Thread timerThread = new Thread(Timer);
            timerThread.Start();
            Labyrinth();
        }
        else if (input == "2")
        {
            Console.Clear();
            Thread timerThread = new Thread(Timer);
            timerThread.Start();
            Labyrinth();
        }
        else if (input == "3")
        {
            Console.Clear();
            return;
        }
    }
    public static void Labyrinth()
    {
        Console.SetCursorPosition(0, 0);

        foreach (string level in Maze)
        {
            Console.WriteLine(level);
        }
        Movement();

    }

    public static void Timer()
    {
        while (true)
        {
            Thread.Sleep(1000);
            time++;
        }
    }


    public static void Movement()
    {
        while (true)
        {
            Console.SetCursorPosition(0, 16);
            Console.Write("Time: " + time + " seconds");

            Console.SetCursorPosition(x, y);
            Console.Write("X");

            Console.SetCursorPosition(x, y);
            Console.Write(" ");

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo UserInput = Console.ReadKey(true);
                if (UserInput.Key == ConsoleKey.UpArrow)
                {
                    y--;
                }
                else if (UserInput.Key == ConsoleKey.DownArrow)
                {
                    y++;
                }
                else if (UserInput.Key == ConsoleKey.RightArrow)
                {
                    x++;
                }
                else if (UserInput.Key == ConsoleKey.LeftArrow)
                {
                    x--;
                }

                if (y < 0 || y >= Maze.Length ||
                    x < 0 || x >= Maze[0].Length)
                {
                    if (UserInput.Key == ConsoleKey.UpArrow)
                    {
                        y++;
                    }
                    else if (UserInput.Key == ConsoleKey.DownArrow)
                    {
                        y--;
                    }
                    else if (UserInput.Key == ConsoleKey.RightArrow)
                    {
                        x--;
                    }
                    else if (UserInput.Key == ConsoleKey.LeftArrow)
                    {
                        x++;
                    }
                }
                else if (Maze[y][x] == '#')
                {
                    if (UserInput.Key == ConsoleKey.UpArrow)
                    {
                        y++;
                    }
                    else if (UserInput.Key == ConsoleKey.DownArrow)
                    {
                        y--;
                    }
                    else if (UserInput.Key == ConsoleKey.RightArrow)
                    {
                        x--;
                    }
                    else if (UserInput.Key == ConsoleKey.LeftArrow)
                    {
                        x++;
                    }
                }


            }

            
        }

    }

    public static void Labyrinth2()
    {
        Console.SetCursorPosition(0, 0);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //Console.Write(Maze[]);
            }

            Console.WriteLine();
        }

        Movement();
    }

    public static void CreatePath()
    {

    }
}
