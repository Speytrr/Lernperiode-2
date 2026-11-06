using System;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
public class Program
{
    static int x = 1;
    static int y = 1;
    static int time = 0;
    static int width = 60;
    static int height = 15;
    static int changeX;
    static int recordTime = 0;
    static bool reachedEnd = false;



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
        Console.SetCursorPosition(15, 8);
        Console.WriteLine("Record: " + recordTime + " seconds");

        Console.SetCursorPosition(0,7);


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

        Thread movementThread = new Thread(Movement);
        Thread pathThread = new Thread(CreatePath);

        movementThread.Start();
        pathThread.Start();
    }

    public static void Timer()
    {
        while (!reachedEnd)
        {
            Thread.Sleep(1000);
            time++;
        }
    }

    public static void UpdateRecord()
    {
        if (recordTime == 0 || time < recordTime)
        {
            recordTime = time;
        }
    }


    public static void Movement()
    {
        while (!reachedEnd)
        {
            Console.SetCursorPosition(0, 16);
            Console.Write("Time: " + time + " seconds");

            Console.SetCursorPosition(x, y);
            Console.Write("X");


            if (Console.KeyAvailable)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(" ");
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

    public static void CreatePath()
    {
        int pathX = 1;
        int pathY = 1;
        Random coordinates = new Random();
        List<int> availableDirections = new List<int>();

        int changeX = coordinates.Next(4);
        Console.SetCursorPosition(pathX, pathY);

        while (!reachedEnd)
        {
            availableDirections.Clear();

            if (pathY + 1 < Maze.Length &&
                Maze[pathY + 1][pathX] == ' ')
                availableDirections.Add(0);

            if (pathX + 1 < Maze[pathY].Length &&
                Maze[pathY][pathX + 1] == ' ')
                availableDirections.Add(1);

            if (pathY - 1 >= 0 &&
                Maze[pathY - 1][pathX] == ' ')
                availableDirections.Add(2);

            if (pathX - 1 >= 0 &&
                Maze[pathY][pathX - 1] == ' ')
                availableDirections.Add(3);

            if (availableDirections.Count == 0)
            {
                Console.WriteLine("Dead end!");
                break;
            }

            changeX = availableDirections[
                coordinates.Next(availableDirections.Count)];

            if (changeX == 0)
                pathY++;
            else if (changeX == 1)
                pathX++;
            else if (changeX == 2)
                pathY--;
            else if (changeX == 3)
                pathX--;

            Console.SetCursorPosition(pathX, pathY);

            Maze[pathY] = Maze[pathY].Remove(pathX, 1).Insert(pathX, "+");

            Console.Write("+");

            if ((pathX, pathY) == (58, 13))
                reachedEnd = true;

            Thread.Sleep(200);
            //There could be dead ends but its functional
        }
        if (reachedEnd)
        {
            UpdateRecord();
        }
    }
}
