using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
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
    public static Thread timerThread = new Thread(Timer);


    static string[] Maze =
    {
            "############################################################",
            "#S                                                         #",
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
            "#                                                         E#",
            "############################################################"
    };
    public static bool[,] visited = new bool[Maze.Length, Maze[0].Length];



    public static void Main()
    {
        Console.CursorVisible = false;
        Console.SetWindowSize(60, 17);
        Menu();
    }

    public static void Menu()
    {
        string savedRecord = RecordReader();

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
        Console.WriteLine(savedRecord + " seconds");

        Console.SetCursorPosition(0,7);


        string input = Console.ReadLine();

        if (input == "1")
        {
            Console.Clear();
            Labyrinth();
        }
        else if (input == "2")
        {
            Console.Clear();
            Labyrinth();
        }
        else if (input == "3")
        {
            Console.Clear();
            return;
        }
    }

    public static string RecordReader()
    {
        using (StreamReader readrec = new StreamReader("Record.txt"))
            return readrec.ReadLine(); 
    }
    public static void Labyrinth()
    {
        Console.SetCursorPosition(0, 0);

        foreach (string level in Maze)
        {
            Console.WriteLine(level);
        }

        Thread movementThread = new Thread(Movement);
        Thread createPathThread = new Thread(CreatePath);

        createPathThread.Start();
    }

    public static void Timer()
    {
        while (!reachedEnd)
        {
            Console.SetCursorPosition(0, 16);
            Console.Write("Time: " + time + " seconds");
            Thread.Sleep(1000);
            time++;
        }
        if (recordTime == 0 || time < recordTime)
        {
            recordTime = time;
        }
        using (StreamWriter record = new StreamWriter("Record.txt"))
            record.WriteLine("Record: " + recordTime);
    }

    public static void Movement()
    {
        timerThread.Start();
        while (!reachedEnd)
        {
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
        bool foundWay = false;
        Random coordinates = new Random();
        List<int> availableDirections = new List<int>();
        bool[,] visited = new bool[Maze.Length, 13];
        List<(int x, int y)> locations = new List<(int x, int y)>();
        locations.Add((pathX, pathY));

        int changeX = coordinates.Next(4);
        Console.SetCursorPosition(pathX, pathY);

        while (!foundWay)
        {
            availableDirections.Clear();

            while (!foundWay)
            {
                
                if (pathY + 2 < Maze.Length && Maze[pathY + 2][pathX] == ' ')
                    availableDirections.Add(0);

                if (pathX + 2 < Maze[pathY].Length && Maze[pathY][pathX + 2] == ' ')
                    availableDirections.Add(1);

                if (pathY - 2 >= 0 && Maze[pathY - 2][pathX] == ' ')
                    availableDirections.Add(2);

                if (pathX - 2 >= 0 && Maze[pathY][pathX - 2] == ' ')
                    availableDirections.Add(3);

                if (availableDirections.Count == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Maze[pathY] = Maze[pathY].Remove(pathX, 1).Insert(pathX, "x");
                        Console.SetCursorPosition(pathX, pathY);
                        Console.Write(" ");
                        locations.RemoveAt(locations.Count - 1);
                        (pathX, pathY) = locations[locations.Count - 1];
                    }
                    break;
                }

                changeX = availableDirections[coordinates.Next(availableDirections.Count)];

                for (int c = 0; c <= 1; c++)
                {
                    if (changeX == 0)
                        pathY += 1;
                    else if (changeX == 1)
                        pathX += 1;
                    else if (changeX == 2)
                        pathY -= 1;
                    else if (changeX == 3)
                        pathX -= 1;
                    locations.Add((pathX, pathY));
                    Console.SetCursorPosition(pathX, pathY);
                    Maze[pathY] = Maze[pathY].Remove(pathX, 1).Insert(pathX, "+");
                    Console.Write("+");
                }

                break;
            }

            if ((pathX, pathY) == (57, 13))
            {
                Maze[13] = Maze[13].Remove(58, 1).Insert(58, "+");
                Console.SetCursorPosition(58, 13);
                Console.Write("+");
                foundWay = true;
            }
            Thread.Sleep(200);
        }
    }
}
