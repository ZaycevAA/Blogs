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
    /// Логика взаимодействия для Singup.xaml
    /// </summary>
    public partial class Singup : Page
    {
        public User User { get; set; } = new User();

        public Singup()
        {
            InitializeComponent();
            DataContext = User;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Instance.PageWindow= new Pagewindow());
            NavigationService.RemoveBackEntry();
        }

        private void SingClick(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(User.Surname) &&
                !string.IsNullOrEmpty(User.Name) &&
                !string.IsNullOrEmpty(User.Login) &&
                !string.IsNullOrEmpty(TBPass.Text) &&
                TBPass.Text == User.Password && !Instance.DB.Users.Any(i=>i.Login==User.Login))
            {
                Instance.DB.Users.Add(User);
                Instance.DB.SaveChanges();
                App.CurentUser= Instance.DB.Users.Where(i => i.Login == User.Login).Single<User>();
                Instance.PageWindow = new Pagewindow();
                NavigationService.Navigate(Instance.PageWindow);
                NavigationService.RemoveBackEntry();
            }
            else
            {
                MessageBox.Show("Ты не прав");

            }
           

        }

        private void BSign_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            User.IsAdmin = true;
        }
    }
}
