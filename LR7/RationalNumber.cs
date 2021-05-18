using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LR7
{
    class RationalNumber:IComparable<RationalNumber>
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0) throw new DivideByZeroException("/0 not allowed");
           
            Numerator = numerator;
            Denominator = denominator;
        }

        public static int GetNOD(int number1, int number2)
        {
            if (number1 == 0) return number2;
            return GetNOD(number2 % number1, number1);
        }

        public static int GetNOK(int number1, int number2)
        {
            return number1 * number2 / GetNOD(number1, number2);
        }

        public static void Reduce(RationalNumber number)
        {   
            int NOD = GetNOD(number.Numerator, number.Denominator);
            number.Numerator /= NOD;
            number.Denominator /= NOD;
            Console.WriteLine($"{number.Numerator} / {number.Denominator}");
        }

        public static void ToCommonDenomirator(RationalNumber number1, RationalNumber number2)
        {
            int NOK = GetNOK(number1.Denominator, number2.Denominator);
            number1.Numerator = number1.Numerator * (NOK / number1.Denominator);
            number2.Numerator = number2.Numerator * (NOK / number2.Denominator);
            number1.Denominator = NOK;
            number2.Denominator = NOK;
        }
        
        public static RationalNumber operator + (RationalNumber number1, RationalNumber number2)
        {
            Reduce(number1);
            Reduce(number2);
            ToCommonDenomirator(number1, number2);

            return new RationalNumber(number1.Numerator + number2.Numerator, number1.Denominator);
        }

        public static RationalNumber operator +(RationalNumber number1, int number2)
        {
            Reduce(number1);

            return new RationalNumber(number1.Numerator + number2 * number1.Denominator, number1.Denominator);
        }

        public static RationalNumber operator -(RationalNumber number1, RationalNumber number2)
        {
            Reduce(number1);
            Reduce(number2);
            ToCommonDenomirator(number1, number2);

            return new RationalNumber(number1.Numerator - number2.Numerator, number1.Denominator);
        }

        public static RationalNumber operator -(RationalNumber number1, int number2)
        {
            Reduce(number1);

            return new RationalNumber(number1.Numerator - number2 * number1.Denominator, number1.Denominator);
        }

        public static RationalNumber operator *(RationalNumber number1, RationalNumber number2)
        {
            Reduce(number1);
            Reduce(number2);

            var result = new RationalNumber(number1.Numerator * number2.Numerator, number1.Denominator * number2.Denominator);
            Reduce(result);

            return result;
        }

        public static RationalNumber operator *(RationalNumber number1, int number2)
        {
            Reduce(number1);

            var result = new RationalNumber(number1.Numerator * number2, number1.Denominator);
            Reduce(result);

            return result;
        }

        public static RationalNumber operator /(RationalNumber number1, RationalNumber number2)
        {
            Reduce(number1);
            Reduce(number2);

            var result = new RationalNumber(number1.Numerator * number2.Denominator, number1.Denominator * number2.Numerator);
            Reduce(result);

            return result;
        }

        public static RationalNumber operator /(RationalNumber number1, int number2)
        {
            Reduce(number1);

            var result = new RationalNumber(number1.Numerator, number1.Denominator * number2);
            Reduce(result);

            return result;
        }

        public static RationalNumber operator ++(RationalNumber number1)
        {
            Reduce(number1);

            return new RationalNumber(number1.Numerator + number1.Denominator, number1.Denominator);
        }

        public static RationalNumber operator --(RationalNumber number1)
        {
            Reduce(number1);

            return new RationalNumber(number1.Numerator - number1.Denominator, number1.Denominator);
        }

        public static bool operator ==(RationalNumber number1, RationalNumber number2)
        {
            Reduce(number1);
            Reduce(number2);

            return (number1.Numerator == number2.Numerator) && (number1.Denominator == number2.Denominator);
        }

        public static bool operator ==(RationalNumber number1, int number2)
        {
            Reduce(number1);

            return (number1.Numerator == number2) && (number1.Denominator == 1);
        }

        public static bool operator !=(RationalNumber number1, RationalNumber number2)
        {
            Reduce(number1);
            Reduce(number2);

            return (number1.Numerator != number2.Numerator) || (number1.Denominator != number2.Denominator);
        }

        public static bool operator !=(RationalNumber number1, int number2)
        {
            Reduce(number1);

            return (number1.Numerator != number2) || (number1.Denominator != 1);
        }

        public static bool operator <(RationalNumber number1, RationalNumber number2)
        {
            Reduce(number1);
            Reduce(number2);
            ToCommonDenomirator(number1, number2);

            return number1.Numerator < number2.Numerator;
        }

        public static bool operator <(RationalNumber number1, int number2)
        {
            Reduce(number1);

            return number1.Numerator < number2 * number1.Denominator;
        }

        public static bool operator >(RationalNumber number1, RationalNumber number2)
        {
            Reduce(number1);
            Reduce(number2);
            ToCommonDenomirator(number1, number2);

            return number1.Numerator > number2.Numerator;
        }

        public static bool operator >(RationalNumber number1, int number2)
        {
            Reduce(number1);

            return number1.Numerator > number2 * number1.Denominator;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) throw new Exception("Wrong operand");

            return this == (RationalNumber)obj;
        }

        public override int GetHashCode()
        {
            return (Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator)).GetHashCode();
        }

        public int CompareTo(RationalNumber other)
        {
            if (this < other) return -1;
            if (this > other) return 1;
            return 0;
        }

        public static implicit operator RationalNumber(int number)
        {
            return new RationalNumber(number, 1);
        }

        public static explicit operator int(RationalNumber number)
        {
            int wholePart = number.Numerator / number.Denominator;

            if((double) number - wholePart >= 0.5) return wholePart + 1;
            return wholePart;
        }

        public static implicit operator RationalNumber(double number)
        {
            int dozens = 1;

            while(number % 1 != 0)
            {
                number *= 10;
                dozens *= 10;
            }

            var result = new RationalNumber(Convert.ToInt32(number), dozens);
            Reduce(result);

            return result;
        }

        public static explicit operator double(RationalNumber number)
        {
            return Convert.ToDouble(number.Numerator) / Convert.ToDouble(number.Denominator);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public string ToString(string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
