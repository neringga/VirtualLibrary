using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualLibrary.DataSources.Db;

namespace Database.Db
{
    public class DbGenre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowId { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<DbBook> Books { get; set; }
    }
}
