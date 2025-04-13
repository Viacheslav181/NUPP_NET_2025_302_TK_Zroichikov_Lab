using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Common
{
    public class Person
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        //  Статичне поле
        public static int PersonCount;

        //  Статичний конструктор
        static Person()
        {
            PersonCount = 0;
        }

        //  Конструктор
        public Person(string fullName, string gender, int age)
        {
            FullName = fullName;
            Gender = gender;
            Age = age;
            PersonCount++;
        }

        //  Метод
        public string GetInfo()
        {
            return $"{FullName}, {Gender}, {Age} years old";
        }

        //  Статичний метод
        public static int GetTotalPeople()
        {
            return PersonCount;
        }
    }
}
