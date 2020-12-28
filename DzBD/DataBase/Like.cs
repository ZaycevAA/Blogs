using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzBD.DataBase
{
    [Table("Likes")]
    public class Like
    {
        [Key]
        public int Id { get; set; }
        [Index("Firsttosecond", 1, IsUnique = true)]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        [Index("Firsttosecond", 2, IsUnique = true)]
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
