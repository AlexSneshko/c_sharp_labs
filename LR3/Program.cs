using System;

namespace LR3
{ 
    class Program
    {
        static void Main(string[] args)
        {

            /*
            Human Alex = new Human(0, 18, "Lexa", 70, 180, 297536898, 90);
            Human Sergey = new Human(1, 18, "Sergey", 70, 180, 445789632, 90);
            Human.setLimitHealthPoints(70);
            Alex[0] = 297536898;
            Alex[5] = 295784125;
            Alex[1] = 445789632;

            Alex.checkWeight();
            Alex.checkGoToHospital();
            Alex.getSick();
            Alex.getSick(20);
            Alex.checkGoToHospital();
            Alex.goToHospital();
            Alex.checkGoToHospital();
            Alex.printFullInfo();
            Console.WriteLine("{0}, {1}, {2}", Alex[0], Alex[5], Alex[1]);
            */
            //Patient Alex = new Patient(0, 18, "Lexa", 70, 180, 297536898, 90);
            Patient Alex = new LitePatient(0, 18, "Lexa", 70, 180, 297536898, 90);
            Patient Sergey = new HardPatient(0, 18, "Sergey", 70, 180, 297536898, 90);
            Alex.getSick();
            Sergey.getSick();
            Alex.getTested(14, 10);
            Sergey.getTested(14, 10);
            Alex.checkAnalyzes();
            Sergey.checkAnalyzes();
            Patient.chechDoctor(4);
        }
    }
}
