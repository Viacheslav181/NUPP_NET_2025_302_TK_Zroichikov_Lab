using System;
using System.Threading;

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

        private static readonly string[] FirstNames = { "Anna", "Ivan", "Sergey", "Olga", "Maria", "Petro", "Dmytro" };
        private static readonly string[] LastNames = { "Ivanov", "Petrova", "Sidorov", "Tkachenko", "Shevchenko" };
        private static readonly string[] Diagnoses = { "Cold", "Flu", "Diabetes", "Covid-19", "Pneumonia" };
        private static readonly string[] Insurances = { "INS001", "INS002", "INS003", "INS004" };
        private static readonly string[] Genders = { "Male", "Female" };

        private static readonly Random random = new Random();

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

        public static Patient CreateNew()
        {
            var firstName = FirstNames[random.Next(FirstNames.Length)];
            var lastName = LastNames[random.Next(LastNames.Length)];
            var fullName = $"{firstName} {lastName}";

            return new Patient
            {
                Name = fullName,
                Gender = Genders[random.Next(Genders.Length)],
                Age = random.Next(18, 90),
                PatientId = Guid.NewGuid().ToString(),
                Diagnosis = Diagnoses[random.Next(Diagnoses.Length)],
                InsuranceId = Insurances[random.Next(Insurances.Length)]
            };
        }

        public string GetInfo()
        {
            return $"{Name}, {Gender}, Age: {Age}, ID: {PatientId}, Diagnosis: {Diagnosis}, Insurance: {InsuranceId}";
        }

        // === Примітиви синхронізації ===

        private static object lockObj = new object();
        private static int sharedCounter = 0;

        public static void LockExample()
        {
            void Increment()
            {
                for (int i = 0; i < 1000; i++)
                {
                    lock (lockObj)
                    {
                        sharedCounter++;
                    }
                }
            }

            Thread t1 = new Thread(Increment);
            Thread t2 = new Thread(Increment);
            t1.Start(); t2.Start();
            t1.Join(); t2.Join();

            Console.WriteLine($"LockExample: sharedCounter = {sharedCounter}");
        }

        private static Semaphore semaphore = new Semaphore(2, 2);

        public static void SemaphoreExample()
        {
            void Access(int id)
            {
                Console.WriteLine($"Потік {id} чекає доступ...");
                semaphore.WaitOne();
                Console.WriteLine($"Потік {id} працює...");
                Thread.Sleep(1000);
                Console.WriteLine($"Потік {id} завершує.");
                semaphore.Release();
            }

            for (int i = 0; i < 5; i++)
            {
                int localId = i;
                new Thread(() => Access(localId)).Start();
            }
        }

        private static AutoResetEvent autoEvent = new AutoResetEvent(false);

        public static void AutoResetEventExample()
        {
            new Thread(() =>
            {
                Console.WriteLine("AutoResetEvent: Потік чекає...");
                autoEvent.WaitOne();
                Console.WriteLine("AutoResetEvent: Отримано сигнал!");
            }).Start();

            Thread.Sleep(1000);
            Console.WriteLine("AutoResetEvent: Відправка сигналу...");
            autoEvent.Set();
        }

        private static ManualResetEvent manualEvent = new ManualResetEvent(false);

        public static void ManualResetEventExample()
        {
            for (int i = 0; i < 3; i++)
            {
                new Thread(() =>
                {
                    Console.WriteLine("ManualResetEvent: Потік чекає...");
                    manualEvent.WaitOne();
                    Console.WriteLine("ManualResetEvent: Потік продовжив роботу.");
                }).Start();
            }

            Thread.Sleep(1000);
            Console.WriteLine("ManualResetEvent: Надсилається сигнал...");
            manualEvent.Set(); // Всі потоки продовжують
        }

        private static Mutex mutex = new Mutex();

        public static void MutexExample()
        {
            void Work(int id)
            {
                Console.WriteLine($"Mutex: Потік {id} чекає...");
                mutex.WaitOne();
                Console.WriteLine($"Mutex: Потік {id} працює...");
                Thread.Sleep(500);
                Console.WriteLine($"Mutex: Потік {id} завершує.");
                mutex.ReleaseMutex();
            }

            for (int i = 0; i < 3; i++)
            {
                int localId = i;
                new Thread(() => Work(localId)).Start();
            }
        }
    }
}
