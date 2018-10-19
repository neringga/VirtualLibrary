using System;
using System.IO;
using VILIB.DataSources.Data;

namespace VILIB.Helpers
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
