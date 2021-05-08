using System;
using System.Collections.Generic;

namespace LR3
{ 
    class Program
    {
        static void Main(string[] args)
        {

            IPatient Alex = new LitePatient(0, 10, "Lexa", 70, 180, 297536898, 80);
            IPatient Sergey = new HardPatient(0, 16, "Sergey", 70, 180, 297536898, 80);
            IPatient Danik = new RegularPatient(0, 13, "Danik", 70, 180, 297536898, 80);
            IPatient Pavel = new HardPatient(0, 9, "Pavel", 70, 180, 297536898, 80);
            IPatient Mihail = new RegularPatient(0, 14, "Mihail", 70, 180, 297536898, 80);

            var patients = new List<IPatient> { Alex, Sergey, Danik, Pavel, Mihail };
 
            patients.Sort();
            Alex.takePills();
            Sergey.takePills();
            
            foreach (IPatient temp in patients)
                temp.getInfo();

            Alex.workWithAnalyzes(12, 16);
            Sergey.workWithAnalyzes(12, 16);
            Danik.workWithAnalyzes(12, 16);

            Patient.chechDoctor(4);
        }
    }
}
