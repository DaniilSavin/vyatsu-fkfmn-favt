
#define _USE_MATH_DEFINES
#include <iostream>
#include <vector>
#include <complex>
#include <cmath>

using namespace std;

typedef complex<double> base;

vector<base> fft(vector<base>& a, bool invert) { //ДПФ переходит от коэффициентов многочлена к его значениям в комплексных корнях n-ой степени из 1
	int n = (int)a.size();

	for (int i = 1, j = 0; i < n; ++i) //пусть  j - уже подсчитанное число, равное обратной перестановке битов числа i
	{                                  //Тогда, при переходе к следующему числу i+1 мы должны и к числу j прибавить единицу,
		int bit = n >> 1;             //но прибавить её в такой "инвертированной" системе счисления.
		for (; j >= bit; bit >>= 1)    //Соответственно, в "инвертированной" системе мы должны идти по битам числа, начиная со старших,
		{                             //и пока там стоят единицы, удалять их и переходить к следующему биту;
			j -= bit;                 //когда же встретится первый нулевой бит, поставить в него единицу и остановиться.
		}
		j += bit;
		if (i < j)
			swap(a[i], a[j]);
	}

	for (int len = 2; len <= n; len <<= 1)
	{
		double ang = 2 * M_PI / len * (invert ? -1 : 1);
		base wlen(cos(ang), sin(ang)); //базисные оси функций кос и син
		for (int i = 0; i < n; i += len)
		{
			base w(1);
			for (int j = 0; j < len / 2; ++j)
			{
				base u = a[i + j],
					v = a[i + j + len / 2] * w;
				a[i + j] = u + v;
				a[i + j + len / 2] = u - v;
				w *= wlen;
			}
		}
	}
	if (invert)
		for (int i = 0; i < n; ++i)
			a[i] /= n;
	return a;
}

void main()
{
	//6x^4-2x^3+5x^2+x
	setlocale(LC_ALL, "ru");
	int size=0;
	cout << "size = ";
	cin >> size;

	vector<base> in(size);

	for (int i = 0; i < size; i++)
	{
		cin >> in[i];
	}
	

	in =fft(in, 0);
	cout << "Прямое дискретное преобразование Фурье: ";
		for (int i = 0; i < in.size(); i++)
		{
			cout << in[i] << " ";
		}
	system("pause");

}