using MidnightCommander.Components;
using MidnightCommander.Managers;


namespace MidnightCommander.Pages
{
    public class BrowserWindow : IWindow
    {
        private FileManager fileManager { get; } = new FileManager();
        private Table Table1 { get; set; }
        private Table Table2 { get; set; }
        public BrowserWindow(string path = @"C:\")
        {
            var (dataarray, counter) = fileManager.CreateFileList(path);

            Table1 = new Table(dataarray, counter, true);
            Table2 = new Table(dataarray, counter, false);
        }
        public void Draw()
        {
            Table1.Draw();
            // Table2.Draw();

        }
        public void HandleKey(ConsoleKeyInfo key)
        {
            Table1.HandleKey(key);
            // Table2.HandleKey(key);
        }
    }
}