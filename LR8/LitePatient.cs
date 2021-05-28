using System;
using System.Collections.Generic;
using System.Text;

namespace LR3
{
    sealed class LitePatient : Patient
    {
        public LitePatient(int id, int age, String name, int weight, int height, int phoneNumber, int healthPoints) :
            base(id, age, name, weight, height, phoneNumber, healthPoints)
        { }

        public override void takePills()
        {
            HealthPoints += 5;
        }

        public override void checkAnalyzes()
        {
            if (analyzes.Blood > 14)
                Console.WriteLine("You have problems with blood");
            if (analyzes.Urine > 17)
                Console.WriteLine("You have problems with urine");
            if (analyzes.Blood <= 14 && analyzes.Urine <= 17)
                Console.WriteLine("You have good analyzes");
        }
    }
}
