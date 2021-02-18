using System;

namespace MenuLibrary
{
    public class Menu
    {
        string[] elements;
        int width = 0;
        public Menu(string[] data)
        {
            elements = data;

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i].Length > width) width = elements[i].Length;
            }
        }

        public int Display()
        {
            int selected = 1;
            ConsoleKeyInfo k;
            Console.CursorVisible = false;
            do
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < elements.Length; i++)
                {
                    if (selected == i) Console.BackgroundColor = ConsoleColor.Blue;
                    else Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"   {elements[i].PadRight(width)}   ");

                }
                k = Console.ReadKey(true);

                if (k.Key == ConsoleKey.DownArrow && selected < elements.Length - 1)
                {
                    selected++;
                }
                if (k.Key == ConsoleKey.UpArrow && selected > 0)
                {
                    selected--;
                }
                if (k.Key == ConsoleKey.Escape)
                {
                    selected = -1;
                }

            } while (!(k.Key == ConsoleKey.Enter || k.Key == ConsoleKey.Escape));

            Console.CursorVisible = true;
            return selected;
        }
    }
}
