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

            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+/.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, pattern);
        }
        private bool isvalidpassword(string email)
        {
            //password
             
            string symvol = "!@#$%^&*()_+";
            return pass1.Any(x=> symvol.Contains(x));
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            var newlogin = login.Text;
            var newemail = email.Text;
            var newpassword = pass1.Text;
            var secondpassword = pass2.Text;

            var context = new AppDbContext();

            bool isvalid = true;
            //проверка почты
            if (!isvalidemail(newemail))
            {
                email.Text = "Неккоректный email";
                RED.BorderBrush = Brushes.Red;
                isvalid = false;
                return;

            }
            else
            {
                RED.BorderBrush = Brushes.MediumPurple;
                
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
        
    }
}
