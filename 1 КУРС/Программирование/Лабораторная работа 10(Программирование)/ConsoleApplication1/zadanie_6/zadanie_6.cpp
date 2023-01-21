// zadanie_6.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include "ctime"
#include <clocale>

using namespace std;

void display(int A[], int n);
void perezapis(int A[], int n);

int main()
	{

		srand(time(0));
		int n, N, K;
		cout << "Enter n(size): ";
		cin >> n;
		int *A = new int[n*2];

		for (int i = 0; i < n; i++)
		{
			*(A + i) = rand() % 101 - 50;
		}
		cout << "Старый массив: " << endl;
		cout << endl;
		display(A, n);
		cout << endl;
		perezapis(A, n);
		delete[]A;
		return 0;
	}


void display(int A[], int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << i << "= " << *(A+i) << endl;
	}
}

void perezapis(int A[], int n)
{
	int N, K;
	cout << "Enter N(с какого элемента) and K(сколько элементов): ";
	cin >> N >> K;

	if ((N + K) > n)
	{
		int * tmp = new int[N + K];
		for (int i = 0; i < N; i++)
			tmp[i] = *(A + i);
		for (int i = N; i < (N + K); i++)
		{
			cout << "Enter " << i - N << "-th element ";
			cin >> tmp[i];
			for (int i = n; i > N; i--)
			{
				*(A + i + 1) = *(A + i);
				cin >> *(A + i);
			}
			cout << "TUT" << endl;
			cout << *(A + i) << endl;
		}
		delete[]A;
		A = tmp;
	}
	else
	{
		for (int i = n; i >= N; i--)
		{
			*(A + i + 1) = *(A + i);
		}
		cout << "TUT" << endl;

		for (int i = N; i < N + K; i++)
		{
			cout << "Enter " << i - N << "-th element ";

			cin >> *(A + i);

		}
	}
	
	cout << endl;
	cout << "Новый массив: " << endl;
	display(A, n);
}



/*int main()
{
	srand(time(0));
	int * Arr;
	int n, N, K;
	cout << "Enter n \n";
	cin >> n;
	Arr = new int[n];
	for (int i = 0; i < n; i++)
	{
		Arr[i] = rand() % 20; // 20 - заполнение рандомными числами от 0 до 19
	}
	for (int i = 0; i < n; i++)
	{
		cout << Arr[i] << " ";
	}
	cout << std::endl;
	cout << "Enter N and K ";
	cin >> N >> K;
	if ((N + K) > n)
	{
		int * tmp = new int[N + K];
		for (int i = 0; i < N; i++)
			tmp[i] = Arr[i];
		for (int i = N; i < (N + K); i++)
		{
			cout << "Enter " << i - N << "-th element ";
			cin >> tmp[i];
		}
		delete[]Arr;
		Arr = tmp;
	}
	else
	{
		for (int i = N; i < N + K; i++)
		{
			cout << "Enter " << i - N << "-th element ";
			cin >> Arr[i];
		}
	}
	for (int i = 0; i < n; i++)
	{
		cout << Arr[i] << " ";
	}
	delete[]Arr;
	system("pause");
	return 0;
}*/