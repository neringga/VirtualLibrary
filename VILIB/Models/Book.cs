﻿using System;
using System.Collections.Generic;
using Shared.View;

namespace VILIB.Model
{
    public class Book : IBook, IEquatable<IBook>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Code { get; set; }
        public int DaysForBorrowing { get; set; }

        public bool IsTaken { get; set; }
        public string TakenByUser { get; set; }
        public DateTime? TakenWhen { get; set; }
        public DateTime? HasToBeReturned { get; set; }

        public string Genre { get; set; }
        public IList<string> Hashtags { get; set; }

        public bool Equals(IBook other)
        {
            return
                Code == other
                    .Code;
        }

        //TODO: 
        //public BookGenre Genre { get; set}
    }
}