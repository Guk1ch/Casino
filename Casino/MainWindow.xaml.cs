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
using Casino.DB;

namespace Casino
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
        private void btn_authoriz_Click(object sender, RoutedEventArgs e)
        {
            string log = tb_login.Text.Trim();
            string pas = pb_pass.Password.Trim();
            List<User> users = new List<User>(bd_connection.connection.User.ToList());
            var userExsist = users.Where(user => user.Login == log && user.Password == pas).FirstOrDefault();
            if (userExsist != null)
            {
                Properties.Settings.Default.Login = userExsist.Login;
                Properties.Settings.Default.Password = userExsist.Password;
                GameWindow playWindow = new GameWindow();
                playWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Невернвый логин или пароль");
            }
        }

        private void btn_regis_Click(object sender, RoutedEventArgs e)
        {
            RegWindow registrationWindow = new RegWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
