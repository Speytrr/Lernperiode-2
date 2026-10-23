using System;
public class Program
{
    static int x = 1;
    static int y = 1;

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
    public static void Labyrinth()
    {
        Console.SetCursorPosition(0, 0);

        foreach (string level in Maze)
        {
            Console.WriteLine(level);
        }
        Movement();

    }

    public static void Movement()
    {
        while (true)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("X");

            ConsoleKeyInfo UserInput = Console.ReadKey(true);

            Console.SetCursorPosition(x, y);
            Console.Write(" ");

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