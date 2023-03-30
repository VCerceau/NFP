using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NeverForgetPass
{

    [Table("pass")]
    public class Pass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("url")]
        public string Url { get; set; }

        [Column("Username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }

        public Pass(string username, string password, string name = "", string url = "")
        {
            Name = name;
            Url = url;
            Username = username;
            Password = password;
        }

    }
}
