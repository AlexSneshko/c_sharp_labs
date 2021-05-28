using System;
using System.Collections.Generic;
using System.Text;

namespace LR3
{
    delegate void MakeQueue();
    delegate void GetTestResult(int input);

    class Hospital
    {
        public int Capacity { get; private set; }

        private MakeQueue lifeQueue;
        public event MakeQueue LifeQueue
        {
            add
            {
                if (value.Target is LitePatient)
                {
                    Console.WriteLine($"Lite Patient {(value.Target as Patient).Name} is only allowed to Online Queue");
                    return;
                } 
                else if(value.Target is RegularPatient)
                {
                    int HP = (value.Target as RegularPatient).HealthPoints;

                    if (HP >= 80)
                    {
                        Console.WriteLine($"Regular Patient(HP>80) {(value.Target as Patient).Name} is only allowed to Online Queue");
                        return;
                    }
                }

                lifeQueue += () => Console.WriteLine("-------------------- \n{0}", value.Target);
                lifeQueue += value;
            }
            remove
            {
                lifeQueue -= value;
            }
        }

        public event MakeQueue OnlineQueue;
       
        public void getLifeQueue()
        {
            lifeQueue();
        }

        public void getOnlineQueue()
        {
            OnlineQueue();
        }

        public void getTestResult(GetTestResult test, int input)
        {
            Console.WriteLine();

            test(input);
        }
    }
}
