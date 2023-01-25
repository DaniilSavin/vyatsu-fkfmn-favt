// zadanie_1313.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include<iostream>
using namespace std;
int main()
{
	int n;
	cin >> n;
	int x[101][101];
	for (int i = 1; i <= n; i++)
	{
		for (int j = 1; j <= n; j++) cin >> x[i][j];
	}
	int i1 = 0;
	for (int i = 1; i <= n; i++)
	{
		for (int j = 1; j <= i; j++)
		{
			cout << x[i - i1][j] << " ";
			i1++;
		}
		i1 = 0;
	}
	int j1 = 2, r = 2;
	for (int i = 1; i <= n - 1; i++)
	{
		for (int j = n; j > i; j--)
		{
			cout << x[j][j1] << " ";
			j1++;
		}
		r++;
		j1 = r;
	}
}