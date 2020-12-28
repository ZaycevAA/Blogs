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
    /// Логика взаимодействия для Addoredit.xaml
    /// </summary>
    public partial class Addoredit : Page
    {
        public Post Poste { get; set; } = new Post();
        public bool add = false;
        public bool more = false;
        public Addoredit()
        {
            InitializeComponent();
            DataContext = Poste;
            add = false;

        }
        public Addoredit(Post post)
        {
            InitializeComponent();
            Poste = post;
            DataContext = Poste;
            add = true;


        }


        private void CancelClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            NavigationService.RemoveBackEntry();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Poste.Text)&&!string.IsNullOrEmpty(Poste.Title))
            {
                if (add == true)
                {

                    Poste.Datelast = DateTime.Now;

                }
                else
                {
                    Poste.UserId = App.CurentUser.Id;
                    Poste.Date = DateTime.Now;
                    Instance.DB.Posts.Add(Poste);

                }
                Instance.DB.SaveChanges();
            }
            else
            {
                MessageBox.Show("Заполниете поля они не могут быть пустыми", "Подумой!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


            if (more == true) 
            {
                NavigationService.Navigate(Instance.More = new More() { Post=Poste});
            }
            else 
            {
                NavigationService.Navigate(Instance.PageWindow = new Pagewindow());
                
            }
            NavigationService.RemoveBackEntry();



        }
    }
}
