using System;
using System.IO;
using VirtualLibrary.DataSources.Data;

namespace VirtualLibrary.Helpers
{
    public static class Exceptions
    {
        public static void Log(this Exception ex)
        {
            using (var text = new StreamWriter(StaticStrings.ExceptionsLogFile))
            {
                text.WriteLine(ex.ToString());
            }
        }
    }
}