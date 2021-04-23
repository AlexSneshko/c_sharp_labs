using System;
using System.Collections.Generic;
using System.Text;

namespace LR3
{
    sealed class HardPatient: Patient
    {
        public HardPatient(int id, int age, String name, int weight, int height, int phoneNumber, int healthPoints) :
            base(id, age, name, weight, height, phoneNumber, healthPoints)
        { }

        public void goToOperation()
        {
            HealthPoints += 20;
        }

        public override void checkAnalyzes()
        {
            if (analyzes.Blood > 10)
                Console.WriteLine("You have problems with blood");
            if (analyzes.Urine > 13)
                Console.WriteLine("You have problems with urine");
            if (analyzes.Blood <= 10 && analyzes.Urine <= 13)
                Console.WriteLine("You have good analyzes");
        }
    }
}
