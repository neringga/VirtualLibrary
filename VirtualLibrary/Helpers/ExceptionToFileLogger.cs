using System;
using System.IO;
using VirtualLibrary.DataSources.Data;

namespace VirtualLibrary.Helpers
{
    public class ExceptionToFileLogger : IExceptionLogger
    {
        public void Log(Exception ex)
        {
            using (var text = new StreamWriter(StaticStrings.ExceptionsLogFile))
            {
                text.WriteLine(ex.ToString());
            }
        }
    }
}
