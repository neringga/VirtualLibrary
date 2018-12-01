using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLibrary.DataSources.Db
{
    public class DbImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowId { get; set; }
        public string Nickname { get; set; }
        [MaxLength(1048576)]
        public byte[] Bytes { get; set; }
    }
}
