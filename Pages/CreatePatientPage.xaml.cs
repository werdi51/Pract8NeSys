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
    /// Логика взаимодействия для CreatePatientPage.xaml
    /// </summary>
    public partial class CreatePatientPage : Page
    {
        private Doctor _currentDoctor;

        public CreatePatientPage(Doctor doctor)
        {
            InitializeComponent();
            _currentDoctor = doctor;

            BirthdayDatePicker.DisplayDateEnd = DateTime.Today;
            LastNameTextBox.Focus();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(MiddleNameTextBox.Text) ||
                !BirthdayDatePicker.SelectedDate.HasValue ||
                string.IsNullOrWhiteSpace(PhoneTextBox.Text))
            {
                MessageBox.Show("Все поля обязательны");
                return;
            }

            if (BirthdayDatePicker.SelectedDate > DateTime.Today)
            {
                MessageBox.Show("Дата рождения не может быть в будущем");
                return;
            }

            string phone = PhoneTextBox.Text.Trim();
            if (!phone.StartsWith("+"))
            {
                MessageBox.Show("Телефон должен начинаться с +");
                return;
            }

            var existingPatients = JSON.LoadAllPatients();
            int newId = JSON.GeneratePatientId(existingPatients);

            var newPatient = new Pacient
            {
                Id = newId,
                LastName = LastNameTextBox.Text.Trim(),
                Name = NameTextBox.Text.Trim(),
                MiddleName = MiddleNameTextBox.Text.Trim(),
                Birthday = BirthdayDatePicker.SelectedDate.Value.ToString("dd.MM.yyyy"),
                PhoneNumber = phone
            };

            JSON.SavePatient(newPatient);

            MessageBox.Show($"Пациент создан! ID: {newId}");

            var mainPage = NavigationService.Content as MainPage;

            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
