
using System.Security.Cryptography;
int x = 10;
int y = 10;
string character = "x";


while (true)
{
    Console.SetCursorPosition(0,0);
    Console.WriteLine("-------------------------------------------------------------");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("¦                                                           ¦");
    Console.WriteLine("-------------------------------------------------------------");


    Console.SetCursorPosition(x, y);
    Console.WriteLine(character);

    ConsoleKeyInfo Up = Console.ReadKey();
    if (Up.Key == ConsoleKey.UpArrow)
    {
        y = y - 1;
    }
    ConsoleKeyInfo Down = Console.ReadKey();
    if (Down.Key == ConsoleKey.DownArrow)
    {
        y += 1;
    }
    ConsoleKeyInfo Right = Console.ReadKey();
    if (Right.Key == ConsoleKey.RightArrow)
    {
        x += 1;
    }
    ConsoleKeyInfo Left = Console.ReadKey();
    if (Left.Key == ConsoleKey.LeftArrow)
    {
        x = x - 1;
    }
}



//if((AsyncFlowControl.ModifierKeys  & Key) != 0))