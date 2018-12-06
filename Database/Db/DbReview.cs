using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Db
{
    public class DbReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowId { get; set; }
        public string BookCode { get; set; }
        public string User { get; set; }
        public string Review { get; set; }
    }
}
