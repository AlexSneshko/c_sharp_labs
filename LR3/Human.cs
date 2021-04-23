﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LR3
{
    abstract class Human
    {
        public int Id { get; protected set; }
        public String Name { get; protected set; }
        protected int age;
        public int Age {
            get
            {
                return age;
            }
            protected set
            {
                if (value < 0)
                    age = 17;
                else
                    age = value;
            }
        }
        protected int weight;
        public int Weight
        {
            get
            {
                return weight;
            }
            protected set
            {
                if (value < 0)
                    weight = 50;
                else
                    weight = value;
            }
        }
        protected int height;
        public int Height
        {
            get
            {
                return height;
            }
            protected set
            {
                if (value < 0)
                    height = 170;
                else
                    height = value;
            }
        }
        public int PhoneNumber { get; protected set; }
        private int[] PhoneBook = new int[0];
        protected int healthPoints;
        public int HealthPoints
        {
            get
            {
                return healthPoints;
            }
            protected set
            {
                if (value < 0)
                    healthPoints = 80;
                else
                    healthPoints = value;
            }
        }
        protected static int limitHealthPoints;
        public static int LimitHealthPoints
        {
            get
            {
                return limitHealthPoints;
            }
            protected set
            {
                if (value < 0 || value > 100)
                    limitHealthPoints = 70;
                else
                    limitHealthPoints = value;
            }
        }

        public Human(int id, int age, String name, int weight, int height, int phoneNumber, int healthPoints)
        {
            Id = id;
            Age = age;
            Name = name;
            Weight = weight;
            Height = height;
            PhoneNumber = phoneNumber;
            HealthPoints = healthPoints;
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
