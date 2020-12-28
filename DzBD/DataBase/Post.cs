using DzBD.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzBD.DataBase
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int ID { get; set; }

        [StringLength(128), Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public DateTime? Datelast { get; set; }

        [NotMapped]
        public string Wasdate
        {
            get
            {
                if (Datelast == null)
                {
                    return $"Date:";
                }
                else
                {
                    return $"*Date:";
                }

            }
        }
        [NotMapped]
        public string Like
        {
            get
            {
                if (Instance.DB.Likes.FirstOrDefault(i => i.UserId == App.CurentUser.Id)!=null)
                {
                    return "#68a166";
                }
                else
                {
                    return "#d8d9d4";
                }

            }
        }
        [NotMapped]
        public string UserCor
        {
            get
            {
                if (App.CurentUser.Id == UserId || App.CurentUser.IsAdmin == true)
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }

            }
        }
        [NotMapped]
        public string LCor
        {
            get
            {
                if (App.CurentUser.Id!=0)
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }

            }
        }



        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Coment> Coments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }




    }

}
