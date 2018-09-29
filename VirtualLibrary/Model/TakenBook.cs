using System;
using VirtualLibrary.View;

namespace VirtualLibrary.Model
{
    public class TakenBook : ITakenBook
    {
        public string User { get; set; }
        public string BookCode { get; set; }
        public DateTime Taken { get; set; }
        public DateTime HasToBeReturned { get; set; }
    }
}
