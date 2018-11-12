using Shared.View;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLibrary.DataSources.Db
{
    public class DbBook : IBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Code { get; set; }
        public int DaysForBorrowing { get; set; }
        public bool IsTaken { get; set; }
        public string TakenByUser { get; set; }
        public DateTime? TakenWhen { get; set; }
        public DateTime? HasToBeReturned { get; set; }
    }
}
