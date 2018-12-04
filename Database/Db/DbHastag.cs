using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualLibrary.DataSources.Db;

namespace Database.Db
{
    public class DbHastag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowId { get; set; }
        public string Hastag { get; set; }

        public virtual ICollection<DbBook> Books { get; set; }
    }
}
