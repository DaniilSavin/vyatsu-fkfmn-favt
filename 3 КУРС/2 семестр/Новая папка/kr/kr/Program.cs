﻿using System;

namespace kr
{
    class Program
    {
        class Polynomial
        {
            List<int> Arguments;
            public Polynomial(int[] arr)
            {
                Arguments = new List<int>();
                for (int i = 0; i < arr.Length; i++)
                    Arguments.Add(arr[i]);
            }
            public Polynomial(int n)
            {
                Arguments = new List<int>();
                for (int i = 0; i < n; i++)
                    Arguments.Add(0);
            }
            public Polynomial(Polynomial polynomial)
            {
                Arguments = new List<int>();
                for (int i = 0; i < polynomial.GetDegree(); i++)
                    Arguments.Add(polynomial.Arguments[i]);
            }
            public Polynomial(List<int> arr)
            {
                Arguments = new List<int>();
                for (int i = 0; i < arr.Count; i++)
                    Arguments.Add(arr[i]);
            }
            public Polynomial()
            {
                Arguments = new List<int>();
            }
            public int Value(int x)
            {
                int value = 0;
                for (int i = 0; i < Arguments.Count; i++)
                    value += (int)Math.Pow(x, i) * Arguments[i];
                return value;
            }
            public int this[int index]
            {
                get
                {
                    try
                    {
                        return Arguments[index];
                    }
                    catch
                    {
                        return 0;
                    }
                }
                set
                {
                    Arguments[index] = value;
                }
            }
            public int GetDegree()
            {
                return Arguments.Count;
            }
            public static Polynomial operator -(Polynomial a)
            {
                Polynomial c = new Polynomial(a.GetDegree());
                for (int i = 0; i < a.GetDegree(); i++)
                    c[i] = a[i] * -1;
                return c;
            }
            public static Polynomial operator +(Polynomial a, Polynomial b)
            {
                int max = Math.Max(a.GetDegree(), b.GetDegree());
                Polynomial c = new Polynomial(max);
                for (int i = 0; i < max; i++)
                    c[i] = a[i] + b[i];
                return c;
            }
            public static Polynomial operator -(Polynomial a, Polynomial b)
            {
                return a + -b;
            }
            public static Polynomial operator *(Polynomial a, Polynomial b)
            {
                int max = Math.Max(a.GetDegree(), b.GetDegree());
                Polynomial c = new Polynomial(a.GetDegree() * b.GetDegree());
                for (int i = 0; i < a.GetDegree(); i++)
                    for (int j = 0; j < b.GetDegree(); j++)
                        c[i + j] += a[i] * b[j];
                return c;
            }
            void Reduction()
            {
                int k = GetDegree() - 1;
                while (this[k] == 0 && GetDegree() > 0)
                {
                    Arguments.RemoveAt(k);
                    k--;
                }
            }
            public static Polynomial[] operator /(Polynomial a, Polynomial b)
            {
                a.Reduction();
                b.Reduction();
                if (a.GetDegree() < b.GetDegree())
                    throw new ArgumentException("Некорректная степень многочленов");
                Polynomial c = new Polynomial((a.GetDegree() - b.GetDegree()) + 1);
                Polynomial d = new Polynomial(a.Arguments);
                Polynomial temp;
                int i = 0;
                while (d.GetDegree() >= b.GetDegree() && d[d.GetDegree() - 1] >= b[b.GetDegree() - 1])
                {
                    Polynomial d1 = new Polynomial(d);
                    c[c.GetDegree() - i - 1] = d[a.GetDegree() - i - 1] / b[b.GetDegree() - 1];
                    Polynomial temp1 = new Polynomial(c.GetDegree());
                    temp1[c.GetDegree() - i - 1] = c[c.GetDegree() - i - 1];
                    temp = b * temp1;
                    d = d - temp;
                    i++;
                    int k = d.GetDegree() - 1;
                    while (d[k] == 0 && d.GetDegree() > 0)
                    {
                        d.Arguments.RemoveAt(k);
                        k--;
                    }
                    if (c.ToString() == "0")
                    {
                        Polynomial[] res1 = { new Polynomial(), new Polynomial() };
                        return res1;
                    }
                }
                if (d.GetDegree() < 0)
                    d = new Polynomial();

                Polynomial[] res = { c, d };
                return res;
            }
            public static Polynomial operator /(Polynomial a, int b)
            {
                Polynomial c = new Polynomial(a.GetDegree());
                for (int i = 0; i < a.GetDegree(); i++)
                    c[i] = a[i] / b;
                return c;
            }
            public static Polynomial operator *(Polynomial a, int b)
            {
                Polynomial c = new Polynomial(a.GetDegree());
                for (int i = 0; i < a.GetDegree(); i++)
                    c[i] = a[i] * b;
                return c;
            }
            public static bool operator ==(Polynomial a, Polynomial b)
            {
                if (a.GetDegree() == b.GetDegree())
                {
                    for (int i = 0; i < a.GetDegree(); i++)
                        if (a[i] != b[i])
                            return false;
                    return true;
                }
                else
                    return false;
            }
            public static bool operator !=(Polynomial a, Polynomial b)
            {
                return !(a == b);
            }
            public override string ToString()
            {
                string s = "";
                for (int i = GetDegree() - 1; i >= 0; i--)
                    if (Arguments[i] != 0)
                        s += Arguments[i].ToString() + "x^" + i.ToString() + '+';

                if (s == "")
                    s = "0";
                else
                    s = s.Remove(s.Length - 1, 1);
                return s;
            }
            public static Polynomial Interpolate(int[] ax, int[] ay)
            {
                Polynomial res = new Polynomial();
                for (int i = 0; i < ax.Length; i++)
                {
                    Polynomial num = new Polynomial();
                    int divider = 1;
                    for (int j = 0; j < ax.Length; j++)
                    {
                        if (i != j)
                        {
                            int[] a = { -ax[j], 1 };
                            if (num == new Polynomial())
                            {
                                num = new Polynomial(a);
                            }
                            else
                                num *= new Polynomial(a);
                            divider *= (ax[i] - ax[j]);
                        }
                    }
                    if (res == new Polynomial())
                    {
                        res = num * ay[i] / divider;
                    }
                    else
                    {
                        res += num * ay[i] / divider;
                    }
                }
                res.Reduction();
                return res;
            }
        }
        static List<Polynomial> fact_kron(Polynomial polynomial)
        {
            List<Polynomial> res = new List<Polynomial>();
            Polynomial workPol = new Polynomial(polynomial);

            while (true)
            {
                Polynomial temp = kronecker(workPol);

                if (temp == new Polynomial() || workPol == new Polynomial())
                {
                    res.Add(workPol);
                    return res;
                }
                else
                {
                    res.Add(temp);
                    workPol = (workPol / temp)[0];
                }
            }
        }

