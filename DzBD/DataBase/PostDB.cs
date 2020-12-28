using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzBD.DataBase
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class PostDB : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Coment> Coments { get; set; }
        public DbSet<Like> Likes { get; set; }

        public PostDB() : base("server=localhost;port=3306;user=root;password=0000;database=PostDB")
        {
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-US");


            Database.CreateIfNotExists();
        }
    }
}
