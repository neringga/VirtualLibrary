using System;
using System.Collections.Generic;

namespace Shared.View
{
    public interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        string Code { get; set; }
        int DaysForBorrowing { get; set; }

        bool IsTaken { get; set; }
        string TakenByUser { get; set; }
        DateTime? TakenWhen { get; set; }
        DateTime? HasToBeReturned { get; set; }

        string Genre { get; set; }
        IList<string> Hashtags { get; set; }
    }
}