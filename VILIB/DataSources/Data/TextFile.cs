using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Reflection;

namespace VILIB.DataSources.Data
{
    public class TextFile
    {
        public List<string> ReadTextFile(string fileName)
        {
            var directoryInfo = AppDomain.CurrentDomain.BaseDirectory;
            var file = new StreamReader(Path.Combine(directoryInfo, fileName));

            var textList = new List<string>();
            string line;
            while ((line = file.ReadLine()) != null) textList.Add(line);

            return textList;
        }
    }
}