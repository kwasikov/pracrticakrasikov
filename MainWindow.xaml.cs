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

namespace kras_lit
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void registr(object sender, MouseButtonEventArgs e)
        {
            RegistrarionWindow regWindow = new();
            regWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var Password = pass.Text;
            var loginoremail = login.Text;

            var context = new AppDbContext();
            var user = context.Users.SingleOrDefault(x => (x.login == loginoremail || x.email == loginoremail) && x.password == Password);

            if (user is null)
            {
                MessageBox.Show("Неправильный логин и пароль");
                return;
            }
            else
            {
                welcome welcomeWindow = new();
                welcomeWindow.Show();
                this.Close();
                MessageBox.Show($"Вы успешно вошли в аккаунт ваш логин {loginoremail}  и пароль {Password}");
            }

        }
        double eyecheck = 1;
        private void eyeopen_Click(object sender, RoutedEventArgs e)
        {
            eyecheck++;
            if (eyecheck % 2 == 0)
            {
                pass.Text = passPassword.Password;
                passPassword.Visibility = Visibility.Hidden;

                eyeopen.Visibility = Visibility.Hidden;
                eyeclose.Visibility = Visibility.Visible;

            }
        }
        private void eyeclose_Click(object sender, RoutedEventArgs e)
        {
            eyecheck++;
            if (eyecheck % 2 != 0)
            {

                passPassword.Password = pass.Text;
                passPassword.Visibility = Visibility.Visible;

                eyeclose.Visibility = Visibility.Hidden;
                eyeopen.Visibility = Visibility.Visible;
            }
        }
    }
}