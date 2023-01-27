using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RationalNumbers
{
    class Polinomial
    {
        int deg;
        string[] coefficientsStr;
        List<Rational> coefficients;
        public string polinomial;
        public static readonly Polinomial FirstDeg, Zero, One;

        static Polinomial()
        {
            FirstDeg = new Polinomial("x");
            Zero = new Polinomial("0");
            One = new Polinomial("1");
        }

        public Polinomial(string polinomial)
        {
            this.polinomial = polinomial;
            Koeff();
        }

        public Polinomial(Rational koeff, int deg)
        {
            this.deg = deg;
            coefficients = new List<Rational>();

            coefficients.Add(koeff);

            for (int i = deg - 1; i >= 0; i--)
                coefficients.Add(new Rational(0, 1));
        }

        private void Koeff()
        {
            int ind = polinomial.IndexOf("x^");
            int старшаяСтепень;

            try
            {
                if (ind != -1)
                {
                    старшаяСтепень = int.Parse(polinomial.Substring(ind + 2, lenOfDeg(ind + 2, polinomial)).ToString());
                    coefficientsStr = new string[старшаяСтепень + 1];
                }
                else
                    if (polinomial.IndexOf('x') != -1)
                {
                    старшаяСтепень = 1;
                    coefficientsStr = new string[2];
                }
                else
                {
                    старшаяСтепень = 0;
                    coefficientsStr = new string[1];
                }
            }
            catch
            {
                if (polinomial.IndexOf('x') != -1)
                {
                    старшаяСтепень = 1;
                    coefficientsStr = new string[2];
                }
                else
                {
                    старшаяСтепень = 0;
                    coefficientsStr = new string[1];
                }
            }

            for (int i = 0; i < coefficientsStr.Length; i++)
                coefficientsStr[i] = "0";

            string currentRowCopy = polinomial;

            string коэффициент;
            while (currentRowCopy.Length > 0 && currentRowCopy.Contains("x^"))
            {
                ind = currentRowCopy.IndexOf("x^");
                коэффициент = currentRowCopy.Substring(0, ind);
                int индексКоэффициента = int.Parse(currentRowCopy.Substring(ind + 2, lenOfDeg(ind + 2, currentRowCopy)));

                if (коэффициент.Length == 0 || коэффициент == "+")
                    coefficientsStr[индексКоэффициента] = "1";
                else
                     if (коэффициент == "-")
                    coefficientsStr[индексКоэффициента] = "-1";
                else
                    coefficientsStr[индексКоэффициента] = коэффициент.Replace("+", "");

                currentRowCopy = currentRowCopy.Substring(ind + 2 + lenOfDeg(ind + 2, currentRowCopy));
            }

            if (currentRowCopy.Contains("x"))
            {
                ind = currentRowCopy.IndexOf("x");
                коэффициент = currentRowCopy.Substring(0, ind);

                if (коэффициент.Length == 0 || коэффициент == "+")
                    coefficientsStr[1] = "1";
                else
                     if (коэффициент == "-")
                    coefficientsStr[1] = "-1";
                else
                    coefficientsStr[1] = коэффициент.Replace("+", "");

                currentRowCopy = currentRowCopy.Substring(ind + 1);
            }

            if (currentRowCopy.Length > 0)
            {
                coefficientsStr[0] = currentRowCopy.Replace("+", "");
            }

            coefficientsStr = coefficientsStr.Reverse().ToArray();

            coefficients = new List<Rational>();

            foreach (string coeff in coefficientsStr)
                if (coeff.IndexOf('/') == -1)
                    coefficients.Add(new Rational(int.Parse(coeff), 1));
                else
                    coefficients.Add(new Rational(int.Parse(coeff.Substring(0, coeff.IndexOf('/'))),
                        int.Parse(coeff.Substring(coeff.IndexOf('/') + 1))));

            deg = coefficients.Count - 1;
            var kek = coefficientsStr.Length;
        }

        private int lenOfDeg(int ind, string current)
        {
            int res = 0;

            while (ind < current.Length && Char.IsDigit(current[ind]))
            {
                res++;
                ind++;
            }

            return res;
        }

        public Polinomial Plus(Polinomial polinom2)
        {
            Polinomial resPolinom;
            int resDeg = Math.Max(this.deg, polinom2.deg);

            List<Rational> firstCoefficients = this.coefficients.ToArray().Reverse().ToList();
            List<Rational> secondCoefficients = polinom2.coefficients.ToArray().Reverse().ToList();
            List<Rational> resCoefficients = new List<Rational>();

            for (int i = 0; i <= resDeg; i++)
                if (firstCoefficients.Count > i && secondCoefficients.Count > i)
                    resCoefficients.Add(firstCoefficients[i] + secondCoefficients[i]);
                else
                    if (firstCoefficients.Count > i)
                    resCoefficients.Add(firstCoefficients[i]);
                else
                    resCoefficients.Add(secondCoefficients[i]);

            resPolinom = new Polinomial(PolinomialToString(resCoefficients.ToArray().Reverse().ToList()));

            return resPolinom;
        }

        public static Polinomial operator +(Polinomial polinom1, Polinomial polinom2)
        {
            return polinom1.Plus(polinom2);
        }

        public Polinomial Minus(Polinomial polinom2)
        {
            Polinomial resPolinom;
            int resDeg = Math.Max(this.deg, polinom2.deg);

            List<Rational> firstCoefficients = this.coefficients.ToArray().Reverse().ToList();
            List<Rational> secondCoefficients = polinom2.coefficients.ToArray().Reverse().ToList();
            List<Rational> resCoefficients = new List<Rational>();
            Rational minusOne = new Rational(-1, 1);

            for (int i = 0; i <= resDeg; i++)
                if (firstCoefficients.Count > i && secondCoefficients.Count > i)
                    resCoefficients.Add(firstCoefficients[i] - secondCoefficients[i]);
                else
                    if (firstCoefficients.Count > i)
                    resCoefficients.Add(firstCoefficients[i]);
                else
                    if (secondCoefficients.Count > i)
                    resCoefficients.Add(secondCoefficients[i] * minusOne);

            resPolinom = new Polinomial(PolinomialToString(resCoefficients.ToArray().Reverse().ToList()));

            return resPolinom;
        }

        public static Polinomial operator -(Polinomial polinom1, Polinomial polinom2)
        {
            return polinom1.Minus(polinom2);
        }

        private string PolinomialToString(List<Rational> coefficients)
        {
            string res = "";

            int deg = coefficients.Count - 1;

            foreach (Rational coeff in coefficients)
            {
                if (deg == 0)
                {
                    if (!coeff.IsZero())
                    {
                        if (!coeff.IsOne() && !coeff.IsNegativeOne())
                        {
                            if (coeff.Negative())
                                res += coeff.ToString();
                            else
                                res += "+" + coeff.ToString();
                        }
                        else
                        {
                            if (coeff.IsOne())
                                res += "+1";
                            else
                                res += "-1";
                        }
                    }
                    else
                    {
                        if (res.Length == 0)
                            res += "0";
                    }
                }
                else
                    if (deg == 1)
                {
                    if (!coeff.IsZero())
                    {
                        if (!coeff.IsOne() && !coeff.IsNegativeOne())
                        {
                            if (coeff.Negative())
                                res += coeff.ToString() + "x";
                            else
                                res += "+" + coeff.ToString() + "x";
                        }
                        else
                        {
                            if (coeff.IsOne())
                                res += "+x";
                            else
                                res += "-x";
                        }
                    }
                }
                else
                {
                    if (!coeff.IsZero())
                    {
                        if (!coeff.IsOne() && !coeff.IsNegativeOne())
                        {
                            if (coeff.Negative())
                                res += coeff.ToString() + "x^" + deg;
                            else
                                res += "+" + coeff.ToString() + "x^" + deg;
                        }
                        else
                        {
                            if (coeff.IsOne())
                                res += "+x^" + deg;
                            else
                                res += "-x^" + deg;
                        }
                    }
                }

                deg--;
            }

            if (res[0] == '+')
                res = res.Substring(1);

            return res;
        }

        public void Print()
        {
            Console.Write(PolinomialToString(this.coefficients));
        }

        public Polinomial Multy(Polinomial polinom2)
        {
            if (polinom2.Equals(Zero) || this.Equals(Zero))
                return Zero;
            if (polinom2 == One)
                return this;
            if (this == One)
                return polinom2;

            Polinomial resPolinom;
            int resDeg = this.deg + polinom2.deg;

            Rational[] resCoefficients = new Rational[resDeg + 1];
            for (int i = 0; i <= resDeg; i++)
                resCoefficients[i] = Rational.Zero;

            int ind = 0, shift = 0;
            foreach (Rational koeff2 in polinom2.coefficients)
            {
                foreach (Rational koeff1 in this.coefficients)
                {
                    resCoefficients[shift + ind++] += koeff1 * koeff2;
                }
                shift++;
                ind = 0;
            }
            resPolinom = new Polinomial(PolinomialToString(resCoefficients.ToList()));

            return resPolinom;
        }

        public static Polinomial operator *(Polinomial polinom1, Polinomial polinom2)
        {
            return polinom1.Multy(polinom2);
        }

        public List<Polinomial> Div(Polinomial polinom2)
        {
            if (this.Equals(Zero))
                return new List<Polinomial> { Zero, Zero };
            if (polinom2 == One)
                return new List<Polinomial> { this, Zero };
            if (this == One)
                return new List<Polinomial> { Zero, One };

            Polinomial quotient;
            bool divFirstOnSecond = true;
            int resDeg = this.deg - polinom2.deg;

            if (this < polinom2)
            {
                resDeg = polinom2.deg - this.deg;
                divFirstOnSecond = false;
            }

            Rational[] resCoefficients = new Rational[resDeg + 1];
            for (int i = 0; i <= resDeg; i++)
                resCoefficients[i] = Rational.Zero;

            int resDegCopy = resDeg;
            Polinomial dividend;
            Polinomial divisor;

            if (divFirstOnSecond)
            {
                dividend = new Polinomial(this.polinomial);
                divisor = new Polinomial(polinom2.polinomial);
            }
            else
            {
                dividend = new Polinomial(polinom2.polinomial);
                divisor = new Polinomial(this.polinomial);
            }

            bool end = false;

            for (int i = 0; i <= resDegCopy && !end; i++)
            {
                resCoefficients[i] = dividend.coefficients[0] / divisor.coefficients[0];
                Polinomial kek = new Polinomial(resCoefficients[i], resDeg);
                dividend.coefficients = (dividend - divisor * kek).coefficients;
                dividend.deg = coefficients.Count - 1;
                resDeg--;
                end = dividend.coefficients.Count < divisor.coefficients.Count;
            }

            quotient = new Polinomial(PolinomialToString(resCoefficients.ToList()));

            Polinomial remainder = new Polinomial(PolinomialToString(dividend.coefficients));

            List<Polinomial> answer = new List<Polinomial>();
            answer.Add(quotient);
            answer.Add(remainder);

            return answer;
        }

        public static List<Polinomial> operator /(Polinomial polinom1, Polinomial polinom2)
        {
            return polinom1.Div(polinom2);
        }

        public Polinomial NOD(Polinomial polinom2)
        {
            if (polinom2.Equals(this))
                return polinom2;

            Polinomial a = new Polinomial(this.polinomial);
            Polinomial b = new Polinomial(polinom2.polinomial);

            while (a * b != Zero)
                if (a > b)
                    a = (a / b)[1];
                else
                    b = (b / a)[1];

            Polinomial res = a + b;

            List<Rational> resCoefficients = res.coefficients;
            Rational nod = resCoefficients[0];
            for (int i = 1; i < resCoefficients.Count; i++)
                nod = resCoefficients[i].nod(nod);

            for (int i = 0; i < res.coefficients.Count; i++)
                res.coefficients[i] /= nod;

            return res;
        }

        public List<object> GornerScheme(Rational x0)
        {
            Rational answer;
            string res = "Разложение многочлена по схеме Руффини-Горнера: ";
            List<Rational> koefficients = this.coefficients.ToArray().Reverse().ToList();
            int n = koefficients.Count - 1;
            answer = koefficients[n--];

            res += koefficients[0] + " + ";

            for (int i = 1; i < koefficients.Count - 1; i++)
            {
                res += "x(" + koefficients[i] + " + ";
                answer = x0 * answer + koefficients[n--];
            }
            answer = x0 * answer + koefficients[n--];

            res += koefficients[koefficients.Count - 1] + "x";

            int countOfBr = res.Count(s => s == '(');
            for (int i = 0; i < countOfBr; i++)
                res += ")";

            res += "\nВ точке " + x0.ToString() + " многочлен равен ";
            res += answer.ToString() + " = " + (double)answer.GetM() / (double)answer.GetN() + "\n";

            List<object> answers = new List<object>();
            answers.Add(res);
            answers.Add(answer);

            return answers;
        }

        public List<Polinomial> DivUsingGornerScheme(Rational a)
        {
            string firstStr = "\t";
            List<Rational> koefficients = this.coefficients;
            List<Rational> resCoefficients = new List<Rational>(), resCoefficientsLast;
            Rational pred;

            firstStr = "\t";
            string secondStr = "a = " + a.ToString() + "\t";

            firstStr += koefficients[0] + "\t";
            pred = koefficients[0];
            secondStr += pred.ToString() + "\t";
            resCoefficients = new List<Rational>();
            resCoefficients.Add(pred);

            for (int i = 1; i < koefficients.Count; i++)
            {
                firstStr += koefficients[i].ToString() + "\t";
                pred = pred * a + koefficients[i];
                secondStr += pred.ToString() + "\t";

                if (i != koefficients.Count - 1)
                    resCoefficients.Add(pred);
            }

            Console.WriteLine("СХЕМА ГОРНЕРА:");
            Console.WriteLine(firstStr);
            Console.WriteLine(secondStr);

            //if (pred == Rational.Zero)
            //{
            //    Console.WriteLine("СХЕМА ГОРНЕРА:");
            //    Console.WriteLine(firstStr);
            //    Console.WriteLine(secondStr);

            //   /* resCoefficientsLast = resCoefficients.Select(d => d).ToList();
            //    predLast = Rational.Zero;*/
            //}
            /*BigInteger lastMember = koefficients.Last().GetM();
            if (lastMember.Sign < 0)
                lastMember = koefficients.Last().GetM()*(- 1);

            BigInteger divisorOfLastMember = 1;
            BigInteger n = koefficients.Last().GetN();
            string secondStr = "a = " + divisorOfLastMember.ToString() + "\t";
            Rational pred = new Rational(0,1);

            List<Rational> resCoefficientsLast = new List<Rational>();
            Rational predLast = new Rational(0, 1);

            while (lastMember>= divisorOfLastMember && pred==Rational.Zero) {
                if (lastMember % divisorOfLastMember == 0)
                {
                firstStr = "\t";
            string secondStr = "a = " + (new Rational(divisorOfLastMember, n)).ToString() + "\t";

            if (divisorOfLastMember == 1)
                koefficients = this.coefficients;
            firstStr += koefficients[0] + "\t";
            pred = koefficients[0];
            secondStr += pred.ToString() + "\t";
            resCoefficients = new List<Rational>();
            resCoefficients.Add(pred);

            for (int i = 1; i < koefficients.Count; i++)
            {
                firstStr += koefficients[i].ToString() + "\t";
                pred = pred * (new Rational(divisorOfLastMember, n)) + koefficients[i];
                secondStr += pred.ToString() + "\t";

                if (i != koefficients.Count - 1)
                    resCoefficients.Add(pred);
            }

            koefficients = resCoefficients;

            if (pred == Rational.Zero)
            {
                Console.WriteLine("СХЕМА ГОРНЕРА:");
                Console.WriteLine(firstStr);
                Console.WriteLine(secondStr);

                resCoefficientsLast = resCoefficients.Select(d => d).ToList();
                predLast = Rational.Zero;
            }
                }
                divisorOfLastMember++;
            }*/

            Polinomial quotient = new Polinomial(PolinomialToString(resCoefficients));

            List<Rational> remCoefficients = new List<Rational>();
            remCoefficients.Add(pred);
            Polinomial remainder = new Polinomial(PolinomialToString(remCoefficients));

            List<Polinomial> answer = new List<Polinomial>();
            answer.Add(quotient);
            answer.Add(remainder);

            return answer;
        }

        public static bool operator <(Polinomial polinom1, Polinomial polinom2)
        {
            if (polinom1.deg < polinom2.deg)
                return true;
            else
                if (polinom1.deg > polinom2.deg)
                return false;
            else
                for (int i = 0; i < polinom1.coefficients.Count; i++)
                    if (polinom1.coefficients[i] < polinom2.coefficients[i])
                        return true;
                    else
                        if (polinom1.coefficients[i] > polinom2.coefficients[i])
                        return false;

            return false;
        }

        public static bool operator >(Polinomial polinom1, Polinomial polinom2)
        {
            if (polinom1.deg > polinom2.deg)
                return true;
            else
                if (polinom1.deg < polinom2.deg)
                return false;
            else
                for (int i = 0; i < polinom1.coefficients.Count; i++)
                    if (polinom1.coefficients[i] > polinom2.coefficients[i])
                        return true;
                    else
                        if (polinom1.coefficients[i] < polinom2.coefficients[i])
                        return false;

            return false;
        }

        public static bool operator ==(Polinomial polinom1, Polinomial polinom2)
        {
            return polinom1.Equals(polinom2);
        }

        public static bool operator !=(Polinomial polinom1, Polinomial polinom2)
        {
            return !polinom1.Equals(polinom2);
        }

        public override bool Equals(object obj)
        {
            Polinomial polinom2 = (Polinomial)obj;

            try
            {
                for (int i = 0; i < Math.Max(polinom2.coefficients.Count, this.coefficients.Count); i++)
                    if (polinom2.coefficients[i] != this.coefficients[i])
                        return false;
            }
            catch
            {
                return false;
            }

            return true;
        }

        private double[] getKoeffs(string polynom)
        {
            int ind = polynom.IndexOf("x^");
            int старшаяСтепень;

            try
            {
                старшаяСтепень = int.Parse(polynom.Substring(ind + 2, lenOfDeg(ind + 2, polynom)).ToString());
                coefficientsStr = new string[старшаяСтепень + 1];
            }
            catch
            {
                старшаяСтепень = 1;
                coefficientsStr = new string[2];
            }
            for (int i = 0; i < coefficientsStr.Length; i++)
                coefficientsStr[i] = "0";

            string currentPolynomCopy = polynom;


            string коэффициент;
            while (currentPolynomCopy.Length > 0 && currentPolynomCopy.Contains("x^"))
            {
                ind = currentPolynomCopy.IndexOf("x^");
                коэффициент = currentPolynomCopy.Substring(0, ind);
                int индексКоэффициента = int.Parse(currentPolynomCopy.Substring(ind + 2, lenOfDeg(ind + 2, currentPolynomCopy)));

                if (коэффициент.Length == 0 || коэффициент == "+")
                    coefficientsStr[индексКоэффициента] = "1";
                else
                     if (коэффициент == "-")
                    coefficientsStr[индексКоэффициента] = "-1";
                else
                    coefficientsStr[индексКоэффициента] = коэффициент.Replace("+", "");

                currentPolynomCopy = currentPolynomCopy.Substring(ind + 2 + lenOfDeg(ind + 2, currentPolynomCopy));
            }

            if (currentPolynomCopy.Contains("x"))
            {
                ind = currentPolynomCopy.IndexOf("x");
                коэффициент = currentPolynomCopy.Substring(0, ind);

                if (коэффициент.Length == 0 || коэффициент == "+")
                    coefficientsStr[1] = "1";
                else
                     if (коэффициент == "-")
                    coefficientsStr[1] = "-1";
                else
                    coefficientsStr[1] = коэффициент.Replace("+", "");

                currentPolynomCopy = currentPolynomCopy.Substring(ind + 1);
            }

            if (currentPolynomCopy.Length > 0)
            {
                coefficientsStr[0] = currentPolynomCopy.Replace("+", "");
            }

            coefficientsStr = coefficientsStr.Reverse().ToArray();

            return coefficientsStr.Select(elem => double.Parse(elem.Replace(".", ","))).ToArray();
        }

        public void KronekerMethod()//https://math24.biz/factor
        {
            int n = this.deg;

            for (int i = 0; i < n; i++)
                if (this.coefficients[i].GetN() != 1)
                {
                    Console.WriteLine("Невозможно применить метод Кронекера к данному многочлену!");
                    return;
                }

            List<BigInteger> coeffs = this.coefficients.Select(elem => elem.GetM()).ToList();
            for (int i = 0; i <= n / 2; i++)
                if (((Rational)(GornerScheme(new Rational(i, 1))[1])).GetM() == 0)
                {
                    Console.WriteLine($"Множитель найден: x-{i}");
                    return;
                }

            BigInteger last = coeffs[coeffs.Count - 1];
            //List<BigInteger> U = FindDividers(last);//делители свободного члена
            List<List<BigInteger>> allDividersForEach = new List<List<BigInteger>>();
            int countOfComb = 1;//число комбинаций

            for (int i = 0; i <= n / 2; i++)
            {
                List<BigInteger> dividerForCurrentI = FindDividers(((Rational)(GornerScheme(new Rational(i, 1))[1])).GetM());
                allDividersForEach.Add(dividerForCurrentI);
                countOfComb *= dividerForCurrentI.Count;
            }

            List<BigInteger>[] allComb = GetAllComb(countOfComb, allDividersForEach);

            bool end = false;
            int indOfComb = 0;
            while (!end)
            {
                List<BigInteger> comb = allComb[indOfComb];

                /*for (int i = 0; i <= n / 2; i++)
                    comb.Add(allDividersForEach[i][rand.Next(allDividersForEach[i].Count)]);*/

                List<Rational> coefficients = new List<Rational>();
                coefficients.Add(new Rational(1, 1));

                Polinomial partOfLagranzhPolinom = new Polinomial(PolinomialToString(coefficients));
                Polinomial multiplier = new Polinomial(PolinomialToString(coefficients));
                Polinomial lagranzhPolinom = Zero;
                Polinomial dividend = new Polinomial(PolinomialToString(this.coefficients));

                //string kek = "";

                BigInteger ans = 1;
                for (int i = 0; i <= n / 2; i++)
                {
                    //kek += comb[i] + "*(1/";

                    for (int j = 0; j <= n / 2; j++)
                    {
                        if (i != j)
                        {
                            ans *= (i - j);
                            coefficients.Add(new Rational(-j, 1));
                            multiplier = new Polinomial(PolinomialToString(coefficients));

                            partOfLagranzhPolinom *= multiplier;
                            coefficients.RemoveAt(coefficients.Count - 1);
                        }
                    }

                    //kek += ans+") + ";

                    List<Rational> y_i_coefficients = new List<Rational>();
                    y_i_coefficients.Add(new Rational(comb[i] / ans, 1));
                    Polinomial y_i = new Polinomial(PolinomialToString(y_i_coefficients));

                    partOfLagranzhPolinom = partOfLagranzhPolinom * y_i;//yi * ()/()

                    lagranzhPolinom += partOfLagranzhPolinom;

                    partOfLagranzhPolinom = new Polinomial(PolinomialToString(coefficients));

                    ans = 1;
                }
                lagranzhPolinom.Print();
                Console.WriteLine();
                if (lagranzhPolinom.deg >= n / 2)
                    if ((dividend / lagranzhPolinom)[1] == Polinomial.Zero)
                    {
                        Console.WriteLine($"Множитель найден: {PolinomialToString(lagranzhPolinom.coefficients)}");
                        end = true;
                    }

                indOfComb++;

                if (!end && indOfComb == allComb.Count())
                {
                    end = true;
                    Console.WriteLine("Множителей не найдено!!!");
                }
            }

        }

        private List<BigInteger> FindDividers(BigInteger num)
        {
            List<BigInteger> res = new List<BigInteger>();//делители свободного члена
            num = BigInteger.Abs(num);

            res.Add(-1);
            res.Add(1);

            if (num == 1)
                return res;

            for (BigInteger i = 2; i < num; i++)//ищем делители свободного члена
                if (num % i == 0)
                {
                    res.Add(-i);
                    res.Add(i);
                }

            res.Add(-num);
            res.Add(num);

            return res;
        }

        private List<BigInteger>[] GetAllComb(int countOfComb, List<List<BigInteger>> allDividersForEach)
        {
            List<BigInteger>[] res = new List<BigInteger>[countOfComb];

            /*res = res.Select(elem => elem = new List<BigInteger>()).ToArray();
            res[0] = new List<BigInteger>() { -1, -1 };
            res[1] = new List<BigInteger>() { -1, -2 };

            int k = 0;
            for (int j = 0; j < allDividersForEach.Count; j++)
                for (int i = 0; i < countOfComb; i++)
                {
                    res[i].Add(allDividersForEach[j][k]);
                    k++;

                    if (k == allDividersForEach[j].Count)
                        k = 0;
                }*/
            int i = 0;

            foreach (var sequence in allDividersForEach.CartesianProduct())
            {
                res[i] = sequence.ToList();
                i++;
            }

            return res;
        }
    }

    static class Combinations
    {
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> allDividersForEach)
        {
            IEnumerable<IEnumerable<T>> result = new[] { Enumerable.Empty<T>() };

            return allDividersForEach.Aggregate(result, (accumulator, sequence) =>
                from accseq in accumulator
                from item in sequence
                select accseq.Concat(new[] { item }));
        }
    }
}