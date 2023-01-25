// zadanie_1880.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;
int main()
{
	int a, b, c, count = 0;
	cin >> a;
	int* A = new int[a];
	for (int i = 0; i < a; i++)
	{
		cin >> *(A + i);
	}
	cin >> b;
	int* B = new int[b];
	for (int i = 0; i < b; i++)
	{
		cin >> *(B + i);
	}
	cin >> c;
	int* C = new int[c];
	for (int i = 0; i < c; i++)
	{
		cin >> *(C + i);
	}
	for (int i = 0; i < a; i++)
	{
		for (int k = 0; k < b; k++)
		{
			if (A[i] == B[k])
			{
				for (int j = 0; j < c; j++)
				{
					if (B[k] == C[j])
					{
						count++;
						break;
					}
				}
				break;
			}
		}
	}
	cout << count;

}
