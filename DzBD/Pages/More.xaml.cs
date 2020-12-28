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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DzBD.Pages
{
    /// <summary>
    /// Логика взаимодействия для More.xaml
    /// </summary>
    public partial class More : Page
    {
        public Post Post { get; set; }
        public Coment Coment { get; set; } = new Coment();


        public More()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += More_Loaded;
        }

        private void More_Loaded(object sender, RoutedEventArgs e)
        {
            ICComent.ItemsSource = Instance.DB.Coments.Where(i => i.PostId == Post.ID).OrderByDescending(i => i.Date).ToList();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(Instance.PageWindow = new Pagewindow());
            NavigationService.RemoveBackEntry();
        }

        private void SendClick(object sender, RoutedEventArgs e)
        {
            if (App.CurentUser.Id != 0 &&
                !string.IsNullOrEmpty(TBCum.Text))
            {
                Coment.PostId = Post.ID;
                Coment.UserId = App.CurentUser.Id;
                Coment.Date = DateTime.Now;
                Coment.Text = TBCum.Text;
                Instance.DB.Coments.Add(Coment);
                Instance.DB.SaveChanges();
                Coment = new Coment();
                TBCum.Text = null;

            }
            else
            {
                MessageBox.Show("Не неполучиться");
            }

            ICComent.ItemsSource = Instance.DB.Coments.Where(i => i.PostId == Post.ID).OrderByDescending(i => i.Date).ToList();
            ICpost.DataContext = null;
            ICpost.DataContext = Post;
            


        }

    
      
    }
}
