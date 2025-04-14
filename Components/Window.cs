using System;
using MidnightCommander.Pages;

namespace MidnightCommander.Components
{
    public class Window
    {
        private IWindow _window;
        public Window()
        {
            _window = new BrowserWindow();
        }
        public void HandleKey(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.F1) //tohle funguje proste nahradit tlacitkem pro editaci
            {
                if (_window is EditWindow)
                {
                    _window = new BrowserWindow();
                    return;
                }
                else
                {
                    _window = new EditWindow();
                    return;
                }
            }
            _window.HandleKey(key);
        }
        public void Draw()
        {
            _window.Draw();
        }
    }
}