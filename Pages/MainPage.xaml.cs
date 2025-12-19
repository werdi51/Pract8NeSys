using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace _7.Pages
{
    public partial class MainPage : Page, INotifyPropertyChanged
    {
        private Doctor _currentDoctor;
        private Pacient _selectedPatient;
        private int _doctorsCount;
        private int _patientsCount;
        private ObservableCollection<Pacient> _patients; 
        private string _doctorInfoString;

        public Doctor CurrentDoctor
        {
            get => _currentDoctor;
            set
            {
                _currentDoctor = value;
                OnPropertyChanged();
                UpdateDoctorInfoString();
            }
        }

        public Pacient SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                OnPropertyChanged();
            }
        }

        public int DoctorsCount
        {
            get => _doctorsCount;
            set
            {
                _doctorsCount = value;
                OnPropertyChanged();
            }
        }

        public int PatientsCount
        {
            get => _patientsCount;
            set
            {
                _patientsCount = value;
                OnPropertyChanged();
            }
        }

        public string DoctorInfoString
        {
            get => _doctorInfoString;
            set
            {
                _doctorInfoString = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Pacient> Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                OnPropertyChanged();
                PatientsCount = _patients?.Count ?? 0;
            }
        }

        public MainPage(Doctor doctor)
        {
            InitializeComponent();

            DataContext = this;

            CurrentDoctor = doctor;
            LoadAllPatients();
            UpdateDoctorsCount();

            Loaded += Page_Loaded;
        }

        private void UpdateDoctorInfoString()
        {
            if (CurrentDoctor == null)
            {
                DoctorInfoString = "Врач: не выбран";
            }
            else
            {
                DoctorInfoString = $"Врач: {CurrentDoctor.LastName} {CurrentDoctor.Name} ({CurrentDoctor.Specialisation})";
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshAllData();
        }


        private void RefreshAllData()
        {
            UpdateDoctorsCount();
            LoadAllPatients();

            if (CurrentDoctor != null)
            {
                var refreshedDoctor = JSON.FindDoctorById(CurrentDoctor.Id);
                if (refreshedDoctor != null)
                {
                    CurrentDoctor = refreshedDoctor;
                }
            }

            if (SelectedPatient != null)
            {
                var refreshedPatient = JSON.FindPatientById(SelectedPatient.Id);
                if (refreshedPatient != null)
                {
                    SelectedPatient = refreshedPatient;
                }
                else
                {
                    SelectedPatient = null;
                }
            }
        }

        private void UpdateDoctorsCount()
        {
            var doctors = JSON.LoadAllDoctors();
            DoctorsCount = doctors.Count;
        }

        private void LoadAllPatients()
        {
            var patients = JSON.LoadAllPatients();
            Patients = new ObservableCollection<Pacient>(patients);
        }


        private void CreatePatientButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreatePatientPage(CurrentDoctor));
        }

        private void StartAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Сначала выберите пациента из списка");
                return;
            }

            NavigationService.Navigate(new AppointmentPage(CurrentDoctor, SelectedPatient));
        }

        private void EditPatientButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Сначала выберите пациента из списка");
                return;
            }

            NavigationService.Navigate(new EditPatientPage(CurrentDoctor, SelectedPatient));
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}