using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegistrarionWindow.xaml
    /// </summary>
    public partial class RegistrarionWindow : Window
    {
        public RegistrarionWindow()
        {
            InitializeComponent();
        }

        private void vhod_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window1 main = new();
            main.Show();
            this.Close();
        }

        private void reg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
        private bool isvalidemail(string email)
        {
            //email

            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, pattern);
        }
        private bool isvalidpassword(string pass1)
        {
            //password
             
            string symvol = "!@#$%^&*()_+";
            return pass1.Any(x => symvol.Contains(x));
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            var newlogin = login.Text;
            var newemail = email.Text;
            var newpassword = pass1Password.Password;
            var secondpassword = pass2.Text;

            var context = new AppDbContext();

            bool isvalid = true;

            //проверка почты
            if (!isvalidemail(newemail))
            {
                emailtext.Text = "Неккоректный email";
                RED.BorderBrush = Brushes.Red;
                isvalid = false;
                return;

            }
            else
            {
                emailtext.Text = "";
                RED.BorderBrush = Brushes.MediumPurple;
                
            }

            //проверка пароля
            if (newpassword.Length<8)
            {
                text1.Text = "Слабый пароль";
                redpass1.BorderBrush = Brushes.Red;
                isvalid = false;
                return;
            }
            else
            {
                text1.Text = "";

                redpass1.BorderBrush= Brushes.MediumPurple;
            }


            //совпадение паролей
            if (newpassword != secondpassword)
            {
                text2.Text = "- пароли не совпадают";
                redpass2.BorderBrush = Brushes.Red;
                isvalid = false;
                return ;
            }
            else
            {
                text2.Text = "";
                redpass2.BorderBrush= Brushes.MediumPurple;
            }

            isvalid = true;
            
            var user_exist = context.Users.FirstOrDefault(x => x.login == newlogin);
            if (user_exist is not null)
            {
                MessageBox.Show("Такой пользователь уже зарегестрирован в системе");
                return;
            }
            var user = new User { login = newlogin, password = newpassword,email = newemail };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("Добро пожаловать в систему");
        }
        double eyecheck = 1;
        

        private void eyeopen_Click(object sender, RoutedEventArgs e)
        {
            eyecheck++;
            if (eyecheck %2 ==0)
            {
                pass1Box.Text = pass1Password.Password;
                pass1Password.Visibility = Visibility.Hidden;

                pass2.Text = pass2Password.Password;
                pass2Password.Visibility = Visibility.Hidden;

                eyeopen.Visibility = Visibility.Hidden;
                eyeclose.Visibility = Visibility.Visible;

            }
        }
        private void eyeclose_Click(object sender, RoutedEventArgs e)
        {
            eyecheck++;
            if (eyecheck % 2 != 0)
            {

                pass1Password.Password = pass1Box.Text;
                pass1Password.Visibility = Visibility.Visible;

                pass2Password.Password = pass2.Text;
                pass2Password.Visibility = Visibility.Visible;

                eyeclose.Visibility = Visibility.Hidden;
                eyeopen.Visibility = Visibility.Visible;
            }
        }
    }
}
