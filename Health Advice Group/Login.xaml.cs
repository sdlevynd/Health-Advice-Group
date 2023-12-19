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
using MySql.Data.MySqlClient;

namespace Health_Advice_Group
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            data.connect();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            data.open();
            string loginUser = "SELECT count(email)" +
                " FROM users" +
                " WHERE email = @paramEmail" +
                " AND password = SHA2(@paramPassword,256);";
            MySqlCommand cmd = new MySqlCommand(loginUser, data.getConnection());
            cmd.Parameters.AddWithValue("@paramEmail", txtEmail.Text);
            cmd.Parameters.AddWithValue("@paramPassword", pbxPassword.Password);
            var check = cmd.ExecuteScalar();
            data.close();
            if ((long)check != 0)
            {
                Menu menu = new Menu();
                menu.Show();
                menu.Focus();
                this.Close();
            }
            else
            {
                lblMessage.Foreground = new SolidColorBrush(Colors.Red);
                lblMessage.Content = "Login Failed";
            }
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            data.open();
            string checkUser = "SELECT email" +
                " FROM users" +
                " WHERE email = @paramEmail";
            MySqlCommand cmd = new MySqlCommand(checkUser, data.getConnection());
            cmd.Parameters.AddWithValue("@paramEmail",txtEmail.Text);
            var result = cmd.ExecuteScalar();
            if (result == null)
            {
                string registerUser = "INSERT INTO users (email, password)" +
                    " VALUES (@paramEmail, SHA2(@paramPassword,256));";
                cmd = new MySqlCommand(registerUser, data.getConnection());
                cmd.Parameters.AddWithValue("@paramEmail", txtEmail.Text);
                cmd.Parameters.AddWithValue("@paramPassword", pbxPassword.Password);
                cmd.ExecuteNonQuery();
                lblMessage.Foreground = new SolidColorBrush(Colors.Green);
                lblMessage.Content = "Account Registered";
            }
            data.close();
        }
    }
}
