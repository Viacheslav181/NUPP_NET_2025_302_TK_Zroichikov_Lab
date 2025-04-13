using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Common;
using System;
using System.Collections.Generic;
using System.IO;


namespace Healthcare
{
    public class Program
    {
        static void Main(string[] args)
        {
            var patientService = new CrudService<Patient>();
            string filePath = "patients.json";

            // Завантажуємо з файлу
            patientService.Load(filePath);

            // Додаємо нових пацієнтів
            patientService.Create(new Patient("Ivan Ivanov", "Male", 35, "P001", "Flu", "INS001"));
            patientService.Create(new Patient("Anna Petrovna", "Female", 28, "P002", "Cold", "INS002"));
            patientService.Create(new Patient("Sergey Sidorov", "Male", 42, "P003", "Diabetes", "INS003"));

            Console.WriteLine("📋 Усі пацієнти:");
            foreach (var patient in patientService.ReadAll())
            {
                Console.WriteLine(patient.GetInfo());
            }

            // Оновлюємо діагноз
            patientService.Update(p => p.PatientId == "P002", p => p.Diagnosis = "Pneumonia");

            Console.WriteLine("\n🛠 Після оновлення:");
            foreach (var patient in patientService.ReadAll())
            {
                Console.WriteLine(patient.GetInfo());
            }

            // Видаляємо пацієнта
            patientService.Delete(p => p.PatientId == "P001");

            Console.WriteLine("\n🗑 Після видалення:");
            foreach (var patient in patientService.ReadAll())
            {
                Console.WriteLine(patient.GetInfo());
            }

            // Знаходимо пацієнта
            var foundPatient = patientService.Read(p => p.PatientId == "P002");
            Console.WriteLine("\n🔍 Знайдено пацієнта:");
            Console.WriteLine(foundPatient?.GetInfo());

            // Зберігаємо до файлу
            patientService.Save(filePath);

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
}
