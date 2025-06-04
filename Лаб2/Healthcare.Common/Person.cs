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

        public static Person CreateNew()
        {
            var random = new Random();
            string[] names = { "Ivan Petrenko", "Olga Tkachenko", "Nazar Bondar" };
            string[] genders = { "Male", "Female" };

            return new Person(
                names[random.Next(names.Length)],
                genders[random.Next(genders.Length)],
                random.Next(18, 80)
            );
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
