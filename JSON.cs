using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _7
{
    public static class JSON
    {
        private static string doctorsFolder = "Doctors";
        private static string patientsFolder = "Patients";

        public static void SaveDoctor(Doctor doctor)
        {
            if (!Directory.Exists(doctorsFolder))
                Directory.CreateDirectory(doctorsFolder);

            string fileName = $"D_{doctor.Id}.json";
            string filePath = Path.Combine(doctorsFolder, fileName);

            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(doctor, options);
            File.WriteAllText(filePath, json);
        }

        public static List<Doctor> LoadAllDoctors()
        {
            var doctors = new List<Doctor>();

            if (!Directory.Exists(doctorsFolder))
                return doctors;

            string[] files = Directory.GetFiles(doctorsFolder, "D_*.json"); 

            foreach (string file in files)
            {
                try
                {
                    string json = File.ReadAllText(file);
                    var doctor = JsonSerializer.Deserialize<Doctor>(json);

                    string fileName = Path.GetFileNameWithoutExtension(file);
                    if (fileName.StartsWith("D_") && int.TryParse(fileName.Substring(2), out int id))
                    {
                        doctor.Id = id;
                    }

                    doctors.Add(doctor);
                }
                catch (Exception ex)
                {
                }
            }

            return doctors;
        }


        public static Doctor FindDoctorById(int id)
        {
            string fileName = $"{id}.json";
            string filePath = Path.Combine(doctorsFolder, fileName);

            if (!File.Exists(filePath))
                return null;

            try
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Doctor>(json);
            }
            catch
            {
                return null;
            }
        }

        public static int GenerateDoctorId(List<Doctor> existingDoctors)
        {
            Random rnd = new Random();
            int newId;
            bool isUnique;

            do
            {
                isUnique = true;
                newId = rnd.Next(10000, 99999);

                foreach (var doctor in existingDoctors)
                {
                    if (doctor.Id == newId)
                    {
                        isUnique = false;
                        break;
                    }
                }
            } while (!isUnique);

            return newId;
        }

        public static void SavePatient(Pacient patient)
        {
            if (!Directory.Exists(patientsFolder))
                Directory.CreateDirectory(patientsFolder);

            string fileName = $"P_{patient.Id}.json";
            string filePath = Path.Combine(patientsFolder, fileName);

            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(patient, options);
            File.WriteAllText(filePath, json);
        }

        public static List<Pacient> LoadAllPatients()
        {
            var patients = new List<Pacient>();

            if (!Directory.Exists(patientsFolder))
                return patients;

            string[] files = Directory.GetFiles(patientsFolder, "P_*.json"); 

            foreach (string file in files)
            {
                try
                {
                    string json = File.ReadAllText(file);
                    var patient = JsonSerializer.Deserialize<Pacient>(json);

                    string fileName = Path.GetFileNameWithoutExtension(file); 
                    if (fileName.StartsWith("P_") && int.TryParse(fileName.Substring(2), out int id))
                    {
                        patient.Id = id; 
                    }

                    patients.Add(patient);
                }
                catch (Exception ex)
                {
                }
            }

            return patients;
        }

        public static Pacient FindPatientById(int patientId)
        {
            string fileName = $"P_{patientId}.json";
            string filePath = Path.Combine(patientsFolder, fileName);

            if (!File.Exists(filePath))
                return null;

            try
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Pacient>(json);
            }
            catch
            {
                return null;
            }
        }

        public static int GeneratePatientId(List<Pacient> existingPatients)
        {
            Random rnd = new Random();
            int newId;
            bool isUnique;

            do
            {
                isUnique = true;
                newId = rnd.Next(1000000, 9999999);

                foreach (var patient in existingPatients)
                {
                    if (patient.Id == newId)
                    {
                        isUnique = false;
                        break;
                    }
                }
            } while (!isUnique);

            return newId;
        }

        
    }
}
