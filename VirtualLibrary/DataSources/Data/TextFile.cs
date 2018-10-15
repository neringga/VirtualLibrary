using System.Collections.Generic;
using System.IO;

namespace VirtualLibrary.DataSources.Data
{
    public class TextFile
    {
        public List<string> ReadTextFile(string fileName)
        {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            var file = new StreamReader(Path.Combine(directoryInfo.FullName, fileName));

            var textList = new List<string>();
            string line;
            while ((line = file.ReadLine()) != null) textList.Add(line);

            return textList;
        }
    }
}