using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Common
{
    public class Patient
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string PatientId { get; set; }
        public string Diagnosis { get; set; }
        public string InsuranceId { get; set; }

        public Patient() { }

        public Patient(string name, string gender, int age, string patientId, string diagnosis, string insuranceId)
        {
            Name = name;
            Gender = gender;
            Age = age;
            PatientId = patientId;
            Diagnosis = diagnosis;
            InsuranceId = insuranceId;
        }

        public string GetInfo()
        {
            return $"{Name}, {Gender}, Age: {Age}, ID: {PatientId}, Diagnosis: {Diagnosis}, Insurance: {InsuranceId}";
        }
    }
}

