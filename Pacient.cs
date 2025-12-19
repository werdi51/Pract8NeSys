using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Collections.ObjectModel;


namespace _7
{

    public class Pacient : INotifyPropertyChanged
    {


        public class AppointmentStory : INotifyPropertyChanged
        {
            private string _date;
            private int _doctor_id;
            private string _diagnosis;
            private string _recomendations;

            public string date
            {
                get => _date;
                set
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }

            public int doctor_id
            {
                get => _doctor_id;
                set
                {
                    _doctor_id = value;
                    OnPropertyChanged();
                }
            }

            public string Diagnosis
            {
                get => _diagnosis;
                set
                {
                    _diagnosis = value;
                    OnPropertyChanged();
                }
            }

            public string Recomendations
            {
                get => _recomendations;
                set
                {
                    _recomendations = value;
                    OnPropertyChanged();
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private int _id;
        private string _name;
        private string _lastName;
        private string _middleName;
        private string _birthday;
        private string _phoneNumber;
        private ObservableCollection<AppointmentStory> _appointmentStories;


        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string MiddleName
        {
            get => _middleName;
            set
            {
                _middleName = value;
                OnPropertyChanged();
            }
        }

        public string Birthday  
        {
            get => _birthday;
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<AppointmentStory> AppointmentStories
        {
            get => _appointmentStories ??= new ObservableCollection<AppointmentStory>();
            set
            {
                _appointmentStories = value;
                OnPropertyChanged();
            }
        }

        public Pacient()
        {
            _appointmentStories = new ObservableCollection<AppointmentStory>();
        }













        //private int _id;
        //private string _name="";
        //private string _lastName="";
        //private string _middleName="";
        //private DateTime? _birthdayDate;
        //private string _lastAppointment="";
        //private string _lastDoctorDisplay="";
        //private int _lastDoctorId=0;
        //private string _diagnosis="";
        //private string _recommendations="";

        //public int Id
        //{
        //    get => _id;
        //    set { _id = value; OnPropertyChanged(); }
        //}

        //public string Name
        //{
        //    get => _name;
        //    set { _name = value; OnPropertyChanged(); }
        //}

        //public string LastName
        //{
        //    get => _lastName;
        //    set { _lastName = value; OnPropertyChanged(); }
        //}

        //public string MiddleName
        //{
        //    get => _middleName;
        //    set { _middleName = value; OnPropertyChanged(); }
        //}

        //public DateTime? BirthdayDate
        //{
        //    get => _birthdayDate;
        //    set
        //    {
        //        if (_birthdayDate != value)
        //        {
        //            _birthdayDate = value;
        //            OnPropertyChanged();
        //            OnPropertyChanged(nameof(BirthdayString)); // Обновляем строковое представление
        //        }
        //    }
        //}
        //public string BirthdayString
        //{
        //    get
        //    {
        //        return _birthdayDate.HasValue
        //            ? _birthdayDate.Value.ToString("dd.MM.yyyy")
        //            : "Не указана";
        //    }
        //}


        ////public string Birthday
        ////{
        ////    get => _birthdayDate.HasValue ? _birthdayDate.Value.ToString("dd.MM.yyyy") : "";
        ////    set
        ////    {
        ////        if (!string.IsNullOrEmpty(value) && DateTime.TryParse(value, out DateTime date))
        ////        {
        ////            BirthdayDate = date;
        ////        }
        ////        else
        ////        {
        ////            BirthdayDate = null;
        ////        }
        ////    }
        ////}

        //public string LastAppointment
        //{
        //    get => _lastAppointment;
        //    set { _lastAppointment = value; OnPropertyChanged(); }
        //}

        //public string LastDoctorDisplay
        //{
        //    get => _lastDoctorDisplay;
        //    set
        //    {
        //        _lastDoctorDisplay = value;
        //        OnPropertyChanged();
        //    }
        //}
        //public int LastDoctorId
        //{
        //    get => _lastDoctorId;
        //    set
        //    {
        //        _lastDoctorId = value;
        //        OnPropertyChanged();
        //        UpdateLastDoctorDisplay();
        //    }
        //}
        //private void UpdateLastDoctorDisplay()
        //{
        //}
        //public string CurrentDoctorInfo
        //{
        //    get
        //    {

        //        if (LastDoctorId == 0) return "Врач не назначен";

        //        return $"Врач ID: {LastDoctorId}";
        //    }
        //}

        //public string Diagnosis
        //{
        //    get => _diagnosis;
        //    set { _diagnosis = value; OnPropertyChanged(); }
        //}

        //public string Recommendations
        //{
        //    get => _recommendations;
        //    set { _recommendations = value; OnPropertyChanged(); }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
