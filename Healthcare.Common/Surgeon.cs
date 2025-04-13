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
