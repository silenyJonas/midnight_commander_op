using System;
using MidnightCommander.Components;

namespace midnight_commander
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Config.Instance.Set("config.txt");
            Config.Instance.Apply();

            Window window = new Window();

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                window.Draw();
                window.HandleKey(Console.ReadKey());
            }
        }
    }

}