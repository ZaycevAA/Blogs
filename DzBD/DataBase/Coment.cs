using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzBD.DataBase
{
    [Table("Coments")]
    public class Coment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PostId { get; set;}
        public virtual Post Post { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Date { get; set; }
        
        
    }
}
