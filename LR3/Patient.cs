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

    class Patient: Human
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

        public static void chechDoctor(int neddedDay)
        {
            DayOfWeek dayOfWeek;
            if (Enum.IsDefined(typeof(DayOfWeek), neddedDay))
            {
                dayOfWeek = (DayOfWeek)neddedDay;
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
    }
}
