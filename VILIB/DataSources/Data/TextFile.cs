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
            //var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            //var file = new StreamReader(Path.Combine(directoryInfo.FullName, fileName));
            var file = new StreamReader(Path.Combine(directoryInfo, fileName));


            var textList = new List<string>();
            string line;
            while ((line = file.ReadLine()) != null) textList.Add(line);

            return textList;
        }
    }
}