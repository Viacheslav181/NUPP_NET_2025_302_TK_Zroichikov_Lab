using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Common
{
    public class Surgeon : Doctor
    {
        public bool PerformsTransplants { get; set; }
        public int MonthlySurgeries { get; set; }
        public string OperatingRoom { get; set; }

        //  Статичне поле
        public static int TotalSurgeons;

        //  Статичний конструктор
        static Surgeon()
        {
            TotalSurgeons = 0;
        }

        //  Конструктор
        public Surgeon(string fullName, string gender, int age,
                       string specialty, string licenseNumber, int yearsOfExperience,
                       bool performsTransplants, int monthlySurgeries, string operatingRoom)
            : base(fullName, gender, age, specialty, licenseNumber, yearsOfExperience)
        {
            PerformsTransplants = performsTransplants;
            MonthlySurgeries = monthlySurgeries;
            OperatingRoom = operatingRoom;
            TotalSurgeons++;
        }

        public static Surgeon CreateNew()
        {
            var random = new Random();
            string[] names = { "Dr. Yaroslav", "Dr. Daria" };
            string[] genders = { "Male", "Female" };
            string[] specialties = { "Neurosurgeon", "Orthopedic", "Cardiac" };
            string[] rooms = { "OR-1", "OR-2", "OR-3" };

            return new Surgeon(
                names[random.Next(names.Length)],
                genders[random.Next(genders.Length)],
                random.Next(30, 65),
                specialties[random.Next(specialties.Length)],
                $"LIC-{random.Next(10000, 99999)}",
                random.Next(5, 30),
                random.Next(0, 2) == 0,
                random.Next(10, 100),
                rooms[random.Next(rooms.Length)]
            );
        }

        //  Метод
        public string GetStats()
        {
            return $"{FullName} performs {MonthlySurgeries} surgeries/month in {OperatingRoom}.";
        }

        //  Статичний метод
        public static int GetTotalSurgeons()
        {
            return TotalSurgeons;
        }
    }
}
