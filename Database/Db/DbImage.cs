using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualLibrary.DataSources.Db
{
    public class DbImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Nickname { get; set; }
        public byte[] Bytes { get; set; }
    }
}
