
#define _USE_MATH_DEFINES
#include <iostream>
#include <vector>
#include <complex>
#include <cmath>

using namespace std;

typedef complex<double> base;

void fft(vector<base>& a, bool invert)
{
	int n = (int)a.size();
	if (n == 1)  return;

	vector<base> a0(n / 2), a1(n / 2);
	for (int i = 0, j = 0; i < n; i += 2, ++j)
	{
		a0[j] = a[i];
		a1[j] = a[i + 1];
	}
	fft(a0, invert);
	fft(a1, invert);

	double ang = 2 * M_PI / n * (invert ? -1 : 1);
	base w(1), wn(cos(ang), sin(ang));
	for (int i = 0; i < n / 2; ++i) {
		a[i] = a0[i] + w * a1[i];
		a[i + n / 2] = a0[i] - w * a1[i];
		if (invert)
			a[i] /= 2, a[i + n / 2] /= 2;
		w *= wn;
	}

	for (int i = 0; i < a.size(); i++)
	{
		cout << a[i] << endl;
	}
}

int main()
{
   //6x^4-2x^3+5x^2+x
	int size = 0;
	cin >> size;

	vector<base> in(size);
	for (int i = 0; i < size; i++)
	{
		cin >> in[i];
	}
	fft(in, 0);
	system("pause");

}

