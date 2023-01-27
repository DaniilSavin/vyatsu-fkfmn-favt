using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RationalNumbers
{
    public class Rational
    {
        BigInteger m, n;
        public static readonly Rational Zero, One;

        static Rational()
        {
            //Console.WriteLine("static constructor Rational");
            Zero = new Rational(0, 1, "private");
            One = new Rational(1, 1, "private");
        }

        public Rational(BigInteger a, BigInteger b)
        {
            if (b == 0)
            {
                m = 0;
                n = 1;
            }
            else
            {
                //приведение знака
                if (b < 0)
                {
                    b = -b;
                    a = -a;
                }
                if (a != 0)
                {
                    //приведение несократимой дроби
                    BigInteger d = nod(a, b);
                    m = a / d;
                    n = b / d;
                }
                else
                {
                    m = 0;
                    n = 1;
                }
            }
        }

        private Rational(BigInteger a, BigInteger b, string t) //аргумент t, чтобы не было конфликтов с дргуим конструктором
        {
            m = a;
            n = b;
        }

        public BigInteger GetM()
        {
            return m;
        }

        public BigInteger GetN()
        {
            return n;
        }

        BigInteger nod(BigInteger m, BigInteger n)
        {
            BigInteger p = 0;
            m = BigInteger.Abs(m);
            n = BigInteger.Abs(n);
            do
            {
                if (m < n)
                    n = n % m;
                else
                {
                    m = m % n;
                }
            }
            while (n * m != 0);
            return (n + m);
        }

        public Rational nod(Rational second)
        {
            Rational p = Zero;
            Rational first = new Rational(this.m, this.n);
            if (first.m < 0)
                first.m *= -1;
            if (second.m < 0)
                second.m *= -1;

            while (first!= Zero && second!=Zero)
                if (first > second)
                    first = first- second;
                else
                    second = second- first;
       
            return first+second;
        }

        public Rational Plus(Rational a)
        {
            BigInteger u, v;
            u = m * a.n + n * a.m;
            v = n * a.n;
            return (new Rational(u, v));
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            return (r1.Plus(r2));
        }

        public Rational Minus(Rational a)
        {
            BigInteger u, v;
            u = m * a.n - n * a.m;
            v = n * a.n;
            return (new Rational(u, v));
        }
        public static Rational operator -(Rational r1, Rational r2)
        {
            return (r1.Minus(r2));
        }

        public Rational Mult(Rational a)
        {
            BigInteger u, v;
            u = m * a.m;
            v = n * a.n;
            return (new Rational(u, v));
        }

        public static Rational operator *(Rational r1, Rational r2)
        {
            return (r1.Mult(r2));
        }

        public Rational Divide(Rational a)
        {
            BigInteger u, v;
            u = m * a.n;
            v = n * a.m;
            return (new Rational(u, v));
        }
        public static Rational operator /(Rational r1, Rational r2)
        {
            return (r1.Divide(r2));
        }

        public static bool operator ==(Rational r1, Rational r2)
        {
            return ((r1.m == r2.m) && (r1.n == r2.n));
        }
        public static bool operator !=(Rational r1, Rational r2)
        {
            return ((r1.m != r2.m) || (r1.n != r2.n));
        }

        public override int GetHashCode()
        {
            return GetHashCode();
        }

        public static bool operator <(Rational r1, Rational r2)
        {
            return (r1.m * r2.n < r2.m * r1.n);
        }
        public static bool operator >(Rational r1, Rational r2)
        {
            return (r1.m * r2.n > r2.m * r1.n);
        }
        public static bool operator <(Rational r1, double r2)
        {
            return ((double)r1.m / (double)r1.n < r2);
        }
        public static bool operator >(Rational r1, double r2)
        {
            return ((double)r1.m / (double)r1.n > r2);
        }

        public bool Negative()
        {
            if (m < 0)
                return true;

            return false;
        }

        public bool IsZero()
        {
            return this == Zero;
        }

        public bool IsOne()
        {
            return this == One;
        }

        public bool IsNegativeOne()
        {
            return this == new Rational(-1,1);
        }

        public void PrintRational(string name)
        {
            if (m == 0)
                Console.WriteLine("{0} = {1}", name, m);
            else
                Console.WriteLine("{0} = {1}/{2}", name, m, n);
        }

        public override string ToString()
        {
            if (n != 1)
                return $"{m}/{n}";
            else
                return $"{m}";
        }
    }
}
