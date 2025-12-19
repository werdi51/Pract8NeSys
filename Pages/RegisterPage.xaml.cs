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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
            LastNameTextBox.Focus();
            SpecialisationComboBox.SelectedIndex = 0;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(MiddleNameTextBox.Text) ||
                SpecialisationComboBox.SelectedItem == null ||
                string.IsNullOrWhiteSpace(PasswordBox1.Password) ||
                string.IsNullOrWhiteSpace(PasswordBox2.Password))
            {
                MessageBox.Show("Все поля обязательны");
                return;
            }

            if (PasswordBox1.Password != PasswordBox2.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                PasswordBox1.Focus();
                return;
            }

            var existingDoctors = JSON.LoadAllDoctors();
            int newId = JSON.GenerateDoctorId(existingDoctors);

            var newDoctor = new Doctor
            {
                Id = newId,
                LastName = LastNameTextBox.Text.Trim(),
                Name = NameTextBox.Text.Trim(),
                MiddleName = MiddleNameTextBox.Text.Trim(),
                Specialisation = (SpecialisationComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "",
                Password = PasswordBox1.Password
            };

            JSON.SaveDoctor(newDoctor);

            MessageBox.Show($"врач зарегистрирован ID: {newId}");

            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
