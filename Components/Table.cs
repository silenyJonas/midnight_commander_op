using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace MidnightCommander.Components
{
    public class Table : BaseTable
    {
        private int Counter { get; set; }
        private Row[] DataArray { get; set; }
        public bool IsActive { get; set; }
        private int XStart { get; set; }
        private int StartIndex { get; set; } = 0;
        private int SelectedIndex { get; set; } = 0;
        private int EndIndex { get; set; } = Config.Instance.Body_Height;


        public Table(Row[] dataArray, int counter, bool isLeft)
        {
            Counter = counter;
            DataArray = dataArray;
            if (isLeft)
            {
                this.XStart = 0;
            }
            else
            {
                this.XStart = Config.Instance.Console_Width / 2;
            }
        }
        public void Draw()
        {
            base.Draw(DataArray, Counter, XStart, SelectedIndex, StartIndex, EndIndex);
        }
        public void HandleKey(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                if (SelectedIndex > 0)
                {
                    SelectedIndex--;
                    if (SelectedIndex < StartIndex)
                    {
                        StartIndex--;
                        EndIndex--;
                    }
                }
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (SelectedIndex < Counter - 1)
                {
                    SelectedIndex++;
                    if (SelectedIndex >= EndIndex)
                    {
                        EndIndex++;
                        StartIndex++;
                    }
                }
            }
            
           
        }
    }
}