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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public User User { get; set; } = new User();
        public Login()
        {
            InitializeComponent();
            
            DataContext = User;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Instance.PageWindow = new Pagewindow();
            NavigationService.Navigate(Instance.PageWindow);
            NavigationService.RemoveBackEntry();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Instance.DB.Users.Where(i => i.Login == User.Login && i.Password == User.Password).Count() == 1)
            {
                App.CurentUser = Instance.DB.Users.Where(i => i.Login == User.Login).Single<User>();
                
                NavigationService.GoBack();
                NavigationService.RemoveBackEntry();
            }
            else
            {
                MessageBox.Show("Ты не прав");
            }
        }

        private void RegClick(object sender, RoutedEventArgs e)
        {
            Instance.Singup = new Singup();
            NavigationService.Navigate(Instance.Singup);
            NavigationService.RemoveBackEntry();

        }
    }
}
