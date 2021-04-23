using System;
using System.Collections.Generic;
using System.Text;

namespace LR3
{
    sealed class RegularPatient: Patient
    {
        public RegularPatient(int id, int age, String name, int weight, int height, int phoneNumber, int healthPoints) :
            base(id, age, name, weight, height, phoneNumber, healthPoints)
        { }

        public override void takePills()
        {
            base.takePills();
        }

        public override void checkAnalyzes()
        {
            base.checkAnalyzes();
        }
    }
}
