using DzBD.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DzBD
{
    /// <summary>
    /// Логика взаимодействия для Addoredit.xaml
    /// </summary>
    public partial class Addoredit : Window
    {
        public string Text { get; set; }
        public string Title { get; set; }
        public Addoredit()
        {
            InitializeComponent();

            
        }
        public Addoredit(Post post)
        {
            InitializeComponent();

            Text = post.Text;
            Title = post.Title;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Text = TBtext.Text;
            Title = TBtitle.Text;
            DialogResult = true;
        }
    }
}
