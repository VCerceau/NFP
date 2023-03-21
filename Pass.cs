using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WpfApp2
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

        [Column("password")]
        public string Password { get; set; }

        public Pass(int id, string name, string url, string password)
        {
            Id = id;
            Name = name;
            Url = url;
            Password = password;
        }
    }
}
