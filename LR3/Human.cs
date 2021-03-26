using System;
using System.Collections.Generic;
using System.Text;

namespace LR3
{
    class Human
    {
        public int Id { get; private set; }
        private int Age;
        private String Name;
        private int Weight;
        private int Height;
        private int PhoneNumber;
        private int[] PhoneBook = new int[0];
        private int HealthPoints;
        private static int LimitHealthPoints;


        public Human() { }

        public Human(int id, int age, String name, int weight, int height, int phoneNumber, int healthPoints)
        {
            this.Id = id;
            setAge(age);
            setName(name);
            setWeight(weight);
            setHeight(height);
            setPhoneNumber(phoneNumber);
            setHealthPoints(healthPoints);
        }

        public int getAge()
        {
            return Age;
        }

        public void setAge(int age)
        {
            if (age < 0)
                Age = 17;
            else
                Age = age;
        }

        public String getName()
        {
            return Name;
        }

        public void setName(String name)
        {
            Name = name;
        }

        public int getWeight()
        {
            return Weight;
        }

        public void setWeight(int weight)
        {
            if (weight < 0)
                weight = 50;
            else
                Weight = weight;
        }

        public int getHeight()
        {
            return Height;
        }

        public void setHeight(int height)
        {
            if (height < 0)
                height = 170;
            else
                Height = height;
        }

        public int getPhoneNumber()
        {
            return PhoneNumber;
        }

        public void setPhoneNumber(int phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public int getHealthPoints()
        {
            return HealthPoints;
        }

        public void setHealthPoints(int healthPoints)
        {
            if (healthPoints < 0)
                HealthPoints = 80;
            else
            {
                HealthPoints = healthPoints;
            }
        }

        public int this[int index]
        {
            set
            {
                if (index > PhoneBook.Length + 1 || index < 0) return;
                int[] helper = new int[PhoneBook.Length + 1];
                for (int i = 0; i < PhoneBook.Length; i++)
                    helper[i] = PhoneBook[i];
                helper[PhoneBook.Length] = value;
                PhoneBook = helper;
            }
            get
            {
                if (index >= PhoneBook.Length || index < 0) return -1;
                return PhoneBook[index];
            }

        }

        public static int getLimitHealthPoints()
        {
            return LimitHealthPoints;
        }

        public static void setLimitHealthPoints(int limitHealthPoints)
        {
            if (limitHealthPoints < 0 || limitHealthPoints > 100)
                LimitHealthPoints = 70;
            else
                LimitHealthPoints = limitHealthPoints;
        }

        public void checkWeight()
        {
            int idealWeight = Height / 2 - 25;
            int limit = 3;
            if (idealWeight == Weight)
            {
                Console.WriteLine("You have ideal weight!");
            }
            else
            {
                if (idealWeight - limit < Weight && Weight < idealWeight + limit)
                {
                    Console.WriteLine("You weight is OK.");
                }
                else
                {
                    Console.WriteLine("You have problems with your weight!");
                }
            }
        }

        public void getSick()
        {
            HealthPoints -= 15;
        }

        public void getSick(int sickPoints)
        {
            if (sickPoints > HealthPoints)
            {
                Console.WriteLine("It is imposible or you dead, try again.");
                return;
            }
            HealthPoints -= sickPoints;
        }

        public bool checkGoToHospital()
        {
            if (HealthPoints < LimitHealthPoints)
            {
                Console.WriteLine("You need to go to Hospital!");
                return true;
            }
            else
            {
                Console.WriteLine("Your health is OK.");
                return false;
            }
        }

        public void goToHospital()
        {
            HealthPoints += 15;
        }

        public void printFullInfo()
        {
            Console.WriteLine("Name = {0}", Name);
            Console.WriteLine("Id = {0}", Id);
            Console.WriteLine("Age = {0}", Age);
            Console.WriteLine("Weight = {0}", Weight);
            Console.WriteLine("Heigth = {0}", Height);
            Console.WriteLine("Phone number = {0}", PhoneNumber);
            Console.WriteLine("Helth poitns = {0}", HealthPoints);
            Console.WriteLine("Limit health points = {0}", LimitHealthPoints);
        }
    }
}
