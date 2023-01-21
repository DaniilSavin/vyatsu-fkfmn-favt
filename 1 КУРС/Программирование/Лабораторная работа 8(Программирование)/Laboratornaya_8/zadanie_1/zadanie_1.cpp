// zadanie_1.cpp: определ€ет точку входа дл€ консольного приложени€.
//

#include "stdafx.h"
#include "iostream"
#include "clocale"
#include <cstdlib>

using namespace std;

int A(int n, int m);

int main()
{
	system("color 0a");
	setlocale(LC_ALL, "rus");
	int n, m;
	do 
	{
		cout << "¬ведите n, m: ";
		cin >> n >> m;
	} while (n < 0 || m < 0);
	cout << A(n, m) << endl;
	return 0;
}


int A(int n, int m)
{
	if (n == 0)
	{
		return (m + 1);
	} 
	else //n!=0
	{
		if (m == 0)
		{
			return A(n - 1, 1);
		}
		else //m!=0
		{
			return A(n - 1, A(n, m - 1));
		}
	}
}

