using System;
using System.Collections.Generic;
using System.Text;

namespace LR3
{
    class Program
    {
        static void getInfoWithAnalyzes(IPatient patient, int blood, int urine)
        {
            patient.getInfo();
            patient.workWithAnalyzes(blood, urine);
        }

        static void Main(string[] args)
        {
            try
            {
                Patient Alex = new LitePatient(0, 10, "Lexa", 70, 180, 297536898, 80);
                Patient Sergey = new HardPatient(0, 16, "Sergey", 70, 180, 297536898, 80);
                Patient Danik = new RegularPatient(0, 13, "Danik", 70, 180, 297536898, 79);
                Patient Pavel = new HardPatient(0, 56, "Pavel", 70, 180, 297536898, 80);
                Patient Mihail = new RegularPatient(0, 14, "Mihail", 70, 180, 297536898, 80);

                var patients = new List<Patient> { Alex, Sergey, Danik, Pavel, Mihail };

                patients.Sort();

                foreach (Patient temp in patients)
                    getInfoWithAnalyzes(temp, 12, 16);

                Hospital hospital = new Hospital();

                foreach (Patient temp in patients)
                    hospital.LifeQueue += temp.getInfo;

                Console.WriteLine("\nLife queue:");
                hospital.getLifeQueue();

                foreach (Patient temp in patients)
                    hospital.OnlineQueue += temp.getInfo;

                Console.WriteLine("\nOnline queue:");
                hospital.getOnlineQueue();

                GetTestResult tests = Alex.checkBloodTest;
                tests += Sergey.checkCovidTest;
                tests += Danik.checkUrineTest;

                hospital.getTestResult(tests, 17);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
