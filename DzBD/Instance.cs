using DzBD.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DzBD.Pages
{
    public static class Instance
    {

        public static PostDB DB { get; set; } = new PostDB();
        public static Pagewindow PageWindow { get; set; } 
        public static Addoredit Addoredit { get; set; } 
        public static Login Login { get; set; } 
        public static More More { get; set; } 
        public static Singup Singup { get; set; } 
    }
}
