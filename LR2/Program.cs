using System;
using System.Text;

namespace LR2
{
    class Program
    {
        static void program1()
        {
            string text;
            text = Console.ReadLine();
            string[] words = text.Split(new[] { ' ' });
            Array.Reverse(words);
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write("{0} ", words[i]);
            }
        }

        static bool checkVowels(char letter)
        {
            var allVowels = new Char[6] {'a', 'e', 'i', 'o', 'u', 'y' };

            for (int i = 0; i < 6; i++)
            {
                if (Char.ToLower(letter) == allVowels[i])
                {
                    return true;
                }
            }

            return false;
        }

        static char changeLetter(char letter)
        {
            switch (letter)
            {
                case 'z':
                    return 'a';
                case 'Z':
                    return 'A';
                default:
                    return (char)((int)letter + 1);
            }
        }

        static void program2() {
            StringBuilder text = new StringBuilder(Console.ReadLine());
            string staticText = text.ToString();
           
            for(int i = 0; i < text.Length - 1; i++)
            {
                if (checkVowels(staticText[i]))
                {
                    text[i + 1] = changeLetter(staticText[i + 1]);
                } 
            }

            Console.WriteLine(text);
        }

        static void program3()
        {
            StringBuilder text = new StringBuilder(Console.ReadLine());
            double number = 0;
            int rank = 0, n = text.Length - 1;
            int i = 0;

            for (; i < n; i++)
            {
                if (text[i] == '.' || text[i] == ',')
                {
                    rank = n - i;
                    text.Remove(i, 1);
                    i--;
                    continue;
                }
                number += (text[i] - '0') * Math.Pow(10, n - i - 1);
            }
            number /= Math.Pow(10, rank);

            Console.WriteLine("number = {0}; type: {1}", number, number.GetTypeCode());
        }

        static void Main(string[] args)
        {

            //program1();
            //program2();
            program3();
            
        }
    }
}
