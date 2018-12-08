using Shared.Views;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Db
{
    class DbFaceImage : IFaceImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RowId { get; set; }
        public string Nickname { get; set; }
        public byte[] Bytes { get; set; }
    }
}
