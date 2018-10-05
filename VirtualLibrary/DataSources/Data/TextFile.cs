using System.Collections.Generic;
using System.IO;

namespace VirtualLibrary.DataSources.Data
{
    public class TextFile
    {
        public List<string> ReadTextFile(string fileName)
        {
            var textList = new List<string>();
            var directoryInfo = Directory.GetParent(
                Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo != null)
            {
                var file = new StreamReader(Path.Combine(directoryInfo.FullName, fileName));
                string line;
                while ((line = file.ReadLine()) != null) textList.Add(line);
            }

            return textList;
        }
    }
}