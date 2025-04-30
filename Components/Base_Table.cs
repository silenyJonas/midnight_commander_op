using System;
using MidnightCommander.Managers;

namespace MidnightCommander.Components
{
    public class BaseTable
    {
        private int size_width = 7;
        private int mod_width = 12;
        protected void Draw(Row[] rows, int counter, int xStart, int SelectedIndex, int start_index, int end_index)
        {
            Console.SetCursorPosition(xStart, 0);
            DrawHeaderRow();
            DrawFirstLineRow();
            DrawBody(rows, counter, xStart, SelectedIndex, start_index, end_index);
            DrawConsoleInput();
            DrawFooterActionButtons();
        }
        private void DrawHeaderRow()
        {
            int consoleWidth = Config.Instance.Console_Width;
            string header = "Vlevo" + "".PadRight(10) + "Soubor" + "".PadRight(10) + "Příkaz" + "".PadRight(10) + "Nastavení" + "".PadRight(10) + "Vpravo";
            header = header.PadRight(consoleWidth - 1);
            System.Console.WriteLine(header);
        }
        private void DrawFirstLineRow()
        {
            System.Console.Write("│.n Název".PadRight(Config.Instance.Console_Width / 2 - size_width - mod_width - 2));
            System.Console.Write("│Velikos");
            System.Console.WriteLine("│ Modifikace │");
        }
        private void DrawSelectedFile(Row row)
        {
            if (row.Name.Text == null)
            {
                row.Name.Text = "ERROR";
            }

            DriveManager driveManager = new DriveManager();
            string driveInfo = driveManager.DrawDriveInfo();
            System.Console.WriteLine("├" + "".PadRight(Config.Instance.Console_Width / 2 - 1, '─') + "┤");
            System.Console.WriteLine("│" + row.Name.Text.PadRight(Config.Instance.Console_Width / 2 - 1) + "│");
            System.Console.WriteLine("└" + "".PadRight(Config.Instance.Console_Width / 2 - driveInfo.Length - 4, '─') + driveInfo.PadRight(driveInfo.Length + 3, '─') + "┘");
        }
        private void DrawBody(Row[] rows, int counter, int xStart, int SelectedIndex, int start_index, int end_index)
        {
            for (int i = start_index; i < end_index; i++)
            {
                if (i == SelectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(CreateBodyLine(rows[i]));
                Console.BackgroundColor = ConsoleColor.Black;
            }
            DrawSelectedFile(rows[SelectedIndex]);
        }
        private string CreateBodyLine(Row row)
        {
            // ┌ ┐ └ ┘ ├ ┤ ┬ ┴ ─ │
            int console_width = Config.Instance.Console_Width;
            int name_length = console_width / 2 - size_width - mod_width - 4;
            string line = "│";
            line += row.Prefix.Text;
            string name = "";

            if (row == null || row.Name == null || row.Name.Text == null || row.Size == null || row.Size.Text == null || row.LastMod == null || row.LastMod.Text == null)
            {
                throw new ArgumentNullException("Row or one of its properties is null");
            }

            if (row.Name.Text.Length > name_length)
            {
                name = row.Name.Text.Substring(0, name_length - 2) + "..";
                name = name.PadRight(name_length);
            }
            else
            {
                name = row.Name.Text;
                name = name.PadRight(name_length);
            }
            line += name;
            line += "│";
            string size = row.Size.Text.Length > size_width ? row.Size.Text.Substring(0, size_width) : row.Size.Text.PadRight(size_width);
            line += size;
            line += "│";
            line += row.LastMod.Text.PadRight(mod_width);
            line += "│";

            return line;
        }

        private void DrowFooterFirstRow()
        {

        }
        
        private void DrawFooterSecondRow()
        {

        }
        private void DrawConsoleInput()
        {
            System.Console.WriteLine("Tip");
            System.Console.WriteLine("$");
        }
        private void DrawFooterActionButtons()
        {
            string[][] arr = {
                new string[] { "F1", "Nápověda" },
                new string[] { "F2", "Nabídka" },
                new string[] { "F3", "Zobrazit" },
                new string[] { "F4", "Upravit" },
                new string[] { "F5", "Kopie" },
                new string[] { "F6", "Přesunout" },
                new string[] { "F7", "Nová slož." },
                new string[] { "F8", "Smazat" },
                new string[] { "F9", "Přejmenovat" },
                new string[] { "F10", "Konec" }
            };
            for(int i = 0; i < arr.Length; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.Write(arr[i][0]);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Black;
                System.Console.Write(arr[i][1] + " ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }  
        }
    }
}