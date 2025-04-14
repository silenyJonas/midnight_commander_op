using System;
using MidnightCommander.Components;

namespace MidnightCommander.Pages
{
    public class EditWindow : IWindow
    {
        public void Draw(){
            System.Console.WriteLine("Edit Window");
        }

        public void HandleKey(ConsoleKeyInfo key){

        }
    }
}