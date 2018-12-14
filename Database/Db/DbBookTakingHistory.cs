using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Db
{
    public class DbBookTakingHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowId { get; set; }
        [Required]
        public string BookCode { get; set; }
        [Required]
        public string TakenByUser { get; set; }
    }
}
