using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrary.View
{
    public interface ITakenBook
    {
        string User { get; set; }
        string BookCode { get; set; }
        DateTime Taken { get; set; }
        DateTime HasToBeReturned { get; set; }
    }
}
