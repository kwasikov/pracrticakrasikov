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

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            var newlogin = login.Text;
            var newemail = email.Text;
            var newpasswod = pass1.Text;
            var secondpassword = pass2.Text;
        }
    }
}
