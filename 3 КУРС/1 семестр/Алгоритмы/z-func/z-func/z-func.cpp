// z-func.cpp : Реализовать эффективный метод нахождения значений z-функции
//

#include<iostream> 
#include <string>
using namespace std;


// Заполняет Z-массив для заданной строки str []
void getZarr(string str, int Z[])
{
	Z[0] = str.length();
	int n = str.length();
	int L, R, k;
	// [L, R] создать окно, соответствующее префиксу s
	L = R = 0;
	for (int i = 1; i < n; ++i)
	{
		// если i> R ничего не подходит, мы рассчитаем. Z [i] наивным способом. 
		if (i > R)
		{
			L = R = i;
			// R-L = 0 в начале, поэтому проверка будет начинаться с 0-го индекса.
			while (R < n && str[R - L] == str[R])
				R++;
			Z[i] = R - L;
			R--;
		}
		else
		{
			//k = i-L, поэтому k соответствует числу, которое соответствует интервалу [L, R].
			k = i - L;
			// если Z [k] меньше оставшегося интервала, то Z [i] будет равно Z [k].

			if (Z[k] < R - i + 1)
				Z[i] = Z[k];
			else
			{
				// иначе начинаем с R и проверяем вручную
				L = i;
				while (R < n && str[R - L] == str[R])
					R++;
				Z[i] = R - L;
				R--;
			}
		}

	}
}

int main()
{
	string text;
	text = "abaabaabaa";
	//cin >> text;
	int Z[100];
	getZarr(text, Z);
	for (int i = 0; i < text.length(); i++)
		cout << text[i] << " ";
	cout << endl;
	for (int i = 0; i < text.length(); i++)
		cout << Z[i] << " ";

	return 0;
}


