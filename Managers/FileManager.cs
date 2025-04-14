using System;
using System.Diagnostics.Metrics;
using System.IO;
using MidnightCommander.Components;
using System.Globalization;
using System.Data;

namespace MidnightCommander.Managers
{
    public class FileManager
    {
        public (Row[] rows, int counter) CreateFileList(string path)
        {
            int counter = 0;
            int arrayLength = 1;
            Row[] files = new Row[arrayLength];

            AddRow(ref counter, ref arrayLength, @"\", "..", "", "", ref files);

            foreach (string dir in Directory.GetDirectories(path))
            {
                AddRow(ref counter, ref arrayLength, @"\", Path.GetFileName(dir), dir, ReturnFileMod(Directory.GetLastWriteTime(dir)), ref files, "");
            }

            foreach (string file in Directory.GetFiles(path))
            {
                AddRow(ref counter, ref arrayLength, " ", Path.GetFileName(file), file, ReturnFileMod(File.GetLastWriteTime(file)), ref files, new FileInfo(file).Length.ToString());
            }
            return (files, counter);
        }

        private string ReturnFileMod(DateTime date)
        {
            if (date.Year == DateTime.Now.Year)
            {
                return date.ToString("dd.MMM HH:mm", CultureInfo.InvariantCulture);
            }
            else
            {
                return date.ToString("dd.MMM  yyyy", CultureInfo.InvariantCulture);
            }
        }
        private Row[] ExtendArray(int arrayLength, Row[] files)
        {
            Row[] tempArray = new Row[arrayLength * 2];
            for (int i = 0; i < arrayLength; i++)
            {
                tempArray[i] = files[i];
            }
            return tempArray;
        }
        private void AddRow(ref int counter, ref int arrayLength, string prefix, string name, string fullpath, string lastmod, ref Row[] files, string size = "")
        {
            const int default_prefix_length = 1;
            const int default_name_length = 20;
            const int default_fullpath_length = 0;
            const int default_size_length = 10;
            const int default_lastmod_length = 10;

            if (counter >= arrayLength)
            {
                files = ExtendArray(arrayLength, files);
                arrayLength *= 2;
            }
            files[counter++] = new Row()
            {
                Prefix = new Node() { Text = prefix, Length = default_prefix_length, Color = new int[] { 255, 255, 255 } },
                Name = new Node() { Text = name, Length = default_name_length, Color = new int[] { 255, 255, 255 } },
                FullPath = new Node() { Text = fullpath, Length = default_fullpath_length, Color = new int[] { 255, 255, 255 } },
                Size = new Node() { Text = size, Length = default_size_length, Color = new int[] { 255, 255, 255 } },
                LastMod = new Node() { Text = lastmod, Length = default_lastmod_length, Color = new int[] { 255, 255, 255 } }
            };
        }
    }
}
