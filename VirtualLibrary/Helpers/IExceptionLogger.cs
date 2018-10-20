using System;

namespace VirtualLibrary.Helpers
{
    public interface IExceptionLogger
    {
        void Log(Exception ex);
    }
}
