using System;

namespace VILIB.Helpers
{
    public interface IExceptionLogger
    {
        void Log(Exception ex);
    }
}
