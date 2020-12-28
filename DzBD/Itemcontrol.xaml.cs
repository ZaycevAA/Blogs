using DzBD.DataBase;
using DzBD.Pages;
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

namespace DzBD
{
    /// <summary>
    /// Логика взаимодействия для Itemcontrol.xaml
    /// </summary>
    public partial class Itemcontrol : UserControl
    {
        public Post Post { get; set; }
        public Itemcontrol()
        {
            InitializeComponent();
            
           
        }
        private void DeleteClick(object sender, RoutedEventArgs e)
        {

            var post = pop(sender);

            if (MessageBox.Show($"Удалить {post.Title}?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes) == MessageBoxResult.Yes)
            {
                Instance.DB.Posts.Remove(post);
                Instance.DB.SaveChanges();
                if (Instance.More == ((Window.GetWindow(this) as MainWindow).NavigationService.Content))
                {
                    (Window.GetWindow(this) as MainWindow).NavigationService.Navigate(Instance.PageWindow= new Pagewindow());
                    (Window.GetWindow(this) as MainWindow).NavigationService.RemoveBackEntry(); ;
                }
                
                

                if (Instance.PageWindow.mypost == false)
                {
                    Instance.PageWindow.DGBLog.ItemsSource = Instance.DB.Posts.ToList().OrderByDescending(i => i.Date);
                }
                else
                {
                    if (App.CurentUser.IsAdmin==true)
                    {
                        Instance.PageWindow.CBUsers.ItemsSource = Instance.DB.Users.ToList();
                        Instance.PageWindow.CBUsers.SelectedItem = App.CurentUser;
                        Instance.PageWindow.DGBLog.ItemsSource = Instance.DB.Posts.ToList().Where<Post>(i => i.UserId == App.CurentUser.Id).OrderByDescending(i => i.Date);
                    }
                    else
                    {
                        Instance.PageWindow.DGBLog.ItemsSource = Instance.DB.Posts.ToList().Where<Post>(i => i.UserId == App.CurentUser.Id).OrderByDescending(i => i.Date);

                    }

                   
                }


            }




        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            var post = pop(sender);
            if (Instance.More == ((Window.GetWindow(this) as MainWindow).NavigationService.Content))
            {
                (Window.GetWindow(this) as MainWindow).NavigationService.Navigate(Instance.Addoredit = new Addoredit(post) {more=true});
            }
            else
            {
                (Window.GetWindow(this) as MainWindow).NavigationService.Navigate(Instance.Addoredit = new Addoredit(post));

            }
           
            (Window.GetWindow(this) as MainWindow).NavigationService.RemoveBackEntry();


        }

        private void MoreClick(object sender, RoutedEventArgs e)
        {
            var post = pop(sender);
            
            (Window.GetWindow(this) as MainWindow).NavigationService.Navigate( Instance.More=new More() { Post=post});
            (Window.GetWindow(this) as MainWindow).NavigationService.RemoveBackEntry();


        }

        private void LikeClick(object sender, RoutedEventArgs e)
        {
            var post = pop(sender);
            post.Likes = Instance.DB.Likes.Where(i => i.PostId == post.ID).ToList();
            var like = post.Likes.FirstOrDefault(i => i.UserId == App.CurentUser.Id);
            if (like != null)
            {

                Instance.DB.Likes.Remove(like);
                

            }
            else
            {
                like = new Like()
                {
                    PostId = post.ID,
                    UserId = App.CurentUser.Id
                };


                Instance.DB.Likes.Add(like);
               
            }
            Instance.DB.SaveChanges();
            DataContext = null;
            DataContext = Post;
            

        }
        private Post pop(object sender)
        {
            var hyperlink = sender as Hyperlink;
            return hyperlink.DataContext as Post;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Post = DataContext as Post;
            
            if (Instance.More==((Window.GetWindow(this)as MainWindow).NavigationService.Content))
            {
                BMore1.Visibility = Visibility.Collapsed;
                BMore2.Visibility = Visibility.Collapsed;
            }
        }
    }
}
