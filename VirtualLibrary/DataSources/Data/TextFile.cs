using System.Collections.Generic;
using System.IO;

namespace VirtualLibrary.DataSources.Data
{
    class TextFile
    {
        public List<string> ReadTextFile(string fileName)
        {
            string line;
            List<string> textList = new List<string>();
            StreamReader file = new StreamReader( Path.Combine(Directory.GetParent(
                Directory.GetCurrentDirectory()).Parent.FullName, fileName));
            while ((line = file.ReadLine()) != null)
            {
                textList.Add(line);
            }
            return textList;
        }
    }
}
