using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLibrary.Database.Db
{
    public class DbReviews
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowId { get; set; }
        public string BookCode { get; set; }
        public string User { get; set; }
        public string Review { get; set; }
    }
}
