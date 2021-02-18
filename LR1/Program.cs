using System;
using System.Linq;

namespace LR1
{
    class Deck_of_cards
    {
        private int[] desk = new int[52];


        public int get_number_of_cards()
        {
            return desk.Length;
        }

        public void update()
        {
            desk = new int[52];

            for (int i = 0; i < 32; i++)
            {
                desk[i] = i / 4 + 2;
            }
            for (int i = 32; i < 48; i++)
            {
                desk[i] = 10;
            }
            for (int i = 48; i < 52; i++)
            {
                desk[i] = 11;
            }

        }

        public int get_card(int number_of_card)
        {
            var new_desk = new int[desk.Length - 1];
            int new_points = desk[number_of_card];

            for (int i = 0; i < number_of_card; i++)
            {
                new_desk[i] = desk[i];
            }
            for (int i = number_of_card + 1; i < desk.Length; i++)
            {
                new_desk[i - 1] = desk[i];
            }
            desk = new_desk;

            return new_points;
        }

        public void print()
        {
            Console.WriteLine();
            for (int i = 0; i < desk.Length; i++)
            {
                Console.WriteLine("card " + i + " = " + desk[i]);
            }
            Console.WriteLine();
        }

        public void number_of_cards_checker()
        {
            if (desk.Length < 13)
            {
                update();
            }
        }
    }


    class Player
    {
        private int points;
        bool auto_11_choser;

        public void print_points()
        {
            Console.WriteLine("Points: {0}\n", points);
        }

        public int get_points()
        {
            return points;
        }

        public void clean_points()
        {
            auto_11_choser = false;
            points = 0;
        }

        public bool take_card(Deck_of_cards desk, bool identify)
        {
            Random random_card = new Random();
            int new_card = random_card.Next(desk.get_number_of_cards());
            int add_points = desk.get_card(new_card);
            

            if (add_points == 11)
            {
                if (identify)
                {
                    Console.WriteLine("Choose 1 or 11 points: ");
                    if (Console.ReadLine() == "1")
                    {
                        add_points = 1;
                    }
                }
                else
                {
                    auto_11_choser = true;
                    if ((points + add_points) > 21)
                    {
                        add_points = 1;
                    }
                }
            }

            Console.WriteLine("Added points: " + add_points);
            points += add_points;

            if (auto_11_choser && points > 21)
            {
                points -= 10;
                Console.WriteLine("11 back to 1");
                auto_11_choser = false;
            }

            if (points > 21)
            {
                return true;
            }
            return false;
        }
    }


    class Program
    {
        static void players_turn(ref bool checker_of_points, Player player, Deck_of_cards desk)
        {
            checker_of_points = true;


            while (true)
            {
                Console.WriteLine("Print h - hit, s - stand: ");
                if (Console.ReadLine() == "h")
                {
                    if (player.take_card(desk, true))
                    {
                        player.print_points();
                        Console.WriteLine("\nYou lost\n");
                        checker_of_points = false;
                        break;
                    }
                    player.print_points();
                }
                else
                {
                    break;
                }
            }
        }

        static void dealers_turn(ref bool checker_of_points, Player dealer, Deck_of_cards desk)
        {
            if (checker_of_points)
            {
                Console.WriteLine("\nDealer playes\n");
                while (dealer.get_points() < 17)
                {
                    if (dealer.take_card(desk, false))
                    {
                        dealer.print_points();
                        Console.WriteLine("\ndealer lost\n");
                        checker_of_points = false;
                        break;
                    }
                    dealer.print_points();
                }
            }
        }

        static void compare_points(bool checker_of_points, Player player, Player dealer)
        {
            if (checker_of_points)
            {
                if (player.get_points() > dealer.get_points())
                {
                    Console.WriteLine("\nYou win");
                }
                else
                {
                    if (player.get_points() < dealer.get_points())
                    {
                        Console.WriteLine("\nYou lost");
                    }
                    else
                    {
                        Console.WriteLine("\nDraw");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Deck_of_cards desk = new Deck_of_cards();
            desk.update();
            Player player = new Player();
            Player dealer = new Player();
            bool checker_of_points = true;


            while (true)
            {
                player.clean_points();
                dealer.clean_points();
                desk.number_of_cards_checker();
                players_turn(ref checker_of_points, player, desk);
                dealers_turn(ref checker_of_points, dealer, desk);
                compare_points(checker_of_points, player, dealer);

                Console.WriteLine("\nPrint c - continue, f - finish: ");
                if (Console.ReadLine() != "c")
                {
                    break;
                }
                Console.WriteLine("\n");
            }

            //desk.print();
        }
    }
}
