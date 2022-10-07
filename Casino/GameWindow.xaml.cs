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
using Casino.DB;

namespace Casino
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public static User userG { get; set; }
        public GameWindow()
        {
            InitializeComponent();
            string log = Properties.Settings.Default.Login;
            string pas = Properties.Settings.Default.Password;
            List<User> users = new List<User>(bd_connection.connection.User.ToList());
            userG = users.Where(user => user.Login == log && user.Password == pas).FirstOrDefault();
            tb_count.Text = userG.CountXP.ToString();
            tb_name.Text = userG.Name;
        }
        private void btn_rnd_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int r1 = rnd.Next(1, 6);
            int r2 = rnd.Next(1, 6);
            int r3 = rnd.Next(1, 6);


            if (r1 == 1)
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\1.png"));
            }
            else if (r1 == 2)
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\2.png"));
            }
            else if (r1 == 3)
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\3.png"));
            }
            else if (r1 == 4)
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\4.png"));
            }
            else
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\5.png"));
            }

            if (r2 == 1)
            {
                img2.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\1.png"));
            }
            else if (r2 == 2)
            {
                img2.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\2.png"));
            }
            else if (r2 == 3)
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\3.png"));
            }
            else if (r2 == 4)
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\4.png"));
            }
            else
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\5.png"));
            }

            if (r3 == 1)
            {
                img3.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\1.png"));
            }
            else if (r3 == 2)
            {
                img3.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\2.png"));
            }
            else if (r3 == 3)
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\3.png"));
            }
            else if (r3 == 4)
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\4.png"));
            }
            else
            {
                img1.Source = new BitmapImage(new Uri("C:\\Users\\Gukich\\source\\repos\\Casino\\Casino\\img\\5.png"));
            }
            if (r1 == r2 && r2 == r3)
            {
                userG.CountXP += 1000;
            }
            else
            {
                if (r1 == r2 || r2 == r3 || r1 == r3)
                {
                    userG.CountXP += 100;
                }
                else
                {
                    userG.CountXP -= 10;
                }
            }

            bd_connection.connection.SaveChanges();
            tb_count.Text = userG.CountXP.ToString();
        }
    }
}
