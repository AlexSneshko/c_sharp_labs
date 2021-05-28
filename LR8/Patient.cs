using System;
using System.Collections.Generic;
using System.Text;

namespace LR3
{
    enum DayOfWeek
    {
        Moday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday, 
        Sunday
    }

    struct Analyzes
    {
        public int Blood;
        public int Urine;
    }

    abstract class Patient: Human, IPatient, IComparable
    {
        
        protected Analyzes analyzes;
        public string Diagnosis { get; protected set; }

        public Patient(int id, int age, String name, int weight, int height, int phoneNumber, int healthPoints) :
            base(id, age, name, weight, height, phoneNumber, healthPoints)
        { }
        
        public virtual void takePills()
        {
            HealthPoints += 10;
        }

        public void getTested(int blood, int urine)
        {
            analyzes.Blood = blood;
            analyzes.Urine = urine;
        }

        
        public virtual void checkAnalyzes()
        {
            if (analyzes.Blood > 12)
                Console.WriteLine("You have problems with blood");
            if (analyzes.Urine > 15)
                Console.WriteLine("You have problems with urine");
            if (analyzes.Blood <= 12 && analyzes.Urine <= 15)
                Console.WriteLine("You have good analyzes");
        }

        public void checkBloodTest(int blood)
        {
            Console.Write(Name + ": ");
            if (blood > 12)
                Console.WriteLine("You have problems with blood");
            else
                Console.WriteLine("Your blood is OK");
        }

        public void checkUrineTest(int urine)
        {
            Console.Write(Name + ": ");
            if (urine > 15)
                Console.WriteLine("You have problems with urine");
            else
                Console.WriteLine("Your urine is OK");
        }

        public void checkCovidTest(int covid)
        {
            Console.Write(Name + ": ");
            if (covid > 40)
                Console.WriteLine("You have COVID");
            else
                Console.WriteLine("You dont have COVID");
        }

        public void workWithAnalyzes(int blood, int urine)
        {
            getTested(blood, urine);
            checkAnalyzes();
            Console.WriteLine();
        }

        public static void chechDoctor(int neddedDay)
        {
            if (Enum.IsDefined(typeof(DayOfWeek), neddedDay))
            {
                DayOfWeek dayOfWeek = (DayOfWeek)neddedDay;
                if (dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Thursday)
                    Console.WriteLine("Doc is not present this day");
                else
                    Console.WriteLine("Doc is present this day");
            }
            else
            {
                Console.WriteLine("Check day of the week");
            }
        }

        public void getInfo()
        {
            Console.WriteLine($"Name: {Name}, age: {Age}");
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Patient otherPatient = obj as Patient;

            if (otherPatient != null)
                return this.age.CompareTo(otherPatient.age);
            else
                throw new ArgumentException("Object is not a patient");
        }
    }
}
