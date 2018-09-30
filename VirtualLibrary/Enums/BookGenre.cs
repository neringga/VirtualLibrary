using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrary.Enums
{
    [Flags]
    public enum  BookGenre
    {
        ROMANCE = 1,
        DRAMA = 2,
        COMEDY = 4,
        EDUCATIONAL = 8, 
        POETRY = 16
    }
}
