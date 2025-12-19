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

namespace _7.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            IdTextBox.Focus();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string idText = IdTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(idText) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите ID и пароль");
                return;
            }

            if (!int.TryParse(idText, out int doctorId))
            {
                MessageBox.Show("ID должен быть числом");
                IdTextBox.SelectAll();
                IdTextBox.Focus();
                return;
            }

            var doctors = JSON.LoadAllDoctors();
            var doctor = doctors.FirstOrDefault(d => d.Id == doctorId && d.Password == password);

            if (doctor == null)
            {
                MessageBox.Show("Неверный ID или пароль");
                return;
            }

            NavigationService.Navigate(new MainPage(doctor));
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }
    }
}
