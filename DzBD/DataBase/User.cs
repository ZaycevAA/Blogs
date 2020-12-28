using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzBD.DataBase
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50), Required, Index("uniq", IsUnique = true)]
        public string Login { get; set; }

        [StringLength(50), Required]
        public string Password { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        
        [StringLength(100), Required]
        public string Surname { get; set; }
        public bool IsAdmin { get; set; }
        [NotMapped]
        public string Fullname { 
            get
            {
                return $"{Name} {Surname}";
            }
        }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Coment> Coments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }

    }

   
}