        static Polynomial kronecker(Polynomial polynomial)
        {
            int n = polynomial.GetDegree() - 1;

            for (int i = 0; i <= n / 2; i++)
            {
                if (polynomial.Value(i) == 0)
                {
                    int[] a = { -i, 1 };
                    return new Polynomial(a);
                }
            }

            List<int> U1 = factors(polynomial.Value(0));
            List<List<int>> U = new List<List<int>>();
            foreach (int i in U1)
            {
                List<int> x = new List<int>();
                x.Add(i);
                U.Add(x);
            }
            for (int i = 1; i <= n / 2; i++)
            {
                List<int> M = factors(polynomial.Value(i));
                U = decart(U, M);
                foreach (List<int> j in U)
                {
                    j.Reverse();
                    Polynomial x;
                    List<int> ax = new List<int>();
                    List<int> ay = new List<int>();
                    for (int k = 0; k < i + 1; k++)
                    {
                        ax.Add(k);
                        ay.Add(j[k]);
                    }
                    x = Polynomial.Interpolate(ax.ToArray(), ay.ToArray());
                    if (x != new Polynomial() && x.GetDegree() > 1)
                    {
                        Polynomial[] y = polynomial / x;
                        if (x != new Polynomial() && y[1] == new Polynomial() && y[0] != new Polynomial())
                            return x;
                    }
                }
            }
            return new Polynomial();

        }

        static List<int> factors(int x)
        {
            x = Math.Abs(x);
            List<int> fact = new List<int>();

            for (int i = 1; i <= Math.Sqrt(Math.Abs(x)); i++)
            {
                if (x % i == 0)
                {
                    if (!fact.Contains(i))
                        fact.Add(i);
                    if (!fact.Contains(-i))
                        fact.Add(-i);
                    if (!fact.Contains(x / i))
                        fact.Add(x / i);
                    if (!fact.Contains(-x / i))
                        fact.Add(x / -i);
                }
            }
            if (!fact.Contains(x))
                fact.Add(x);
            if (!fact.Contains(-x))
                fact.Add(-x);
            return fact;
        }

        static List<List<int>> decart(List<List<int>> a, List<int> b)
        {
            List<List<int>> res = new List<List<int>>();
            foreach (List<int> ax in a)
                foreach (int bx in b)
                {
                    List<int> x = new List<int>();
                    for (int i = 0; i < ax.Count; i++)
                        x.Add(ax[i]);
                    x.Add(bx);
                    res.Add(x);
                }
            return res;
        }

        static void Main(string[] args)
        {
            int[] a = { -1, 6, -8, -2, -1, 1 };

            Polynomial polynomial = new Polynomial(a);

            List<Polynomial> ap = fact_kron(polynomial);

            Console.WriteLine("Многочлен:");

            Console.WriteLine(polynomial);

            Console.WriteLine("Множители:");

            for (int i = 0; i < ap.Count; i++)
                Console.WriteLine(ap[i]);

            Console.ReadKey();
        }
    }
}
