using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrary.View
{
    public interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        string Code { get; set; }
    }
}
