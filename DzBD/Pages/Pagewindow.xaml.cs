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
using DzBD;

namespace DzBD.Pages
{
    /// <summary>
    /// Логика взаимодействия для Pagewindow.xaml
    /// </summary>
    public partial class Pagewindow : Page
    {
        public bool mypost = false;
        public Pagewindow()
        {
            InitializeComponent();
            try
            {

                DataContext = Instance.PageWindow;
                DGBLog.ItemsSource = Instance.DB.Posts.ToList().OrderByDescending(i => i.Date);
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        private void AddClick(object sender, RoutedEventArgs e)
        {

            try
            {
             
                NavigationService.Navigate(Instance.Addoredit = new Addoredit());
                NavigationService.RemoveBackEntry();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
                if (mypost==true)
                {
                    if (App.CurentUser.IsAdmin==true)
                    {
                        var user = CBUsers.SelectedItem as User;
                        DGBLog.ItemsSource = Instance.DB.Posts.Where(i => i.UserId == user.Id).Where<Post>(i => i.Title.ToLower().Contains(TBSearch.Text.ToLower()) || i.Text.ToLower().Contains(TBSearch.Text.ToLower())).OrderByDescending(i => i.Date).ToList();

                    }
                    else
                    {
                        DGBLog.ItemsSource = Instance.DB.Posts.Where(i => i.UserId == App.CurentUser.Id).Where<Post>(i => i.Title.ToLower().Contains(TBSearch.Text.ToLower()) || i.Text.ToLower().Contains(TBSearch.Text.ToLower())).OrderByDescending(i => i.Date).ToList();
                            
                    }
                }
                else
                {
                    DGBLog.ItemsSource = Instance.DB.Posts.Where<Post>(i => i.User.Name.Contains(TBSearch.Text.ToLower()) || i.Title.ToLower().Contains(TBSearch.Text.ToLower()) || i.Text.ToLower().Contains(TBSearch.Text.ToLower())).OrderByDescending(i => i.Date).ToList();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }




        private void CBUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var user = CBUsers.SelectedItem as User;
            DGBLog.ItemsSource = Instance.DB.Posts.ToList().Where<Post>(i => i.UserId == user.Id).OrderByDescending(i => i.Date);
        }

        private void Log_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(Instance.Login = new Login());
            NavigationService.RemoveBackEntry();
            mypost = false;
            DGBLog.ItemsSource = Instance.DB.Posts.ToList().OrderByDescending(i => i.Date);
            BMyPosts.Content = "My profile";
            CBUsers.Visibility = Visibility.Collapsed;
            App.CurentUser = new User();

        }
        public void find() 
        {
            DGBLog.ItemsSource = Instance.DB.Posts.ToList().OrderByDescending(i => i.Date);
        }

        private void MypostClick(object sender, RoutedEventArgs e)
        {
            if (mypost == true)
            {

                DGBLog.ItemsSource = Instance.DB.Posts.ToList().OrderByDescending(i => i.Date);
                BMyPosts.Content = "My profile";
                CBUsers.Visibility = Visibility.Collapsed;
                mypost = false;



            }
            else
            {

                DGBLog.ItemsSource = Instance.DB.Posts.ToList().Where<Post>(i => i.UserId == App.CurentUser.Id).OrderByDescending(i => i.Date);
                BMyPosts.Content = "All posts";

                if (App.CurentUser.IsAdmin == true)
                {
                    CBUsers.Visibility = Visibility.Visible;
                    CBUsers.ItemsSource = Instance.DB.Users.ToList();
                    CBUsers.SelectedItem = App.CurentUser;
                }

                Instance.DB.SaveChanges();
                DGBLog.ItemsSource = Instance.DB.Posts.ToList().Where<Post>(i => i.UserId == App.CurentUser.Id).OrderByDescending(i => i.Date);

                mypost = true;
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.CurentUser.Id != 0)
            {
                Log.Content = "Login out";
                Add.Visibility = Visibility.Visible;
                BMyPosts.Visibility = Visibility.Visible;

            }
            else
            {
                Add.Visibility = Visibility.Collapsed;
                BMyPosts.Visibility = Visibility.Collapsed;
                Log.Content = "Login in";

            }
        }
    }
}
