using Healthcare.Common;

class Program
{
    static void Main()
    {
        Patient.LockExample();
        Patient.SemaphoreExample();
        Patient.AutoResetEventExample();
        Patient.ManualResetEventExample();
        Patient.MutexExample();

        Console.ReadLine();
    }
}