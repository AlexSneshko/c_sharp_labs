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
            if (letter == 'z')
            {
                return 'a';
            }
            return (char)((int)letter + 1);
        }

        static void program2() {
            string text1 = Console.ReadLine();
            StringBuilder text = new StringBuilder(text1);
            char letter = '0';

            for(int i = 0; i < text.Length - 1; i++)
            {
                if (checkVowels(text[i]))
                {
                    letter = text[i + 1];
                    text[i + 1] = changeLetter(letter);
                } 
            }

            Console.WriteLine(text);
        }

        static void program3()
        {
            StringBuilder text = new StringBuilder();
            string stText = Console.ReadLine();
            text.Append(stText);
            double number = 0;
            int rank = 0, n = text.Length - 1;

            for (int i = 0; i < n; i++)
            {
                if (text[i] == '.' || text[i] == ',')
                {
                    rank = i + 1;
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
            //program3();
            
        }
    }
}
