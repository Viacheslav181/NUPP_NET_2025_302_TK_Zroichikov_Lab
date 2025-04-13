using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Common
{
    //  Делегат
    public delegate void DoctorCertifiedHandler(string doctorName);

    public class Doctor : Person
    {
        public string Specialty { get; set; }
        public string LicenseNumber { get; set; }
        public int YearsOfExperience { get; set; }

        //  Подія
        public event DoctorCertifiedHandler OnCertified;

        //  Статичне поле
        public static int TotalDoctors;

        //  Статичний конструктор
        static Doctor()
        {
            TotalDoctors = 0;
        }

        //  Конструктор
        public Doctor(string fullName, string gender, int age, string specialty, string licenseNumber, int yearsOfExperience)
            : base(fullName, gender, age)
        {
            Specialty = specialty;
            LicenseNumber = licenseNumber;
            YearsOfExperience = yearsOfExperience;
            TotalDoctors++;
        }

        //  Метод
        public void Certify()
        {
            OnCertified?.Invoke(FullName);
        }

        //  Статичний метод
        public static int GetTotalDoctors()
        {
            return TotalDoctors;
        }
    }
}
