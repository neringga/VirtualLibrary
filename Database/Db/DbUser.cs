using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.View;

namespace VirtualLibrary.DataSources.Db
{
    public class DbUser : IUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Language { get; set; }

        //TODO: store images
    }
}
