using System;

namespace DZ_12_Tumakov
{
    internal class RationalNumber
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            }
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        private void Simplify()
        {
            int gcd = GreatestCommonDivisor(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
            if (Denominator < 0)
            {
                Denominator = -Denominator;
                Numerator = -Numerator;
            }
        }

        private static int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static bool operator ==(RationalNumber r1, RationalNumber r2)
        {
            if (ReferenceEquals(r1, r2))
            {
                return true;
            }
            if (ReferenceEquals(r1, null) || ReferenceEquals(r2, null))
            {
                return false;
            }
            return r1.Numerator == r2.Numerator && r1.Denominator == r2.Denominator;
        }

        public static bool operator !=(RationalNumber r1, RationalNumber r2)
        {
            return !(r1 == r2);
        }

        public override bool Equals(object obj)
        {
            return this == (obj as RationalNumber);
        }

        public override int GetHashCode()
        {
            return CombineHashCodes(Numerator, Denominator);
        }

        private static int CombineHashCodes(int h1, int h2)
        {
            int hash = 17;
            hash = hash * 31 + h1;
            hash = hash * 31 + h2;
            return hash;
        }

        public static bool operator <(RationalNumber r1, RationalNumber r2)
        {
            return (double)r1.Numerator / r1.Denominator < (double)r2.Numerator / r2.Denominator;
        }

        public static bool operator >(RationalNumber r1, RationalNumber r2)
        {
            return (double)r1.Numerator / r1.Denominator > (double)r2.Numerator / r2.Denominator;
        }

        public static bool operator <=(RationalNumber r1, RationalNumber r2)
        {
            return (double)r1.Numerator / r1.Denominator <= (double)r2.Numerator / r2.Denominator;
        }

        public static bool operator >=(RationalNumber r1, RationalNumber r2)
        {
            return (double)r1.Numerator / r1.Denominator >= (double)r2.Numerator / r2.Denominator;
        }

        public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
        {
            int newNumerator = r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator;
            int newDenominator = r1.Denominator * r2.Denominator;
            return new RationalNumber(newNumerator, newDenominator);
        }
        public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
        {
            int newNumerator = r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator;
            int newDenominator = r1.Denominator * r2.Denominator;
            return new RationalNumber(newNumerator, newDenominator);
        }

        public static RationalNumber operator ++(RationalNumber r)
        {
            return r + new RationalNumber(1, 1);
        }

        public static RationalNumber operator --(RationalNumber r)
        {
            return r - new RationalNumber(1, 1);
        }

        public static explicit operator float(RationalNumber r)
        {
            return (float)r.Numerator / r.Denominator;
        }
        public static explicit operator int(RationalNumber r)
        {
            return r.Numerator / r.Denominator;
        }

        public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
        }
        public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
        {
            if (r2.Numerator == 0)
                throw new DivideByZeroException("Деление на ноль");
            return new RationalNumber(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);
        }
        public static RationalNumber operator %(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber((r1.Numerator * r2.Denominator) % (r2.Numerator * r1.Denominator), r1.Denominator * r2.Denominator);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}
